using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoryObject : MonoBehaviour
{
    public static int ObjNum = 6;
    private void Awake()
    {
        var obj = FindObjectsOfType<DontDestoryObject>();

        if (obj.Length == ObjNum) // 파괴되지 않을 오브젝트 수의 개수 ( 물체 하나 추가 할 때 마다 + 1) 현재 레스토랑 들어 갈 때 7로 변하게 하여 7임
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
