using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(transferMapName == "Main" && GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn == true)
            {
                return;
            }
            else
            {
                GameObject.Find("FadeControl").GetComponent<FadeControl>().FadeStart();
                Invoke("SceneLoad", 1.3f);
            }
        }
    }

    void SceneLoad()
    {
        if (transferMapName == "Restaurant")
        {
            SceneManager.LoadScene(transferMapName);
            DontDestoryObject.ObjNum = 7;
        }
        else
        {
            if(transferMapName == "Main" && GameObject.Find("CookSystem").GetComponent<CookingSystem>().timerOn == true)
            {
                return;
            }
            SceneManager.LoadScene(transferMapName);
        }   
    }
}
