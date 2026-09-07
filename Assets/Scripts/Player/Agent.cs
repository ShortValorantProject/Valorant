using Unity.Cinemachine;
using UnityEngine;

public class Agent : ControlableObject
{
    [field: SerializeField] public Vector3 velocity {get; protected set;}
    public float moveSpeed =  10f;
    public float rotationSpeed = 720f;

    public CinemachineCamera agentCamera;

    [Range(0.001f, 10f)]
    public float playerSensitivity = .5f;

    protected Camera mainCamera;
    protected CinemachineBrain cinemachineBrain;

    public Vector2 cameraDamping = new Vector2(8f, 8f);
    float rotationX;
    float rotationY;
    float lastRotationX;
    float lastRotationY;


    protected void _Start()
    {
        mainCamera = Camera.main;
        cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();
    }

    public override void Move()
    {
        var cameraRelativeMoveDirection = CameraRelativeMouvement(mainCamera).normalized;
        var nextPosition = transform.position + cameraRelativeMoveDirection * moveSpeed * Time.deltaTime;
        var _deltaPosition = nextPosition - transform.position;
        velocity = _deltaPosition / Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    public override void LookAround()
    {
        rotationX += lookInputVector.x * playerSensitivity * rotationSpeed * Time.deltaTime;
        rotationY += lookInputVector.z * playerSensitivity * rotationSpeed * Time.deltaTime;

        var smoothFactors = Damp(new Vector2(lastRotationX, lastRotationY), new Vector2(rotationX, rotationY), cameraDamping);
        var newRotationX = smoothFactors.x;
        var newRotationY = smoothFactors.y;


        rotationX = Mathf.Repeat(rotationX, 360f);
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        agentCamera.transform.localRotation = Quaternion.Euler(-newRotationY, newRotationX, 0f); 
        transform.localRotation = Quaternion.Euler(0f, newRotationX, 0f);

        lastRotationX = newRotationX;
        lastRotationY = newRotationY;
    }
}

    // 1 -Mathf.Exp(-cameraDamping.x * Time.deltaTime) Exponmatial smoothing function.
