using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    float volumeSave = 1.0f;
    private void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            musicSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
            musicSource.volume = volumeSave;
        }
        else if (scene.name == "Forest_1-1")
        {
            musicSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
            musicSource.volume = volumeSave;
        }
        else if (scene.name == "Ocean")
        {
            musicSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
            musicSource.volume = volumeSave;
        }
        else if (scene.name == "Volcano")
        {
            musicSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
            musicSource.volume = volumeSave;
        }
        else if (scene.name == "Restaurant")
        {
            musicSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
            musicSource.volume = volumeSave;
        }
        else if (scene.name == "BossRoom")
        {
            musicSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
            musicSource.volume = volumeSave;
        }
    }

    public void SetMusicVolumeApply()
    {
        musicSource.volume = GameObject.Find("SoundManager").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value;
        volumeSave = GameObject.Find("SoundBar").gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value;
    }
    public void SetMusicVolumeCancel()
    {
        musicSource.volume = (GameObject.Find("SoundManager").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value = 1.0f);
    }
    public void SoundBarExitButton()
    {
        GameObject.Find("SoundManager").gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void SoundBarOnButton()
    {
        GameObject.Find("SoundManager").gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

}
