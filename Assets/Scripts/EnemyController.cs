using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public static EventHandler OnEndReached;

    public GameObject healthBarPrefab;
    private FollowGauge followGauge;
    private HealthBar healthBar;

    private EnemyModel enemyModel;

    private int currentHealth;

    public static UnityEvent<EnemyController> OnDeleted = new UnityEvent<EnemyController>();

    public void Initialize(EnemyModel enemyModel, LineRenderer lineRenderer)
    {
        this.enemyModel = enemyModel;
        currentHealth = enemyModel.enemyMaxHealth;

        LineMover lineMover = GetComponent<LineMover>();
        lineMover.Initialize(0, enemyModel.enemySpeed, lineRenderer);
        lineMover.OnEndReached += LineMover_OnEndReached;

        Transform rootTransform = GameObject.Find("tempLayer").transform;
        //Debug.Log(Resources.Load<GameObject>("Prefabs/HealthBar"));
        //Debug.Log(rootTransform);

        followGauge = Instantiate(Resources.Load<GameObject>("Prefabs/HealthBar"), rootTransform).GetComponent<FollowGauge>();
        followGauge.SetTarget(transform, Vector2.up * 0.5f);

        healthBar = followGauge.GetComponent<HealthBar>();
        HealthUpdate();

    }

    private void HealthUpdate()
    {
        healthBar.SetHealth((float)currentHealth / enemyModel.enemyMaxHealth);
    }

    private void LineMover_OnEndReached(object sender, EventArgs e)
    {
        //Debug.Log("終端に到着しました");
        Castle.OnTakeDamage?.Invoke(enemyModel.enemyPower);
        OnEndReached?.Invoke(this, EventArgs.Empty);

        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }
        HealthUpdate();
    }

    private void OnDestroy()
    {
        OnDeleted?.Invoke(this);
        if (followGauge != null)
        {
            Destroy(followGauge.gameObject);
        }
    }
}
