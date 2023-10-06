using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType _itemType;
    public ItemType itemType { set { _itemType = value; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Inventory.instance.addItem(_itemType);
            Destroy(gameObject);
        }
    }
}
