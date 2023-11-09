using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�v�[��
/// </summary>
public class ObjectPool : SingletonMonoBehaviour<ObjectPool>
{
    #region private
    /// <summary>�Q�[���I�u�W�F�N�g�̎���</summary>
    private Dictionary<string, Queue<GameObject>> _pooledGameObjects = new Dictionary<string, Queue<GameObject>>();
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion

    #region public method
    /// <summary>
    /// �I�u�W�F�N�g�̎擾�i�Ȃ���ΐ����j
    /// </summary>
    /// <param name="prefab">�g�p����I�u�W�F�N�g</param>
    /// <param name="pos">�ʒu</param>
    /// <returns></returns>
    public GameObject GetGameObject(GameObject prefab, Vector2 pos)
    {
        //�v���n�u�̖��O��key��
        string key = prefab.name;

        //Key�����݂��Ȃ���΍쐬
        if (_pooledGameObjects.ContainsKey(key) == false)
        {
            _pooledGameObjects.Add(key, new Queue<GameObject>());
        }

        Queue<GameObject> gameObjects = _pooledGameObjects[key];
        GameObject go = null;

        if (gameObjects.Count > 0)
        {
            //Queue�������o��
            go = gameObjects.Dequeue();
            //�ʒu��ݒ�
            go.transform.position = pos;
            //�A�N�e�B�u��
            go.SetActive(true);
        }
        else
        {
            //�V���ɍ쐬
            go = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            //clone�h�~
            go.name = prefab.name;
            //�q�ɐݒ�
            go.transform.parent = transform;
        }
        return go;
    }

    /// <summary>
    /// ��A�N�e�B�u��
    /// </summary>
    /// <param name="go"></param>
    public void ReleaseGameObject(GameObject go)
    {
        //��A�N�e�B�u�ɂ���
        go.SetActive(false);

        string key = go.name;
        Queue<GameObject> gameObjects = _pooledGameObjects[key];
        gameObjects.Enqueue(go);
    }
    #endregion
}
