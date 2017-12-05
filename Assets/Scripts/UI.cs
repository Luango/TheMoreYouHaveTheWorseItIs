using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {
    public Transform Timer;
    public Transform Income;
    public Transform Loss;
    public Transform Salary;
    public Transform Ending;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer.GetComponent<Text>().text = "Time : " + TimeManager.GameTime.ToString("N0");
        Loss.GetComponent<Text>().text = "Loss" + ProfitManager.loss.ToString("N0");
        Income.GetComponent<Text>().text = "Income" + ProfitManager.income.ToString("N0");
        float profit = ProfitManager.income - ProfitManager.loss;
        Salary.GetComponent<Text>().text = "Salary" + profit.ToString("N0");
        Ending.GetComponent<Text>().text = "You earned " + profit + " coins. Not much.";
    }
}
