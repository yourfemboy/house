using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "item", menuName = "Scriptable Objects/Item")]

public class ItemSO : ScriptableObject
{

    [Header("Properties")]
    public float cooldown;
    public itemType item_type;
    public Sprite item_sprite;

}

public enum itemType { AssaultRifle6_06 };
