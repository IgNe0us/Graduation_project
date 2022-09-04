using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;
    public GameObject inventoryPanel;
    bool activeInventory = false;
    Player player;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory; // !activeInventory 는 true 다시 i 를 누르면 false
            inventoryPanel.SetActive(activeInventory);
        }
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;
            
            if(i < inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
                slots[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
                slots[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(157, 157, 157, 255);
            }
        }
    }

    public void AddSlot()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if(player.money >= 500 && inven.SlotCnt <= 19)
        {
            player.money -= 500;
            inven.SlotCnt++;
        }
        else
        {
            Debug.Log("돈이 없거나 슬롯을 모두 구매하였습니다..");
        }

    }

    public void RedrawSlotUI()
    {
        for(int i =0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for(int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].item.itemCount = inven.items[i].itemCount;
            slots[i].UpdateSlotUI();
        }
    }


}
