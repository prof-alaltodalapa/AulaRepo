using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator anim;
    public float speed = 10;
    public float attackDelay = 1.2f;
    public float dealDamageDelay = 0.5f;

    private bool locked = false;

    void Update()
    {
        if(!locked)
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

            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                rig.velocity = new Vector2(0, 0);

                locked = true;
                CancelInvoke("Unlock");
                Invoke("Unlock", attackDelay);
                CancelInvoke("DealDamage");
                Invoke("DealDamage", dealDamageDelay);
            }
        }
    }

    void DealDamage()
    {
        //dar dano nos inimigos
    }

    void Unlock() => locked = false;
}