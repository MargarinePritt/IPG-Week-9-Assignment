using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JSONLoader : MonoBehaviour
{
    string url="https://data.police.uk/api/forces";

    public delegate void JSONRefreshed(JSONNode json);
	public JSONRefreshed jsonRefreshed;

	public JSONNode currentJSON;
    // Start is called before the first frame update
    void Start()
    {
        StartRefreshJSON();
    }

    public void StartRefreshJSON()
	{
		//For external use
		StartCoroutine(RefreshJSON());
	}

	IEnumerator RefreshJSON()
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			currentJSON = JSON.Parse(www.text);
			jsonRefreshed.Invoke(currentJSON);
		}
		else
		{
			//Display disconnected
			Debug.Log("ERROR: " + www.error);
		}
		StopCoroutine(RefreshJSON());
	}
}
