using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ServerCommunication
{
    const string RequestURL = "https://api.pubg.com/tournaments";
    const string APIKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJhOTI0NDg2MC0yYjVmLTAxMzktMGMxZS0xN2FlNjNjNWE1OGEiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjA5MTc2MzUzLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6Indvcmt0ZXN0In0.XUSIvXO1KT1oJTsQGt1PrnFX-wcGe5u8pT0OyWBY_T4";

    private readonly static ServerCommunication _instance = new ServerCommunication();

    public static ServerCommunication Instance
    {
        get
        {
            return _instance;
        }
    }

    public ServerCommunication()
    {
    }

    private void ParseResponse<T>(string data, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        var parsedData = JsonUtility.FromJson<T>(data);
        callbackOnSuccess?.Invoke(parsedData);
    }

    public IEnumerator RequestCoroutine<T>(UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        var www = UnityWebRequest.Get(RequestURL);
        www.SetRequestHeader("accept", "application/vnd.api+json");
        www.SetRequestHeader("Authorization", "Bearer "+ APIKey);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            callbackOnFail?.Invoke(www.error);
        }
        else
        {
            ParseResponse(www.downloadHandler.text, callbackOnSuccess, callbackOnFail);
        }
    }
   

  
}


