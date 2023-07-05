using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject knight;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveDragon();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("water"))
        {
            Destroy(transform.gameObject);
        }
    }

    //Move when knight is within range*
    void MoveDragon()
    {
        var diff = transform.position.x - knight.transform.position.x;

        if (diff < 10.0)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);

        }

        if (transform.position.x < -49)
        {
            Destroy(transform.gameObject);
        }

    }


}
