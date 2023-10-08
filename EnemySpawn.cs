
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
  private static GameObject[] enemies;
  private static int enemyCount;
  private Vector3 spawnPoint;

  private void Awake()
  {
  }

  private void Update()
  {
    EnemySpawn.enemies = GameObject.FindGameObjectsWithTag("Enemy");
    EnemySpawn.enemyCount = EnemySpawn.enemies.Length;
    if (EnemySpawn.enemyCount == 1)
      return;
    this.InvokeRepeating("spawnEnemy", 5f, 10f);
  }

  private void spawnEnemy()
  {
    this.spawnPoint.x = (float) Random.Range(-40, 40);
    this.spawnPoint.y = 0.5f;
    this.spawnPoint.z = (float) Random.Range(-40, 40);
    Object.Instantiate((Object) EnemySpawn.enemies[Random.Range(1, EnemySpawn.enemies.Length)], this.spawnPoint, Quaternion.identity);
    this.CancelInvoke();
  }
}