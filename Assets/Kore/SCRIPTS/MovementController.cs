using UnityEngine;


namespace Kore
{
    public class MovementController : MonoBehaviour
    {
        public float crouchSpeed = 3;
        public float walkSpeed = 5;
        public float runSpeed = 7;
        public float velSalto = 5;
               
        private Rigidbody rb;

        Corrutinas corrutinas;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            corrutinas = GetComponent<Corrutinas>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            Jump();
        }

        private void FixedUpdate()
        {
            Move();
                      
        }

        private void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3 (rb.velocity.x, velSalto, rb.velocity.z);
                
            }
        }

        private void Move()
        {
            rb.velocity = transform.rotation * new Vector3(HorizontalMove(), rb.velocity.y, VerticalMove());
        }

        private float ActualSpeed()
        {
            return IsRunning() ? runSpeed : IsCrouching() ? crouchSpeed : walkSpeed; // Operador ternario
        }

        public float HorizontalMove()
        {
            return Input.GetAxis("Horizontal") * ActualSpeed();
        }

        public float VerticalMove()
        {
            return Input.GetAxis("Vertical") * ActualSpeed();
        }

        public bool IsMoving()
        {
            if (HorizontalMove() != 0 || VerticalMove() != 0)
            {
                Debug.Log("Me muevo");
                return true;
            }
            else
            {
                Debug.Log("No me muevo");
                return false;
            }
        }

        public bool IsRunning()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        private bool IsCrouching()
        {
            return Input.GetKey(KeyCode.LeftControl);
        }

    }
}