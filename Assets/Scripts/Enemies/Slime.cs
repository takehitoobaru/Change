using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �X���C��
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
    [Tooltip("�X�e�[�g�R���g���[���[")]
    [SerializeField]
    private SlimeStateController _controller = default;

    [SerializeField]
    private int _maxHP = 30;

    [SerializeField]
    private Element _element = Element.Water;
    #endregion

    #region private
    private int _hitPoint = 30;
    /// <summary>�҂�����</summary>
    private float _waitTime = 1f;
    /// <summary>�T�[�`�G���A�Ƀv���C���[�����邩�ǂ���</summary>
    private bool _isChase = false;
    /// <summary>�U���\�����Ƀv���C���[�����邩�ǂ���</summary>
    private bool _isAttack = false;
    /// <summary>�v���C���[��Transform</summary>
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
    /// Idle��ԂɈڍs
    /// </summary>
    public void Idle()
    {
        _controller.ChangeState(SlimeState.Idle);
    }

    /// <summary>
    /// Search��ԂɈڍs
    /// </summary>
    public void Search()
    {
        _controller.ChangeState(SlimeState.Search);
    }

    /// <summary>
    /// Chase��ԂɈڍs
    /// </summary>
    public void Chase()
    {
        _controller.ChangeState(SlimeState.Chase);
    }

    /// <summary>
    /// Attack��ԂɈڍs
    /// </summary>
    public void Attack()
    {
        _controller.ChangeState(SlimeState.Attack);
    }

    /// <summary>
    /// SpecialAttack��ԂɈڍs
    /// </summary>
    public void SpecialAttack()
    {
        _controller.ChangeState(SlimeState.Attack);
    }

    /// <summary>
    /// �^�[�Q�b�g�̎擾
    /// </summary>
    /// <param name="target">�擾����Transform</param>
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    /// <summary>
    /// �ǂ������邩�ǂ����̔���
    /// </summary>
    /// <param name="isChase">�^�U</param>
    public void ChangeIsChase(bool isChase)
    {
        _isChase = isChase;
    }

    /// <summary>
    /// �������f
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
    /// �҂����Ԃ̃Z�b�g
    /// </summary>
    /// <param name="waitTime">�҂�����</param>
    public void SetWaitTime(float waitTime)
    {
        _waitTime = waitTime;
    }

    public void Damage(int amount,Element element)
    {
        var damageAmount = amount;

        switch (element)
        {
            //�G�̍U�������̏ꍇ
            case Element.Fire:
                //���������̏ꍇ
                if (_element == Element.Water)
                {
                    damageAmount = amount / 2;
                }
                //���������̏ꍇ
                else if (_element == Element.Wind)
                {
                    damageAmount = amount * 2;
                }
                break;
            //�G�̍U�������̏ꍇ
            case Element.Water:
                //���������̏ꍇ
                if (_element == Element.Wind)
                {
                    damageAmount = amount / 2;
                }
                //���������̏ꍇ
                else if (_element == Element.Fire)
                {
                    damageAmount = amount * 2;
                }
                break;
            //�G�̍U�������̏ꍇ
            case Element.Wind:
                //���������̏ꍇ
                if (_element == Element.Fire)
                {
                    damageAmount = amount / 2;
                }
                //���������̏ꍇ
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
