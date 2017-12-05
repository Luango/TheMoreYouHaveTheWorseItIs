using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    static public float GameTime = 120f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.isGaming)
        {
            GameTime -= Time.deltaTime;
            if (GameTime < 0)
            {
                print("Game Over");
                GameManager.Instance.EndGame();
            }
        }
	}
}
