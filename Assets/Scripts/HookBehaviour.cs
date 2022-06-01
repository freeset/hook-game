using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    Vector3 mousePos;
    bool hookConnected;
    Vector3[] lineVertices;
    int numberOfVertices;
    float timer;
    LineRenderer lineRenderer;
    SpringJoint2D springJoint;
    // Start is called before the first frame update
    void Start()
    {
        numberOfVertices = 10;
        lineVertices = new Vector3[numberOfVertices];
        hookConnected = false;
        timer = 0;
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            hookToObject();
        }
        if (Input.GetMouseButtonUp(0))
        {
            deatachHook();
        }
        if (hookConnected)
        {
            animateHook();
            timer = timer + Time.deltaTime;
            if (timer > 2)
            {
                deatachHook();
            }
        }
    }

    void hookToObject()
    {
        Collider2D hit;
        hit = Physics2D.OverlapPoint(mousePos);
        if (hit != null)
        {
            if (hit.tag == "AttachableWall")
            {
                lineRenderer.enabled = true;
                springJoint.enabled = true;
                hookConnected = true;
                timer = 0;
                springJoint.connectedAnchor = mousePos;
            }
        }
    }

    void animateHook()
    {
        lineVertices[0] = transform.position;
        lineVertices[1] = springJoint.connectedAnchor;
        lineRenderer.SetPositions(lineVertices);
    }

    void deatachHook()
    {
        hookConnected = false;
        springJoint.enabled = false;
        lineRenderer.enabled = false;
    }
    public bool hookConnectedGetter()
    {
        return hookConnected;
    }
}
