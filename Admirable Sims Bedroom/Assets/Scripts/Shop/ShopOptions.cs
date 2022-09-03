using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopOptions : MonoBehaviour
{
    public int index;

    public GameObject buyWindow;
    public GameObject sellWindow;

    public GameObject clothesWindow;
    public GameObject sellWoodWindow;

    public TextMeshProUGUI buyText;
    public TextMeshProUGUI sellText;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(index == 0)
            {
                index = 1;
            }
            else
            {
                index--;
            }
            
            
            UpdateTexts();
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(index == 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            UpdateTexts();
        }

        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Return))
        {
            if(index == 0)
            {
                OpenClothesWindow();
            }
            else if(index == 1)
            {
                OpenSellWoodWindow();
            }
        }
    }

    public void UpdateTexts()
    {
        if(index == 0)
        {
            buyText.text = "> Buy";
            sellText.text = "Sell";
        }
        else if(index == 1)
        {
            buyText.text = "Buy";
            sellText.text = "> Sell";
        }
    }

    public void OpenClothesWindow()
    {
        clothesWindow.SetActive(true);
        GetComponentInParent<Dialogue>().dialogueGameObject.SetActive(false);
    }
    public void OpenSellWoodWindow()
    {
        sellWoodWindow.SetActive(true);
        GetComponentInParent<Dialogue>().dialogueGameObject.SetActive(false);
    }
}
