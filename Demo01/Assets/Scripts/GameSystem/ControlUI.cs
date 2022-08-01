using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUI : MonoBehaviour
{
    public GameObject ControlManual;
    public GameObject RestaurantUpgrade;

    public void OpenManual()
    {
        ControlManual.SetActive(true);
    }

    public void CloseManual()
    {
        ControlManual.SetActive(false);
    }

    public void OpenRestaurantManual()
    {
        RestaurantUpgrade.SetActive(true);
    }
    public void CloseRestaurantManual()
    {
        RestaurantUpgrade.SetActive(false);
    }

}
