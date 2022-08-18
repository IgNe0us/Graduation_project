using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ItemEft/Consumable/Health")]
public class ItemHealing : ItemEffect
{
    public int HealingPoint = 0;
    public override bool ExecuteRole()
    {
        GameObject.Find("Player").GetComponent<Player>().curHp += HealingPoint;
        return true;
    }
}
