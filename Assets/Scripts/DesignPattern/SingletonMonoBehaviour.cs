using UnityEngine;

/// <summary>
/// Singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "Ç™ÉVÅ[ÉìÇ…ë∂ç›ÇµÇ‹ÇπÇÒ");
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
