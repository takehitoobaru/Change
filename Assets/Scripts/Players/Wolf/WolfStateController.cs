using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStateController : MonoBehaviour
{
    #region private
    private bool _init = false;
    private IWolfState _currentState;
    private IWolfState _previousState;
    private WolfStateIdle _idle;
    private WolfStateRun _run;
    private WolfStateAttack _attack;
    private WolfStateSpecialAttack _specialAttack;
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
    #endregion
}
