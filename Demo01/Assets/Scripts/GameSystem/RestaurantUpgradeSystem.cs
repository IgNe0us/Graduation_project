using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantUpgradeSystem : MonoBehaviour
{
    // 레스토랑 메뉴판 오브젝트들
    public GameObject Lv2_Unlock_Obj;
    public GameObject Lv2_Buy_Obj;
    public GameObject Lv2_final_Obj;
    public GameObject Lv3_Unlock_Obj;
    public GameObject Lv3_Buy_Obj;
    public GameObject Lv3_final_Obj;

    //------------변경 구매 의사 물어보는 이미지----------//
    public GameObject Lv1_C;
    public GameObject Lv2_C;
    public GameObject Lv3_C;
    public GameObject Lv2_B;
    public GameObject Lv3_B;

    // 분기점 업데이트
    public int RestaurantLevel;
    public int StackRestaurantLevel = 1;
    public bool SelectedRestaurant1;
    public bool SelectedRestaurant2;
    public bool SelectedRestaurant3;
    public bool InRestaurant;

    // 프리뷰 중인지 체크
    bool PreviewCheck;

    private void Awake()
    {
        InRestaurant = false;
        PreviewCheck = false;
        SelectedRestaurant1 = true;
        SelectedRestaurant2 = false;
        SelectedRestaurant3 = false;
    }

    private void Update()
    {
        if(!PreviewCheck && InRestaurant)
        {
            LevelCheck();
        }
        

        // 레스토랑 분기점 업데이트 시 알아서 구매 화면으로 바뀔 수 있게 설정.
        if (RestaurantLevel == 2)
        {
            Lv2_Unlock_Obj.SetActive(false);
            Lv2_Buy_Obj.SetActive(true);
        }
        else if (RestaurantLevel == 3)
        {
            Lv3_Unlock_Obj.SetActive(false);
            Lv3_Buy_Obj.SetActive(true);
        }

    }

    void LevelCheck()
    {
        if(RestaurantLevel >= 1 && SelectedRestaurant1 == true)
        {
            GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(false);
        }
        else if(RestaurantLevel >= 2 && SelectedRestaurant2 == true)
        {
            GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(false);
        }
        else if(RestaurantLevel == 3 && SelectedRestaurant3 == true)
        {
            GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void EndPreview()
    {
        PreviewCheck = false;
    }


    public void Lv1_Preview()
    {
        PreviewCheck = true;
        GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(false);
        Invoke("EndPreview", 5f);
    }
    public void Lv1_Apply()
    {
        Lv1_C.SetActive(true); // 레스토랑 외관 변경할거냐고 묻는 창 띄움.
    }
    public void Lv1_C_Yes_Button()
    {
        GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(2).gameObject.SetActive(false);
        SelectedRestaurant1 = true;
        SelectedRestaurant2 = false;
        SelectedRestaurant3 = false;
        Lv1_C.SetActive(false); // 묻는 창 종료
    }
    public void Lv1_C_No_Button()
    {
        Lv1_C.SetActive(false); // 묻는 창 종료
    }
    public void Lv2_Preview()
    {
        PreviewCheck = true;
        GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(false);
        Invoke("EndPreview", 5f);
    }
    public void Lv2_Buy()
    {
        Lv2_B.SetActive(true); // 레스토랑 구매 할 거냐고 묻는 창 띄움.
    }
    public void Lv2_B_Yes_Button()
    {
        // Lv2_Buy 를 종료하고 Lv2_Final을 킴 그리고 Lv2 외관 내관을 적용 그리고 돈을 지불할 코드 작성.
        if(GameObject.Find("Player").GetComponent<Player>().money >= 7000)
        {
            Lv2_Buy_Obj.SetActive(false);
            Lv2_final_Obj.SetActive(true);
            GameObject.Find("Player").GetComponent<Player>().money -= 7000;
            Lv2_B.SetActive(false); // 묻는 창 종료
            StackRestaurantLevel = 2;
        }
        Lv2_B.SetActive(false); // 묻는 창 종료
    }
    public void Lv2_B_No_Button()
    {
        Lv2_B.SetActive(false); // 묻는 창 종료
    }

    public void Lv2_Apply()
    {
        Lv2_C.SetActive(true); // 레스토랑 외관 변경할거냐고 묻는 창 띄움.
    }
    public void Lv2_C_Yes_Button()
    {
        GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(2).gameObject.SetActive(false);
        SelectedRestaurant1 = false;
        SelectedRestaurant2 = true;
        SelectedRestaurant3 = false;
        Lv2_C.SetActive(false); // 묻는 창 종료
    }
    public void Lv2_C_No_Button()
    {
        Lv2_C.SetActive(false); // 묻는 창 종료
    }
    public void Lv3_Preview()
    {
        PreviewCheck = true;
        GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(true);
        Invoke("EndPreview", 5f);
    }
    public void Lv3_Buy()
    {
        Lv3_B.SetActive(true); // 레스토랑 구매 할 거냐고 묻는 창 띄움.
    }
    public void Lv3_B_Yes_Button()
    {
        // Lv3_Buy 를 종료하고 Lv3_Final을 킴 그리고 Lv3 외관 내관을 적용 그리고 돈을 지불할 코드 작성.
        if (GameObject.Find("Player").GetComponent<Player>().money >= 50000)
        {
            Lv3_Buy_Obj.SetActive(false);
            Lv3_final_Obj.SetActive(true);
            GameObject.Find("Player").GetComponent<Player>().money -= 50000;
            Lv3_B.SetActive(false); // 묻는 창 종료
            StackRestaurantLevel = 3;
        }
        Lv3_B.SetActive(false); // 묻는 창 종료
    }
    public void Lv3_B_No_Button()
    {
        Lv3_B.SetActive(false); // 묻는 창 종료
    }
    public void Lv3_Apply()
    {
        Lv3_C.SetActive(true); // 레스토랑 외관 변경할거냐고 묻는 창 띄움.
    }
    public void Lv3_C_Yes_Button()
    {
        GameObject.Find("Switch").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Switch").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("RestaurantO_BackGround").transform.GetChild(2).gameObject.SetActive(true);
        SelectedRestaurant1 = false;
        SelectedRestaurant2 = false;
        SelectedRestaurant3 = true;
        Lv3_C.SetActive(false); // 레스토랑 외관 변경할거냐고 묻는 창 띄움.
    }
    public void Lv3_C_No_Button()
    {
        Lv3_B.SetActive(false); // 묻는 창 종료
    }







}
