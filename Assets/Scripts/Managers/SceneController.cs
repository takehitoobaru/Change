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
    /// シーンを削除する
    /// </summary>
    /// <param name="sceneName">削除するシーン名</param>
    public void SceneUnLoad(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    /// <summary>
    /// シーンをロードする
    /// </summary>
    /// <param name="sceneName">ロードするシーン名</param>
    public void SceneLoad(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        scene.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    /// <summary>
    /// シーン変更
    /// </summary>
    /// <param name="currentScene">現在のシーン</param>
    /// <param name="nextScene">次のシーン</param>
    public void ChangeScene(string currentScene,string nextScene)
    {
        SceneUnLoad(currentScene);
        SceneLoad(nextScene);
    }
    #endregion

    #region private method
    #endregion
}
