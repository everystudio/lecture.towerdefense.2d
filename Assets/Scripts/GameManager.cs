using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int coin = 0;
    [SerializeField] private int initialCoin = 10;
    public static UnityEvent<int> OnGoldChanged = new UnityEvent<int>();

    public GameObject panelGameOver;
    public GameObject panelGameClear;

    [SerializeField] private EnemySequenceModel sequenceModel;

    private int enemyCount;
    [SerializeField] private Castle castle;

    // 一定時間ごとにcoinが増える
    private void Start()
    {
        coin = initialCoin;
        StartCoroutine(AddCoin());
        OnGoldChanged.Invoke(coin);

        Castle.OnCastleDestroy.AddListener(() =>
        {
            Debug.Log("GameOver");
            panelGameOver.SetActive(true);
        });

        enemyCount = 0;
        foreach (EnemyModel enemyModel in sequenceModel.enemyModelList)
        {
            if (enemyModel != null)
            {
                enemyCount += 1;
            }
        }
        EnemyController.OnDeleted.AddListener(EnemyDeleted);
    }

    IEnumerator AddCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            coin++;
            OnGoldChanged.Invoke(coin);
        }
    }

    // Coinを消費するプログラム。Coinが足りない場合はfalseを返す
    public bool UseCoin(int cost)
    {
        if (coin < cost)
        {
            return false;
        }
        coin -= cost;
        OnGoldChanged.Invoke(coin);
        return true;
    }


    private void EnemyDeleted(EnemyController arg0)
    {
        enemyCount -= 1;

        if (enemyCount <= 0 && 0.0f < castle.Health)
        {
            Debug.Log("GameClear");
            panelGameClear.SetActive(true);
        }
    }

}
