using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eagleのステートコントローラー
/// </summary>
public class EagleStateController : MonoBehaviour
{
    #region private
    /// <summary>初期化用</summary>
    private bool _init = false;
    /// <summary>現在の状態</summary>
    private IEagleState _currentState;
    /// <summary>直前の状態</summary>
    private IEagleState _previousState;
    /// <summary>待機状態</summary>
    private EagleStateIdle _idle;
    /// <summary>移動状態</summary>
    private EagleStateRun _run;
    /// <summary>攻撃状態</summary>
    private EagleStateAttack _attack;
    /// <summary>特殊攻撃状態</summary>
    private EagleStateSpecialAttack _specialAttack;
    /// <summary>テーブル</summary>
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
