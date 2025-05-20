using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A (-1) <-> D (+1)
        float vertical = Input.GetAxis("Vertical");     // S (-1) <-> W (+1)

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
