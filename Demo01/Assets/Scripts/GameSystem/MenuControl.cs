using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject Menupage1;
    public GameObject Menupage2;
    public GameObject Menupage3;

    public GameObject ShopMenuPage1;
    public GameObject ShopMenuPage2;
    public GameObject ShopMenuPage3;
    public int page = 1;
    public int ShopPage = 1;

    public void RightPage()
    {
        if(page == 1)
        {
            page++;
            Menupage1.SetActive(false);
            Menupage2.SetActive(true);
        }
        else if(page == 2)
        {
            page++;
            Menupage2.SetActive(false);
            Menupage3.SetActive(true);
        }
    }

    public void LeftPage()
    {
        if (page == 2)
        {
            page--;
            Menupage1.SetActive(true);
            Menupage2.SetActive(false);
        }
        else if (page == 3)
        {
            page--;
            Menupage3.SetActive(false);
            Menupage2.SetActive(true);
        }
    }

    public void ShopKeeperRightPage()
    {
        if (page == 1)
        {
            page++;
            ShopMenuPage1.SetActive(false);
            ShopMenuPage2.SetActive(true);
        }
        else if (page == 2)
        {
            page++;
            ShopMenuPage2.SetActive(false);
            ShopMenuPage3.SetActive(true);
        }
    }

    public void ShopKeeperLeftpage()
    {
        if (page == 2)
        {
            page--;
            ShopMenuPage1.SetActive(true);
            ShopMenuPage2.SetActive(false);
        }
        else if (page == 3)
        {
            page--;
            ShopMenuPage3.SetActive(false);
            ShopMenuPage2.SetActive(true);
        }
    }



}
