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
    [Tooltip("�^�C�g��BGM")]
    [SerializeField]
    private AudioClip _titleBGM = default;

    [Tooltip("�C���Q�[��BGM")]
    [SerializeField]
    private AudioClip _inGameBGM = default;

    [Tooltip("���U���gBGM")]
    [SerializeField]
    private AudioClip _resultBGM = default;

    [Tooltip("�U��SE")]
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
    /// SE�Đ�
    /// </summary>
    /// <param name="se">���ʉ�</param>
    public void PlaySE(AudioClip se)
    {
        _audio.PlayOneShot(se);
    }

    /// <summary>
    /// BGM�Đ�
    /// </summary>
    /// <param name="bgm">���y</param>
    public void PlayBGM(AudioClip bgm)
    {
        _audio.clip = bgm;
        _audio.Play();
    }

    /// <summary>
    /// BGM��~
    /// </summary>
    public void StopBGM()
    {
        _audio.Stop();
    }
    #endregion
}
