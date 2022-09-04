using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HpHotKeyUI : MonoBehaviour
{ 
    Inventory inven;
    public Text HpText;
    public Text AdHpText;
    public Text EgText;
    public Item item;


    private void Start()
    {
        inven = Inventory.instance;
    }

    private void Update()
    {
        HotkeyUIUpdate();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int idx = inven.items.FindIndex(a => a.itemName == "HpPotion");
            if (idx != -1)
            {
                inven.items[idx].itemCount -= 1;
                GameObject.Find("Player").GetComponent<Player>().curHp += 2;
                if (inven.items[idx].itemCount < 1)
                {
                    HotkeyUIUpdate();
                    inven.RemoveItem(idx);
                }
                GameObject.Find("UI").GetComponent<InventoryUI>().RedrawSlotUI();
            }
            else
            {
                Debug.Log("포션이 없습니다.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int idx = inven.items.FindIndex(a => a.itemName == "AdvancedHpPotion");
            if (idx != -1)
            {
                inven.items[idx].itemCount -= 1;
                GameObject.Find("Player").GetComponent<Player>().curHp += 4;
                if (inven.items[idx].itemCount < 1)
                {
                    HotkeyUIUpdate();
                    inven.RemoveItem(idx);
                }
                GameObject.Find("UI").GetComponent<InventoryUI>().RedrawSlotUI();

            }
            else
            {
                Debug.Log("포션이 없습니다.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int idx = inven.items.FindIndex(a => a.itemName == "EnergyPotion");
            if (idx != -1)
            {
                inven.items[idx].itemCount -= 1;
                GameObject.Find("Player").GetComponent<Player>().curEnergy += 20;
                if (inven.items[idx].itemCount < 1)
                {
                    HotkeyUIUpdate();
                    inven.RemoveItem(idx);
                }
                GameObject.Find("UI").GetComponent<InventoryUI>().RedrawSlotUI();
            }
            else
            {
                Debug.Log("포션이 없습니다.");
            }
        }
    }

    public void HotkeyUIUpdate()
    {
        // HotKeyUI Hp , adHp, EgPotion 개수를 item 리스트 에서 가져와 표시해줌
        for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].itemName == "HpPotion")
            {
                HpText.text = "x" + inven.items[i].itemCount.ToString();
            }
            else if (inven.items[i].itemName == "AdvancedHpPotion")
            {
                AdHpText.text = "x" + inven.items[i].itemCount.ToString();
            }
            else if (inven.items[i].itemName == "EnergyPotion")
            {
                EgText.text = "x" + inven.items[i].itemCount.ToString();
            }
        }
    }


}
