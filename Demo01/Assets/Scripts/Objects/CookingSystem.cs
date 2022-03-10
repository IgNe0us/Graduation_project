using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CookingSystem : MonoBehaviour
{
    public GameObject cookSystemManagement;
    public bool cookingSystemOnOff = false;
    public TextMeshProUGUI cookingDay;
    public TextMeshProUGUI cookingTimer;
    public Button operation_StartBtn;
    public Slider CookingGagebar;
    
    int day = 0;
    float timer_sec;
    float timer_min;
    float timer = 299; // 타이머 게이지 확인용
    float timer_Max = 299; // 타이머 게이지 확인용
    bool timerOn = false;
    private void Start()
    {
        cookSystemManagement.SetActive(cookingSystemOnOff);
        SceneManager.sceneLoaded += LoadedsceneEvent;
        cookingDay.text = "운영 0일 째";
        cookingTimer.text = "0:0";
    }
    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Restaurant")
        {
            cookSystemManagement.SetActive(false);
        }
    }
    void Update()
    {
        //타이머 게이지 구현
        CookingGagebar.value = Mathf.Lerp(CookingGagebar.value, timer / timer_Max , Time.deltaTime * 5f);
        //마우스의 위치를 받음
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //레이히트로 마우스의 위치에서 vector2.zero의 방향으로 쏴주는 것으로 만듬
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        //만약 레이 히트가 null 이 아니면
        if (rayhit.collider != null)
        {
            //그 콜라이더랑 충돌했고 마우스 클릭을했을 때 실행
            if (rayhit.collider.tag == "Brazier" && Input.GetMouseButtonDown(0))
            {
                cookingSystemOnOff = !cookingSystemOnOff;
                cookSystemManagement.SetActive(cookingSystemOnOff);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                cookSystemManagement.SetActive(false);
            }
        }

        if (timerOn)
        {
            Operation_Start();
        }

    }

    //운영 시작 버튼 구현 TimerOn 누르면 Operation_Start 시작.
    void Operation_Start()
    {
        timer_sec -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer_sec <= 0)
        {
            timer_sec = 59;
            timer_min -= 1;
        }
        else if (timer_min <= -1)
        {
            timer_min = 0;
            timer_sec = 0;
            timer = 299;
            timerOn = false;
            operation_StartBtn.interactable = true;
        }
        cookingDay.text = "운영 " + day.ToString() + "일 째";
        cookingTimer.text = timer_min + ":" + Mathf.Round(timer_sec).ToString();
    }
    public void TimerOn()
    {
        timer = 299;
        timer_sec = 59;
        timer_min = 4;
        timerOn = true;
        day++;
        operation_StartBtn.interactable = false;
    }

}
