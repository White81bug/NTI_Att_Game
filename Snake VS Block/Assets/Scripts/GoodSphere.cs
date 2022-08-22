using UnityEngine;


public class GoodSphere : MonoBehaviour
{
    

   

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Snake Snake))
        {
            Snake.AddSphere();
            Destroy(gameObject);
        }
    }
}
