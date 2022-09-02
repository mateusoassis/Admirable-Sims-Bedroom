using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject interactMessageObject;

    public bool insideMoneyPrinterArea;
    public MoneyPrinter moneyPrinter;

    public bool insideShopArea;
    public Shop shop;
    public ClothesWindowManager clothesWindowManager;

    public bool insideWardrobeArea;
    public Wardrobe wardrobe;

    public bool isWindowOpen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !isWindowOpen)
        {
            if(insideMoneyPrinterArea)
            {
                moneyPrinter.AddMoney();
            }
            else if(insideShopArea)
            {
                clothesWindowManager.Open();
            }
            else if(insideWardrobeArea)
            {

            }
        }
    }

    public void EnableMessageToInteract()
    {
        interactMessageObject.SetActive(true);
    }

    public void DisableMessageToInteract()
    {
        interactMessageObject.SetActive(false);
    }
}
