using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject Instruction;
    public GameObject StartGameButton;
    public GameObject Ending;
    public GameObject RestartGameButton;

    static public bool isGaming = false;

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void RestartGame()
    {
        Instruction.SetActive(true);
        StartGameButton.SetActive(true);
        RestartGameButton.SetActive(false);
        Ending.SetActive(false);
        TimeManager.GameTime = 120f;
        ProfitManager.income = 0f;
        ProfitManager.loss = 0f;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        isGaming = true;
        Instruction.SetActive(false);
        StartGameButton.SetActive(false);
    }

    public void EndGame()
    {
        isGaming = false;
        Ending.SetActive(true);
        RestartGameButton.SetActive(true);
    }
}
