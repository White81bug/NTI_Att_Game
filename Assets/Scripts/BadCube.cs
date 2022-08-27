using UnityEngine;
using TMPro;

public class BadCube : MonoBehaviour
{
    
    public float KnockBackAmount;
    public int MaximunHealthPoints;
    public int healthPoints;

    public TextMeshPro cubeText;

    private Renderer renderer;



    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material.SetFloat("_Maximum", MaximunHealthPoints);
        renderer.material.SetFloat("_Amount", healthPoints);
    }

    private void Update()
    {
        cubeText.text = healthPoints.ToString();
        renderer.material.SetFloat("_Amount", healthPoints);
        if (healthPoints <= 0) Destroy(gameObject);
        
    }

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
      //  else Destroy(gameObject);
    }
    
}
