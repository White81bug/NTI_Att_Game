using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake : MonoBehaviour
{

    public Rigidbody snakeHead;
    public GameObject SpherePrefab;
    public TextMeshPro SpheresCount;

    private List<Transform> spheres = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    public Transform Head;
    public float SphereDiameter;

    public GameMonitor GameMonitor;


    public AudioSource hitSound;
    public AudioSource pickUpSound;
    void Start()
    {

        positions.Add(Head.position);
        AddSphere();
        AddSphere();
        AddSphere();
    }

 
    void Update()
    {

        if (spheres.Count <= 0) Die();

        float distance = (Head.position - positions[0]).magnitude;

        if (distance > SphereDiameter)
        {
            Vector3 direction = (Head.position - positions[0]).normalized;
            positions.Insert(0, positions[0] + direction * SphereDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= SphereDiameter;
        }


        for (int i = 0; i < spheres.Count; i++)
        {
            spheres[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / SphereDiameter);
        }

        SpheresCount.text = spheres.Count.ToString();
    }
    public void AddSphere()
    {
        GameObject newSegment = GameObject.Instantiate(SpherePrefab, positions[positions.Count - 1], Quaternion.identity, transform);
        Transform sphere = newSegment.transform;
        spheres.Add(sphere);
        positions.Add(sphere.position);
        pickUpSound.Play();
    }

    public void RemoveSphere()
    {
        if (spheres.Count > 0)
        {
            Destroy(spheres[0].gameObject);
            spheres.RemoveAt(0);
            positions.RemoveAt(1);
            hitSound.Play();
           
        }
     
    }

    public void Die()
    {
        GameMonitor.OnPlayerDied();
        snakeHead.velocity = Vector3.zero;
        
    }

    public void Won()
    {
        GameMonitor.OnPlayerReachedFinish();
        snakeHead.velocity = Vector3.zero;
    }
}
