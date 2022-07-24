using UnityEngine;

public class SystemRoot<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    public virtual void InitSystem()
    {
        Instance = this as T;
    }
}