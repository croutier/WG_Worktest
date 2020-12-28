using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{
    TournamentInfo info;
    void Start()
    {
        StartCoroutine(ServerCommunication.Instance.RequestCoroutine<TournamentInfo>(LoadInfo,LoadFailed));
        

    }

    public void LoadInfo(TournamentInfo info)
    {
        this.info = info;
        Debug.Log("");
    }

    public void LoadFailed(string error)
    {
    }

}
[System.Serializable]
public class TournamentInfo
{
    public TournamentData[] data;
    public Links links;
    public MetaData meta;
}

[System.Serializable]
public struct TournamentData
{
    public string type;
    public string id;
    public TournamentAttributes attributes;
}
[System.Serializable]
public struct TournamentAttributes
{
    public string createdAt;    
}

[System.Serializable]
public struct Links
{
    public string self;
}
[System.Serializable]
public struct MetaData
{
}
