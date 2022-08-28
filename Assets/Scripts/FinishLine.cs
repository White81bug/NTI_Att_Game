
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Snake snake = collision.collider.GetComponent<Snake>();
        if (snake)
        {
            snake.Won();
        }

    }
}
