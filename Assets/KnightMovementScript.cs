using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovementScript : MonoBehaviour
{
    public Animator animator;
    public static float horizontalMove = 0f;
    public static float runSpeed = 30f;

    public static Vector3 characterPosition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * runSpeed;
            animator.SetFloat("speed", 0.1f);
            animator.SetBool("isJumping", false);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * runSpeed;
            animator.SetFloat("speed", 0.005f);
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("isJumping", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);

        }


    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
}
