using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jump;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inputManager.OnMove.AddListener(Move);
        inputManager.OnSpacePressed.AddListener(Jump);
        inputManager.OnShiftPressed.AddListener(Dash);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(Vector2 direction)
    {
    }

    private void Jump()
    {

    }
    private void Dash()
    {

    }
}
