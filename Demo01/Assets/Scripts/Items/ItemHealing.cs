using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ItemEft/Consumable/Health")]
public class ItemHealing : ItemEffect
{
    Player player;
    public override bool ExecuteRole()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.curHp += 10;
        return true;
    }
}
