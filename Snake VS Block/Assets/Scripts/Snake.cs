using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

  //  public Rigidbody snakeHead;
 //   private Camera mainCamera;

  //  private Vector3 lastInpitPos;
  //  private float sidewaysSpeed;

  //  public int speed;
  //  public float Sensitivity;

    public GameObject SpherePrefab;

    private List<Transform> Spheres = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    public Transform Head;
    public float SphereDiameter;

    public GameMonitor GameMonitor;

    void Start()
    {
     //   snakeHead = GetComponent<Rigidbody>();
      //  mainCamera = Camera.main;
        positions.Add(Head.position);
        AddSphere();
        AddSphere();
        AddSphere();
    }

 
    void Update()
    {

  //      if (Input.GetMouseButtonDown(0))
   //     {
   //         lastInpitPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
  //      }
  //      else if (Input.GetMouseButtonUp(0))
  //      {
  //          sidewaysSpeed = 0;
  //      }
 //       else if (Input.GetMouseButton(0))
 //       {
  //          Vector3 delta = mainCamera.ScreenToViewportPoint(Input.mousePosition) - lastInpitPos;
//            sidewaysSpeed += delta.x * Sensitivity;
 //           lastInpitPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
 //       }

 //       snakeHead.velocity = new Vector3(sidewaysSpeed * Sensitivity, 0, speed);

        float distance = (Head.position - positions[0]).magnitude;

        if (distance > SphereDiameter)
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
        GameObject newSegment = GameObject.Instantiate(SpherePrefab, positions[positions.Count - 1], Quaternion.identity, transform);
        Transform sphere = newSegment.transform;
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

    public void Die()
    {
        GameMonitor.OnPlayerDied();
        
    }
}
