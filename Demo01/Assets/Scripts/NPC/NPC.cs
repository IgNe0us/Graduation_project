using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class NPC : MonoBehaviour
{
    bool Move;
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;
    public string TableName;
    public int moveSpeed;
    public Sprite[] Food;
    public string[] FoodName;
    public string CurFoodName;
    int RandomFoodIdx;
    bool ColliderCheck;
    public AudioClip Clearserving;
    public AudioClip Failserving;
    AudioSource ServingSound;

    int RestaurantLevelCheck;

    public enum AnimState
    {
        Idle, Walk
    }

    private AnimState _AnimState;
    private string CurrentAnimation;

    void Start()
    {
        ColliderCheck = false;
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        ServingSound = GetComponent<AudioSource>();
        Move = true;
        _AnimState = AnimState.Walk;
        RestaurantLevelCheck = GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel;
    }

    private void Update()
    {
        SetCurrentAnimation(_AnimState);
        if (Move)
        {
            gameObject.transform.position -= new Vector3(Time.deltaTime * moveSpeed, 0, 0);
        }

        // NPC 충돌 체크
        if(ColliderCheck)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.Count == 0)
                {
                    PlaySound("Fail");
                }
                else
                {
                    if (CurFoodName == GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem[0])
                    {
                        if (GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel == 1)
                        {
                            if (CurFoodName == "Omelet")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 50;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "Salad")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 120;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "CornSoup")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 250;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "PanCake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 320;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledLopster")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 270;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SquidSpaghetti")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 350;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SteamedSharkfin")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 170;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "TunaStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 150;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledShrimp")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 210;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledBird")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 450;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SheepStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 280;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "PorkChop")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 480;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledLizardTail")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 250;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "DragonStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 800;
                                PlaySound("Clear");
                            }
                            GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                            GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                            if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                            {
                                GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            }
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                            CancelInvoke("ThinkFood1");
                            InvokeRepeating("ThinkFood1", 0f, 20.0f);
                        }
                        else if (GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel == 2)
                        {
                            if (CurFoodName == "Omelet")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 70;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "Salad")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 140;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "CornSoup")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 270;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "PanCake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 340;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledLopster")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 290;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SquidSpaghetti")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 370;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SteamedSharkfin")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 190;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "TunaStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 170;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledShrimp")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 230;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledBird")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 470;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SheepStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 300;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "PorkChop")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 500;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledLizardTail")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 270;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "DragonStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 820;
                                PlaySound("Clear");
                            }
                            GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                            GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                            if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                            {
                                GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            }
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                            CancelInvoke("ThinkFood2");
                            InvokeRepeating("ThinkFood2", 0f, 20.0f);
                        }
                        else if (GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel == 3)
                        {
                            if (CurFoodName == "Omelet")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 100;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "Salad")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 170;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "CornSoup")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 300;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "PanCake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 370;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledLopster")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 320;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SquidSpaghetti")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 400;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SteamedSharkfin")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 220;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "TunaStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 200;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledShrimp")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 260;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledBird")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 500;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "SheepStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 330;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "PorkChop")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 530;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "GrilledLizardTail")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 300;
                                PlaySound("Clear");
                            }
                            else if (CurFoodName == "DragonStake")
                            {
                                GameObject.Find("Player").GetComponent<Player>().money += 850;
                                PlaySound("Clear");
                            }
                            GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                            GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                            if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                            {
                                GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            }
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                            CancelInvoke("ThinkFood3");
                            InvokeRepeating("ThinkFood3", 0f, 20.0f);
                        }
                    }
                    else
                    {
                        Debug.Log("음식이 같지 않습니다");
                        PlaySound("Fail");
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                        if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                        {
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                        }
                        GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                    }
                }
                
            }
        }
    }

    void ThinkFood1()
    {
        RandomFoodIdx = Random.Range(0, 4);  // 0 - 14
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Food[RandomFoodIdx];
        CurFoodName = FoodName[RandomFoodIdx];
    }
    void ThinkFood2()
    {
        RandomFoodIdx = Random.Range(0, 10);  // 0 - 14
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Food[RandomFoodIdx];
        CurFoodName = FoodName[RandomFoodIdx];
    }
    void ThinkFood3()
    {
        RandomFoodIdx = Random.Range(0, 14);  // 0 - 14
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Food[RandomFoodIdx];
        CurFoodName = FoodName[RandomFoodIdx];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColliderCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ColliderCheck = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == TableName)
        {
            Move = false;
            StartCoroutine("AnimReturn");
            if (RestaurantLevelCheck == 1)
            {
                InvokeRepeating("ThinkFood1", 0f, 20.0f);
            }
            else if (RestaurantLevelCheck == 2)
            {
                InvokeRepeating("ThinkFood2", 0f, 20.0f);
            }
            else if (RestaurantLevelCheck == 2)
            {
                InvokeRepeating("ThinkFood3", 0f, 20.0f);
            }
        }
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "Clear":
                ServingSound.clip = Clearserving;
                break;
            case "Fail":
                ServingSound.clip = Failserving;
                break;
            case "STOP":
                ServingSound.Stop();
                break;
        }
        ServingSound.Play();
    }

    IEnumerator AnimReturn()
    {
        yield return new WaitForSeconds(0.1f);
        _AnimState = AnimState.Idle;
    }

    //애니메이션 적용                                    클립         / 루프      / 애니메이션 속도
    private void _AsncAnimation(AnimationReferenceAsset animClip, bool loop, float timeScale)
    {
        //동일한 애니메이션을 재생하려고 한다면 아래 코드 구문 실행 X
        if (animClip.name.Equals(CurrentAnimation))
        {
            return;
        }

        //해당 애니메이션으로 변경한다.
        skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = timeScale;
        skeletonAnimation.loop = loop;
        skeletonAnimation.timeScale = timeScale;



        //현재 재생되고 있는 애니메이션 값을 변경
        CurrentAnimation = animClip.name;

    }

    private void SetCurrentAnimation(AnimState _State)
    {
        switch (_State)
        {
            case AnimState.Idle:
                _AsncAnimation(AnimClip[(int)AnimState.Idle], true, 1f);
                break;
            case AnimState.Walk:
                _AsncAnimation(AnimClip[(int)AnimState.Walk], true, 1f);
                break;
        }
    }

}

