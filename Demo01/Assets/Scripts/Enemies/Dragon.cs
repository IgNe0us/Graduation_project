using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Dragon : MonoBehaviour
{
    //드랍 확율관련
    public int drop_Percentage;
    //스파인 애니메이션을 위한 것
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    //애니메이션을 위한 이넘
    public enum AnimState
    {
        BREATH, LIGHT, ROAR , IDLE
    }

    //현재 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;

    //현재 어떤 애니메이션이 재생 되고 있는지에 대한 변수
    private string CurrentAnimation;

    //애니메이션 변경처리
    int iPrevTransform;
    private int transformChange = 2;

    //체력관련
    public int hp = 500;

    //히트관련
    Rigidbody2D rig;
    bool isHit = false;

    //데미지
    public int damage;

    //오디오 관련
    AudioSource audioSource;
    public AudioClip damaged;
    public AudioClip aBrath;
    public AudioClip aLight;
    public AudioClip aRoar;

    public GameObject Lightning;
    public GameObject[] Stone;
    public GameObject FireBallPos;
    public GameObject FireBall;

    // 스킬 관련
    float fcoolTime = 0f;
    float nextThinkTime;
    Transform LightningspawnPosition;

    GameObject player;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").gameObject;
        TransformChange();
    }
    // Update is called once per frame
    void Update()
    {
        //DragonPattern();
        SetCurrentAnimation(_AnimState);
    }

    void TransformChange()
    {
        nextThinkTime = Random.Range(4f, 6f);
        iPrevTransform = transformChange;
        transformChange = Random.Range(0, 3);
        switch (transformChange)
        {
            case 0:
                _AnimState = AnimState.BREATH;
                PlaySound("BRATH");

                break;
            case 1:
                _AnimState = AnimState.LIGHT;
                PlaySound("LIGHT");
                LightningspawnPosition = player.transform;
                Invoke("LightningAttack", 1.5f);
                break;
            case 2:
                _AnimState = AnimState.ROAR;
                PlaySound("ROAR");

                break;
        }
        Invoke("TransformChange", nextThinkTime);
    }

/*    void DragonPattern()
    {
        fcoolTime += Time.deltaTime;
        if (fcoolTime >= nextThinkTime)
        {
            fcoolTime = 0f;
            switch (transformChange)
            {
                case 0:
                    _AnimState = AnimState.BREATH;
                    PlaySound("BRATH");

                    break;
                case 1:
                    _AnimState = AnimState.LIGHT;
                    PlaySound("LIGHT");
                    LightningspawnPosition = player.transform;
                    Invoke("LightningAttack", 1.5f);
                    break;
                case 2:
                    _AnimState = AnimState.ROAR;
                    PlaySound("ROAR");

                    break;
            }
        }
    }*/

    void LightningAttack()
    {
        GameObject instance = Instantiate(Lightning, LightningspawnPosition.position, LightningspawnPosition.rotation);
        Destroy(instance, 0.5f);
    }
    void FireBallAttack()
    {

    }
    void RoarAttack()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 드래곤 발 오브젝트에서 공격모드로 변경
        }
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
            case AnimState.BREATH:
                _AsncAnimation(AnimClip[(int)AnimState.BREATH], false, 1f);
                break;
            case AnimState.LIGHT:
                _AsncAnimation(AnimClip[(int)AnimState.LIGHT], false, 1f);
                break;
            case AnimState.ROAR:
                _AsncAnimation(AnimClip[(int)AnimState.ROAR], false, 1f);
                break;
        }
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "DAMAGED":
                audioSource.clip = damaged;
                break;
            case "BRATH":
                audioSource.clip = aBrath;
                break;
            case "LIGHT":
                audioSource.clip = aLight;
                break;
            case "ROAR":
                audioSource.clip = aRoar;
                break;
        }
        audioSource.Play();
    }

    public void TakeDamage(int damage)
    {
        if (!isHit)
        {
            isHit = true;
            hp -= damage;
            PlaySound("DAMAGED");
            //_AnimState = AnimState.Death;
            skeletonAnimation.skeleton.SetColor(Color.red);
            FindObjectOfType<HitStop>().Stop(0.07f);
            Invoke("HitEnd", 0.5f);
            Die();
        }
    }

    void HitEnd()
    {
        isHit = false;
    }

    private void Die()
    {
        if (hp <= 0)
        {
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
            //_AnimState = AnimState.Disappear;
            gameObject.tag = "Died";
            Invoke("Death", 0.5f);
        }
    }
    private void Death()
    {
        ItemDatabase.instance.ItemDrop(gameObject.transform.position, 3);
        Destroy(gameObject);
    }


}