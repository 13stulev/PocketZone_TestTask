using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardItem : MonoBehaviour
{
    public void discard()
    {
        var temp = gameObject.GetComponentInParent<Image>();
        Inventory.instance.removeItem(gameObject.GetComponentInParent<Image>().sprite);
        Inventory.instance.redraw();
    }
}
