using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClothesContainer : MonoBehaviour
{
    public MoneyHandler moneyHandler;
    public AnimationManager animationManager;
    public RectTransform[] sixPositions;
    public TextMeshProUGUI[] sixTextPositions;
    public bool[] sixUnlocked;
    public bool[] sixEquipped;
    public int[] sixValues;
    public RectTransform selectBorder;

    private int index;

    void Start()
    {
        index = 0;
        
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        for(int i = 0; i < sixTextPositions.Length; i++)
        {
            if(sixEquipped[i])
            {
                sixTextPositions[i].text = "Using";
            }
            else if(sixUnlocked[i])
            {
                sixTextPositions[i].text = "Use?";
            }
            else
            {
                sixTextPositions[i].text = "$ "+ sixValues[i];
            }
        }
        selectBorder.anchoredPosition = sixPositions[index].anchoredPosition;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            index--;
            if(index < 0)
            {
                index = sixPositions.Length - 1;
            }
            index--;
            if(index < 0)
            {
                index = sixPositions.Length - 1;
            }
            index--;
            if(index < 0)
            {
                index = sixPositions.Length - 1;
            }
            UpdateTexts();
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(index == 0)
            {
                index = sixPositions.Length - 1;
            }
            else
            {
                index--;
            }
            UpdateTexts();
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            index++;
            if(index > sixPositions.Length - 1)
            {
                index = 0;
            }
            index++;
            if(index > sixPositions.Length - 1)
            {
                index = 0;
            }
            index++;
            if(index > sixPositions.Length - 1)
            {
                index = 0;
            }
            UpdateTexts();
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(index == sixPositions.Length - 1)
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
            if(sixUnlocked[index])
            {
                EquipClothes(index);
            }
            else
            {
                if(moneyHandler.totalMoney > sixValues[index])
                {
                    UnlockClothes(index);
                }
                
            }
        }
    }

    public void EquipClothes(int i)
    {
        ResetClothes();
        sixEquipped[i] = true;
        animationManager.clothes = index;
        animationManager.gender = index;
        animationManager.ChangePlayer();
        UpdateTexts();
    }
    public void UnlockClothes(int i)
    {
        moneyHandler.UpdateMoney(-sixValues[i]);
        sixUnlocked[i] = true;
        UpdateTexts();
    }

    public void ResetClothes()
    {
         for(int i = 0; i < sixTextPositions.Length; i++)
        {
            sixEquipped[i] = false;
        }
    }
}
