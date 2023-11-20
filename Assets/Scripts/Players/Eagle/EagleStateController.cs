using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eagle�̃X�e�[�g�R���g���[���[
/// </summary>
public class EagleStateController : MonoBehaviour
{
    #region private
    /// <summary>�������p</summary>
    private bool _init = false;
    /// <summary>���݂̏��</summary>
    private IEagleState _currentState;
    /// <summary>���O�̏��</summary>
    private IEagleState _previousState;
    /// <summary>�ҋ@���</summary>
    private EagleStateIdle _idle;
    /// <summary>�ړ����</summary>
    private EagleStateRun _run;
    /// <summary>�U�����</summary>
    private EagleStateAttack _attack;
    /// <summary>����U�����</summary>
    private EagleStateSpecialAttack _specialAttack;
    /// <summary>�e�[�u��</summary>
    Dictionary<EagleState, IEagleState> _stateTable;
    #endregion

    #region unity methods
    private void Awake()
    {
        _idle = GetComponent<EagleStateIdle>();
        _run = GetComponent<EagleStateRun>();
        _attack = GetComponent<EagleStateAttack>();
        _specialAttack = GetComponent<EagleStateSpecialAttack>();
    }
    #endregion

    #region public method
    public void Init(EagleState initState)
    {
        if (_stateTable != null) return;

        Dictionary<EagleState, IEagleState> table = new()
        {
            { EagleState.Idle, _idle },
            { EagleState.Run, _run },
            { EagleState.Attack, _attack },
            { EagleState.SpecialAttack, _specialAttack },
        };
        _stateTable = table;
        ChangeState(initState);
        _init = true;
    }

    public void ChangeState(EagleState next)
    {
        if (_stateTable == null) return;
        if (_init)
        {
            if (_currentState == null || _currentState.EagleState == next) return;
        }

        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();

    }

    public void UpdateSequence() => _currentState?.UpdateSequence();

    public void FixedUpdateSequence() => _currentState?.FixedUpdateSequence();
    #endregion
}
