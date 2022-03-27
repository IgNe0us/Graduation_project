using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image image;
    public GameObject button;
    public bool fadeInCheck = false;

    private void Update()
    {
        if (fadeInCheck == true)
        {
            StartCoroutine(fadeOut());
            fadeInCheck = false;
        }
    }
    public void FadeButton()
    {
        //button.SetActive(false); 버튼 구현시 사용 / 버튼을 클릭하면 비활성화해줌.
        StartCoroutine(FadeIn());
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

}
