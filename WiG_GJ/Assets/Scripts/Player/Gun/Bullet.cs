using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 hitPoint;
    
    private float m_speed = 100f;
    private float m_damage = 10f;

    [SerializeField] private bool m_reachedHitPoint = false;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce((hitPoint - transform.position).normalized * m_speed, ForceMode.VelocityChange);
    } 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            /*Target targetEnemy = collision.gameObject.GetComponent<Target>();

            if (targetEnemy != null)
            {
                targetEnemy.TakeDamage(m_damage);
            }

            // Instantiate impact effect ?
            */

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle" || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
