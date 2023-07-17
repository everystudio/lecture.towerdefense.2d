using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void Start()
    {
        LineMover lineMover = GetComponent<LineMover>();
        lineMover.OnEndReached += LineMover_OnEndReached;
    }

    private void LineMover_OnEndReached(object sender, EventArgs e)
    {
        Debug.Log("終端に到着しました");
    }
}
