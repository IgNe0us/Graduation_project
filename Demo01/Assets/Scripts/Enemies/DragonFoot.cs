using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class DragonFoot : MonoBehaviour
{
    //드랍 확율관련
    public int drop_Percentage;
    //스파인 애니메이션을 위한 것
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    //애니메이션을 위한 이넘
    public enum AnimState
    {
        ATTACK, SMASH
    }

    //현재 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;

    //현재 어떤 애니메이션이 재생 되고 있는지에 대한 변수
    private string CurrentAnimation;

    //애니메이션 변경처리
    int iPrevTransform;
    private int transformChange;

    //히트관련
    Rigidbody2D rig;
    bool isHit = false;

    //데미지
    public int damage;

    //오디오 관련
    AudioSource audioSource;
    public AudioClip damaged;
    public AudioClip aAttack;
    public AudioClip aSmash;

    // 스킬 관련
    float fcoolTime = 0f;
    float nextThinkTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rig = GetComponent<Rigidbody2D>();
        transformChange = Random.Range(0, 3);
        TransformChange();
    }
    // Update is called once per frame
    void Update()
    {
        SetCurrentAnimation(_AnimState);
    }

    void TransformChange()
    {
        nextThinkTime = Random.Range(4f, 6f);
        iPrevTransform = transformChange;
        transformChange = Random.Range(0, 2);
        if (transformChange == iPrevTransform)
        {
            if (transformChange == 0)
            {
                transformChange += 1;
            }
            else if (transformChange == 1)
            {
                transformChange -= 1;
            }
            else
            {
                transformChange -= 1;
            }
        }
        Invoke("TransformChange", nextThinkTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _AnimState = AnimState.ATTACK;
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
            case AnimState.ATTACK:
                _AsncAnimation(AnimClip[(int)AnimState.ATTACK], false, 1f);
                break;
            case AnimState.SMASH:
                _AsncAnimation(AnimClip[(int)AnimState.SMASH], false, 1f);
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
            case "ATTACK":
                audioSource.clip = aAttack;
                break;
            case "SMASH":
                audioSource.clip = aSmash;
                break;
        }
        audioSource.Play();
    }

    public void TakeDamage(int damage)
    {
        if (!isHit)
        {
            isHit = true;
            gameObject.GetComponentInParent<Dragon>().hp -= damage;
            PlaySound("DAMAGED");
            //_AnimState = AnimState.Death;
            skeletonAnimation.skeleton.SetColor(Color.red);
            FindObjectOfType<HitStop>().Stop(0.07f);
            Invoke("HitEnd", 0.5f);
        }
    }

    void HitEnd()
    {
        isHit = false;
    }

}
