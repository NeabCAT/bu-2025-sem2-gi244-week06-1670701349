using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;
    private float nextSpawnTime = 0f;

    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;
    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    private void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        

            if (enableAutoFireMode == true)
            {
                AutoSpawn();
                nextSpawnTime = Time.time + autoFireInterval;

            }
            else
            {
                if (shootAction.triggered)
                {
                    AutoSpawn();
                }

            }
       


    }
    void AutoSpawn()
    {
           
        Instantiate(projectilePrefab, transform.position, transform.rotation);

    }


    
}
