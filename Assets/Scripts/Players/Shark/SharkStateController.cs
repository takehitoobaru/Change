using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sharkのステートコントローラー
/// </summary>
public class SharkStateController : MonoBehaviour
{
    #region private
    /// <summary>初期化用</summary>
    private bool _init = false;
    /// <summary>現在の状態</summary>
    private ISharkState _currentState;
    /// <summary>直前の状態</summary>
    private ISharkState _previousState;
    /// <summary>待機状態</summary>
    private SharkStateIdle _idle;
    /// <summary>移動状態</summary>
    private SharkStateRun _run;
    /// <summary>攻撃状態</summary>
    private SharkStateAttack _attack;
    /// <summary>特殊攻撃状態</summary>
    private SharkStateSpecialAttack _specialAttack;
    /// <summary>テーブル</summary>
    Dictionary<SharkState, ISharkState> _stateTable;
    #endregion

    #region unity methods
    private void Awake()
    {
        _idle = GetComponent<SharkStateIdle>();
        _run = GetComponent<SharkStateRun>();
        _attack = GetComponent<SharkStateAttack>();
        _specialAttack = GetComponent<SharkStateSpecialAttack>();
    }
    #endregion

    #region public method
    public void Init(SharkState initState)
    {
        if (_stateTable != null) return;

        Dictionary<SharkState, ISharkState> table = new()
        {
            { SharkState.Idle, _idle },
            { SharkState.Run, _run },
            { SharkState.Attack, _attack },
            { SharkState.SpecialAttack, _specialAttack },
        };
        _stateTable = table;
        ChangeState(initState);
        _init = true;
    }

    public void ChangeState(SharkState next)
    {
        if (_stateTable == null) return;
        if (_init)
        {
            if (_currentState == null || _currentState.SharkState == next) return;
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
