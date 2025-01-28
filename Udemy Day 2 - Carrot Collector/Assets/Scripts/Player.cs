using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;
    public GameObject winText;
    public int winScore;

    float hInput, vInput;
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        transform.Translate(hInput, vInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Potato") {
            score++;
            Destroy(collision.gameObject);

            if (score >= winScore) {
                winText.SetActive(true);
            }
        }
    }
}
