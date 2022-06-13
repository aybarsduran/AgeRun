#if UNITY_EDITOR

using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.Networking;    
public class VersionInfoWizard: ScriptableWizard{
    public string android = "connecting...";
    public string androidBundle = "connecting...";
    public string ios = "connecting...";
    public string iosBundle = "connecting...";
    public bool increaseAndroid = true;
    public bool increaseIos = true;
    [Serializable]
    public class Response
    {
        public string value;
    }

    [MenuItem("Project/Auto Version Info")]
    private static void MenuEntryCall() {
        var wizard = DisplayWizard<VersionInfoWizard>("Version Data From Internet","Increase");
        wizard.Get();
    }

    private void Get(){
        var targets = new string[]{ BuildTarget.Android.ToString().ToLower(), BuildTarget.iOS.ToString().ToLower() };
        foreach(var target in targets){
            var bundle = PlayerSettings.applicationIdentifier;
            var url = "https://api.countapi.xyz/get/"+bundle+"/"+target;
            Debug.Log("GET: " + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            Response info;
            try{
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Debug.Log(response.StatusCode);
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = reader.ReadToEnd();
                info = JsonUtility.FromJson<Response>(jsonResponse);
            }catch(Exception e){
                Debug.Log(e);
                info = new Response() { value = "1" };
            }

            if(string.IsNullOrEmpty(info.value)){
                info.value = "1";
            }
            
            int code = 1000 + int.Parse(info.value)*10;
            var major = Mathf.Floor(code/1000).ToString();
            var minor = (Mathf.Floor(code/10)%100).ToString("00");
            var buildType = code%10;
            var value = major + "." + minor + "." + buildType;
            if(target == "android"){
                android = value;
                androidBundle = info.value;
            }else{
                ios = value;
                iosBundle = info.value;
            }
        }
    }

    private void OnWizardCreate() {
        if(increaseAndroid){
            VersionScript.Increase("android");
        }
        if(increaseIos){
            VersionScript.Increase("ios");
        }
        AssetDatabase.SaveAssets();
    }
}
#endif