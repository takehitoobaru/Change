using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̃X�e�[�g�R���g���[���[
/// </summary>
public class PlayerStateController : MonoBehaviour
{
    #region property
    public IPlayerState CurrentState => _currentState;
    #endregion

    #region serialize
    [Tooltip("�T")]
    [SerializeField]
    private PlayerStateWolf _wolf = default;

    [Tooltip("�L")]
    [SerializeField]
    private PlayerStateShark _shark = default;

    [Tooltip("�h")]
    [SerializeField]
    private PlayerStateEagle _eagle = default;
    #endregion

    #region private
    /// <summary>�������p</summary>
    private bool _init = false;
    /// <summary>���݂̏��</summary>
    private IPlayerState _currentState;
    /// <summary>���O�̏��</summary>
    private IPlayerState _previousState;
    /// <summary>�e�[�u��</summary>
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

    public void FixedUpdateSequence() => _currentState?.FixedUpdateSequence();
    #endregion

    #region private method
    #endregion
}
