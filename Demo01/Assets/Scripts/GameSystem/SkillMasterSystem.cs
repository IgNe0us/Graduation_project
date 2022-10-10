using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMasterSystem : MonoBehaviour
{
    public GameObject Sword1;
    public GameObject Sword2;
    public GameObject Sword3;

    public Text abilityText;
    public Text GoldText;
    public Text PlayerMoney;
    public Text ChatText;

    public GameObject UpGradeOn;
    public GameObject UpGradeOff;
    public GameObject CoinImage;


    bool Upgrade_Check1 = true;
    bool Upgrade_Check2 = false;
    bool Upgrade_Check3 = false;
    bool Upgrade_On_Check = true;
    bool Upgrade_Off_Check = false;
    bool UpGradeComplete = false;



    private void Update()
    {
        Sword1.SetActive(Upgrade_Check1);
        Sword2.SetActive(Upgrade_Check2);
        Sword3.SetActive(Upgrade_Check3);
        PlayerMoney.text = GameObject.Find("Player").GetComponent<Player>().money.ToString();

        if (UpGradeComplete == false)
        {
            UpGradeOn.SetActive(Upgrade_On_Check);
            UpGradeOff.SetActive(Upgrade_Off_Check);
        }

        if (Upgrade_Check1 == true)
        {
            if((GameObject.Find("Player").GetComponent<Player>().money >= 2500))
            {
                Upgrade_On_Check = true;
                Upgrade_Off_Check = false;
            }
            else
            {
                Upgrade_On_Check = false;
                Upgrade_Off_Check = true;
            }
        }
        else if(Upgrade_Check2 == true)
        {
            if ((GameObject.Find("Player").GetComponent<Player>().money >= 10000))
            {
                Upgrade_On_Check = true;
                Upgrade_Off_Check = false;
            }
            else
            {
                Upgrade_On_Check = false;
                Upgrade_Off_Check = true;
            }
        }
        else if (Upgrade_Check3 == true && UpGradeComplete == false)
        {
            if ((GameObject.Find("Player").GetComponent<Player>().money >= 20000))
            {
                Upgrade_On_Check = true;
                Upgrade_Off_Check = false;
            }
            else
            {
                Upgrade_On_Check = false;
                Upgrade_Off_Check = true;
            }
        }
        else if (Upgrade_Check3 == true && UpGradeComplete == true)
        {
            UpGradeOn.SetActive(false);
            UpGradeOff.SetActive(true);
        }


    }

    public void UpGrade()
    {
        if(Upgrade_Check1 == true)
        {
            if (GameObject.Find("Player").GetComponent<Player>().money >= 2500)
            {
                GameObject.Find("Player").GetComponent<Player>().damage += 5;
                GameObject.Find("Player").GetComponent<Player>().maxHp += 8;
                GameObject.Find("Player").GetComponent<Player>().curHp += 8;
                GameObject.Find("Player").GetComponent<Player>().money -= 2500;
                Upgrade_Check1 = false;
                Upgrade_Check2 = true;
                abilityText.text = "공격력\n15 -> 25 \n하트\n4 -> 7";
                GoldText.text = "필요골드 : 10000G";
            }
        }
        else if(Upgrade_Check2 == true)
        {
            if(GameObject.Find("Player").GetComponent<Player>().money >= 10000)
            {
                GameObject.Find("Player").GetComponent<Player>().damage += 10;
                GameObject.Find("Player").GetComponent<Player>().maxHp += 12;
                GameObject.Find("Player").GetComponent<Player>().curHp += 12;
                GameObject.Find("Player").GetComponent<Player>().money -= 10000;
                GameObject.Find("MapControl").gameObject.transform.GetChild(0).gameObject.GetComponent<MapChoice>().VolcanoOn = true;
                Upgrade_Check2 = false;
                Upgrade_Check3 = true;
                abilityText.text = "공격력\n25 -> 40 \n하트\n7 -> 10";
                GoldText.text = "필요골드 : 20000G";
            }
        }
        else if(Upgrade_Check3 == true)
        {
            if (GameObject.Find("Player").GetComponent<Player>().money >= 20000)
            {
                GameObject.Find("Player").GetComponent<Player>().damage += 15;
                GameObject.Find("Player").GetComponent<Player>().maxHp += 12;
                GameObject.Find("Player").GetComponent<Player>().curHp += 12;
                GameObject.Find("Player").GetComponent<Player>().money -= 20000;
                GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel = 3;
                GameObject.Find("Player").GetComponent<Player>().foodLevelCheck = 3;
                UpGradeComplete = true;
                abilityText.text = "현재공격력\n40\n현재하트\n10";
                GoldText.text = "";
                ChatText.text = "더 이상 강화를 할 수 없어!";
                CoinImage.SetActive(false);

            }
        }
    }

}
