using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 hitPoint;
    
    private float m_speed = 100f;

    // =================================

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce((hitPoint - transform.position).normalized * m_speed, ForceMode.VelocityChange);
    } 

    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.PlaySound("bubbleHit");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 2f);
    }
}
