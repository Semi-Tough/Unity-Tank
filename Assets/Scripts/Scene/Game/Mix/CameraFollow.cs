using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - FollowTarget.position;
    }

    private void LateUpdate()
    {
        if (FollowTarget)
        {
            transform.position = FollowTarget.position + offset;
        }
    }
}