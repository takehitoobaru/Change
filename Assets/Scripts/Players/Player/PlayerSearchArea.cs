using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchArea : MonoBehaviour
{
    #region property
    #endregion

    #region private
    private List<GameObject> _enemies = new List<GameObject>();
    #endregion

    #region unity methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other.gameObject);
        }
    }
    #endregion

    #region public method
    /// <summary>
    /// 一番近い敵のポジションを取得
    /// </summary>
    public Vector3 SetTarget()
    {
        Transform near = _enemies.First().transform;
        float distance = float.MaxValue;

        foreach (GameObject enemy in _enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < distance)
            {
                near = enemy.transform;
                distance = dist;
            }
        }

        return near.position;
    }

    /// <summary>
    /// Listに中身があるかどうか
    /// </summary>
    /// <returns></returns>
    public bool ListCheck()
    {
        if (_enemies?.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EnemyDestroy(GameObject go)
    {
        _enemies.Remove(go);
    }
    #endregion

    #region private method
    #endregion
}
