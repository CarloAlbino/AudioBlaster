using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
    [SerializeField]
    private float maxSpawnTime = 5.0f;
    [SerializeField]
    private float minSpawnTime = 1.5f;
    [SerializeField]
    private float maxDistanceX = 5.0f;
    [SerializeField]
    private float minDistanceX = -5.0f;
    [SerializeField]
    private float maxDistanceY = 5.0f;
    [SerializeField]
    private float minDistanceY = -5.0f;
    [SerializeField]
    private GameObject enemy;
    private GameController _controller;

    void Start()
    {
        _controller = FindObjectOfType<GameController>();
        StartCoroutine(SpawnNewEnemy());
    }

    private Vector3 RandomSpawnPoint()
    {
        Vector3 point = this.transform.position;

        point.x += Random.Range(minDistanceX, maxDistanceX);
        point.y += Random.Range(minDistanceY, maxDistanceY);

        return point;
    }

    private IEnumerator SpawnNewEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        if (_controller.numOfEnemies < _controller.MaxEnemies())
        { 
            Instantiate(enemy, RandomSpawnPoint(), Quaternion.identity);
            _controller.numOfEnemies++;
        }
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnNewEnemy());
    }

}
