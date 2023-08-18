using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySequenceModel", menuName = "ScriptableObjects/EnemySequenceModel", order = 1)]
public class EnemySequenceModel : ScriptableObject
{
    public float intervalSec = 1f;
    public List<EnemyModel> enemyModelList;
}
