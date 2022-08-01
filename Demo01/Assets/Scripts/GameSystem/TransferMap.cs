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
            GameObject.Find("FadeControl").GetComponent<FadeControl>().FadeStart();
            Invoke("SceneLoad", 1.3f);
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
            SceneManager.LoadScene(transferMapName);
        }   
    }
}
