using UnityEngine;


public class GoodSphere : MonoBehaviour
{
    public int amount;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Snake Snake))
        {
            for(int i = 0; i < amount; i++)
            {
                Snake.AddSphere();
            }
          
            Destroy(gameObject);
        }
    }
}
