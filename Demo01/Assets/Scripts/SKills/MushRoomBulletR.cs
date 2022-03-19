using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomBulletR : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Invoke("DestroyBullet", 3);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
