using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamGenerator : MonoBehaviour {
    public GameObject IceCreamParticle;
    public Transform OnImg;
    public Transform OffImg;

    private Vector3 TouchPos;
    private float timeStep;

    private GameObject preIceParticle;
    private GameObject currIceParticle;
    

    // Use this for initialization
    void Start () {
        timeStep = 0.05f;
       
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (GameManager.isGaming)
        {
            var v3 = Input.mousePosition;
            TouchPos = Camera.main.ScreenToWorldPoint(v3);
            TouchPos.z = 0f;
            timeStep -= Time.deltaTime;

            if (Input.GetKeyDown("space"))
            {
                OnImg.gameObject.SetActive(true);
                OffImg.gameObject.SetActive(false); ;
            }
            else if (Input.GetKeyUp("space"))
            {
                OnImg.gameObject.SetActive(false);
                OffImg.gameObject.SetActive(true);
            }

            if (Input.GetKey("space") && timeStep < 0f)
            {
                if (preIceParticle != null)
                {
                    currIceParticle = Instantiate(IceCreamParticle, new Vector3(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f), 0f), Quaternion.identity);
                    if (Vector3.Distance(preIceParticle.transform.position, currIceParticle.transform.position) < 1f)
                    {
                        currIceParticle.AddComponent<FixedJoint2D>();
                        currIceParticle.GetComponent<FixedJoint2D>().connectedBody = preIceParticle.gameObject.GetComponent<Rigidbody2D>();
                        currIceParticle.GetComponent<FixedJoint2D>().breakForce = 300f;
                        currIceParticle.GetComponent<FixedJoint2D>().dampingRatio = 1f;
                        preIceParticle = currIceParticle;
                    }
                    else
                    {
                        print("pre is null");
                        preIceParticle = currIceParticle;
                    }
                }
                else
                {
                    print("pre is null");
                    preIceParticle = Instantiate(IceCreamParticle, new Vector3(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.1f, 0.1f), 0f), Quaternion.identity);
                }

                timeStep = 0.02f;
            }
        }
    }
}
