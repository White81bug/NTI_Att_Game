using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCube : MonoBehaviour
{
   public Collider cube;
    public SnakeController controller;

    private void OnCollisionEnter(Collision collision)
    {
        controller.Die();
    }
}
