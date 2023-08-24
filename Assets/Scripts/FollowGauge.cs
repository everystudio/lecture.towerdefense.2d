using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGauge : MonoBehaviour
{
    public Transform target; // 追従する対象
    public Vector3 offset; // オフセット（World Spaceのオフセット）
    private RectTransform rectTransform;

    public void SetTarget(Transform target, Vector3 offset)
    {
        this.target = target;
        this.offset = offset;
    }
    public void SetTarget(Transform target)
    {
        SetTarget(target, Vector3.zero);
        RefreshPosition();
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        RefreshPosition();
    }

    private void RefreshPosition()
    {
        if (target)
        {
            // World PositionをScreen Positionに変換
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            rectTransform.position = screenPos;
        }
    }
}
