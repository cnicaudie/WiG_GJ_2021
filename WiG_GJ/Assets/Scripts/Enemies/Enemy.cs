using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BubbleTrap m_bubbleTrap;

    // TODO : Rediscuss the management of the layers
    private float m_effectValue = 5f;

    private bool m_isTrappedInBubble = false;
    public bool IsTrappedInBubble
    {
        get { return m_isTrappedInBubble; }
    }

    // =================================

    private void Start()
    {
        m_bubbleTrap.DefineRandomColor();
        m_bubbleTrap.gameObject.SetActive(false);
    }

    public int GetCurrentColorIndex()
    {
        return m_bubbleTrap.CurrentColorIndex;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_isTrappedInBubble && collision.gameObject.GetComponent<Bullet>())
        {
            m_isTrappedInBubble = true;

            // TODO : make the enemy float ?
            m_bubbleTrap.gameObject.SetActive(true);
        }
    }
}
