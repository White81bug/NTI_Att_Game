using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float CameraOffset;

    
    void Update()
    {
        Vector3 position = transform.position;
        position.z = Target.position.z + CameraOffset;
        transform.position = position;
    }
}
