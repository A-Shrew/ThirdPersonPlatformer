using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    public static int gameScore;
    public static float dashCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {gameScore}";
    }
}
