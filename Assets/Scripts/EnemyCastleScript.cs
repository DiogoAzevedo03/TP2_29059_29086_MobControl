using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCastleScript : MonoBehaviour
{
    [SerializeField] ParticleSystem castleParticular;
    [SerializeField] TextMeshProUGUI health_text;
    [SerializeField] private TextMeshProUGUI levelCompleteText;
    [SerializeField] private GameObject levelCompleteBackground;
    [SerializeField] private GameObject nextLevelButton; 


    [SerializeField] int health = 10;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bigEnemy;

    [Header("Spawn:Time-EnemyAmount-BigEnemyAmount")]
    [SerializeField] Vector3[] spawnEvents;
    private float spawnTimer;


    void Start()
    {
        spawnTimer = 0;

    }
    void Update()
    {
        if (health <= 0)
        {
            if (levelCompleteText != null && !levelCompleteText.gameObject.activeInHierarchy)
            {
                Invoke(nameof(DestroyCastle),0.1f);
                levelCompleteText.gameObject.SetActive(true);
                levelCompleteBackground.SetActive(true);
                nextLevelButton.SetActive(true); 

            }
        }


        spawnTimer += Time.deltaTime;

        for (int i = 0; i < spawnEvents.Length; i++)
        {
            if (spawnEvents[i].x == (int)spawnTimer)
            {
                spawn((int)spawnEvents[i].y, (int)spawnEvents[i].z);
                spawnEvents[i].x = 0;
            }
        }
        health_text.text = health.ToString();
    }
    private void DestroyCastle()
    {
        Destroy(gameObject);
    }

    private void spawn(int EnemyAmount, int bigEnemyAmount)
    {
        for (int i = 0; i < EnemyAmount; i++)
        {
            Vector3 newSpawnPoint = spawnPoint.position;
            int spawnX = Random.Range(-2, 2);
            int spawnZ = Random.Range(-3, 3);

            newSpawnPoint.z += spawnZ;
            newSpawnPoint.x += spawnX;
            GameObject enemySpawned = Instantiate(enemy, newSpawnPoint, Quaternion.identity);
            enemySpawned.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        for (int y = 0; y < bigEnemyAmount; y++)
        {
            Vector3 newSpawnPoint = spawnPoint.position;
            int spawnX = Random.Range(-2, 2);
            int spawnZ = Random.Range(-3, 3);

            newSpawnPoint.z += spawnZ;
            newSpawnPoint.x += spawnX;
            GameObject enemySpawned = Instantiate(bigEnemy, newSpawnPoint, Quaternion.identity);
            enemySpawned.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void getHit(int damage)
    {
       // Debug.Log("Castle hit. New health: " + health);

        health -= damage;
        CastleHitEffect();
        
    }
    private void CastleHitEffect()
    {
        castleParticular.Play();
    }
}
