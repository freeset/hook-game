using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    SpringJoint2D springJoint;
    HookBehaviour hb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        hb = GetComponent<HookBehaviour>();
    }
    void Update()
    {
        if(Input.GetKey("a") && hb.hookConnectedGetter())
        {
            rb.AddForce(new Vector2(-0.5f, 0));
        }
        else if (Input.GetKey("d") && hb.hookConnectedGetter())
        {
            rb.AddForce(new Vector2(0.5f, 0));
        }

        if (Input.GetKey("w") && hb.hookConnectedGetter())
        {
            springJoint.distance = springJoint.distance - 0.01f;
        }
        else if (Input.GetKey("s") && hb.hookConnectedGetter())
        {
            springJoint.distance = springJoint.distance + 0.01f;
        }

    }

}
