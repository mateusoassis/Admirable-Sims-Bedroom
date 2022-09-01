using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.TryGetComponent(out PlayerManager playerManager))
            {
                playerManager.insideWardrobeArea = true;
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
                playerManager.insideWardrobeArea = false;
                playerManager.DisableMessageToInteract();
            }
        }
    }
}
