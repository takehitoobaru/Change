using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[
/// </summary>
public class Player : MonoBehaviour,IDamagable
{
    #region property
    public float Horizontal => _horizontal;
    public float Vertical => _vertical;
    public bool IsAttack => _isAttack;
    public Vector3 TargetPos => _targetPos;
    #endregion

    #region serialize
    [Tooltip("�ő�̗�")]
    [SerializeField]
    private int _maxHP = 100;

    [Tooltip("�X�e�[�g�R���g���[���[")]
    [SerializeField]
    private PlayerStateController _controller = default;

    [Tooltip("�`�F���W�{�^��")]
    [SerializeField]
    private Button _changeButton = default;

    [Tooltip("HP�o�[")]
    [SerializeField]
    private Slider _hpBar = default;

    [Tooltip("�T�[�`�G���A")]
    [SerializeField]
    private PlayerSearchArea _search = default;
    #endregion

    #region private
    /// <summary>�̗�</summary>
    private int _hitPoint = 100;
    /// <summary>����</summary>
    private Element _element = Element.Fire;
    /// <summary>���̓���</summary>
    private float _horizontal = 0;
    /// <summary>�c�̓���</summary>
    private float _vertical = 0;
    /// <summary>�U���\���ǂ���</summary>
    private bool _isAttack = false;
    /// <summary>��ԋ߂��G�̃|�W�V����</summary>
    private Vector3 _targetPos;
    /// <summary>����</summary>
    private Rigidbody _rb;
    /// <summary>�R���C�_�[</summary>
    private CapsuleCollider _col;
    #endregion

    #region Constant
    /// <summary>�T�̃R���C�_�[�̒l</summary>
    private const float WOLF_COL_CENTER_X = 0;
    private const float WOLF_COL_CENTER_Y = -0.28f;
    private const float WOLF_COL_CENTER_Z = 0.2671609f;
    private const float WOLF_COL_RADIUS = 0.4128256f;
    private const float WOLF_COL_HEIGHT = 1.534322f;

    /// <summary>�L�̃R���C�_�[�̒l</summary>
    private const float SHARK_COL_CENTER_X = 0;
    private const float SHARK_COL_CENTER_Y = -0.28f;
    private const float SHARK_COL_CENTER_Z = 0.155148f;
    private const float SHARK_COL_RADIUS = 0.4128256f;
    private const float SHARK_COL_HEIGHT = 2.670787f;

    /// <summary>�h�̃R���C�_�[�̒l</summary>
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
        _changeButton.onClick.AddListener(OnClickChange);
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

        if(_hitPoint <= 0 || transform.position.y <= -10)
        {
            SoundManager.Instance.StopBGM();
            GameManager.Instance.SetScore(InGameManager.Instance.Score);
            SceneController.Instance.ChangeScene("InGame", "Result");
        }
    }

    private void FixedUpdate()
    {
        _controller.FixedUpdateSequence();
    }
    #endregion

    #region public method
    /// <summary>
    /// State��Wolf�ɕύX����
    /// </summary>
    public void ChangeWolf()
    {
        _element = Element.Fire;
        _controller.ChangeState(PlayerState.Wolf);
    }

    /// <summary>
    /// State��Shark�ɕύX����
    /// </summary>
    public void ChangeShark()
    {
        _element = Element.Water;
        _controller.ChangeState(PlayerState.Shark);
    }

    /// <summary>
    /// State��Eagle�ɕύX����
    /// </summary>
    public void ChangeEagle()
    {
        _element = Element.Wind;
        _controller.ChangeState(PlayerState.Eagle);
    }

    /// <summary>
    /// �v���C���[�̉�]
    /// </summary>
    /// <param name="rotateSpeed">��]���x</param>
    public void PlayerRotate(float rotateSpeed)
    {
        Vector3 vel = new Vector3(_horizontal, 0, _vertical);
        Vector3 dir = vel.normalized;

        transform.forward = Vector3.Slerp(transform.forward, dir, rotateSpeed);
    }

    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    /// <param name="speed">�X�s�[�h</param>
    public void PlayerMove(float speed)
    {
        _rb.velocity = transform.forward * speed;
    }

    /// <summary>
    /// �T�[�`�G���A�̏��擾
    /// </summary>
    public void GetSearchInfo()
    {
        _isAttack = _search.ListCheck();
        if (_isAttack == true)
        {
            _targetPos = _search.SetTarget();
        }
    }

    /// <summary>
    /// �_���[�W���󂯂鏈��
    /// </summary>
    /// <param name="amount">�_���[�W��</param>
    public void Damage(int amount,Element element)
    {
        SoundManager.Instance.PlaySE(SoundManager.Instance.AttackSE);

        var damageAmount = amount;

        switch (element)
        {
            //�G�̍U�������̏ꍇ
            case Element.Fire:
                //���������̏ꍇ
                if(_element == Element.Water)
                {
                    damageAmount = amount / 2;
                }
                //���������̏ꍇ
                else if(_element == Element.Wind)
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
        _hpBar.value = _hitPoint;
    }

    /// <summary>
    /// ��
    /// </summary>
    /// <param name="amount">�񕜗�</param>
    public void Heal(int amount)
    {
        _hitPoint += amount;
        //�̗͏���𒴂����ꍇ
        if(_hitPoint > _maxHP)
        {
            _hitPoint = _maxHP;
        }

        _hpBar.value = _hitPoint;
    }
    #endregion

    #region private method
    /// <summary>
    /// ���{�^�����������ꍇ
    /// </summary>
    private void OnClickChange()
    {
        switch (_controller.CurrentState)
        {
            case PlayerStateWolf:
                _col.center = new Vector3(SHARK_COL_CENTER_X, SHARK_COL_CENTER_Y, SHARK_COL_CENTER_Z);
                _col.radius = SHARK_COL_RADIUS;
                _col.height = SHARK_COL_HEIGHT;
                ChangeShark();
                break;
            case PlayerStateShark:
                _col.center = new Vector3(EAGLE_COL_CENTER_X, EAGLE_COL_CENTER_Y, EAGLE_COL_CENTER_Z);
                _col.radius = EAGLE_COL_RADIUS;
                _col.height = EAGLE_COL_HEIGHT;
                ChangeEagle();
                break;
            case PlayerStateEagle:
                _col.center = new Vector3(WOLF_COL_CENTER_X, WOLF_COL_CENTER_Y, WOLF_COL_CENTER_Z);
                _col.radius = WOLF_COL_RADIUS;
                _col.height = WOLF_COL_HEIGHT;
                ChangeWolf();
                break;
            default:
                break;
        }
    }
    #endregion
}
