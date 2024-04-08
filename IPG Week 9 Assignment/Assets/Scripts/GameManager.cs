using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using TMPro;

public class GameManager : MonoBehaviour
{
    JSONLoader jsonLoader;

    private int forceIndex=-1;
    [SerializeField]MyForce myForce;
    private string myId="";
    private string myName="";

    [SerializeField]TMP_Text idText;
    [SerializeField]TMP_Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        forceIndex=Random.Range(0,43);

        jsonLoader = GetComponent<JSONLoader>();
        jsonLoader.jsonRefreshed += ReadJSON;
    }

	private void OnDestroy()
	{
		jsonLoader.jsonRefreshed-=ReadJSON;
	}

	public void ReadJSON(JSONNode json)
    {
        myId=json[forceIndex]["id"];
        myForce.myId=myId;
        idText.text=myId;

        myName=json[forceIndex]["name"];
        myForce.myName=myName;
        nameText.text=myName;
    }
}
