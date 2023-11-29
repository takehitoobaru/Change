using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �񕜃A�C�e��
/// </summary>
public class HealItem : MonoBehaviour
{
    #region serialize
    [Tooltip("�񕜗�")]
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
