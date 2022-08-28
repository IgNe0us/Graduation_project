using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour
{
    public GameObject ControlManual;
    public GameObject RestaurantUpgrade;
    private void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            RestaurantUpgrade.SetActive(false);
        }
    }

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
