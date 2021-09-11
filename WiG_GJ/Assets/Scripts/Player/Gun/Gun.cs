using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject m_bullet;

    [SerializeField] private Transform m_shootPoint;

    private float m_shootRate = 0.5f;
    private float m_cooldownSpeed = 0f;

    private float m_range = 100f;

    private const int k_maxAmmunitions = 5;
    private int m_ammunitions = k_maxAmmunitions;

    // =================================

    void Update()
    {
        // TODO : Remove later
        Debug.DrawRay(m_shootPoint.position, Vector3.forward * m_range, Color.red);

        m_cooldownSpeed += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (m_ammunitions > 0 && m_cooldownSpeed > m_shootRate)
            {
                m_cooldownSpeed = 0f;
                m_ammunitions -= 1;
                Shoot();
            }
        }
    }

    private void InstantiateBullet(Vector3 hitPoint)
    {
        GameObject bullet = Instantiate(m_bullet, m_shootPoint.position, Quaternion.identity, transform);
        bullet.GetComponent<Bullet>().hitPoint = hitPoint;
    }

    private void Shoot()
    {
        // TODO : See if it would be better with an aim system (mouse)
        RaycastHit hit;

        // Looking to shoot only thinks part of the environment
        int layerMask = ~LayerMask.NameToLayer("Environment");

        if (Physics.Raycast(m_shootPoint.position, m_shootPoint.forward, out hit, m_range, layerMask, QueryTriggerInteraction.Ignore))
        {
            InstantiateBullet(hit.point);
        }
        else
        {
            Vector3 hitPoint = m_shootPoint.position + m_shootPoint.forward * m_range;
            InstantiateBullet(hitPoint);
        }
    }
}
