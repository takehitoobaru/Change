using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの状態のベースクラス
/// </summary>
public class PlayerStateBase : MonoBehaviour,IPlayerState
{
    #region property
    public PlayerState PlayerState => _state;
    public Player Player => _player;
    #endregion

    #region serialize
    [Tooltip("プレイヤー")]
    [SerializeField]
    protected Player _player = default;
    #endregion

    #region protected
    protected PlayerState _state;
    #endregion

    #region public method
    public virtual void Entry() { }

    public virtual void UpdateSequence() { }

    public virtual void FixedUpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
