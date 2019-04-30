using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float isJump=0;
    private System.Timers.Timer aTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump(); // Прыжок
        }
        Flip(); // Поворот героя
        if (Time.time - isJump < 0.5)
        {
            anim.SetInteger("alive", 3);
        } else {
            if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetInteger("alive", 1);
            }
            else
            {
                anim.SetInteger("alive", 2);
            }
        }
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }



    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);
    }

    void jump()
    {
        if(Time.time - isJump > 1)
        {
            isJump = Time.time;

            rb.AddForce(transform.up * 12f, ForceMode2D.Impulse);
        }
    }

}
