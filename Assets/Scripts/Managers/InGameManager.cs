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
    [Tooltip("タイムテキスト")]
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
    /// スコア加算
    /// </summary>
    /// <param name="amount">加算量</param>
    public void AddScore(int amount)
    {
        _score += amount;
    }

    /// <summary>
    /// 倒すべき敵の数が減少する
    /// </summary>
    public void DownEnemyNum()
    {
        _enemyNum--;
    }
    #endregion

    #region private method
    #endregion
}
