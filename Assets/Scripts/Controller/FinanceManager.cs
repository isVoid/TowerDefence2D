using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinanceManager : System.Object {

    private static FinanceManager instance;

    public static FinanceManager getInstance(){
        if (instance == null)
        {
            instance = new FinanceManager();
        }
        return instance;
    }

    public GameObject moneyUIText;

    public int balance = 100;

    private FinanceManager() {
        moneyUIText = GameObject.Find("CurrentMoney");
    }

    public void increaseMoney(int amount)
    {
        balance += amount;
        Debug.Log(balance + " " + amount);
        moneyUIText.GetComponent<Text>().text = balance.ToString();
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
//            Debug.Log(balance);
            moneyUIText.GetComponent<Text>().text = balance.ToString();
            return true;
        }
        return false;
    }
}
