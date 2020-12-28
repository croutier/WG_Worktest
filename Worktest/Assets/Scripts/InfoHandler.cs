using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{
    [SerializeField] GameObject tournamentInfoPrefab;
    [SerializeField] Transform infoContainer;

    [SerializeField] GameObject infoUI;
    
    public void Request()
    {
        StartCoroutine(ServerCommunication.Instance.RequestCoroutine<TournamentInfo>(LoadInfo,LoadFailed));       

    }

    public void LoadInfo(TournamentInfo info)
    {
        
        foreach(TournamentData data in info.data)
        {
            Instantiate(tournamentInfoPrefab, infoContainer).GetComponent<InfoField>().SetInfo(data.id,data.attributes.createdAt);
        }        
        infoUI.SetActive(true);
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
