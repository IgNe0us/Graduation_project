using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomCreate : MonoBehaviour
{
    public GameObject Cave;

    float start = 0f;
    float end = 1f;
    float time = 0f;

    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            Cave.SetActive(true);
            StartCoroutine("FadeInCave");
        }
    }

    IEnumerator FadeInCave()
    {
        
        while (time < 1.0f)
        {
            time += Time.deltaTime/100.0f;
            Cave.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Lerp(start, end, time));
            yield return null;
        }
    }


}
