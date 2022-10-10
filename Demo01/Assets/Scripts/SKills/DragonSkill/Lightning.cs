using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public AudioSource Sound;
    public AudioClip bolt;
    private void Start()
    {
        Sound.PlayOneShot(bolt);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Player>().curHp -= 6;
        }
    }

}
