using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemTestController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;
    public string itemName { get; set; }
    public int itemPrice { get; set; }
    public Sprite itemPath { get; set; }
    public void SetValue(Sprite path, string name, int price)
    {
        itemPath = path;
        itemName = name;
        itemPrice = price;

        Show();
    }
    private void Show()
    {
        iconImage.sprite = itemPath;
        nameText.text = itemName;
        priceText.text = itemPrice.ToString();
    }
}
