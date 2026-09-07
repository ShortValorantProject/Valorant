using UnityEngine;

public abstract class ControlableObject : MonoBehaviour
{
    public Vector3 moveInputVector => new Vector3(GameInputs.Instance.MoveVector.x, 0, GameInputs.Instance.MoveVector.y);
    public Vector3 lookInputVector => new Vector3(GameInputs.Instance.LookVector.x, 0, GameInputs.Instance.LookVector.y);

    public abstract void Move();
    public abstract void LookAround();
    
    public Vector3 CameraRelativeMouvement(Camera camera)
    {
        var cameraForward = camera.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        var cameraRight = camera.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        var moveDirection = cameraForward * moveInputVector.z + cameraRight * moveInputVector.x;

        return moveDirection;
    }

    public static Vector2 Damp(Vector2 current, Vector2 target, Vector2 damping, bool isLerpAngle = true)
    {
        float xFactor = 1 - Mathf.Exp(-damping.x * Time.deltaTime);
        float yFactor = 1 - Mathf.Exp(-damping.y * Time.deltaTime);

        float newX = isLerpAngle ? Mathf.LerpAngle(current.x, target.x, xFactor) : Mathf.Lerp(current.x, target.x, xFactor);
        float newY = isLerpAngle ? Mathf.LerpAngle(current.y, target.y, yFactor) : Mathf.Lerp(current.y, target.y, yFactor);

        return new Vector2(newX, newY);
    }
}
