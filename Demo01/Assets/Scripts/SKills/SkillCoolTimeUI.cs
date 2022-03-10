using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimeUI : MonoBehaviour
{
    public Image skillCoolTimeUI;

    private void Start()
    {
        skillCoolTimeUI.fillAmount = 0; //스킬 을 가리지 않음
    }

    float throwCoolTime;
    float throwCurTime;
    private void Update()
    {


        //수류탄 쿨타임 3초
        throwCoolTime = 3f; //스킬 쿨타임 표시 시간
        if (throwCurTime <= 0) // 쿨이 0 초일때 다시 쓸 수 있게
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                throwCurTime = throwCoolTime;
                skillCoolTimeUI.fillAmount = 1; //스킬을 가림
                StartCoroutine("CoolTime"); // 스킬 쿨타임 UI 표시 시작
            }
        }
        else
        {
            throwCurTime -= Time.deltaTime;
        }

    }

    IEnumerator CoolTime()
    {
        while(skillCoolTimeUI.fillAmount > 0)
        {
            skillCoolTimeUI.fillAmount -= 1 * Time.smoothDeltaTime / 3f;
            yield return null;
        }
        yield break;
    }

}
