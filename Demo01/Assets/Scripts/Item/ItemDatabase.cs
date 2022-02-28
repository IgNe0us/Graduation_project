﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }
    public List<Item> itemDB = new List<Item>();
    public GameObject fieldItemPrefab;
 

    public void ItemDrop(Vector3 pos,int ItemNumber)
    {
        GameObject go = Instantiate(fieldItemPrefab, pos, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemDB[ItemNumber]);
    }


}