using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController m_playerController;
    [SerializeField] private ProtectiveLayers m_protectiveLayers;
    [SerializeField] private LayerMask m_groundLayer;

    private Vector3 k_crouchScale = new Vector3(1f, 0.75f, 1f);

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

    private bool m_isBumped;
    private Vector3 m_bumpDirection;
    private float m_bumpForce = 80f;
    private float m_bumpTimer;
    private const float k_maxBumpTime = 0.15f;

    // =================================

    private void Start()
    {
        m_playerController = GetComponent<CharacterController>();
        m_protectiveLayers = GetComponent<ProtectiveLayers>();
    }

    private void Update()
    {
        if (m_protectiveLayers.IsAlive)
        {
            GetInputs();

            // TODO : define a crouch button ?
            // TODO : See if we keep the feature
            if (Input.GetKey(KeyCode.C))
            {
                transform.localScale = k_crouchScale;
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
        else
        {
            // Restart
            // TODO : Move this in a GameManager ?
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void FixedUpdate()
    {
        if (m_protectiveLayers.IsAlive)
        {
            m_isGrounded = Physics.CheckSphere(transform.position, m_checkGroundRadius, m_groundLayer, QueryTriggerInteraction.Ignore);

            MovePlayer();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!m_isBumped && (hit.gameObject.CompareTag("Obstacle")
            || (hit.gameObject.CompareTag("Enemy") && !hit.transform.parent.GetComponent<Enemy>().IsTrappedInBubble)))
        {
            m_bumpDirection = new Vector3(-hit.moveDirection.x, 0, -hit.moveDirection.z);
            m_isBumped = true;
            m_bumpTimer = k_maxBumpTime;
        }
    }

    private void GetInputs()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        float verticalMove = m_isBumped ? 0f : 1f;
        Vector3 moveDirection = new Vector3(m_horizontalInput, 0f, verticalMove).normalized;

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

        if (m_bumpTimer > 0f)
        {
            m_bumpTimer -= Time.fixedDeltaTime;
        }
        else
        {
            m_bumpDirection = Vector3.zero;
            m_isBumped = false;
        }

        // Apply motion
        m_playerController.Move((moveDirection * m_speed + m_velocity + m_bumpDirection * m_bumpForce) * Time.fixedDeltaTime);
    }
}
