using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 20 * Time.deltaTime);
        //if dragon go out of screen
        if (transform.position.x < -49)
        {
            Destroy(transform.gameObject);
        }

    }

}
