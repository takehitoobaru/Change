using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    #region serialize
    [SerializeField]
    private PlayerStateWolf _wolf = default;

    [SerializeField]
    private PlayerStateShark _shark = default;

    [SerializeField]
    private PlayerStateEagle _eagle = default;
    #endregion

    #region private
    private bool _init = false;
    private IPlayerState _currentState;
    private IPlayerState _previousState;
    Dictionary<PlayerState, IPlayerState> _stateTable;
    #endregion

    #region public method
    public void Init(PlayerState initState)
    {
        if (_stateTable != null) return;

        Dictionary<PlayerState, IPlayerState> table = new()
        {
            { PlayerState.Wolf, _wolf },
            { PlayerState.Shark, _shark },
            { PlayerState.Eagle, _eagle },
        };
        _stateTable = table;
        ChangeState(initState);
        _init = true;
    }

    public void ChangeState(PlayerState next)
    {
        if (_stateTable == null) return;
        if (_init)
        {
            if (_currentState == null || _currentState.PlayerState == next) return;
        }

        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();

    }

    public void UpdateSequence() => _currentState?.UpdateSequence();
    #endregion

    #region private method
    #endregion
}
