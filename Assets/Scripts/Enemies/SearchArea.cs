using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サーチエリア
/// </summary>
public class SearchArea : MonoBehaviour
{
    #region serialize
    [Tooltip("スライム")]
    [SerializeField]
    private Slime _slime = default;
    #endregion

    #region unity methods
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _slime.SetTarget(other.transform);
            _slime.ChangeIsChase(true);
            _slime.CheckDistance();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _slime.ChangeIsChase(false);   
        }
    }
    #endregion
}
