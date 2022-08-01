﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChoice : MonoBehaviour
{
    public GameObject Map;
    public GameObject Player;
    public void Go_To_Forest()
    {
        GameObject.Find("FadeControl").GetComponent<FadeControl>().FadeStart();
        Invoke("Forest", 1.3f);
        Map.SetActive(false);
    }
    void Forest()
    {
        SceneManager.LoadScene("Forest_1-1");
        Player.transform.position = new Vector2(47f, -6.9f);
    }

    public void Go_To_Village()
    {
        GameObject.Find("FadeControl").GetComponent<FadeControl>().FadeStart();
        Invoke("Village", 1.3f);
        Map.SetActive(false);
    }
    void Village()
    {
        SceneManager.LoadScene("Main");
        Player.transform.position = new Vector2(47f, -6.9f);
    }
    public void Go_To_Volcano()
    {
        GameObject.Find("FadeControl").GetComponent<FadeControl>().FadeStart();
        Invoke("Volcano", 1.3f);
        Map.SetActive(false);
    }
    void Volcano()
    {
        SceneManager.LoadScene("Volcano");
        Player.transform.position = new Vector2(47f, -6.9f);
    }
    public void Go_To_Ocean()
    {
        GameObject.Find("FadeControl").GetComponent<FadeControl>().FadeStart();
        Invoke("Ocean", 1.3f);
        Map.SetActive(false);
    }
    void Ocean()
    {
        SceneManager.LoadScene("Ocean");
        Player.transform.position = new Vector2(47f, -6.9f);
    }

}