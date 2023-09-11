using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIHeader : MonoBehaviour
{
    // コインの枚数を表示に反映させる
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        // GameManagerのgoldを監視する
        GameManager.OnGoldChanged.AddListener(UpdateGoldText);
    }

    private void UpdateGoldText(int arg0)
    {
        goldText.text = string.Format("Coin : {0}", arg0);
    }
}
