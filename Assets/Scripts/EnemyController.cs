using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EventHandler OnEndReached;

    public GameObject healthBarPrefab;
    private FollowGauge followGauge;

    public void Initialize(EnemyModel enemyModel, LineRenderer lineRenderer)
    {
        LineMover lineMover = GetComponent<LineMover>();
        lineMover.Initialize(0, enemyModel.enemySpeed, lineRenderer);
        lineMover.OnEndReached += LineMover_OnEndReached;

        Transform rootTransform = GameObject.Find("tempLayer").transform;
        //Debug.Log(Resources.Load<GameObject>("Prefabs/HealthBar"));
        //Debug.Log(rootTransform);

        followGauge = Instantiate(Resources.Load<GameObject>("Prefabs/HealthBar"), rootTransform).GetComponent<FollowGauge>();
        followGauge.SetTarget(transform, Vector2.up * 0.5f);

    }

    private void LineMover_OnEndReached(object sender, EventArgs e)
    {
        //Debug.Log("終端に到着しました");

        Castle.OnTakeDamage?.Invoke(10f);
        OnEndReached?.Invoke(this, EventArgs.Empty);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (followGauge != null)
        {
            Destroy(followGauge.gameObject);
        }
    }
}
