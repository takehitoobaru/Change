using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー
/// </summary>
public class Player : MonoBehaviour,IDamagable
{
    #region property
    public float Horizontal => _horizontal;
    public float Vertical => _vertical;
    #endregion

    #region serialize
    [Tooltip("最大体力")]
    [SerializeField]
    private int _maxHP = 100;

    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private PlayerStateController _controller = default;
    #endregion

    #region private
    /// <summary>体力</summary>
    private int _hitPoint = 100;
    /// <summary>属性</summary>
    private Element _element = Element.Fire;
    /// <summary>横の入力</summary>
    private float _horizontal = 0;
    /// <summary>縦の入力</summary>
    private float _vertical = 0;
    /// <summary>剛体</summary>
    private Rigidbody _rb;
    /// <summary>コライダー</summary>
    private CapsuleCollider _col;
    #endregion

    #region Constant
    /// <summary>狼のコライダーの値</summary>
    private const float WOLF_COL_CENTER_X = 0;
    private const float WOLF_COL_CENTER_Y = -0.28f;
    private const float WOLF_COL_CENTER_Z = 0.2671609f;
    private const float WOLF_COL_RADIUS = 0.4128256f;
    private const float WOLF_COL_HEIGHT = 1.534322f;

    /// <summary>鮫のコライダーの値</summary>
    private const float SHARK_COL_CENTER_X = 0;
    private const float SHARK_COL_CENTER_Y = -0.28f;
    private const float SHARK_COL_CENTER_Z = 0.155148f;
    private const float SHARK_COL_RADIUS = 0.4128256f;
    private const float SHARK_COL_HEIGHT = 2.670787f;

    /// <summary>鷲のコライダーの値</summary>
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
        _hitPoint = _maxHP;
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        _controller.Init(PlayerState.Wolf);
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _controller.UpdateSequence();
    }

    private void FixedUpdate()
    {
        _controller.FixedUpdateSequence();
    }
    #endregion

    #region public method
    /// <summary>
    /// StateをWolfに変更する
    /// </summary>
    public void ChangeWolf()
    {
        _element = Element.Fire;
        _controller.ChangeState(PlayerState.Wolf);
    }

    /// <summary>
    /// StateをSharkに変更する
    /// </summary>
    public void ChangeShark()
    {
        _element = Element.Water;
        _controller.ChangeState(PlayerState.Shark);
    }

    /// <summary>
    /// StateをEagleに変更する
    /// </summary>
    public void ChangeEagle()
    {
        _element = Element.Wind;
        _controller.ChangeState(PlayerState.Eagle);
    }

    /// <summary>
    /// プレイヤーの回転
    /// </summary>
    /// <param name="rotateSpeed">回転速度</param>
    public void PlayerRotate(float rotateSpeed)
    {
        Vector3 vel = new Vector3(_horizontal, 0, _vertical);
        Vector3 dir = vel.normalized;

        transform.forward = Vector3.Slerp(transform.forward, dir, rotateSpeed);
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    /// <param name="speed">スピード</param>
    public void PlayerMove(float speed)
    {
        _rb.velocity = transform.forward * speed;
    }

    /// <summary>
    /// ダメージを受ける処理
    /// </summary>
    /// <param name="amount">ダメージ量</param>
    public void Damage(int amount,Element element)
    {
        var damageAmount = amount;

        switch (element)
        {
            //敵の攻撃が炎の場合
            case Element.Fire:
                //自分が水の場合
                if(_element == Element.Water)
                {
                    damageAmount = amount / 2;
                }
                //自分が風の場合
                else if(_element == Element.Wind)
                {
                    damageAmount = amount * 2;
                }
                break;
            //敵の攻撃が水の場合
            case Element.Water:
                //自分が風の場合
                if (_element == Element.Wind)
                {
                    damageAmount = amount / 2;
                }
                //自分が炎の場合
                else if (_element == Element.Fire)
                {
                    damageAmount = amount * 2;
                }
                break;
            //敵の攻撃が風の場合
            case Element.Wind:
                //自分が炎の場合
                if (_element == Element.Fire)
                {
                    damageAmount = amount / 2;
                }
                //自分が水の場合
                else if (_element == Element.Water)
                {
                    damageAmount = amount * 2;
                }
                break;
            default:
                break;
        }

        _hitPoint -= damageAmount;
        Debug.Log(_hitPoint);
    }
    #endregion

    #region private method
    #endregion
}
