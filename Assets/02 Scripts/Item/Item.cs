using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour  //ScriptableObject
{
    [SerializeField] protected ItemType itemType;
    [SerializeField] protected AudioClip clip;
}
public enum ItemType
{
    Handbag,
    Sandal,
    Watch,
    Hat
}
