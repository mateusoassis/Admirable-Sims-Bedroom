using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodAmount : MonoBehaviour
{
    public WoodHandler woodHandler;
    public MoneyPrinter moneyPrinter;

    [SerializeField] private TextMeshProUGUI woodAmountText;

    private int woodAmount;

    void Start()
    {
        woodAmount = woodHandler.totalWood;
        UpdateWoodAmount();
    }

    public void UpdateWoodAmount()
    {
        woodAmountText.text = "x " + woodAmount;
        woodHandler.totalWood = woodAmount;
        woodHandler.UpdateWood(0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Return))
        {
            if(woodAmount > 0)
            {
                woodAmount--;
                UpdateWoodAmount();
                moneyPrinter.AddMoney();
            }
        }
    }
}
