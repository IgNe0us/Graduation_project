using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    GameObject go;
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
        go = Instantiate(fieldItemPrefab, pos, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemDB[ItemNumber]);
        go.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 7, ForceMode2D.Impulse);
        go.GetComponent<BoxCollider2D>().isTrigger = true;
        Invoke("TriggerOn", 0.3f);
    }

    void TriggerOn()
    {
        go.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}
