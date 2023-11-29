using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    #region property
    public int Score => _score;
    #endregion

    #region serialize
    [Tooltip("�^�C���e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _timeText = default;
    #endregion

    #region private
    private int _score = 0;
    private int _enemyNum = 5;
    private float _limitTime = 180f;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(SoundManager.Instance.InGameBGM);
    }

    private void Update()
    {
        _limitTime -= Time.deltaTime;

        _timeText.text = "Time:" + _limitTime.ToString("F0");

        if(_limitTime <= 0 || _enemyNum <= 0)
        {
            SoundManager.Instance.StopBGM();
            GameManager.Instance.SetScore(_score);
            SceneController.Instance.ChangeScene("InGame", "Result");
        }
    }
    #endregion

    #region public method
    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="amount">���Z��</param>
    public void AddScore(int amount)
    {
        _score += amount;
    }

    /// <summary>
    /// �|���ׂ��G�̐�����������
    /// </summary>
    public void DownEnemyNum()
    {
        _enemyNum--;
    }
    #endregion

    #region private method
    #endregion
}
