using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_groundTile;

    private Vector3 m_nextSpawnPoint = Vector3.zero;

    private const int k_tileNumber = 10;

    // =================================

    private void Start()
    {
        for (int i = 0; i < k_tileNumber; i++)
        {
            SpawnGround();
        }
    }

    public void SpawnGround()
    {
        GameObject newGround = Instantiate(m_groundTile, m_nextSpawnPoint, Quaternion.identity, transform);

        // TODO : find a way to not hard code this ?
        m_nextSpawnPoint = newGround.transform.GetChild(1).transform.position;
    }
}
