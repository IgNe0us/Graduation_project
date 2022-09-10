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
        Move = true;
        _AnimState = AnimState.Walk;
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
                Debug.Log("1");
                if (CurFoodName == GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem[0])
                {
                    if (GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel == 1)
                    {
                        if (CurFoodName == "Omelet")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 50;
                        }
                        else if (CurFoodName == "Salad")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 120;

                        }
                        else if (CurFoodName == "CornSoup")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 250;
                        }
                        else if (CurFoodName == "PanCake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 320;
                        }
                        else if (CurFoodName == "GrilledLopster")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 270;
                        }
                        else if (CurFoodName == "SquidSpaghetti")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 350;
                        }
                        else if (CurFoodName == "SteamedSharkfin")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 170;
                        }
                        else if (CurFoodName == "TunaStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 150;
                        }
                        else if (CurFoodName == "GrilledShrimp")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 210;
                        }
                        else if (CurFoodName == "GrilledBird")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 450;
                        }
                        else if (CurFoodName == "SheepStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 280;
                        }
                        else if (CurFoodName == "PorkChop")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 480;
                        }
                        else if (CurFoodName == "GrilledLizardTail")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 250;
                        }
                        else if (CurFoodName == "DragonStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 800;
                        }
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                        if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                        {
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                        }
                        GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                        CancelInvoke("ThinkFood");
                        InvokeRepeating("ThinkFood", 0f, 20.0f);
                    }
                    else if (GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel == 2)
                    {
                        if (CurFoodName == "Omelet")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 70;
                        }
                        else if (CurFoodName == "Salad")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 140;

                        }
                        else if (CurFoodName == "CornSoup")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 270;
                        }
                        else if (CurFoodName == "PanCake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 340;
                        }
                        else if (CurFoodName == "GrilledLopster")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 290;
                        }
                        else if (CurFoodName == "SquidSpaghetti")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 370;
                        }
                        else if (CurFoodName == "SteamedSharkfin")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 190;
                        }
                        else if (CurFoodName == "TunaStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 170;
                        }
                        else if (CurFoodName == "GrilledShrimp")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 230;
                        }
                        else if (CurFoodName == "GrilledBird")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 470;
                        }
                        else if (CurFoodName == "SheepStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 300;
                        }
                        else if (CurFoodName == "PorkChop")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 500;
                        }
                        else if (CurFoodName == "GrilledLizardTail")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 270;
                        }
                        else if (CurFoodName == "DragonStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 820;
                        }
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                        if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                        {
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                        }
                        GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                        CancelInvoke("ThinkFood");
                        InvokeRepeating("ThinkFood", 0f, 20.0f);
                    }
                    else if (GameObject.Find("RestaurantUpgradeManual").GetComponent<RestaurantUpgradeSystem>().RestaurantLevel == 3)
                    {
                        if (CurFoodName == "Omelet")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 100;
                        }
                        else if (CurFoodName == "Salad")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 170;
                        }
                        else if (CurFoodName == "CornSoup")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 300;
                        }
                        else if (CurFoodName == "PanCake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 370;
                        }
                        else if (CurFoodName == "GrilledLopster")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 320;
                        }
                        else if (CurFoodName == "SquidSpaghetti")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 400;
                        }
                        else if (CurFoodName == "SteamedSharkfin")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 220;
                        }
                        else if (CurFoodName == "TunaStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 200;
                        }
                        else if (CurFoodName == "GrilledShrimp")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 260;
                        }
                        else if (CurFoodName == "GrilledBird")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 500;
                        }
                        else if (CurFoodName == "SheepStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 330;
                        }
                        else if (CurFoodName == "PorkChop")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 530;
                        }
                        else if (CurFoodName == "GrilledLizardTail")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 300;
                        }
                        else if (CurFoodName == "DragonStake")
                        {
                            GameObject.Find("Player").GetComponent<Player>().money += 850;
                        }
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().MadeItem.RemoveAt(0);
                        GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.RemoveAt(0);
                        if (GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave.Count == 0)
                        {
                            GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                        }
                        GameObject.Find("Player").gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("SubCooknote").GetComponent<SubCookNote>().SpriteSave[0];
                        CancelInvoke("ThinkFood");
                        InvokeRepeating("ThinkFood", 0f, 20.0f);
                    }
                }
                else
                {
                    Debug.Log("음식이 같지 않습니다");
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

    void ThinkFood()
    {
        RandomFoodIdx = Random.Range(0, 2);  // 0 - 14
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
            InvokeRepeating("ThinkFood", 0f, 20.0f);
        }
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

