using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wolf�̃X�e�[�g�R���g���[���[
/// </summary>
public class WolfStateController : MonoBehaviour
{
    #region private
    /// <summary>�������p</summary>
    private bool _init = false;
    /// <summary>���݂̏��</summary>
    private IWolfState _currentState;
    /// <summary>���O�̏��</summary>
    private IWolfState _previousState;
    /// <summary>�ҋ@���</summary>
    private WolfStateIdle _idle;
    /// <summary>�ړ����</summary>
    private WolfStateRun _run;
    /// <summary>�U�����</summary>
    private WolfStateAttack _attack;
    /// <summary>����U�����</summary>
    private WolfStateSpecialAttack _specialAttack;
    /// <summary>�e�[�u��</summary>
    Dictionary<WolfState, IWolfState> _stateTable;
    #endregion

    #region unity methods
    private void Awake()
    {
        _idle = GetComponent<WolfStateIdle>();
        _run = GetComponent<WolfStateRun>();
        _attack = GetComponent<WolfStateAttack>();
        _specialAttack = GetComponent<WolfStateSpecialAttack>();
    }
    #endregion

    #region public method
    public void Init(WolfState initState)
    {
        if (_stateTable != null) return;

        Dictionary<WolfState, IWolfState> table = new()
        {
            { WolfState.Idle, _idle },
            { WolfState.Run, _run },
            { WolfState.Attack, _attack },
            { WolfState.SpecialAttack, _specialAttack},
        };
        _stateTable = table;
        ChangeState(initState);
        _init = true;
    }

    public void ChangeState(WolfState next)
    {
        if (_stateTable == null) return;
        if (_init)
        {
            if (_currentState == null || _currentState.WolfState == next) return;
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
