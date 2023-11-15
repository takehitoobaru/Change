using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private PlayerStateController _controller = default;
    #endregion

    #region private
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {

    }

    private void Start()
    {
        _controller.Init(PlayerState.Wolf);
    }

    private void Update()
    {
        _controller.UpdateSequence();
    }
    #endregion

    #region public method
    public void ChangeWolf()
    {
        _controller.ChangeState(PlayerState.Wolf);
    }

    public void ChangeShark()
    {
        _controller.ChangeState(PlayerState.Shark);
    }

    public void ChangeEagle()
    {
        _controller.ChangeState(PlayerState.Eagle);
    }
    #endregion

    #region private method
    #endregion
}
