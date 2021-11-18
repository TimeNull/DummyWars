using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void UIDelegate();
public class UpdateCostColor : MonoBehaviour
{
    public static UIDelegate updateColor;
    [SerializeField] Cost objInvokedByButton;
    public Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    private void OnEnable()
    {
        updateColor += updateColor;
    }

    private void OnDisable()
    {
        updateColor -= updateColor;
    }

    public void UpdateColor()
    {
        if (MoneyManager.remainingMoney < objInvokedByButton.cost)
        {
            txt.color = Color.red;
        }
        else
        {
            txt.color = Color.white;
        }
    }
}
