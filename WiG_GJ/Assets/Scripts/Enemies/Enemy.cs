using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BubbleTrap m_bubbleTrap;

    private bool m_isTrappedInBubble = false;
    public bool IsTrappedInBubble
    {
        get { return m_isTrappedInBubble; }
    }

    private Vector3 m_floatingPosition;
    private float m_yStartPosition;
    private float m_floatAmplitude = 1f;
    private float m_floatSpeed = 3f;

    // =================================

    private void Start()
    {
        m_floatingPosition = transform.position;
        m_yStartPosition = transform.position.y + m_floatAmplitude;

        m_bubbleTrap.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_isTrappedInBubble)
        {
            Float();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_isTrappedInBubble && collision.gameObject.GetComponent<Bullet>())
        {
            m_isTrappedInBubble = true;
            m_bubbleTrap.gameObject.SetActive(true);
            m_bubbleTrap.DefineRandomColor();
        }
    }

    public int GetCurrentColorIndex()
    {
        return m_bubbleTrap.CurrentColorIndex;
    }

    private void Float()
    {
        m_floatingPosition.y = m_yStartPosition + m_floatAmplitude * Mathf.Sin(m_floatSpeed * Time.time);
        transform.position = m_floatingPosition;
    }
}
