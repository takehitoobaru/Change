using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// スライム
/// </summary>
public class Slime : MonoBehaviour,IDamagable
{
    #region property
    public float WaitTime => _waitTime;
    public bool IsChase => _isChase;
    public bool IsAttack => _isAttack;
    public Transform Target => _target;
    public NavMeshAgent Agent => _agent;
    #endregion

    #region serialize
    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private SlimeStateController _controller = default;

    [SerializeField]
    private int _maxHP = 30;

    [SerializeField]
    private Element _element = Element.Water;
    #endregion

    #region private
    private int _hitPoint = 30;
    /// <summary>待ち時間</summary>
    private float _waitTime = 1f;
    /// <summary>サーチエリアにプレイヤーがいるかどうか</summary>
    private bool _isChase = false;
    /// <summary>攻撃可能距離にプレイヤーがいるかどうか</summary>
    private bool _isAttack = false;
    /// <summary>プレイヤーのTransform</summary>
    private Transform _target;
    /// <summary>NavMeshAgent</summary>
    private NavMeshAgent _agent;
    #endregion

    #region unity methods
    private void Awake()
    {
        _hitPoint = _maxHP;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _controller.Init(SlimeState.Idle);
    }

    private void Update()
    {
        _controller.UpdateSequence();
    }
    #endregion

    #region public method
    /// <summary>
    /// Idle状態に移行
    /// </summary>
    public void Idle()
    {
        _controller.ChangeState(SlimeState.Idle);
    }

    /// <summary>
    /// Search状態に移行
    /// </summary>
    public void Search()
    {
        _controller.ChangeState(SlimeState.Search);
    }

    /// <summary>
    /// Chase状態に移行
    /// </summary>
    public void Chase()
    {
        _controller.ChangeState(SlimeState.Chase);
    }

    /// <summary>
    /// Attack状態に移行
    /// </summary>
    public void Attack()
    {
        _controller.ChangeState(SlimeState.Attack);
    }

    /// <summary>
    /// SpecialAttack状態に移行
    /// </summary>
    public void SpecialAttack()
    {
        _controller.ChangeState(SlimeState.Attack);
    }

    /// <summary>
    /// ターゲットの取得
    /// </summary>
    /// <param name="target">取得するTransform</param>
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    /// <summary>
    /// 追いかけるかどうかの判定
    /// </summary>
    /// <param name="isChase">真偽</param>
    public void ChangeIsChase(bool isChase)
    {
        _isChase = isChase;
    }

    /// <summary>
    /// 距離判断
    /// </summary>
    public void CheckDistance()
    {
        if(Vector3.Distance(transform.position,_target.position) < 1)
        {
            _isAttack = true;
        }
        else
        {
            _isAttack = false;
        }
    }

    /// <summary>
    /// 待ち時間のセット
    /// </summary>
    /// <param name="waitTime">待ち時間</param>
    public void SetWaitTime(float waitTime)
    {
        _waitTime = waitTime;
    }

    public void Damage(int amount,Element element)
    {
        var damageAmount = amount;

        switch (element)
        {
            //敵の攻撃が炎の場合
            case Element.Fire:
                //自分が水の場合
                if (_element == Element.Water)
                {
                    damageAmount = amount / 2;
                }
                //自分が風の場合
                else if (_element == Element.Wind)
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
    }
    #endregion

    #region private method
    #endregion
}
