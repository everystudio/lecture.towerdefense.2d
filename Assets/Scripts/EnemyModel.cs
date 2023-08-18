using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyModel", menuName = "ScriptableObjects/EnemyModel", order = 1)]
public class EnemyModel : ScriptableObject
{
    public string enemyName;
    public Sprite enemySprite;
    public int enemyHealth;
    public int enemyDamage;
    public float enemySpeed;
}
