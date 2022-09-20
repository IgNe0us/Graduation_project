using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEgg : MonoBehaviour
{
    public float speed;
    public Vector3 LRCheck;
    void Start()
    {
        Invoke("DestroyBullet", 3);
    }

    void Update()
    {
        transform.Translate(LRCheck * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyBullet();
        }
        if (collision.gameObject.tag == "Platform")
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
