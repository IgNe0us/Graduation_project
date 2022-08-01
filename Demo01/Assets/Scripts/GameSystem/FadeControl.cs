using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{
    public GameObject FadeInOut;

    public void FadeStart()
    {
        FadeInOut.SetActive(true);
        GameObject.Find("FadeInout").GetComponent<FadeInOut>().FadeButton();
    }


}
