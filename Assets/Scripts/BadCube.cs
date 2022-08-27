using UnityEngine;

public class BadCube : MonoBehaviour
{
    
    public float KnockBackAmount;
    public int healthPoints;

    private void OnCollisionEnter(Collision other)
    {
        if (healthPoints > 0)
        {
            if (other.collider.TryGetComponent(out Snake Snake))
            {
                Snake.RemoveSphere();
            }

            if (other.collider.TryGetComponent(out Rigidbody SnakeHead))
            {
                Vector3 currentPos = SnakeHead.transform.position;
                currentPos.z -= KnockBackAmount;
                SnakeHead.transform.position = currentPos;
            }

            healthPoints--;
        }
        else Destroy(gameObject);
    }
}
