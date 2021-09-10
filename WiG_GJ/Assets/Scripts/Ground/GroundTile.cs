using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner m_groundSpawner;

    // =================================

    private void Start()
    {
        m_groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_groundSpawner.SpawnGround();
            Destroy(gameObject, 2f);
        }
    }
}
