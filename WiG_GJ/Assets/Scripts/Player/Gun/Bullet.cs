using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 hitPoint;
    
    private float m_speed = 100f;
    private float m_damage = 10f;

    [SerializeField] private bool m_reachedHitPoint = false;

    // =================================

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce((hitPoint - transform.position).normalized * m_speed, ForceMode.VelocityChange);
    } 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.gameObject.name);

        // TODO : manage sounds differently considering what the bullet hit

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle" || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
