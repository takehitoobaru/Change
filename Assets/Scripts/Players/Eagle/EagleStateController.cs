using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleStateController : MonoBehaviour
{
    #region private
    private bool _init = false;
    private IEagleState _currentState;
    private IEagleState _previousState;
    private EagleStateIdle _idle;
    private EagleStateRun _run;
    private EagleStateAttack _attack;
    private EagleStateSpecialAttack _specialAttack;
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
    #endregion
}
