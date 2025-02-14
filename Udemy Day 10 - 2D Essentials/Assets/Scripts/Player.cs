using UnityEditor.VisionOS;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float xInput, yInput;

    Vector2 targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 10f;

        if (Input.GetMouseButtonDown(0))
        {
            targetPos = mousePos;
        }
    }

    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

        ClickToMove();
    }

    void ClickToMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed);
    }
}
