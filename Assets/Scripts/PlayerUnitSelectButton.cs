using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// クリックされたイベントのインターフェースをつける
public class PlayerUnitSelectButton : MonoBehaviour, IPointerClickHandler
{

    public static UnityEvent<PlayerUnitModel> OnUnitSelect = new UnityEvent<PlayerUnitModel>();


    // アイコン画像のメンバー変数
    public Image iconImage;

    // ユニットのモデルを保持する
    public PlayerUnitModel unitModel;

    // セットをするメソッドを用意
    public void SetModel(PlayerUnitModel model)
    {
        unitModel = model;
        iconImage.sprite = model.spriteIcon;
    }

    private void Start()
    {
        SetModel(unitModel);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("クリックされた" + gameObject.name);
        OnUnitSelect.Invoke(unitModel);
    }
}



