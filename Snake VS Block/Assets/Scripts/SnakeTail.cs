using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform Head;
    public float SphereDiameter;

    private List<Transform> Spheres = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    GameMonitor GameMonitor;
    void Start()
    {
        positions.Add(Head.position);
    }

    
    void Update()
    {
        float distance = (Head.position - positions[0]).magnitude;

        if(distance > SphereDiameter)
        {
            Vector3 direction = (Head.position - positions[0]).normalized;
            positions.Insert(0, positions[0] + direction * SphereDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= SphereDiameter;
        }


        for (int i = 0; i < Spheres.Count; i++)
        {
            Spheres[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / SphereDiameter);
        }

    }
    public void AddSphere()
    {
        Transform sphere = Instantiate(Head, positions[positions.Count - 1], Quaternion.identity, transform);
        Spheres.Add(sphere);
        positions.Add(sphere.position);
    }

    public void RemoveSphere()
    {
        if (Spheres.Count > 0)
        {
            Destroy(Spheres[0].gameObject);
            Spheres.RemoveAt(0);
            positions.RemoveAt(1);
        }
        
    }

    
}
