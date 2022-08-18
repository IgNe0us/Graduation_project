using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopExitButton : MonoBehaviour
{
    public GameObject Shop;
    public void ExitButton()
    {
        Shop.SetActive(false);
    }

}
