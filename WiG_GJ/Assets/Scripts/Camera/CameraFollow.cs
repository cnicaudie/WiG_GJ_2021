using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 m_offset;

    // =================================

    void Start()
    {
        m_offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 newTargetPosition = target.position + m_offset;
        transform.position = newTargetPosition;
    }
}
