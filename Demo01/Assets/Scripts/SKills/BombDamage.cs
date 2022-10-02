using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    public int damage;
    int playerDamage;
    private void Awake()
    {
        playerDamage = GameObject.Find("Player").gameObject.GetComponent<Player>().damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //콜라이더에 닿는게 몬스터면 데미지 30주기
        if (collision.gameObject.layer == 9)
        {
            collision.SendMessage("TakeDamage", damage + (playerDamage / 2));
        }
    }
}
