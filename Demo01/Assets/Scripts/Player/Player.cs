using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //이동 관련 점프 / 이동속도 /공격 딜레이 및 공격범위
    public float jumpPower;
    private float jumpCount;
    public float moveSpeed;
    private float playerMoveCheck;
    private bool isOnTheGround;
    public Transform attackPoint;
    public Vector2 attackSize;
    public int damage;
    bool isknockback;
    bool isHit;
    bool isSitting;

    // 돈 관련
    public int money;
    string moneyToString;
    TextMeshProUGUI moneyText;

    //HP , Energy 관련
    public Slider hpBar;
    public float maxHp;
    public float curHp;
    public Text hpTextBar;
    public Slider energyBar;
    public float maxEnergy;
    public float curEnergy;
    public Text energyTextBar;
    private bool energyDelay;

    //애니메이션 콤보관련
    public Animator _animator;

    //무브처리
    public Rigidbody2D rig;
    public bool leftRightCheck;
    bool isMoving;
    bool isLadder = false;
    CapsuleCollider2D capsuleCollider;

    //사운드 관련
    public AudioClip audioJump;
    public AudioClip audioAttack;
    public AudioClip audioAttack2;
    public AudioClip audioDamaged;
    public AudioClip audioThrow;
    public AudioClip audioJumpOnGround;
    public AudioClip[] audioForestWalk;
    public AudioClip[] audioStoneWalk;
    AudioSource audioSource;
    int randomWalkSound;

    //죽음 관련
    public GameObject Btn, DiePanel;

    //ESC키 관련
    public GameObject EscOption;
    bool trigger;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        leftRightCheck = true;
        trigger = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            isSitting = true;
        }
        else
        {
            isSitting = false;
        }
        moneyToString = money.ToString();
        moneyText.text = moneyToString; // 머니 텍스트 셋팅 "Money : " + moneyToString;


        //손때면 바로 멈추게
        if (Input.GetButtonUp("Horizontal"))
        { // 버튼에서 손을 때는 경우 
            // normalized : 벡터 크기를 1로 만든 상태 (단위벡터 : 크기가 1인 벡터)
            // 벡터는 방향과 크기를 동시에 가지는데 크기(- : 왼 , + : 오)를 구별하기 위하여 단위벡터(1,-1)로 방향을 알수 있도록 단위벡터를 곱함 
            rig.velocity = new Vector2(0.5f * rig.velocity.normalized.x, rig.velocity.y);
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            rig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //점프 구현
        Jump();

        //HP SP 관련
        HpSystem();

        //앉기 구현
        Sit();

        //뛰기 구현
        Run();

        //공격 애니메이션
        Attack();

        //무브 사운드 구현
        MoveSfx();

        if (!isSitting)
        {
            Move();
        }
        //죽음 구현 
        Die();

        //ESC 키 구현
        Esckey();

    }

    private void FixedUpdate()
    {
        if (!isSitting) {
            playerMoveCheck = Input.GetAxisRaw("Horizontal");
            _animator.SetFloat("move", Mathf.Abs(playerMoveCheck));
            rig.velocity = new Vector2(playerMoveCheck * moveSpeed * Time.deltaTime, rig.velocity.y);
        }
        

        if (rig.velocity.y < 0)
        {
            Debug.DrawRay(rig.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rig.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    if(jumpCount > 1)
                    {
                        PlaySound("JUMPONGROUND");
                    }
                    isOnTheGround = true;
                    jumpCount = 1;
                }
            }
        }

    }

    float MoveCurTime;
    float MoveCoolTime;

    void MoveSfx()
    {
        //걷는 소리 효과들
        //0.5f 는 걷는 소리 간격
        MoveCoolTime = 0.5f;
        if (MoveCurTime <= 0)
        {
            if ((rig.velocity.x != 0) && SceneManager.GetActiveScene().name == "Main") // 현재 캐릭터가 움직이고 있으면실행
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //0.3은 뛰는 소리간격
                    MoveCoolTime = 0.3f;
                }
                MoveCurTime = MoveCoolTime;
                //0,5의 소리를 랜덤하게 재생하여 동일하지않은 사운드를 출력하여 지루하지 않게함.
                randomWalkSound = Random.Range(0, 5);
                audioSource.PlayOneShot(audioStoneWalk[randomWalkSound]);
            }
            else if((rig.velocity.x != 0) && SceneManager.GetActiveScene().name == "Forest_1-1")
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //0.3은 뛰는 소리간격
                    MoveCoolTime = 0.3f;
                }
                MoveCurTime = MoveCoolTime;
                //0,4의 소리를 랜덤하게 재생하여 동일하지않은 사운드를 출력하여 지루하지 않게함.
                randomWalkSound = Random.Range(0, 4);
                audioSource.PlayOneShot(audioForestWalk[randomWalkSound]);
            }
        }
        else
        {
            MoveCurTime -= Time.deltaTime;
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(!isLadder)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                capsuleCollider.isTrigger = false;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(-0.65f, 0.65f, 1);
                //X값 스케일을 -1로 주어 좌우반전
                leftRightCheck = false;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                capsuleCollider.isTrigger = false;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(0.65f, 0.65f, 1);
                //X값 스케일을 1로 주어 다시 원위치 
                leftRightCheck = true;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") < 0 && isLadder == true)
            {
                moveVelocity = Vector3.down;
            }
            else if (Input.GetAxisRaw("Vertical") > 0 && isLadder == true)
            {
                moveVelocity = Vector3.up;
            }
        }
        
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;

    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP":
                audioSource.clip = audioJump;
                break;
            case "ATTACK1":
                audioSource.clip = audioAttack;
                break;
            case "ATTACK2":
                audioSource.clip = audioAttack2;
                break;
            case "DAMAGED":
                audioSource.clip = audioDamaged;
                break;
            case "THROW":
                audioSource.clip = audioThrow;
                break;
            case "JUMPONGROUND":
                audioSource.clip = audioJumpOnGround;
                break;
            case "STOP":
                audioSource.Stop();
                break;
        }
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Radish")
        {
            TakeDamage(20 , collision.gameObject);
            PlaySound("DAMAGED");
        }
        else if (collision.gameObject.tag == "Onion")
        {
            TakeDamage(25, collision.gameObject);
            PlaySound("DAMAGED");
        }
        else if (collision.gameObject.tag == "MushRoomBullet")
        {
            TakeDamage(30, collision.gameObject);
            PlaySound("DAMAGED");
        }
        else if (collision.gameObject.tag == "MushRoom")
        {
            TakeDamage(20, collision.gameObject);
            PlaySound("DAMAGED");
        }
        else if (collision.gameObject.tag == "Robster")
        {
            TakeDamage(40, collision.gameObject);
            PlaySound("DAMAGED");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder" && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("true");
            isLadder = true;
            _animator.Play("ladder");
            rig.gravityScale = 0f;
            capsuleCollider.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        Debug.Log("false");
        rig.gravityScale = 3.5f;
        capsuleCollider.isTrigger = false;
    }

    public void TakeDamage(int damage, GameObject go)
    {
        if (!isHit)
        {
            gameObject.layer = 11;
            curHp -= damage;
            _animator.Play("hurt");
            FindObjectOfType<HitStop>().Stop(0.05f);

            float x = transform.position.x - go.transform.position.x;
            if (x < 0)
                x = 1;
            else
            {
                x = -1;
            }
            StartCoroutine(HitRoutine());
            StartCoroutine(Knockback(x));
            Invoke("OffDamaged", 1);

        }
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
    void OffDamaged()
    {
        gameObject.layer = 10;
    }

    IEnumerator EnergyRecovery()
    {
        //Energy Recovery Time
        yield return new WaitForSeconds(3.0f);
        curEnergy += 10;
        energyDelay = false;
    }

    private float curTime;
    public float coolTime;
    public void Attack()
    {
        //스킬 범위 박스
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPoint.position, attackSize, 0);
        //공격 애니메이션
        if (curTime <= 0)
        {
            //공격
            if (Input.GetKeyDown(KeyCode.X))
            {
                capsuleCollider.isTrigger = false;
                curTime = coolTime;
                _animator.Play("attack1");
                PlaySound("ATTACK1");
                foreach (var c in collider2Ds)
                {
                    if (c.gameObject.layer == 9) // layer 9 = Enemy
                    {
                        c.SendMessage("TakeDamage", damage);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) && (curTime > 0.7f && curTime < 0.9f))
        {
            attackSize = new Vector2(2, 2);
            StartCoroutine(attackSizeControl());
            _animator.Play("attack2");
            PlaySound("ATTACK1");
            foreach (var c in collider2Ds)
            {
                if (c.gameObject.layer == 9)
                {
                    c.SendMessage("TakeDamage", damage);
                }
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    IEnumerator attackSizeControl()
    {
        yield return new WaitForSeconds(0.5f);
        attackSize = new Vector2(1, 2);
    }

    public void Jump()
    {
        //점프 구현
        if (Input.GetKeyDown(KeyCode.C) && jumpCount < 3)
        {
            if (curEnergy <= 0 && jumpCount != 2) //curEnergy <= 0 && jumpCount != 2
            {
                rig.AddForce(Vector2.up * 0.00001f, ForceMode2D.Impulse);
            }
            else if (jumpCount == 1)
            {
                isLadder = false;
                capsuleCollider.isTrigger = false;
                jumpCount += 1;
                rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                _animator.Play("jump");
                PlaySound("JUMP");
                //curEnergy -= 10;
                isOnTheGround = false;
            }
            else if (jumpCount == 2)
            {
                jumpCount += 1;
                rig.AddForce(Vector2.up * (jumpPower * 1.2f), ForceMode2D.Impulse);
                PlaySound("JUMP");
            }
        }


    }

    public void HpSystem()
    {
        //Player Hp
        //hpTextBar.text = "HP  :      " + curHp + "    /    " + maxHp;
        hpBar.value = Mathf.Lerp(hpBar.value, curHp / maxHp, Time.deltaTime * 5f);
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
        else if(curHp < 0)
        {
            curHp = 0;
        }


        //player energy                         //소수점자리 자르기함수 Mathf.Floor
        //energyTextBar.text = "Energy  :    " + Mathf.Floor(curEnergy) + "  /   " + maxEnergy;
        energyBar.value = Mathf.Lerp(energyBar.value, curEnergy / maxEnergy, Time.deltaTime * 5f);
        if (curEnergy > maxEnergy)
        {
            curEnergy = maxEnergy;
        }
        else if(curEnergy < 0)
        {
            curEnergy = 0;
        }

        if (curEnergy < 100 && energyDelay == false)
        {
            energyDelay = true;
            StartCoroutine(EnergyRecovery());
        }
        else if (curEnergy >= 100)
        {
            StopCoroutine(EnergyRecovery());
        }
    }

    //Z 키 눌르면 앉고 가만히 있게 구현하기.
    public void Sit()
    {
        if (Input.GetKey(KeyCode.Z) && isOnTheGround == true)
        {
            moveSpeed = 0;
            _animator.SetBool("sit", true);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            moveSpeed = 5;
            _animator.SetBool("sit", false);
        }
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isOnTheGround == true)
        {
            if (curEnergy <= 0)
            {
                moveSpeed = 5;
                _animator.SetBool("run", false);
            }
            else
            {
                moveSpeed = 10;
                _animator.SetBool("run", true);
                curEnergy -= 0.02f;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            moveSpeed = 5;
            _animator.SetBool("run", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPoint.position, attackSize);
    }

    void Die()
    {
        if(curHp <= 0)
        {
            Btn.SetActive(true);
            DiePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resurrection()
    {
        Btn.SetActive(false);
        DiePanel.SetActive(false);
        Time.timeScale = 1;
        curHp = 100;
        gameObject.transform.position = new Vector2(-11f, -0.45f);
        SceneManager.LoadScene("Main");
    }

    void Esckey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            trigger = !trigger;
            if (trigger)
            {
                DiePanel.SetActive(true);
                EscOption.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                DiePanel.SetActive(false);
                EscOption.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void reStart()
    {
        trigger = false;
        DiePanel.SetActive(false);
        EscOption.SetActive(false);
        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit();
    }


}
