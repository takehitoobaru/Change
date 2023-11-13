using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : MonoBehaviour,IPlayerState
{
    #region property
    public PlayerState PlayerState => _state;
    #endregion

    #region serialize
    [SerializeField]
    protected Player _player = default;
    #endregion

    #region protected
    protected PlayerState _state;
    #endregion

    #region public method
    public virtual void Entry() { }

    public virtual void UpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
