using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUnit : MonoBehaviour
{
    public static UnityEvent<Vector2Int> OnRemoved = new UnityEvent<Vector2Int>();

    private PlayerUnitModel model;
    private Vector2Int position;

    public void Initialize(Vector2Int position, PlayerUnitModel model)
    {
        this.position = position;
        this.model = model;
        GetComponent<SpriteRenderer>().sprite = model.spriteUnit;
    }

    private void OnDestroy()
    {
        Debug.Log("PlayerUnit.OnDestroy");
        OnRemoved.Invoke(position);
    }
}
