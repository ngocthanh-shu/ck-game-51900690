using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hazards;
    public float spawnWave;
    public float startWave;
    public float waitWave;
    private Vector2 spawnValues;
    public int hazardCount;
    public EnemyAIGen2 ai;
    private bool isAttack;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;
    void Start()
    {
        cooldownTimer = Mathf.Infinity;
        spawnValues = new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y +2);
        isAttack = ai.GetAttackRange();
    }

    private void Update()
    {
        isAttack = ai.GetAttackRange();
        if (isAttack)
        {
            SpawnWaves();
        }
        cooldownTimer += Time.deltaTime;
    }

    public void SpawnWaves()
    {
        if (cooldownTimer > attackCooldown)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 spawnPos = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Instantiate(hazard, spawnPos, hazard.transform.rotation);
            }
            cooldownTimer = 0;
        }
        
    }
}
