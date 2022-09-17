using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class EnemyMove : MonoBehaviour
{
    public Rigidbody2D rigid;
    public int nextMove;
    float nextThinkTime;
    Animator anim;
    SpriteRenderer spriteRenderer;

    //애니메이션에 대한 Enum


    Player player;

    //HP 관련
    public int hp = 50;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nextThinkTime = Random.Range(2f, 6f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();
        
        
    }

    private void Update()
    {
        Die();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y );
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            Turn();
        }

    }

    void Think()
    {
        anim.SetInteger("WalkSpeed", nextMove);
        nextMove = Random.Range(-1, 2);
        Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        nextMove = nextMove * -1;
        spriteRenderer.flipX = nextMove == 1;


        CancelInvoke();
        Invoke("Think", nextThinkTime);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }



    private void Die()
    {
        if(hp <= 0)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            ItemDatabase.instance.ItemDrop(rigid.position, 24);
            Destroy(gameObject);
        }
    }


}
