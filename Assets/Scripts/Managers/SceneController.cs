using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion

    #region public method
    /// <summary>
    /// �V�[�����폜����
    /// </summary>
    /// <param name="sceneName">�폜����V�[����</param>
    public void SceneUnLoad(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    /// <summary>
    /// �V�[�������[�h����
    /// </summary>
    /// <param name="sceneName">���[�h����V�[����</param>
    public void SceneLoad(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        scene.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    /// <summary>
    /// �V�[���ύX
    /// </summary>
    /// <param name="currentScene">���݂̃V�[��</param>
    /// <param name="nextScene">���̃V�[��</param>
    public void ChangeScene(string currentScene,string nextScene)
    {
        SceneUnLoad(currentScene);
        SceneLoad(nextScene);
    }
    #endregion

    #region private method
    #endregion
}
