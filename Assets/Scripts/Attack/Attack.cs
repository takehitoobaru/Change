using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        ObjectPool.Instance.ReleaseGameObject(gameObject);
    }
}
