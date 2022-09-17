using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingFood : MonoBehaviour
{
    public Sprite[] BtnFoodImage;
    public int itemCountEqual;
    Inventory inven;
    private void Start()
    {
        inven = Inventory.instance;
    }
    // Part1
    public void Omelet()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Egg") && (inven.items[i].itemCount >= 1))
                {
                    inven.RemoveItem(i);
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[0];
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("Omelet");
                }
            }
        }
    }
    public void Salad() 
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Mushroom") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if((inven.items[i].itemName == "Turnip") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[1];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("Salad");
            }
        }
    }
    public void CornSoup()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int temp4 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            bool EqualCheck3 = false;
            bool EqualCheck4 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Corn") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Onion") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
                if ((inven.items[i].itemName == "Milk") && (inven.items[i].itemCount >= 1))
                {
                    temp3 = i;
                    EqualCheck3 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp4 = i;
                    EqualCheck4 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true) && (EqualCheck3 == true) && (EqualCheck4 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                inven.RemoveItem(temp3);
                inven.RemoveItem(temp4);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[2];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("CornSoup");
            }
        }
            
    }
    public void PanCake()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int temp4 = 0;
            int temp5 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            bool EqualCheck3 = false;
            bool EqualCheck4 = false;
            bool EqualCheck5 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Honey") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Flour") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
                if ((inven.items[i].itemName == "Milk") && (inven.items[i].itemCount >= 1))
                {
                    temp3 = i;
                    EqualCheck3 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp4 = i;
                    EqualCheck4 = true;
                }
                if ((inven.items[i].itemName == "Egg") && (inven.items[i].itemCount >= 1))
                {
                    temp5 = i;
                    EqualCheck5 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true) && (EqualCheck3 == true) && (EqualCheck4 == true) && (EqualCheck5 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                inven.RemoveItem(temp3);
                inven.RemoveItem(temp4);
                inven.RemoveItem(temp5);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[3];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("PanCake");
            }
        }
    }
    public void GrilledLopster()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            bool EqualCheck3 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Egg") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Cheese") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp3 = i;
                    EqualCheck3 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true) && (EqualCheck3 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                inven.RemoveItem(temp3);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[4];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("GrilledLopster");
            }
        }
    }
    public void SquidSpaghetti()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int temp4 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            bool EqualCheck3 = false;
            bool EqualCheck4 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Squid") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Onion") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
                if ((inven.items[i].itemName == "Flour") && (inven.items[i].itemCount >= 1))
                {
                    temp3 = i;
                    EqualCheck3 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp4 = i;
                    EqualCheck4 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true) && (EqualCheck3 == true) && (EqualCheck4 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                inven.RemoveItem(temp3);
                inven.RemoveItem(temp4);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[5];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("SquidSpaghetti");
            }
        }
    }
    //Part2
    public void SteamedSharkfin()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Sharkfin") && (inven.items[i].itemCount >= 1))
                {
                    inven.RemoveItem(i);
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[6];
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("SteamedSharkfin");
                }
            }
        }
    }
    public void TunaStake()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Tuna") && (inven.items[i].itemCount >= 1))
                {
                    inven.RemoveItem(i);
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[7];
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("TunaStake");
                }
            }
        }
    }
    public void GrilledShrimp()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Shrimp") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[8];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("GrilledShrimp");
            }
        }
    }
    public void GrilledBird()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "FireBirdMeat") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[9];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("GrilledBird");
            }
        }
    }
    public void SheepStake()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "Lamb") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[10];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("SheepStake");
            }
        }
    }
    public void PorkChop()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            int temp4 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            bool EqualCheck3 = false;
            bool EqualCheck4 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "WildboarMeat") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Paprika") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
                if ((inven.items[i].itemName == "Onion") && (inven.items[i].itemCount >= 1))
                {
                    temp3 = i;
                    EqualCheck3 = true;
                }
                if ((inven.items[i].itemName == "Mushroom") && (inven.items[i].itemCount >= 1))
                {
                    temp4 = i;
                    EqualCheck4 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true) && (EqualCheck3 == true) && (EqualCheck4 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                inven.RemoveItem(temp3);
                inven.RemoveItem(temp4);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[11];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("PorkChop");
            }
        }
    }
    //Part3
    public void GrilledLizardTail()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            int temp1 = 0;
            int temp2 = 0;
            bool EqualCheck1 = false;
            bool EqualCheck2 = false;
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "LizardTail") && (inven.items[i].itemCount >= 1))
                {
                    temp1 = i;
                    EqualCheck1 = true;
                }
                if ((inven.items[i].itemName == "Butter") && (inven.items[i].itemCount >= 1))
                {
                    temp2 = i;
                    EqualCheck2 = true;
                }
            }
            if ((EqualCheck1 == true) && (EqualCheck2 == true))
            {
                inven.RemoveItem(temp1);
                inven.RemoveItem(temp2);
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[12];
                GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("GrilledLizardTail");
            }
        }
    }
    public void DragonStake()
    {
        if (GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn && GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count < 5)
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if ((inven.items[i].itemName == "DragonMeat") && (inven.items[i].itemCount >= 1))
                {
                    inven.RemoveItem(i);
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().ClickedFoodImage = BtnFoodImage[13];
                    GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SubNoteManager("DragonStake");
                }
            }
        }
    }


}

