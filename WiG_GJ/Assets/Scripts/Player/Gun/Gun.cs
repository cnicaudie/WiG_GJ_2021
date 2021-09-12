using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject m_bullet;

    [SerializeField] private Transform m_shootPoint;

    private const int k_maxAmmunitions = 5;
    [SerializeField] private int m_ammunitions = k_maxAmmunitions;

    private float m_shootRate = 0.5f;
    private float m_cooldownSpeed = 0f;

    private float m_range = 100f;

    // =================================

    void Update()
    {
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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Ammunition"))
        {
            Debug.Log("Player collected ammo !");

            AddAmmunition();

            Destroy(hit.gameObject);
        }
    }

    public void AddAmmunition()
    {
        if (m_ammunitions < k_maxAmmunitions)
        {
            m_ammunitions += 1;
        }
    }

    private void InstantiateBullet(Vector3 hitPoint)
    {
        GameObject bullet = Instantiate(m_bullet, m_shootPoint.position, Quaternion.identity, transform);
        bullet.GetComponent<Bullet>().hitPoint = hitPoint;
    }

    private void Shoot()
    {
        Vector3 hitPoint = m_shootPoint.position + m_shootPoint.forward * m_range;
        InstantiateBullet(hitPoint);
    }
}
