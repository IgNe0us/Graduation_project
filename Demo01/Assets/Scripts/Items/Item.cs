using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Potion,
    Etc,
    
}



[System.Serializable]
public class Item
{
    public ItemType itemType;           // 아이템 타입.
    public string itemName;             // 아이템 이름.
    public Sprite itemImage;            // 기본 이미지.
    public int itemCount;               // 아이템 개수.
    public List<ItemEffect> efts;       // 아이템 이펙트.
    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed;
    }
}
