using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1.5f, -3f);
    public float smoothSpeed = 1f;
    public float rotationSpeed = 2f;

    private float currentX = 0f;
    private float currentY = 0f;

    private void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, -20f, 50f);

        Vector3 desiredPosition = target.position + offset;
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = rotation;
    }
}
