using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(transferMapName);
        }
    }
}
