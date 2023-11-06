using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private float _rotateSpeed = 0.1f;
    #endregion

    #region private
    private float _horizontal;
    private float _vertical;
    private Rigidbody _rb;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Vector3 vel = new Vector3(_horizontal, 0, _vertical);
        Vector3 dir = vel.normalized;

        transform.forward = Vector3.Slerp(transform.forward, dir, _rotateSpeed);
    }

    private void FixedUpdate()
    {
        if (_horizontal == 0 && _vertical == 0) return;
        _rb.velocity = transform.forward * _speed;
    }
    #endregion

    #region public method
    #endregion

    #region private method
    #endregion
}
