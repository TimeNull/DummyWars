using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int levelMoney;
    public static int remainingMoney;

    private void Awake()
    {
        remainingMoney = levelMoney;
        UpdateRemainingMoney.updateMoneyText();
    }

}
