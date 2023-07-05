using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public float respawnTime = 0.1f;
    public GameObject coin;
    public Vector3 screenBounds;
    public int maxCoins = 16;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coinWave());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spawnCoins()
    {

        GameObject a = Instantiate(coin) as GameObject; //added coin to our scene
        //use ref a to manipulate it
        //x: -2 to place at the right, place random y
        a.transform.position = new Vector2(Random.Range(screenBounds.x - 15, 120), Random.Range(1.3f, 10.3f));
        print(screenBounds.x);
    }

    IEnumerator coinWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCoins();
            count += 1;
            if (count.Equals(maxCoins))
            {
                break;
            }
        }

    }
}
