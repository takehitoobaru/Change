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
    private const float WOLF_COL_CENTER_X = 0;
    private const float WOLF_COL_CENTER_Y = -0.28f;
    private const float WOLF_COL_CENTER_Z = 0.2671609f;
    private const float WOLF_COL_RADIUS = 0.4128256f;
    private const float WOLF_COL_HEIGHT = 1.534322f;

    private const float SHARK_COL_CENTER_X = 0;
    private const float SHARK_COL_CENTER_Y = -0.28f;
    private const float SHARK_COL_CENTER_Z = 0.155148f;
    private const float SHARK_COL_RADIUS = 0.4128256f;
    private const float SHARK_COL_HEIGHT = 2.670787f;

    private const float EAGLE_COL_CENTER_X = 0;
    private const float EAGLE_COL_CENTER_Y = -0.28f;
    private const float EAGLE_COL_CENTER_Z = 0.2671609f;
    private const float EAGLE_COL_RADIUS = 0.4128256f;
    private const float EAGLE_COL_HEIGHT = 1.534322f;
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
