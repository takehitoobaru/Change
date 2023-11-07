using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    private GameObject _target;
    private bool _isArea;
    private NavMeshAgent _agent;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (_isArea)
        {
            _target = GameObject.FindGameObjectWithTag("Player");
            _agent.destination = _target.transform.position;
        }
        else
        {
            _agent.destination = transform.position;
        }
    }
    #endregion

    #region public method
    /// <summary>
    /// 真偽の変更
    /// </summary>
    /// <param name="isArea">範囲内にターゲットがいるかどうか</param>
    public void ChangeIsArea(bool isArea)
    {
        _isArea = isArea;
    }
    #endregion

    #region private method
    #endregion
}
