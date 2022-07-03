using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    int i = 0;
    public Image image;
    public GameObject button;
    public bool fadeInCheck = false;
    public GameObject[] prolog = new GameObject[9];
    public GameObject prologEnd;
    bool endCheck = false;

    private void Update()
    {
        if (fadeInCheck == true)
        {
            StartCoroutine(fadeOut());
            fadeInCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
            if(i == 9)
            {
                prologEnd.SetActive(false);
                //SceneLoad();
                StartCoroutine(FadeIn());
                Invoke("SceneLoad", 1.3f);
                endCheck = true;
            }
            if (endCheck == false)
            {
                prolog[i].SetActive(true);
                if (i == 8)
                {
                    prolog[i].SetActive(true);
                }
            }
        }
    }
    public void FadeButton()
    {
        button.SetActive(false);// 버튼 구현시 사용 / 버튼을 클릭하면 비활성화해줌.
        //StartCoroutine(FadeIn());
        prolog[0].SetActive(true);
        // 프롤로그를 보여주고 로드씬


    }

    IEnumerator FadeIn()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        fadeInCheck = true;
    }

    IEnumerator fadeOut()
    {
        float fadeCount = 1;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.02f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }
    void SceneLoad()
    {
        SceneManager.LoadScene("Main");
    }
}
