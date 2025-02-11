using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotateSpeed;

    void FixedUpdate()
    {
        transform.Rotate(0, 0.1f, rotateSpeed);
    }
}
