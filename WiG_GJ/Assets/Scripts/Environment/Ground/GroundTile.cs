using UnityEngine;
using System.Collections.Generic;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner m_groundSpawner;

    [SerializeField] private Transform m_parentObstacle;
    [SerializeField] private List<GameObject> m_obstacles;
    [SerializeField] private List<Transform> m_obstacleSpawnPoints;

    [SerializeField] private Transform m_parentCollectible;
    [SerializeField] private List<GameObject> m_collectibles;
    [SerializeField] private List<Transform> m_collectibleSpawnPoints;

    // =================================

    private void Start()
    {
        m_groundSpawner = FindObjectOfType<GroundSpawner>();

        int obstacleNumber = Random.Range(1, 4);
        int collectibleNumber = Random.Range(0, 3);
        SpawnObjects(obstacleNumber, m_obstacleSpawnPoints, m_obstacles, m_parentObstacle);
        SpawnObjects(collectibleNumber, m_collectibleSpawnPoints, m_collectibles, m_parentCollectible);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_groundSpawner.SpawnGround();
            Destroy(gameObject, 2f);
        }
    }

    private void SpawnObjects(int objectNumber, List<Transform> spawnPoints, List<GameObject> objectTypes, Transform parentObject)
    {
        for (int i = 0; i < objectNumber; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Count);

            int objectTypeIndex = Random.Range(0, objectTypes.Count);

            Transform spawnPoint = spawnPoints[spawnIndex];

            spawnPoints.Remove(spawnPoint);

            GameObject gameObject = objectTypes[objectTypeIndex];

            Instantiate(gameObject, spawnPoint.position, Quaternion.identity, parentObject);
        }
    }
}
