using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private Gun m_gun;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collected ammo !");

            m_gun.AddAmmunition();

            Destroy(gameObject);
        }
    }
}
