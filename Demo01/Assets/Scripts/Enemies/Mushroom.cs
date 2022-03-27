using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Transform posR;
    public Transform posL;
    //체력관련
    public int hp = 50;
    //드랍 확율
    public int drop_Percentage;

    //히트관련
    public BoxCollider2D boxCollider2d;
    bool isHit = false;
    bool isknockback;

    //데미지
    public int damage;

    //오디오 관련
    AudioSource audioSource;
    public AudioClip damaged;

    //발사체 공격관련
    public GameObject bulletL;
    public GameObject bulletR;
    SpriteRenderer sr;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        isknockback = false;
    }
    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.57f);
        if (sr.flipX == true)
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
            //피격 애니메이션
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
    private void Die()
    {
        if (hp <= 0)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            player.money += Random.Range(30, 50);
            if(Random.Range(1, 100) <= drop_Percentage)
            {
                ItemDatabase.instance.ItemDrop(gameObject.transform.position, 9);
            }
            Destroy(gameObject);
        }
    }


}
