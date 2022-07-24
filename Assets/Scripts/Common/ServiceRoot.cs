using UnityEngine;

public class ServiceRoot<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }


    public virtual void InitService()
    {
        Instance = this as T;
    }
}