using UnityEngine;
using System.Collections.Generic;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner m_groundSpawner;

    [SerializeField] private Transform m_parentObstacle;
    [SerializeField] private List<GameObject> m_obstacles;
    [SerializeField] private List<Transform> m_obstacleSpawnPoints;

    // =================================

    private void Start()
    {
        m_groundSpawner = FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_groundSpawner.SpawnGround();
            Destroy(gameObject, 2f);
        }
    }

    private void SpawnObstacles()
    {
        int obstacleNumber = Random.Range(1, 4);

        for (int i = 0; i < obstacleNumber; i++)
        {
            int spawnIndex = Random.Range(0, m_obstacleSpawnPoints.Count);
            int obstacleTypeIndex = Random.Range(0, m_obstacles.Count);
            
            Transform spawnPoint = m_obstacleSpawnPoints[spawnIndex];

            GameObject obstacle = m_obstacles[obstacleTypeIndex];

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity, m_parentObstacle);
        } 
    }
}
