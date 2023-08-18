using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EventHandler OnEndReached;

    public void Initialize(EnemyModel enemyModel, LineRenderer lineRenderer)
    {
        LineMover lineMover = GetComponent<LineMover>();
        lineMover.Initialize(0, enemyModel.enemySpeed, lineRenderer);
        lineMover.OnEndReached += LineMover_OnEndReached;
    }

    private void LineMover_OnEndReached(object sender, EventArgs e)
    {
        Debug.Log("終端に到着しました");

        Castle.OnTakeDamage?.Invoke(10f);
        OnEndReached?.Invoke(this, EventArgs.Empty);

        Destroy(gameObject);
    }
}
