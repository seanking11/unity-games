using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed;
    public int winScore = 10;
    public GameObject winText;

    Rigidbody rb;
    float xInput;
    float yInput;
    int score = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput * speed, 0, yInput * speed);

        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;

            if (score >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
