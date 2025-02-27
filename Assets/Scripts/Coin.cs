using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float hoverSpeed;

    private Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float yPosition = Mathf.Sin(Time.time * hoverSpeed)/4f;
        transform.position = new Vector3(transform.position.x,position.y + yPosition,transform.position.z);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.gameScore++;
            Destroy(gameObject);
        }
    }
}
