using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スライムのステートコントローラー
/// </summary>
public class SlimeStateController : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    /// <summary>初期化用</summary>
    private bool _init = false;
    /// <summary>現在の状態</summary>
    private ISlimeState _currentState;
    /// <summary>直前の状態</summary>
    private ISlimeState _previousState;
    /// <summary>待機状態コンポーネント</summary>
    private SlimeStateIdle _idle;
    /// <summary>探索状態コンポーネント</summary>
    private SlimeStateSearch _search;
    /// <summary>追跡状態コンポーネント</summary>
    private SlimeStateChase _chase;
    /// <summary>攻撃状態コンポーネント</summary>
    private SlimeStateAttack _attack;
    /// <summary>特殊攻撃状態コンポーネント</summary>
    private SlimeStateSpecialAttack _specialAttack;
    /// <summary>テーブル</summary>
    Dictionary<SlimeState, ISlimeState> _stateTable;
    #endregion

    private void Awake()
    {
        _idle = GetComponent<SlimeStateIdle>();
        _search = GetComponent<SlimeStateSearch>();
        _chase = GetComponent<SlimeStateChase>();
        _attack = GetComponent<SlimeStateAttack>();
        _specialAttack = GetComponent<SlimeStateSpecialAttack>();
    }

    #region public method
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="initState">最初の状態</param>
    public void Init(SlimeState initState)
    {
        if (_stateTable != null) return;

        Dictionary<SlimeState, ISlimeState> table = new()
        {
            { SlimeState.Idle, _idle },
            { SlimeState.Search, _search },
            { SlimeState.Chase, _chase },
            { SlimeState.Attack, _attack },
            { SlimeState.SpecialAttack, _specialAttack },
        };
        _stateTable = table;
        ChangeState(initState);
        _init = true;
    }

    /// <summary>
    /// 状態変更
    /// </summary>
    /// <param name="next">次の状態</param>
    public void ChangeState(SlimeState next)
    {
        if (_stateTable == null) return;
        if (_init)
        {
            if (_currentState == null || _currentState.SlimeState == next) return;
        }

        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();
    }

    /// <summary>
    /// 現在の状態のUpdateを実行
    /// </summary>
    public void UpdateSequence() => _currentState?.UpdateSequence();
    #endregion
}
