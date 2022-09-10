using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCookNote : MonoBehaviour
{
    public Sprite ClickedFoodImage;
    public GameObject[] SubCookFoodObj;
    public Slider[] CookingGagebar;
    public string ItemName1;
    public string ItemName2;
    public string ItemName3;
    public string ItemName4;
    float Timer1 = 10.0f;
    bool TimerStart1 = false;
    float Timer2 = 10.0f;
    bool TimerStart2 = false;
    float Timer3 = 10.0f;
    bool TimerStart3 = false;
    float Timer4 = 10.0f;
    bool TimerStart4 = false;
    float Timer_Max = 10.0f;
    public List<string> MadeItem = new List<string>();
    public List<Sprite> SpriteSave = new List<Sprite>();

    bool r1Check = true;
    bool r2Check = true;
    bool r3Check = true;
    bool r4Check = true;
    private void Update()
    {
        CookingGagebar[0].value = Mathf.Lerp(CookingGagebar[0].value, Timer1 / Timer_Max, Time.deltaTime * 5f);
        CookingGagebar[1].value = Mathf.Lerp(CookingGagebar[1].value, Timer2 / Timer_Max, Time.deltaTime * 5f);
        CookingGagebar[2].value = Mathf.Lerp(CookingGagebar[2].value, Timer3 / Timer_Max, Time.deltaTime * 5f);
        CookingGagebar[3].value = Mathf.Lerp(CookingGagebar[3].value, Timer4 / Timer_Max, Time.deltaTime * 5f);

        if(TimerStart1 == true)
        {
            TimerStartfun1();
        }
        
        if (TimerStart2 == true)
        {
            TimerStartfun2();
        }
        
        if (TimerStart3 == true)
        {
            TimerStartfun3();
        }
        
        if (TimerStart4 == true)
        {
            TimerStartfun4();
        }

    }
    
    void TimerStartfun1()
    {
        Timer1 -= Time.deltaTime;
    }
    void TimerStartfun2()
    {
        Timer2 -= Time.deltaTime;
    }
    void TimerStartfun3()
    {
        Timer3 -= Time.deltaTime;
    }
    void TimerStartfun4()
    {
        Timer4 -= Time.deltaTime;
    }

    public void SubNoteManager(string ItemName)
    {
        if(r1Check == true)
        {
            SubNoteRoom1(ItemName);
        }
        else if(r2Check == true)
        {
            SubNoteRoom2(ItemName);
        }
        else if (r3Check == true)
        {
            SubNoteRoom3(ItemName);
        }
        else if (r4Check == true)
        {
            SubNoteRoom4(ItemName);
        }
    }

    void SubNoteRoom1(string ItemName)
    {
        ItemName1 = ItemName;
        r1Check = false;
        TimerStart1 = true;
        SpriteSave.Add(ClickedFoodImage);
        SubCookFoodObj[0].gameObject.SetActive(true);
        SubCookFoodObj[0].gameObject.GetComponent<Image>().sprite = ClickedFoodImage;
        StartCoroutine("Cooked1");
    }
    void SubNoteRoom2(string ItemName)
    {
        ItemName2 = ItemName;
        r2Check = false;
        TimerStart2 = true;
        SpriteSave.Add(ClickedFoodImage);
        SubCookFoodObj[1].gameObject.SetActive(true);
        SubCookFoodObj[1].gameObject.GetComponent<Image>().sprite = ClickedFoodImage;
        StartCoroutine("Cooked2");
    }
    void SubNoteRoom3(string ItemName)
    {
        ItemName3 = ItemName;
        r3Check = false;
        TimerStart3 = true;
        SpriteSave.Add(ClickedFoodImage);
        SubCookFoodObj[2].gameObject.SetActive(true);
        SubCookFoodObj[2].gameObject.GetComponent<Image>().sprite = ClickedFoodImage;
        StartCoroutine("Cooked3");
    }
    void SubNoteRoom4(string ItemName)
    {
        ItemName4 = ItemName;
        r4Check = false;
        TimerStart4 = true;
        SpriteSave.Add(ClickedFoodImage);
        SubCookFoodObj[3].gameObject.SetActive(true);
        SubCookFoodObj[3].gameObject.GetComponent<Image>().sprite = ClickedFoodImage;
        StartCoroutine("Cooked4");
    }


    IEnumerator Cooked1()
    {
        yield return new WaitForSeconds(10.0f);
        GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = SpriteSave[0];
        MadeItem.Add(ItemName1);
        SubCookFoodObj[0].gameObject.SetActive(false);
        Timer1 = Timer_Max;
        TimerStart1 = false;
        r1Check = true;
    }
    IEnumerator Cooked2()
    {
        yield return new WaitForSeconds(10.0f);
        MadeItem.Add(ItemName2);
        SubCookFoodObj[1].gameObject.SetActive(false);
        Timer2 = Timer_Max;
        TimerStart2 = false;
        r2Check = true;
    }
    IEnumerator Cooked3()
    {
        yield return new WaitForSeconds(10.0f);
        MadeItem.Add(ItemName3);
        SubCookFoodObj[2].gameObject.SetActive(false);
        Timer3 = Timer_Max;
        TimerStart3 = false;
        r3Check = true;
    }
    IEnumerator Cooked4()
    {
        yield return new WaitForSeconds(10.0f);
        MadeItem.Add(ItemName4);
        SubCookFoodObj[3].gameObject.SetActive(false);
        Timer4 = Timer_Max;
        TimerStart4 = false;
        r4Check = true;
    }
}


