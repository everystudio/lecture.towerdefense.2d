using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class EnemyLine : MonoBehaviour
{
    public static UnityEvent OnLineFinished = new UnityEvent();

    private LineRenderer lineRenderer;

    private float time = 0f;
    private int enemyIndex = 0;

    [SerializeField] private EnemySequenceModel sequenceModel;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (sequenceModel == null)
        {
            return;
        }

        time += Time.deltaTime;

        if (time >= sequenceModel.intervalSec)
        {
            time = 0f;

            if (enemyIndex >= sequenceModel.enemyModelList.Count)
            {
                OnLineFinished.Invoke();
                enabled = false;
                return;
            }

            EnemyModel enemyModel = sequenceModel.enemyModelList[enemyIndex];

            if (enemyModel != null)
            {
                GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
                EnemyController enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<EnemyController>();
                //Debug.Log(enemy);
                enemy.Initialize(enemyModel, lineRenderer);
            }

            enemyIndex++;
        }
    }
}
