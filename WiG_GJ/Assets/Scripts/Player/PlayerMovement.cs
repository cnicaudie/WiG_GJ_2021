using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController m_playerController;

    [SerializeField] private LayerMask m_groundLayer;

    private Vector3 m_velocity;

    private float m_speed = 20f;

    private float m_horizontalInput;

    private float m_gravity = -4f;

    private bool m_isGrounded;
    private float m_checkGroundRadius = 0.1f;
    
    private bool m_isJumping;
    private float m_jumpForce = 12f;
    private float m_jumpTimer;
    private const float k_maxJumpTime = 0.1f;

    // =================================

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        m_isGrounded = Physics.CheckSphere(transform.position, m_checkGroundRadius, m_groundLayer, QueryTriggerInteraction.Ignore);

        MovePlayer();
    }

    private void GetInputs()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(m_horizontalInput, 0f, 1f).normalized;

        // Vertical movement (jump and gravity)
        if (m_isGrounded)
        {
            m_velocity.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                m_isJumping = true;
                m_jumpTimer = k_maxJumpTime;
                m_velocity.y += m_jumpForce;
            }
        }
        else
        {
            m_velocity.y += m_gravity;

            if (Input.GetButton("Jump") && m_isJumping)
            {
                if (m_jumpTimer > 0f)
                {
                    m_velocity.y += m_jumpForce;
                    m_jumpTimer -= Time.fixedDeltaTime;
                }
                else
                {
                    m_isJumping = false;
                }
            }
            else if (Input.GetButtonUp("Jump"))
            {
                m_isJumping = false;
            }
        }

        // Apply motion
        m_playerController.Move((moveDirection * m_speed + m_velocity) * Time.fixedDeltaTime);
    }
}
