using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class TestGetRequest : MonoBehaviour
{

    public Plane imagePlane;
    private float progress;

    public string url;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequestCoroutine());
    }

    private IEnumerator GetRequestCoroutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        var asyncOperation = www.SendWebRequest();

        while(!www.isDone)
        {
            progress = asyncOperation.progress;
            yield return null;
        }

        progress = 1f;

        if(!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Some Error Occured");
        }

        var result = www.downloadHandler.text;

        //var metadata = JsonUtility.FromJson<OpenSeaMetadata>(result);
        var metadata = JsonConvert.DeserializeObject<OpenSeaMetadata>(result);

        //Debug.Log(metadata.attributes[0].trait_type);

        //Debug.Log(result);
        //Debug.Log(result.GetType());
        //Debug.Log(openSeaMetadata.name);
        Debug.Log(metadata.attributes[0].trait_type);
        //Debug.Log(openSeaMetadata.image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
