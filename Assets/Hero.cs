using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
//123

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump(); // Прыжок
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("alive", 1);
        }
        else
        {
            Flip(); // Поворот героя
            anim.SetInteger("alive", 2);
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
        rb.AddForce(transform.up * 10f, ForceMode2D.Impulse);
    }

}
