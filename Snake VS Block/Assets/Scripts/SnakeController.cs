using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public Rigidbody snakeHead;
    private Camera mainCamera;

    private Vector3 lastInpitPos;
    private float sidewaysSpeed;
    public int speed;
    public float Sensitivity;

    public GameMonitor GameMonitor;
    public SnakeTail Tail;
    
    void Start()
    {
        snakeHead = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        Tail.AddSphere();
    }

   
    void Update()
    {
      
        if(Input.GetMouseButtonDown(0))
        {
           lastInpitPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = mainCamera.ScreenToViewportPoint(Input.mousePosition) - lastInpitPos;
            sidewaysSpeed += delta.x * Sensitivity;
            lastInpitPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
       
        snakeHead.velocity = new Vector3(sidewaysSpeed * Sensitivity, 0, speed);


    }

    public void Die()
    {
        GameMonitor.OnPlayerDied();
    }



}
