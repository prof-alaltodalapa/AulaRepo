using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator anim;
    public float speed = 10;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(x, y).normalized * speed;
        anim.SetBool("IsRunning", x != 0f || y != 0f);
        
        if(anim.GetBool("IsRunning"))
        {
            anim.SetFloat("X", x > 0f ? 1f : x < 0f ? -1f : 0f);
            anim.SetFloat("Y", y > 0f ? 1f : y < 0f ? -1f : 0f);
        }
    }
}