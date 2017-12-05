using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OrderHand : MonoBehaviour {
    public Transform targetPos;
    public GameObject Cone;
    public Transform coneSpawnTran;

    private Vector3 tarPos;
    private Vector3 oriPos;
    private bool isOrdering = false;
    private float waitTime = 0f;

    // Use this for initialization
    void Start()
    {
        tarPos = targetPos.position;
        oriPos = transform.position;
        waitTime = Random.Range(0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (!isOrdering)
            {
                waitTime -= Time.deltaTime;
                if (waitTime < 0f)
                {
                    isOrdering = true;
                    transform.DOMove(tarPos, 1f);
                }
            }
        }
        else if(Vector3.Distance(transform.position, oriPos)>3f)
        {
            isOrdering = false;
            transform.DOMove(oriPos, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Cone")
        {
            Destroy(collision.transform.GetComponent<HoldMovement>());
            collision.transform.parent = this.gameObject.transform;

            isOrdering = true;
            transform.DOMove(oriPos, 1f).OnComplete(() => { 
                var cone = Instantiate(Cone, coneSpawnTran.position, Quaternion.identity);
                cone.transform.name = "Cone";
                ProfitManager.income += collision.transform.childCount;
                Destroy(collision.transform.gameObject);
                isOrdering = false;
                waitTime = Random.Range(0f, 1f);
            });
        }
    }
}
