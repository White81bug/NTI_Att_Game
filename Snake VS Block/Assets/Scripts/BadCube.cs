using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCube : MonoBehaviour
{
   public Collider cube;
    public Snake Snake;

    private void OnCollisionEnter(Collision collision)
    {
        Snake.Die();
    }
}
