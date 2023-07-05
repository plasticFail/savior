using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultFail : MonoBehaviour
{
    public Text coinsLeft;

    void Start()
    {
        coinsLeft.text = "Coins Collected: " + Knight.coinsCollectCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
