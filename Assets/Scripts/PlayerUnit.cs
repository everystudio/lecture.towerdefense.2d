using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUnit : MonoBehaviour
{
    public static UnityEvent<Vector2Int> OnRemoved = new UnityEvent<Vector2Int>();

    private Vector2Int position;

    public void Initialize(Vector2Int position)
    {
        this.position = position;
    }

    private void OnDestroy()
    {
        Debug.Log("PlayerUnit.OnDestroy");
        OnRemoved.Invoke(position);
    }


}
