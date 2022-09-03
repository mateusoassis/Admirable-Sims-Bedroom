using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodArea : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.TryGetComponent(out PlayerManager playerManager))
            {
                playerManager.insideWoodArea = true;
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
                playerManager.insideWoodArea = false;
                playerManager.DisableMessageToInteract();
            }
        }
    }
}
