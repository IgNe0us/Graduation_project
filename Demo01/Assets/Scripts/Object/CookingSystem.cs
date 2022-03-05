using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingSystem : MonoBehaviour
{
    public GameObject cookSystemManagement;
    public bool cookingSystemOnOff = false;
    private void Start()
    {
        cookSystemManagement.SetActive(cookingSystemOnOff);
        SceneManager.sceneLoaded += LoadedsceneEvent;
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
    }
}
