using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ProtectiveLayers m_protectiveLayers;

    [SerializeField] private GameObject m_bullet;

    [SerializeField] private Transform m_shootPoint;

    private const int k_maxAmmunitions = 5;
    [SerializeField] private int m_ammunitions = k_maxAmmunitions;

    private float m_shootRate = 0.5f;
    private float m_cooldownSpeed = 0f;

    private float m_range = 100f;

    public delegate void UpdateBulletValue();
    public event UpdateBulletValue OnBulletNumberChange;

    // =================================

    private void Start()
    {
        m_protectiveLayers = GetComponent<ProtectiveLayers>();
    }

    void Update()
    {
        if (m_protectiveLayers.IsAlive)
        {
            m_cooldownSpeed += Time.deltaTime;

            if (Input.GetButton("Fire1"))
            {
                if (m_ammunitions > 0 && m_cooldownSpeed > m_shootRate)
                {
                    Shoot();
                }
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Ammunition"))
        {
            SoundManager.PlaySound("pickUpAmmo");

            Debug.Log("Player collected ammo !");

            AddAmmunition();

            Destroy(hit.gameObject);
        }
    }

    public int GetAmmunitionCount()
    {
        return m_ammunitions;
    }

    public void AddAmmunition()
    {
        if (m_ammunitions < k_maxAmmunitions)
        {
            m_ammunitions += 1;

            if (OnBulletNumberChange != null)
            {
                OnBulletNumberChange();
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
        m_cooldownSpeed = 0f;
        m_ammunitions -= 1;

        SoundManager.PlaySound("bubbleFire");

        Vector3 hitPoint = m_shootPoint.position + m_shootPoint.forward * m_range;
        InstantiateBullet(hitPoint);

        if (OnBulletNumberChange != null)
        {
            OnBulletNumberChange();
        }
    }
}
