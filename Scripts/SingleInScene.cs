using UnityEngine;

public class SingleInScene<T> : MonoBehaviour where T : SingleInScene<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = this as T;
        else
            Destroy(gameObject);
    }
}