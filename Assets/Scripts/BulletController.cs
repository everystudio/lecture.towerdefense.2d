using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public EnemyController targetEnemy;
    private float speed = 10f;

    private int power;

    public void Initialize(int power, EnemyController target)
    {
        this.targetEnemy = target;
        this.power = power;
    }

    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, speed * Time.deltaTime);

        // ターゲットまでの距離が0.1以下になったらターゲットを破壊する
        if (Vector3.Distance(transform.position, targetEnemy.transform.position) < 0.1f)
        {
            targetEnemy.TakeDamage(power);
            Destroy(gameObject);
        }

    }






}
