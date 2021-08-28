using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{

    public GameObject artwork;
    GameObject spawedObj;
    public List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnArtwork();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnArtwork()
    {
        spawedObj =  Instantiate(artwork, spawnPoints[0].localPosition, spawnPoints[0].localRotation);
        var scriptRef = spawedObj.GetComponent<GetArtwork>();
        //scriptRef.GetArtworkDetails("https://opensea-creatures-api.herokuapp.com/api/creature/2");
        StartCoroutine(scriptRef.GetArtworkDetails("https://opensea-creatures-api.herokuapp.com/api/creature/2"));
    }
}
