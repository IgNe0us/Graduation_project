using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoryObject : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<DontDestoryObject>();

        if (obj.Length == 5) // 파괴되지 않을 오브젝트 수의 개수
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
