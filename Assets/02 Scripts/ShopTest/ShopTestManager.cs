using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTestManager : Singleton<ShopTestManager>
{
    [Header("JSON Data")]
    [SerializeField] private TextAsset jsonData;
    [SerializeField] private ItemTestList itemsList = new ItemTestList();
    [Header("Shelfs")]
    [SerializeField] private GameObject shelfPrefab;
    [SerializeField] private int numberItemsPerShelf = 3;
    [SerializeField] private int totalShelfs;
    [Header("Items")]
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int totalItems;
    [Header("References")]
    [SerializeField] private Transform content;
    private void Start()
    {
        itemsList = JsonUtility.FromJson<ItemTestList>(jsonData.text);
        totalItems = itemsList.items.Length;
        totalShelfs = totalItems / numberItemsPerShelf;
        Invoke("GenerateShop", 5f);
    }
    public void GenerateShop()
    {
        for (int i = 0; i < totalShelfs; i++)
        {
            ShelfTestController shelf = Instantiate(shelfPrefab, content.position, Quaternion.identity).GetComponent<ShelfTestController>();
            shelf.transform.SetParent(content);
            shelf.gameObject.name = $"Shelf {i}";
     
            for (int j = 0; j < numberItemsPerShelf; j++)
            {
                int itemId = (i * numberItemsPerShelf) + j;

                ItemTestController item = Instantiate(itemPrefab, shelf.slots[j].position, Quaternion.identity).GetComponent<ItemTestController>();
                item.transform.SetParent(shelf.slots[j]);
                item.gameObject.name = itemsList.items[itemId].title;

                string path = "ShopTest/ShopItems/" + itemsList.items[itemId].icon;
                Sprite newSprite = Resources.Load<Sprite>(path);
                item.SetValue(newSprite, itemsList.items[itemId].title, itemsList.items[itemId].price);
            }

        }
    }
}
