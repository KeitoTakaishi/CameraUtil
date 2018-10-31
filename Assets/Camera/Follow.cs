/*
 * targetを追うスクリプト
 * スネアの音でnextPosがくるのもあり？
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using  UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = System.Random;


public class Follow : MonoBehaviour
{
    #region Nested Classes
    public enum Interpolator{
        Lerp,
        Slerp,
        Expo
    }
    #endregion

    #region Editable Properties
    [SerializeField] Interpolator _interpolator;
    private Transform _target;
    [SerializeField]private int _interval = 60;
    private float t = 0.0f;
    
    [SerializeField]private float _radius = 15.0f;

    public Interpolator interpolator
    {
        get { return _interpolator; }
        set { _interpolator = value; }
    }

    public Transform target
    {
        get { return _target; }
        set { _target = value; }
    }

    public int Interval
    {
        get { return _interval; }
        set { _interval = value; }
    }

    public float Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }
    #endregion
    
    
    #region Private Properties
    Vector3 _nextPos, _curPos;
    [SerializeField] private AnimationCurve _anim;
    #endregion

    void Start()
    {
        _nextPos = new Vector3();
        _curPos = new Vector3();
    }
    
    private void Update()
    {
        var _dt = 1.0f / _interval;
        
        if (isInterval())
        {
            _nextPos = NextPos();
            _curPos = this.transform.position;
            t = 0.0f;
        }
        
        LookAt();
        
        if (_interpolator == Interpolator.Lerp)
        {
            this.transform.position = Vector3.Lerp(_curPos, _nextPos, t);
        }else if(_interpolator == Interpolator.Expo)
        {
            var val = _anim.Evaluate(t);
            this.transform.position = Interpolation(_curPos, _nextPos, val);
        }     
        
        t += _dt;
    }

    
    
    private Vector3 NextPos()
    {
        
        var _nextPos = UnityEngine.Random.insideUnitSphere * _radius;
        if (_nextPos.y < 0) _nextPos.y = UnityEngine.Random.Range(0.0f, _radius/2.0f);
        return _nextPos;
    }

    protected virtual void LookAt()
    {
        //毎フレームTargetの方向を向くようにする
        if(target == null) return;
        this.gameObject.transform.LookAt(target.transform.position);    
    }

    bool isInterval()
    {
        return Time.frameCount % _interval == 1;
    }

    private Vector3 Interpolation(Vector3 curPos, Vector3 nextPos, float t)
    {
        Debug.Log(t);
        Vector3 pos = (nextPos - curPos);
        pos = pos * t + curPos;

        
        return pos;
    }
}
