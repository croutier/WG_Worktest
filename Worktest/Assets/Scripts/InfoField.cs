using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoField : MonoBehaviour
{
    [SerializeField] Text tournamentID;
    [SerializeField] Text creationDate;

    public void SetInfo(string id, string date)
    {
        tournamentID.text = id;
        string[] parsedDate = date.Split('T');
        creationDate.text = parsedDate[0] + "\n" + parsedDate[1].Remove(parsedDate[1].Length-1);
        //creationDate.text = date;
    }
}
