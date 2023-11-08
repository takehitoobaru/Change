using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// スライム
/// </summary>
public class Slime : MonoBehaviour
{
    #region property
    public bool IsChase => _isChase;
    public bool IsAttack => _isAttack;
    public Transform Target => _target;
    public NavMeshAgent Agent => _agent;
    #endregion

    #region serialize
    [Tooltip("ステートコントローラー")]
    [SerializeField]
    private SlimeStateController _controller = default;
    #endregion

    #region private
    /// <summary>サーチエリアにプレイヤーがいるかどうか</summary>
    private bool _isChase = false;
    private bool _isAttack = false;
    /// <summary>プレイヤーのTransform</summary>
    private Transform _target;
    /// <summary>NavMeshAgent</summary>
    private NavMeshAgent _agent;
    #endregion

    #region unity methods
    private void Awake()
    {
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
    #endregion

    #region private method
    #endregion
}
