using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRemainingMoney : MonoBehaviour
{
    public static UIDelegate updateMoneyText;
    public Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    private void OnEnable()
    {
        updateMoneyText += UpdateValue;
    }

    private void OnDisable()
    {
        updateMoneyText -= UpdateValue;
    }

    public void UpdateValue()
    {
        txt.text = "" + MoneyManager.remainingMoney;
    }
}
