using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private int startingMoney;
    [SerializeField] private int totalMoney;
    [SerializeField] private TextMeshProUGUI moneyTextHolder;

    void Start()
    {
        totalMoney = startingMoney;
        UpdateMoney(0);
    }

    public void UpdateMoney(int sum)
    {
        totalMoney += sum;
        moneyTextHolder.text = totalMoney.ToString();
    }
}
