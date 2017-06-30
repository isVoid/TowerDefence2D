using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinanceManager : System.Object {

    private static FinanceManager instance;
    private static GameSceneController controller;

    public static FinanceManager getInstance(){
        if (instance == null)
        {
            instance = new FinanceManager();
        }
        return instance;
    }

//    public GameObject moneyUIText;

//    public int balance { 
//        get{ return balance; } 
//        set { balance = value;
//            controller.updateMoneyUI(balance);
//        }}

    private int balance;

    private FinanceManager() {
//        moneyUIText = GameObject.FindWithTag("Money");
        controller = GameSceneController.getInstance();
    }

    public void setBalance(int b)
    {
        balance = b;
        controller.updateMoneyUI(balance);
    }

    public int getBalance()
    {
        return balance;
    }

    public void increaseMoney(int amount)
    {
        balance += amount;
        controller.updateMoneyUI(balance);
//        Debug.Log(balance + " " + amount);
//        moneyUIText.GetComponent<Text>().text = balance.ToString();


    }

    public bool checkBalanceAgainst(int amount)
    {
        return balance >= amount;
    }

    public bool useMoney(int amount)
    {
        if (checkBalanceAgainst(amount))
        {
            balance -= amount;
            controller.updateMoneyUI(balance);
//            Debug.Log(balance);
//            moneyUIText.GetComponent<Text>().text = balance.ToString();
            return true;
        }
        return false;
    }
}
