using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab = null;
    Player player;
    void Awake()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        Fire();
    }


    float throwCoolTime;
    float throwCurTime;
    void Fire()
    {
        //수류탄 쿨타임 1초
        throwCoolTime = 3f;
        //수류탄을 던질 플레이어의 위치
        Vector2 tfPlayer = new Vector2(player.transform.position.x, player.transform.position.y + 1.5f);
        //수류탄의 각도 (던질힘 , 얼마나 위로던질지)
        Vector2 rbombOuler = new Vector2(7f, 5f);
        Vector2 lbombOuler = new Vector2(-7f, 5f);
        if (throwCurTime <= 0)
        {
            if (player.curEnergy <= 0)
            {
                return;
                //에너지가 부족합니다.
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    throwCurTime = throwCoolTime;
                    if (player.leftRightCheck == false)
                    {
                        player._animator.Play("throw");
                        player.PlaySound("THROW");
                        player.curEnergy -= 10;
                        GameObject bomb = Instantiate(bombPrefab, tfPlayer, player.transform.rotation);
                        bomb.GetComponent<Rigidbody2D>().Sleep();
                        bomb.GetComponent<Rigidbody2D>().velocity = lbombOuler;
                    }
                    else if (player.leftRightCheck == true)
                    {
                        player._animator.Play("throw");
                        player.PlaySound("THROW");
                        player.curEnergy -= 10;
                        GameObject bomb = Instantiate(bombPrefab, tfPlayer, player.transform.rotation);
                        bomb.GetComponent<Rigidbody2D>().Sleep();
                        bomb.GetComponent<Rigidbody2D>().velocity = rbombOuler;
                    }
                }
            }
        }
        else
        {
            throwCurTime -= Time.deltaTime;
        }
        
        
    }
}
