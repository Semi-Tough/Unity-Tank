using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float RotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
    }
}