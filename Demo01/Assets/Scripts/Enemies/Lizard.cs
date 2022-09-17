using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Lizard : MonoBehaviour
{
    //드랍 확율관련
    public int drop_Percentage;
    //스파인 애니메이션을 위한 것
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    //애니메이션을 위한 이넘
    public enum AnimState
    {
        Idle, Disappear, Death
    }

    //현재 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;

    //현재 어떤 애니메이션이 재생 되고 있는지에 대한 변수
    private string CurrentAnimation;

    //무브처리
    public Rigidbody2D rig;
    private int nextMove;
    float nextThinkTime;
    private int transformChange;

    //체력관련
    public int hp = 100;

    //히트관련
    //public BoxCollider2D boxCollider2d;
    bool isHit = false;
    bool isknockback;
    bool isHitting = false;

    //데미지
    BoxCollider2D boxCollider;
    public int damage;
    private bool Died = false;

    //오디오 관련
    AudioSource audioSource;
    public AudioClip damaged;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        boxCollider = GetComponent<BoxCollider2D>();
        nextThinkTime = Random.Range(2f, 6f);
        TransformChange();
        Think();
        isknockback = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SetCurrentAnimation(_AnimState);
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(nextMove, rig.velocity.y);

        Vector2 frontVec = new Vector2(rig.position.x + nextMove * 0.5f, rig.position.y);
        Debug.DrawRay(frontVec, Vector3.down * 1, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1.5f, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    void TransformChange()
    {
        transformChange = Random.Range(0, 2);
        Invoke("TransformChange", nextThinkTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                nextMove = 1;
                transform.localScale = new Vector2(nextMove * 0.9f, 0.9f);
            }
            else
            {
                nextMove = -1;
                transform.localScale = new Vector2(nextMove * 0.9f, 0.9f);
            }
            //_AnimState = AnimState.Attack;
            StartCoroutine("AnimReturn");
        }
    }

    IEnumerator AnimReturn()
    {
        yield return new WaitForSeconds(0.5f);
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
            isHitting = true;
            _AnimState = AnimState.Death;
            skeletonAnimation.skeleton.SetColor(Color.red);
            FindObjectOfType<HitStop>().Stop(0.07f);
            Invoke("HitEnd", 0.5f);

            float x = transform.position.x - player.transform.position.x;
            if (x < 0)
                x = 1;
            else
            {
                x = -1;
            }
            StartCoroutine(HitRoutine());
            if (hp > 10) //죽을 직전 마지막 타격 때 넉백 안함
            {
                StartCoroutine(Knockback(x));
            }
            Die();
        }
    }

    void HitEnd()
    {
        isHitting = false;
    }

    IEnumerator HitRoutine()
    {
        yield return new WaitForSeconds(1f);
        isHit = false;

    }

    IEnumerator Knockback(float dir)
    {
        isknockback = true;
        float Hitpower = 8;
        float ctime = 0;
        while (ctime < 0.2f)
        {
            if (transform.rotation.y == 0)
                transform.Translate(Vector2.left * Hitpower * Time.deltaTime * dir);
            else
                transform.Translate(Vector2.left * Hitpower * Time.deltaTime * -1f * dir);

            ctime += Time.deltaTime;
            yield return null;
        }
        isknockback = false;
    }


    void Turn()
    {
        nextMove = nextMove * -1;

        CancelInvoke();
        Invoke("Think", nextThinkTime);
    }

    void Move()
    {
        if ((Died == false) && (isHitting == false)) //(_AnimState != AnimState.Attack) && (Died == false) && (isHitting == false)
        {
            skeletonAnimation.skeleton.SetColor(Color.white);
            if (nextMove == 0f)
            {
                _AnimState = AnimState.Idle;
            }
            else
            {
                _AnimState = AnimState.Idle;
                transform.localScale = new Vector2(nextMove * 0.9f, 0.9f);
            }
        }

    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", nextThinkTime);
    }


    Player player;
    private void Die()
    {
        if (hp <= 0)
        {
            Died = true;
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
            _AnimState = AnimState.Disappear;
            gameObject.tag = "Died";
            Invoke("Death", 0.5f);
        }
    }
    private void Death()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        ItemDatabase.instance.ItemDrop(gameObject.transform.position, 4);
        Destroy(gameObject);
    }
}
