using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ProtectiveLayers m_protectiveLayers;

    [SerializeField] private float m_effectValue = 5f;

    private void Start()
    {
        m_protectiveLayers = FindObjectOfType<ProtectiveLayers>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player bumped into obstacle !");

            int randomLayerIndex = Random.Range(0, ProtectiveLayers.numberOfLayers);

            m_protectiveLayers.ReduceLayers(m_effectValue, randomLayerIndex);
        }
    }
}
