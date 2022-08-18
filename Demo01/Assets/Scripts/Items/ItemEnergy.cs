using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ItemEft/Consumable/Energy")]
public class ItemEnergy : ItemEffect
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Player").GetComponent<Player>().curEnergy += 20;
        return true;
    }
}
