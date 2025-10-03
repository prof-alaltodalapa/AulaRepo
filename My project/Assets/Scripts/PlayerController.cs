using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rig;

    public float speed = 10;

    void FixedUpdate()
    {
        rig.velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed,
            Input.GetAxis("Vertical") * speed);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
