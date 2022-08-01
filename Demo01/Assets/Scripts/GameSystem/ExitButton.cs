using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
    public Image btn1, btn2;

    public void BtnFadeOut()
    {
        btn1.color = new Color(0, 0, 0, 0);
        btn2.color = new Color(0, 0, 0, 0);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
