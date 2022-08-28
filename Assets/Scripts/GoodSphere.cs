using UnityEngine;
using TMPro;


public class GoodSphere : MonoBehaviour
{
    public int minimumAmount;
    public int maximumAmount;

    private int amount;

    public TextMeshPro amountText;

   

    private void Start()
    {
       

        amount = Random.Range(minimumAmount, maximumAmount);  
    }

    private void Update()
    {
        amountText.text = amount.ToString();
    }

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
