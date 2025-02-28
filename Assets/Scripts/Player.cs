using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private new CinemachineCamera camera;
    [SerializeField] private TextMeshProUGUI dashText;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private int jumps;
    [SerializeField] private float dash;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float airDrag;

    private Rigidbody rb;
    private bool isGrounded;
    private int remJumps;
    private bool canDash;
    private string dashString;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        canDash = true;
        inputManager.OnMove.AddListener(Move);
        inputManager.OnSpacePressed.AddListener(Jump);
        inputManager.OnShiftPressed.AddListener(Dash);
    }

    private void Update()
    {
        dashText.text = $"Dash Cooldown: {dashString}";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Apply Drag
        rb.linearVelocity = new Vector3(rb.linearVelocity.x / (1 + airDrag), rb.linearVelocity.y,rb.linearVelocity.z / (1 + airDrag));
        transform.rotation = Quaternion.Euler(transform.rotation.x, camera.transform.rotation.eulerAngles.y, transform.rotation.z);
    }


    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = transform.rotation * new Vector3(direction.x, 0f, direction.y);
        rb.AddForce(speed * moveDirection,ForceMode.Acceleration);
    }

    private void Jump()
    {
        if (isGrounded || remJumps>0)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(jumpPower * Vector3.up, ForceMode.VelocityChange);
            remJumps--;
        }
    }
    private void Dash(Vector2 direction)
    {
        if (canDash)
        {
            Vector3 moveDirection = rb.rotation * new Vector3(direction.x, 0f, direction.y);
            rb.AddForce(dash * moveDirection, ForceMode.Impulse);
            rb.AddForce(dash / 10 * Vector3.up, ForceMode.Impulse);
            StartCoroutine(DashCooldown());
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Instantiate(particles,feetPosition.position,feetPosition.rotation);
            isGrounded = true;
            remJumps = jumps;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public IEnumerator DashCooldown()
    {
        canDash = false;
        dashString = "Cooldown";

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
        dashString = "Ready";
    }
}
