using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUnit : MonoBehaviour
{
    public static UnityEvent<Vector2Int> OnRemoved = new UnityEvent<Vector2Int>();

    private PlayerUnitModel model;
    private Vector2Int position;

    [SerializeField] private GameObject bulletPrefab;

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(model.attackIntervalSec);
        Attack2Enemy();
    }

    private void Attack2Enemy()
    {
        Debug.Log("PlayerUnit.Attack2Enemy");
        // 敵のリストを取得する
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 敵のリストから、一番近い敵を探す
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        // 敵がいない場合は、攻撃しない
        if (nearestEnemy == null)
        {
            return;
        }

        // 敵にダメージを与える
        EnemyController enemyController = nearestEnemy.GetComponent<EnemyController>();

        BulletController bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<BulletController>();
        bullet.Initialize(model.attack, enemyController);

        // 再度攻撃する
        StartCoroutine(Attack());
    }

    public void Initialize(Vector2Int position, PlayerUnitModel model)
    {
        this.position = position;
        this.model = model;
        GetComponent<SpriteRenderer>().sprite = model.spriteUnit;

        StartCoroutine(Attack());

    }

    private void OnDestroy()
    {
        //Debug.Log("PlayerUnit.OnDestroy");
        OnRemoved.Invoke(position);
    }
}
