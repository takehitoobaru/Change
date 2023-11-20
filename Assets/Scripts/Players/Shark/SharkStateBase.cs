using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shark�̏�Ԃ̃x�[�X�N���X
/// </summary>
public class SharkStateBase : MonoBehaviour,ISharkState
{
    #region property
    public SharkState SharkState => _state;
    #endregion

    #region serialize
    [Tooltip("�L")]
    [SerializeField]
    protected PlayerStateShark _shark = default;
    #endregion

    #region protected
    protected SharkState _state;
    #endregion

    #region public method
    public virtual void Entry() { }

    public virtual void UpdateSequence() { }

    public virtual void FixedUpdateSequence() { }

    public virtual void Exit() { }
    #endregion
}
