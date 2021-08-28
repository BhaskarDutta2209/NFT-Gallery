using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        QueryArtMarket queryArtMarket = new QueryArtMarket();
        var res = await queryArtMarket.GetItemCounter();
        Debug.Log(res);
        var res2 = await queryArtMarket.GetAllMarketItems();
        Debug.Log(res2[0].nftContractAddress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
