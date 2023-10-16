using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemPickUp : Item, IPointerClickHandler
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameManager.Instant;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameManager.isHooking)
            return;

        Debug.Log("User click into " + gameObject.name);
        gameManager.SendPositionToHook(transform.position);
        gameManager.SendAudioClip(clip);
        gameManager.SendWord(itemType.ToString());
        gameManager.isHooking = true;
        gameManager.onTap = true;
    }
}
