using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestaurantTutorial : MonoBehaviour
{
    public GameObject[] RestaurantGuide = new GameObject[6];
    bool GuideCheck = false;
    int i = 0;

    private void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    private void Update()
    {
        if(GuideCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (i == 6)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    RestaurantGuide[i].SetActive(false);
                    i++;
                }
            }
        }

    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Restaurant" && GuideCheck == false)
        {
            GuideCheck = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
