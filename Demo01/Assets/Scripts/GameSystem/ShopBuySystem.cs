using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuySystem : MonoBehaviour
{
    ItemDatabase idb;
    Inventory ivn;
    public GameObject Snorkel;

    private void Start()
    {
        ivn = Inventory.instance;
        idb = ItemDatabase.instance;
    }
    public void BuyHpPotion()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 200)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[42]);
            GameObject.Find("Player").GetComponent<Player>().money -= 200;
        }
    }

    public void BuyEnergyPotion()
    {
        if(GameObject.Find("Player").GetComponent<Player>().money < 220)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[43]);
            GameObject.Find("Player").GetComponent<Player>().money -= 220;
        }
    }
    public void BuyAdvancedHpPotion()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 500)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[44]);
            GameObject.Find("Player").GetComponent<Player>().money -= 500;
        }
    }
    public void BuyHoney()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 70)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[45]);
            GameObject.Find("Player").GetComponent<Player>().money -= 70;
        }
    }

    public void BuyFiour()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 60)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[46]);
            GameObject.Find("Player").GetComponent<Player>().money -= 60;
        }
    }
    public void BuyMilk()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 60)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[47]);
            GameObject.Find("Player").GetComponent<Player>().money -= 60;
        }
    }

    public void BuyButter()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 50)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[48]);
            GameObject.Find("Player").GetComponent<Player>().money -= 50;
        }
    }
    public void BuySnorkel()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 3000)
        {
            return;
        }
        else
        {
            GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel = 2;
            GameObject.Find("Player").GetComponent<Player>().foodLevelCheck = 2;
            GameObject.Find("MapControl").gameObject.transform.GetChild(0).gameObject.GetComponent<MapChoice>().OceanOn = true;
            GameObject.Find("Player").GetComponent<Player>().money -= 3000;
            Snorkel.GetComponent<Button>().interactable = false;
            Snorkel.transform.GetChild(2).GetComponent<Text>().color = new Color(255, 0, 0);
        }
    }
    public void BuyCheese()
    {
        if (GameObject.Find("Player").GetComponent<Player>().money < 70)
        {
            return;
        }
        else
        {
            ivn.AddItem(idb.itemDB[50]);
            GameObject.Find("Player").GetComponent<Player>().money -= 70;
        }
    }





}
