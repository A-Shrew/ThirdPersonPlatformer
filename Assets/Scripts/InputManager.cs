using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnSpacePressed = new();
    public UnityEvent<Vector2> OnShiftPressed = new();
    public UnityEvent<Vector2> OnMove = new();
    public UnityEvent<Vector2> OnMouseMove = new();
    //public UnityEvent OnResetPressed = new UnityEvent();

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }

        OnMove?.Invoke(input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnShiftPressed?.Invoke(input);
        }

        float horizontalLook = Input.GetAxis("Mouse X");
        float verticalLook = Input.GetAxis("Mouse Y");

        OnMouseMove?.Invoke(new Vector2(horizontalLook, verticalLook));  
    }
}
