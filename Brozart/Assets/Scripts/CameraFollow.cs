using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 targetVelocity, oldPositionTarget;

    void LateUpdate()
    {
        targetVelocity = target.position - oldPositionTarget;
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, 0.5f, 1.0f);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref targetVelocity, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
        oldPositionTarget = target.position;
    }

}
