using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesWindowManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    

    public void Open()
    {
        gameObject.SetActive(true);
        playerManager.isWindowOpen = true;

    }

    public void Close()
    {
        gameObject.SetActive(false);
        playerManager.isWindowOpen = false;
    }
}
