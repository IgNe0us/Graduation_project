using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Mushroom : MonoBehaviour
{
    //스파인 애니메이션을 위한 것
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    //애니메이션을 위한 이넘
    public enum AnimState
    {
        Shoot, Disappear, Death
    }

    //현재 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;

    //현재 어떤 애니메이션이 재생 되고 있는지에 대한 변수
    private string CurrentAnimation;

    // 발사체 위치 관련
    public Transform posR;
    public Transform posL;
    //체력관련
    public int hp;
    //드랍 확율
    public int drop_Percentage;

    //히트관련
    CircleCollider2D circleCollider;
    public Rigidbody2D rig;
    bool isHit = false;
    bool isknockback;

    //데미지
    public int damage;
    bool Died = false;

    //오디오 관련
    AudioSource audioSource;
    public AudioClip damaged;

    //발사체 공격관련
    public GameObject bulletL;
    public GameObject bulletR;
    public bool LRCheck;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        isknockback = false;
    }
    private void Start()
    {
        StartCoroutine(Attack());
        if (LRCheck == true)
        {
            skeletonAnimation.Skeleton.ScaleX = -1;
        }
    }

    private void Update()
    {
        SetCurrentAnimation(_AnimState);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.57f);
        if(LRCheck == true)
        {
            //왼쪽이면 발사체 왼쪽으로 위치 변경
            Instantiate(bulletL, posL.position, transform.rotation);
        }
        else
        {
            Instantiate(bulletR, posR.position, transform.rotation);
        }
        StartCoroutine(Attack());
    }
    IEnumerator AnimReturn()
    {
        if (Died == false)
        {
            yield return new WaitForSeconds(0.5f);
            _AnimState = AnimState.Shoot;
            skeletonAnimation.skeleton.SetColor(Color.white);
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
            case AnimState.Shoot:
                _AsncAnimation(AnimClip[(int)AnimState.Shoot], true, 0.63f);
                break;
            case AnimState.Disappear:
                _AsncAnimation(AnimClip[(int)AnimState.Disappear], false, 1f);
                break;
            case AnimState.Death:
                _AsncAnimation(AnimClip[(int)AnimState.Death], false, 1f);
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
        }
        audioSource.Play();
    }
    public void TakeDamage(int damage)
    {
        if (!isHit)
        {
            hp -= damage;
            PlaySound("DAMAGED");
            player = GameObject.Find("Player").GetComponent<Player>();
            _AnimState = AnimState.Death;
            skeletonAnimation.skeleton.SetColor(Color.red);
            StartCoroutine("AnimReturn");
            FindObjectOfType<HitStop>().Stop(0.07f);
            StartCoroutine(HitRoutine());
            Die();
        }
    }
    IEnumerator HitRoutine()
    {
        yield return new WaitForSeconds(1f);
        isHit = false;

    }

    Player player;
    /*private void Die()
    {
        if (hp <= 0)
        {
            _AnimState = AnimState.Disappear;
            player = GameObject.Find("Player").GetComponent<Player>();
            player.money += Random.Range(30, 50);
            if (Random.Range(1, 100) <= drop_Percentage)
            {
                ItemDatabase.instance.ItemDrop(gameObject.transform.position, 9);
            }
            Destroy(gameObject);
        }
    }*/
    private void Die()
    {
        if (hp <= 0)
        {
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
            _AnimState = AnimState.Disappear;
            Died = true;
            gameObject.tag = "Died";
            Invoke("Death", 0.5f);
        }
    }
    private void Death()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.money += Random.Range(30, 50); //돈 30~ 50 원 사이로 지급
        if (Random.Range(1, 100) <= drop_Percentage)
        {
            ItemDatabase.instance.ItemDrop(gameObject.transform.position, 9);
        }
        Destroy(gameObject);
    }


}
