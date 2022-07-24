using UnityEngine;

public class AutoRecovery : MonoBehaviour
{
    public float LifeTime;

    private void OnEnable()
    {
        Invoke(nameof(RecoveryEffect), LifeTime);
    }

    private void RecoveryEffect()
    {
        gameObject.SetActive(false);
    }
}