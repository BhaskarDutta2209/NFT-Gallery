using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtWorkSpawner : MonoBehaviour
{

    public GameObject artwork;
    public List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnArtworks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void spawnArtworks()
    {
        QueryArtMarket artMarket = new QueryArtMarket();
        QueryNFT nft = new QueryNFT();

        // Get a list of all the listed Artworks
        var itemCount = await artMarket.GetItemCounter();
        var allListedArtWorks = await artMarket.GetAllMarketItems();

        var count = (itemCount<=spawnPoints.Count) ? itemCount : spawnPoints.Count;

        // Spawn the artworks
        for(int i=0; i<count; i++)
        {
            GameObject spawnedObj = Instantiate(artwork, spawnPoints[i].position, spawnPoints[i].rotation);
            var scriptRef = spawnedObj.GetComponent<GetArtwork>();

            string contractAddress = allListedArtWorks[i].nftContractAddress;
            string tokenURI = await nft.GetTokenURI(allListedArtWorks[i].tokenId, contractAddress);

            StartCoroutine(scriptRef.GetArtworkDetails(tokenURI));
        }

        // Set script for all the artworks
    }
}
