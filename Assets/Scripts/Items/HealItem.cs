using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‰ñ•œƒAƒCƒeƒ€
/// </summary>
public class HealItem : MonoBehaviour
{
    #region serialize
    [Tooltip("‰ñ•œ—Ê")]
    [SerializeField]
    private int _healAmount = 30;
    #endregion

    #region unity methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Heal(_healAmount);
            Destroy(gameObject);
        }
    }
    #endregion
}
