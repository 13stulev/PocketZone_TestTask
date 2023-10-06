using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/addItemType")]
public class ItemType : ScriptableObject
{
    public Sprite itemSprite;
    public string name;
    public int count = 1;
}
