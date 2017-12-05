using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamParticle : MonoBehaviour {
    private float waitStopTime = 0.5f;
    private bool isStopped = false;
    private bool isAttached = false;
    private bool isWasted = false;
    private GameObject cone;
	// Use this for initialization
	void Start () {
        cone = GameObject.Find("Cone");
	}

    private void Update()
    {
        if(transform.position.y< -4.3f)
        {
            if (GameManager.isGaming)
            {
                ProfitManager.loss += 3f;
            }
            Destroy(this.gameObject);
        }
        if (transform.GetComponent<FixedJoint2D>() != null)
        {
            if (transform.GetComponent<FixedJoint2D>().connectedBody == null)
            {
                isAttached = false;
                transform.parent = null;
            }
        }
        if (isAttached)
        {
            var speed = transform.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (speed > 4f && Vector3.Distance(transform.position, cone.transform.position) > 6f)
            {
                transform.parent = null;
                isAttached = false;
            }
        }

    }
    // Update is called once per frame
    void FixedUpdate() {
        if (waitStopTime > 0f) {
            waitStopTime -= Time.deltaTime;
        }
        else if(!isStopped){
            var speed = transform.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (speed < 0.4f)
            {
                cone = GameObject.Find("Cone");
                isAttached = true;
                transform.parent = cone.transform;
                isStopped = true;
                // Get the particle below it
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
                if (hit.transform != null)
                {
                    if (hit.transform.GetComponent<Rigidbody2D>() != null)
                    {/*
                        print("connect");
                        print("game obj : " + hit.transform.gameObject);
                        transform.gameObject.AddComponent<RelativeJoint2D>();
                        transform.GetComponent<RelativeJoint2D>().connectedBody = hit.transform.GetComponent<Rigidbody2D>();
                        transform.GetComponent<RelativeJoint2D>().breakForce = 800f; 
                        */
                    }
                }
            }
        }
	}
}
