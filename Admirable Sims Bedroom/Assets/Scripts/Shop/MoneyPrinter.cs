using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPrinter : MonoBehaviour
{
    [SerializeField] private MoneyHandler moneyHandler;
    [SerializeField] private int addMoney;

    [SerializeField] private Transform moneyMessageSpawn;
    [SerializeField] private GameObject moneyMessage;

    public void AddMoney()
    {
        moneyHandler.UpdateMoney(addMoney);
        GameObject.Find("SoundManager").GetComponent<AudioClipManager>().PlayOneShot("money_sound");
        Instantiate(moneyMessage, moneyMessageSpawn.position, Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.TryGetComponent(out PlayerManager playerManager))
            {
                playerManager.insideMoneyPrinterArea = true;
                playerManager.EnableMessageToInteract();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.TryGetComponent(out PlayerManager playerManager))
            {
                playerManager.insideMoneyPrinterArea = false;
                playerManager.DisableMessageToInteract();
            }
        }
    }
}
