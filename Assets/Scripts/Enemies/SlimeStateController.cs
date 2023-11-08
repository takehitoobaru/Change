using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateController : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    private bool _init = false;
    private ISlimeState _currentState;
    private ISlimeState _previousState;
    private SlimeStateIdle _idle;
    private SlimeStateSearch _search;
    private SlimeStateChase _chase;
    private SlimeStateAttack _attack;
    private SlimeStateSpecialAttack _specialAttack;
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

    public void UpdateSequence() => _currentState?.UpdateSequence();
    #endregion
}
