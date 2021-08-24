using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class TestGetRequest : MonoBehaviour
{

    public Renderer imageRenderer;
    public string url;
    private Proximity proximity;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequestCoroutine());
        proximity = gameObject.GetComponent<Proximity>();
    }

    private IEnumerator GetRequestCoroutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        while(!www.isDone)
        {
            Debug.Log("Fetching Metadata Under Progress");
        }

        if(!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Some Error Occured");
        }

        var result = www.downloadHandler.text;

        var metadata = JsonConvert.DeserializeObject<OpenSeaMetadata>(result);

        proximity.newTitle = metadata.name;
        proximity.newDesc = metadata.description;

        var imageUrl = metadata.image;
        StartCoroutine(GetAndSetTexture(imageUrl));

    }

    private IEnumerator GetAndSetTexture(string imageUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return www.SendWebRequest();

        while(!www.isDone)
        {
            Debug.Log("Fetching Image Under Progress");
        }

        Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        imageRenderer.material.mainTexture = myTexture;
        
    }

}
