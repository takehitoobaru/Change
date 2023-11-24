using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wolf�̏�Ԃ̃x�[�X�N���X
/// </summary>
public class WolfStateBase : MonoBehaviour,IWolfState
{
    #region property
    public WolfState WolfState => _state;
    #endregion

    #region serialize
    [Tooltip("�T")]
    [SerializeField]
    protected PlayerStateWolf _wolf = default;
    #endregion

    #region protected
    protected WolfState _state;
    #endregion

    #region public method
    public virtual void Entry() 
    {
        Debug.Log(_state);
    }

    public virtual void UpdateSequence() { }

    public virtual void FixedUpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
