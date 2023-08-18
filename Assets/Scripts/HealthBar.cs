using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform target; // 追従する対象
    public Vector3 offset; // オフセット（World Spaceのオフセット）
    public Image fillImage; // HealthBarのFill部分
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (target)
        {
            // World PositionをScreen Positionに変換
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            rectTransform.position = screenPos;
        }
    }

    public void SetHealth(float healthPercentage)
    {
        fillImage.fillAmount = healthPercentage;
    }
}
