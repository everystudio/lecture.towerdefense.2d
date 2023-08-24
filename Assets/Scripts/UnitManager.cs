using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private Dictionary<Vector2Int, PlayerUnit> playerUnitDict = new Dictionary<Vector2Int, PlayerUnit>();

    private void OnEnable()
    {
        PlayerUnitZombi.OnSpawnUnitRequest.AddListener(OnSpawnUnit);
        PlayerUnit.OnRemoved.AddListener(OnRemovedUnit);
    }
    private void OnDisable()
    {
        PlayerUnitZombi.OnSpawnUnitRequest.RemoveListener(OnSpawnUnit);
        PlayerUnit.OnRemoved.RemoveListener(OnRemovedUnit);
    }

    private void OnSpawnUnit(Vector2Int targetPosition, PlayerUnitModel model)
    {
        if (!playerUnitDict.ContainsKey(targetPosition))
        {
            Vector3 position = new Vector3(targetPosition.x, targetPosition.y, 0f);

            GameObject unitPrefab = Resources.Load<GameObject>("Prefabs/Unit");
            PlayerUnit unit = Instantiate(unitPrefab, position, Quaternion.identity).GetComponent<PlayerUnit>();
            unit.Initialize(targetPosition, model);

            playerUnitDict.Add(targetPosition, unit);
        }
        else
        {
            Debug.Log("PlayerUnit is already exist.");
        }
    }

    private void OnRemovedUnit(Vector2Int arg0)
    {
        Debug.Log("UnitManager.OnRemovedUnit");
        try
        {
            playerUnitDict.Remove(arg0);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
