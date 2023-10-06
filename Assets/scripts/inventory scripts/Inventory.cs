using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryScreen;
    [SerializeField]
    private GameObject slot;
    [SerializeField]
    private Dictionary<Sprite, int> inventory;

    public static Inventory instance;
    
    

    private void Awake()
    {
        instance = this;
        inventory = new Dictionary<Sprite, int>();
    }
    public void addItem(ItemType pickedItem)
    {
        if(inventory.ContainsKey(pickedItem.itemSprite)) {
            inventory[pickedItem.itemSprite] += pickedItem.count;
        } else
        {
            inventory.Add(pickedItem.itemSprite, pickedItem.count);
        }
    }

    public void removeItem(Sprite itemSprite)
    {
        inventory.Remove(itemSprite);
    }
    public void useItem(Sprite itemSprite)
    {
        inventory[itemSprite]--;
        if(inventory[itemSprite] <= 0)
        {
            removeItem(itemSprite);
        }
    }
    public void redraw()
    {
        foreach (TextMeshProUGUI slot in inventoryScreen.GetComponentsInChildren<TextMeshProUGUI>())
        {
            Destroy(slot.GetComponentInParent<Image>().gameObject);
        }
        foreach(KeyValuePair<Sprite, int> entry in inventory)
        {
            GameObject slot = Instantiate(this.slot, inventoryScreen.transform);
            slot.GetComponent<Image>().sprite = entry.Key;
            if(entry.Value == 1)
            {
                slot.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            }
            else {
                slot.GetComponentInChildren<TextMeshProUGUI>().text = entry.Value.ToString();
            }
            
        }
    }

    public bool contains(Sprite sprite)
    {
        return inventory.ContainsKey(sprite);
    }
}
