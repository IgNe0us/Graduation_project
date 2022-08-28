using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopExplanation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text ChatText1;
    public Text ChatText2;
    public string ItemName;
    public string ItemExplanation;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChatText1.text = ItemName;
        ChatText2.text = ItemExplanation;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

}
