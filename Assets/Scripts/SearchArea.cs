using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var parent = transform.parent.GetComponent<EnemyControll>();

            parent.ChangeIsArea(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var parent = transform.parent.GetComponent<EnemyControll>();

            parent.ChangeIsArea(false);
        }
    }
    #endregion

    #region public method
    #endregion

    #region private method
    #endregion
}
