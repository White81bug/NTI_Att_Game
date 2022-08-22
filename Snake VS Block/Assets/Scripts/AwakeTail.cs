using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeTail : MonoBehaviour
{
    public SnakeTail Tail;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Tail.AddSphere();
        }
    }

}
