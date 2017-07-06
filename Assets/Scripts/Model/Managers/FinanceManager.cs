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
        
    private int balance;

    private FinanceManager() {
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
            return true;
        }
        return false;
    }
}
