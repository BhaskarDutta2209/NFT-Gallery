using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class GetArtwork : MonoBehaviour
{

    public Renderer imageRenderer;
    public string url;
    private Proximity proximity;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetArtworkDetails(url));
        //proximity = gameObject.GetComponent<Proximity>();
    }

    public IEnumerator GetArtworkDetails(string URI)
    {
        proximity = gameObject.GetComponent<Proximity>();
        StartCoroutine(GetRequestCoroutine(URI));
        yield return 0;
    }

    private IEnumerator GetRequestCoroutine(string uri)
    {
        UnityWebRequest www = UnityWebRequest.Get(uri);
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
        Debug.Log("TESTWORKING");

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
