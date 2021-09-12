using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BubbleTrap m_bubbleTrap;

    [SerializeField] private float m_effectValue = 5f;

    private bool m_isTrappedInBubble = false;

    // =================================

    private void Start()
    {
        m_bubbleTrap.DefineRandomColor();
        m_bubbleTrap.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_isTrappedInBubble)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player popped the bubble trap !");

                ProtectiveLayers protectiveLayers = collision.transform.parent.GetComponent<ProtectiveLayers>();

                protectiveLayers.AddToLayers(m_effectValue, m_bubbleTrap.CurrentColorIndex);

                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.GetComponent<Bullet>())
            {
                m_isTrappedInBubble = true;

                // TODO : make the enemy float ?
                m_bubbleTrap.gameObject.SetActive(true);

            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player bumped into an enemy !");

                ProtectiveLayers protectiveLayers = collision.transform.parent.GetComponent<ProtectiveLayers>();

                protectiveLayers.ReduceLayers(m_effectValue, m_bubbleTrap.CurrentColorIndex);
            }
        }
    }
}
