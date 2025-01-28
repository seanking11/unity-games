using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System;

public class Balloon : MonoBehaviour
{
    public float upSpeed;
    public TextMeshProUGUI scoreText;
    int score = 0;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(0, upSpeed, 0);
    }

    private void OnMouseDown()
    {
        score++;
        scoreText.text = score.ToString();
        audioSource.Play();
        ResetPosition();
    }

    private void ResetPosition()
    {
        float randomX = UnityEngine.Random.Range(-2.5f, 2.5f);

        transform.position = new Vector2(randomX, -7f);
    }
}
