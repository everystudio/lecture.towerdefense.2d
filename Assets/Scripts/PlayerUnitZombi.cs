using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerUnitZombi : MonoBehaviour
{
    public static UnityEvent<Vector2Int, PlayerUnitModel> OnSpawnUnitRequest = new UnityEvent<Vector2Int, PlayerUnitModel>();

    [SerializeField] private SpriteRenderer spriteRenderer;
    private PlayerUnitModel selectingModel;

    private bool isHovering = false;

    private void OnEnable()
    {
        PlayerUnitSelectButton.OnUnitSelect.AddListener(SelectUnit);
    }
    private void OnDisable()
    {
        PlayerUnitSelectButton.OnUnitSelect.RemoveListener(SelectUnit);
    }

    private void SelectUnit(PlayerUnitModel arg0)
    {
        selectingModel = arg0;
        spriteRenderer.sprite = arg0.spriteUnit;
    }

    void Update()
    {
        // マウスの位置を追従する
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2Int roundPosition = Vector2Int.RoundToInt(targetPosition);

        // マウスの位置がUIの上にある場合は、ユニットを表示しない
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // マウスがUIの上にある、オブジェクトを取得する
            Debug.Log(EventSystem.current.currentSelectedGameObject);

            spriteRenderer.enabled = false;
            return;
        }
        spriteRenderer.enabled = true;

        transform.position = new Vector3(roundPosition.x, roundPosition.y, transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            OnSpawnUnitRequest.Invoke(roundPosition, selectingModel);
            // マウスの位置にユニットを生成する
        }
    }

}
