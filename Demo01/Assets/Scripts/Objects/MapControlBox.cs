using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControlBox : MonoBehaviour
{
    GameObject MapControl;
    bool mapControl_Exit = false;

    private void Awake()
    {
        MapControl = GameObject.Find("MapControl");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mapControl_Exit = false;
            MapControl.transform.GetChild(0).gameObject.SetActive(mapControl_Exit);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && Input.GetKeyDown(KeyCode.UpArrow))
        {
            mapControl_Exit = !mapControl_Exit;
            MapControl.transform.GetChild(0).gameObject.SetActive(mapControl_Exit);
        }
    }
}
