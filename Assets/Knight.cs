using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    private static int hitObj = 0;
    public AudioClip collideSfx; //collide with dragon
    public AudioClip fall; //collide with water

    public AudioClip coinSfx;
    public GameObject explosionObj;
    public Text countdown;
    public Text coinsCollected;
    private int endTime = 60;
    private int endTime2;
    private int score = 1000; //coins to collect
    public static int coinsCollectCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        endTime2 = (int)Time.time + endTime;
        hitObj = 0; // else if restart game, the count wont work
        coinsCollectCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var timeLeft = (int)(endTime2 - Time.time);
        countdown.text = "Time Left: " + timeLeft;
        coinsCollected.text = "Left: " + score.ToString();

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("LevelEnd");
        }

    }

    //reduce life when collide with dragon/water
    void OnCollisionEnter2D(Collision2D other)
    {

        print(hitObj);
        if (other.transform.CompareTag("dragon"))
        {
            hitObj += 1;
            GetComponent<AudioSource>().clip = collideSfx;
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject explosion = Instantiate(explosionObj, transform.position, transform.rotation);
            Destroy(explosion, 1);

            ReduceLife();

        }
        if (other.transform.CompareTag("water"))
        {
            hitObj += 1;
            GetComponent<AudioSource>().clip = fall;
            GetComponent<AudioSource>().Play();
            ReduceLife();
        }
        if (other.transform.CompareTag("end"))
        {
            if (score <= 0)
            {
                SceneManager.LoadScene("SuccessScene");
            }
            else
            {
                SceneManager.LoadScene("LevelEnd");
            }
        }


    }

    private void ReduceLife()
    {
        if (hitObj.Equals(1))
        {
            GameObject heart3 = GameObject.FindGameObjectWithTag("heart3");
            Destroy(heart3);
        }
        if (hitObj.Equals(2))
        {
            GameObject heart2 = GameObject.FindGameObjectWithTag("heart2");
            Destroy(heart2);
        }
        if (hitObj.Equals(3))
        {
            GameObject heart1 = GameObject.FindGameObjectWithTag("heart1");
            Destroy(heart1);
            SceneManager.LoadScene("LevelEnd");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("coin"))
        {
            GetComponent<AudioSource>().clip = coinSfx;
            GetComponent<AudioSource>().Play();
            score -= 100;
            coinsCollectCount += 100;
            Destroy(other.gameObject);
        }
    }

}
