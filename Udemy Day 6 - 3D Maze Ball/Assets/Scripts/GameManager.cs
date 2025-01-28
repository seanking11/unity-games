using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float timeLeft = 20;
    public GameObject winText;
    public GameObject gameOverText;
    public GameObject ball;
    public PlayerController player;
    public TextMeshProUGUI timerText;
    bool didWin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0 && !didWin)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("F1");
        }
        if (timeLeft <= 0 && !didWin )
        {
            GameOver();
        }
    }

    public void GameWin()
    {
        didWin = true;
        winText.SetActive(true);
        player.enabled = false;
        ball.SetActive(false);        
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        player.enabled = false;

        // Stop the ball's movement
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Freeze position and rotation
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
