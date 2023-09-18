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

}
