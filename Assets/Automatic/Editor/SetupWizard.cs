#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class SetupWizard: ScriptableWizard {
    public const string SERVER_ADDRESS = "https://raw.githubusercontent.com/foXpider/foxpider-metadata/main/unity-config.json";
    public class ServerData {
        public string companyName;
        public string bundleAddress;
        public string teamID;
    }
    public ServerData data;
    public string bundle = "";
    public string companyName = "";
    public string productName = "";
    public string version = "";
    public bool portraitOnly = true;
    public bool setPlaceholderIconIfThereIsNoIcon = true;
    public bool multithreadedRendering = true;
    public bool gammaColorSpace = true;
    public bool enableTeamIDForAutoSign = true;
    public string teamID = "";
    public bool enableIL2CPP = true;
    public bool enableNet4 = true;

    [MenuItem("Project/Auto Setup")]
    private static void MenuEntryCall() {
        var wizard = DisplayWizard<SetupWizard>("Setup","Set");
        wizard.SetFormData();
    }

    private void SetFormData(){
        bundle = PlayerSettings.applicationIdentifier;
        // if data is not null and bundle contains "Default"
        if (data != null && bundle.Contains("Default")) {
            bundle = data.bundleAddress+'.'+productName;
            bundle = bundle.ToLower();
        }
        companyName = PlayerSettings.companyName;
        // if data is not null and companyName contains "Default"
        if (data != null && companyName.Contains("Default")) {
            companyName = data.companyName;
        }
        productName = PlayerSettings.productName;
        version = PlayerSettings.bundleVersion;
        // set teamID if data is not null
        if (data != null) {
            teamID = data.teamID;
        }

        // if version is 0.1 set it to 1.0
        if (version == "0.1") {
            version = "1.0";
        }
    }

    private void OnWizardCreate() {
        // Save Player Settings

        var icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Automatic/logoplaceholder.png");
        PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Unknown, new Texture2D[] { icon });
        PlayerSettings.MTRendering = multithreadedRendering;
        if(gammaColorSpace){
            // setGammaColorSpace
            PlayerSettings.colorSpace = ColorSpace.Gamma;
        }
        // enable IL2CPP
        if(enableIL2CPP){
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        }

        // enable Net 4.0 support
        if(enableNet4){
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_4_6);
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.iOS, ApiCompatibilityLevel.NET_4_6);
            PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.WebGL, ApiCompatibilityLevel.NET_4_6);
        }

        if(portraitOnly){
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
            PlayerSettings.allowedAutorotateToPortrait = true;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = true;
            PlayerSettings.allowedAutorotateToLandscapeLeft = false;
            PlayerSettings.allowedAutorotateToLandscapeRight = false;

        }
        
        if(enableTeamIDForAutoSign){
            PlayerSettings.iOS.appleEnableAutomaticSigning = true;
            // set teamID
            PlayerSettings.iOS.appleDeveloperTeamID = teamID;
        }

        // set bundle
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, bundle);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, bundle);
        
        // set companyName
        PlayerSettings.companyName = companyName;
        // set productName
        PlayerSettings.productName = productName;
        // set version
        PlayerSettings.bundleVersion = version;
        AssetDatabase.SaveAssets();
    }

    private void Awake() {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            ShowNotification(new GUIContent(){
                text = "No internet connection.",
                tooltip = "Please connect to the internet to continue."
            });
        }else{
            GetDataFromServer();
        }
    }

    void GetDataFromServer(){
        // GetDataFromServer with UnityWebRequest
        Debug.Log("Retriving Data From: " + SERVER_ADDRESS);
        var request = UnityWebRequest.Get(SERVER_ADDRESS);
        request.SendWebRequest().completed += (x) => {
            if (request.result == UnityWebRequest.Result.Success) {
                // Parse JSON data
                var json = request.downloadHandler.text;
                Debug.Log("JSON: " + json);
                data = JsonUtility.FromJson<ServerData>(json);
                SetFormData();
            }else{
                // error notification with ShowNotification
                ShowNotification(new GUIContent(){
                    text = "Error connecting to server.",
                    tooltip = "Please try again later."
                });
                Debug.LogError(request.error);
            }
        };
    }
}
#endif