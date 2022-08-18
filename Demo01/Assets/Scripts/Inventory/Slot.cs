using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public Item item;
    public Text text;
    public Image itemIcon;
    public int slotnum;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        text.text = item.itemCount.ToString();
        itemIcon.gameObject.SetActive(true);
    }
    public void RemoveSlot()
    {
        item = null;
        text.text = "";
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isUse = item.Use();
        if (isUse)
        {
            Inventory.instance.RemoveItem(slotnum);
        }
    }
}
