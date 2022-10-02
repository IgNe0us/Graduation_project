using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cave : MonoBehaviour
{
    bool OnCave = false;


    private void Update()
    {
        if(OnCave == true && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("BossRoom");
            GameObject.Find("Player").gameObject.transform.position = new Vector2(48.17f, -6.62f);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnCave = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnCave = false;
    }



}
