using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinanceManager : SingletonScriptableObject<FinanceManager> {

    public GameObject moneyUIText;

    public int balance = 100;

    public void increaseMoney(int amount)
    {
        balance += amount;
    }

    public bool checkBalanceAgainst(int amount)
    {
        return amount >= balance;
    }

    public bool useMoney(int amount)
    {
        if (checkBalanceAgainst(amount))
        {
            balance -= amount;
            return true;
        }
        return false;
    }
}
