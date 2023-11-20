using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wolfのステートコントローラー
/// </summary>
public class WolfStateController : MonoBehaviour
{
    #region private
    /// <summary>初期化用</summary>
    private bool _init = false;
    /// <summary>現在の状態</summary>
    private IWolfState _currentState;
    /// <summary>直前の状態</summary>
    private IWolfState _previousState;
    /// <summary>待機状態</summary>
    private WolfStateIdle _idle;
    /// <summary>移動状態</summary>
    private WolfStateRun _run;
    /// <summary>攻撃状態</summary>
    private WolfStateAttack _attack;
    /// <summary>特殊攻撃状態</summary>
    private WolfStateSpecialAttack _specialAttack;
    /// <summary>テーブル</summary>
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
