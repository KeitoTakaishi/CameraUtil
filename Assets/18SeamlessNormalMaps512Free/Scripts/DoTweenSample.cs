using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenSample : MonoBehaviour {

	void Start ()
	{
		//this.transform.DOMove(new Vector3(5.0f, 1.5f, 1.5f), 15f);
		//this.transform.DOScale(new Vector3(0.5f, 0.5f, 2.0f), 15f);
		
		/*
		this.transform.DOLocalJump(
			Vector3.one,      // 移動終了地点
			1f,               // ジャンプする力
			3,               // ジャンプする回数
			15.0f              // アニメーション時間
		);
		*/
		
		this.transform.DOPunchScale(
			new Vector3(1.5f, 1.5f),    // scale1.5倍指定
			3.0f                        // アニメーション時間
		);
		
	}
	
	void Update () {
		
	}
}
