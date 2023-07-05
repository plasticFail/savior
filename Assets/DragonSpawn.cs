using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawn : MonoBehaviour
{

    public GameObject dragon_fly;
    public int timer = 0;

    // Update is called once per frame
    void Update()
    {

        timer = timer + 1;

        if (timer > 550)
        {
            Instantiate(dragon_fly, new Vector3(transform.position.x, Random.Range(7.0f, 10.0f), 0), transform.rotation);
            timer = 0;
        }
    }

}
