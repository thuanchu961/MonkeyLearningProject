using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip clip;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name);
    }
    
}
