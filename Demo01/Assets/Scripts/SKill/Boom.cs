using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Boom : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;
    AudioSource audioSource;
    public AudioClip audioBombed;
    public AudioClip audioBrokenGlass;
    public Rigidbody2D rig;

    public enum AnimState
    {
        Fly,Boom
    }

    private AnimState _AnimState;
    private string CurrentAnimation;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(BombOn());
    }
    IEnumerator BombOn()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    private void Update()
    {
        SetCurrentAnimation(_AnimState);
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Platform")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            _AnimState = AnimState.Boom;
            rig.drag = 100;
            audioSource.PlayOneShot(audioBrokenGlass);
            audioSource.PlayOneShot(audioBombed);
            StartCoroutine(Bombed());
        }
        
    }

    IEnumerator Bombed()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void SetCurrentAnimation(AnimState _State)
    {
        switch (_State)
        {
            case AnimState.Fly:
                _AsncAnimation(AnimClip[(int)AnimState.Fly], true, 1f);
                break;
            case AnimState.Boom:
                _AsncAnimation(AnimClip[(int)AnimState.Boom], false, 1f);
                break;
        }
    }

}
