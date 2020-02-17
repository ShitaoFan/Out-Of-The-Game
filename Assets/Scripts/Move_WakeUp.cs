using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_WakeUp : MonoBehaviour
{

    private enum ControlMode
    {
        Tank,
        Direct
    }

    public Rigidbody CharacterRigidbody;
    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 4;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Direct;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();
    public GameObject Eye;

    void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    void Update()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        switch (m_controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        m_wasGrounded = m_isGrounded;

        //CheckAngle(Eye.transform.eulerAngles.x);
        if (Eye.transform.eulerAngles.x > 80f & Eye.transform.eulerAngles.x <= 180f)
        {
            Eye.transform.eulerAngles = new Vector3(80f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        UseGravity();
    }

    private void TankUpdate()
    {
        /* float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift);

        if (v < 0) {
            if (walk) { v *= m_backwardsWalkScale; }
            else { v *= m_backwardRunScale; }
        } else if(walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;*/
        //if (Input.GetMouseButton(1))
        //{
        if (Input.GetAxis("Mouse X") != 0)
        {
            //Debug.Log(Input.GetAxis("Mouse X"));
            if (Input.GetAxis("Mouse X") < 0.1f && Input.GetAxis("Mouse X") > -0.1f)
            {
                // return;
            }
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 200, 0));
            //clearArrow(false);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            if (Input.GetAxis("Mouse Y") < 0.1f && Input.GetAxis("Mouse Y") > -0.1f)
            {
                //bug.Log("Mouse Y");
                //  return;
            }
            Eye.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -200, 0, 0));

        }
        //}
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * m_moveSpeed);
            m_currentV = 5;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            m_currentV = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(-Vector3.forward * Time.deltaTime * m_moveSpeed);
            m_currentV = -5;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            m_currentV = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-Vector3.right * Time.deltaTime * m_moveSpeed);
            m_currentV = 5;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_currentV = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * m_moveSpeed);
            m_currentV = 5;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_currentV = 0;
        }
        m_animator.SetFloat("MoveSpeed", m_currentV);

        //JumpingAndLanding();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        //JumpingAndLanding();
    }

    /* private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * 10.0f * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }*/
    public float CheckAngle(float value)
    {
        float angle = value;

        if (angle > 0)
            return angle;

        return angle + 360;
    }
    public void UseGravity()
    {
        if (transform.position.x < -1135.19f | transform.position.z < 84.91f)
        {
            CharacterRigidbody.useGravity = true;
            CharacterRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;
            Debug.Log("超过界限");
        }
    }
}