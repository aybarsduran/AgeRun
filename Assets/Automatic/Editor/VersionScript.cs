#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.Net;
  using System;
  using System.IO;
using UnityEditor;

public class VersionScript : IPreprocessBuildWithReport{
    public int callbackOrder { get { return 0; } }

    [Serializable]
    public class Response
    {
        public string value;
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.Log("# Auto Version Pre Processor Script");
        Debug.Log("Version Counter Sending Request");
        var platform = report.summary.platform.ToString().ToLower();
        Increase(platform);
    }

    public static void Increase(string platform){
        string bundle = PlayerSettings.applicationIdentifier;
        var url = "https://api.countapi.xyz/hit/"+bundle+"/"+platform;
        Debug.Log("URL: " + url + " PS:replace /hit/ with /get/ please");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Response info = JsonUtility.FromJson<Response>(jsonResponse);
        Debug.Log("Count : " + info.value);
        int code = 1000 + int.Parse(info.value)*10;
        var major = Mathf.Floor(code/1000).ToString();
        var minor = (Mathf.Floor(code/10)%100).ToString("00");
        var buildType = code%10;
        PlayerSettings.bundleVersion = major + "." + minor + "." + buildType;
        PlayerSettings.Android.bundleVersionCode = code;
        PlayerSettings.iOS.buildNumber = code.ToString();
        Debug.Log("Code : " + code);
        Debug.Log("Version : " + PlayerSettings.bundleVersion);
    }
}

#endif