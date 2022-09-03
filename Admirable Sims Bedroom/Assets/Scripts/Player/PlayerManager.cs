using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject interactMessageObject;

    public bool insideWoodArea;
    public WoodHandler woodHandler;

    public bool insideMoneyPrinterArea;
    public MoneyPrinter moneyPrinter;

    public bool insideShopArea;
    public Shop shop;
    public ClothesWindowManager clothesWindowManager;
    public Dialogue clothesDialogue;

    public bool insideWardrobeArea;
    public Wardrobe wardrobe;

    public bool isWindowOpen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !isWindowOpen)
        {            
            if(insideShopArea)
            {
                //clothesWindowManager.Open();
                UnityEngine.Debug.Log("dialogue");
                clothesDialogue.StartDialogue();
                isWindowOpen = true;
            }    
            else if(insideWardrobeArea)
            {

            }
            else if(insideWoodArea)
            {
                woodHandler.ActivateObject();
                woodHandler.pressing = true;
                isWindowOpen = true;
                DisableMessageToInteract();
            }
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            if(woodHandler.pressing)
            {
                woodHandler.pressing = false;
                isWindowOpen = false;
                EnableMessageToInteract();
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
