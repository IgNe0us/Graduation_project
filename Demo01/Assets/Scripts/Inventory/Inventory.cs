using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    private void Start()
    {
        SlotCnt = 10;
    }

    public bool AddItem(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].itemName == item.itemName)
            {
                GameObject.Find("UI").GetComponent<InventoryUI>().slots[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = (++GameObject.Find("UI").GetComponent<InventoryUI>().slots[i].itemCount).ToString();
                return true;
            }
        }

        if (items.Count < SlotCnt)
        {
            GameObject.Find("UI").GetComponent<InventoryUI>().slots[items.Count].transform.GetChild(1).gameObject.GetComponent<Text>().text = (++GameObject.Find("UI").GetComponent<InventoryUI>().slots[items.Count].itemCount).ToString();
            items.Add(item);
            if (onChangeItem != null)
                onChangeItem.Invoke();
            return true;
        }
        Debug.Log("아이템이 꽉 찼습니다.");
        return false;

    }

    public void RemoveItem(int index)
    {
        items.RemoveAt(index);
        onChangeItem.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))          // 필드 아이템과 충돌 시.
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.Getitem()))
            {
                fieldItems.DestroyItem();               // 필드 아이템 파괴.
            }
        }
    }

}
