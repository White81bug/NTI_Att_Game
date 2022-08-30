using UnityEngine;
using TMPro;

public class BadCube : MonoBehaviour
{
    

    public int maximunHealthPoints;
    public int minimunHealthPoints;
    private int healthPoints;

    public TextMeshPro cubeText;
    public GameObject Particles;

    private Renderer renderer;





    private void Start()
    {
        healthPoints = Random.Range(minimunHealthPoints,maximunHealthPoints);
        renderer = GetComponent<MeshRenderer>();
        renderer.material.SetFloat("_Maximum", maximunHealthPoints);
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
        GameObject.Instantiate(Particles, transform.position, Quaternion.identity);
        if (healthPoints > 0)
        {
            if (other.collider.TryGetComponent(out Snake Snake))
            {
                Snake.RemoveSphere();
            }


            healthPoints--;
        }
    }
    
}
