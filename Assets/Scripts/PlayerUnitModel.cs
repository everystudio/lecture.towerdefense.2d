using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitModel")]
public class PlayerUnitModel : ScriptableObject
{
    public string unitName;
    public int maxHp;
    public int attack;
    public int defense;
    public int moveSpeed;
    public int attackRange;
    public int attackSpeed;
    public int cost;
    public float attackIntervalSec;
    public Sprite spriteUnit;
    public Sprite spriteIcon;
}
