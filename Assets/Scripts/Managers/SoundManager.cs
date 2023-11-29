using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    #region property
    public AudioClip TitleBGM => _titleBGM;
    public AudioClip InGameBGM => _inGameBGM;
    public AudioClip ResultBGM => _resultBGM;
    public AudioClip AttackSE => _attackSE;
    #endregion

    #region serialize
    [Tooltip("タイトルBGM")]
    [SerializeField]
    private AudioClip _titleBGM = default;

    [Tooltip("インゲームBGM")]
    [SerializeField]
    private AudioClip _inGameBGM = default;

    [Tooltip("リザルトBGM")]
    [SerializeField]
    private AudioClip _resultBGM = default;

    [Tooltip("攻撃SE")]
    [SerializeField]
    private AudioClip _attackSE = default;
    #endregion

    #region private
    private AudioSource _audio;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        _audio = GetComponent<AudioSource>();
    }
    #endregion

    #region public method
    /// <summary>
    /// SE再生
    /// </summary>
    /// <param name="se">効果音</param>
    public void PlaySE(AudioClip se)
    {
        _audio.PlayOneShot(se);
    }

    /// <summary>
    /// BGM再生
    /// </summary>
    /// <param name="bgm">音楽</param>
    public void PlayBGM(AudioClip bgm)
    {
        _audio.clip = bgm;
        _audio.Play();
    }

    /// <summary>
    /// BGM停止
    /// </summary>
    public void StopBGM()
    {
        _audio.Stop();
    }
    #endregion
}
