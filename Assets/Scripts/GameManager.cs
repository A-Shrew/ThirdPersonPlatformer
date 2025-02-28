using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI dashText;

    public static int gameScore;
    public static bool canDash;

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
        if(canDash)
        {
            dashText.text = $"Dash Cooldown: {"Ready"}";
        }
        else
        {
            dashText.text = $"Dash Cooldown: {"Cooldown"}";
        }
   
    }
}
