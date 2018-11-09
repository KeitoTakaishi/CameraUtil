using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0.4f, 1, 0.7f), Time.deltaTime*150.0f);
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Time.frameCount % 30 == 1) {
            this.transform.localScale = new Vector3(Random.Range(1.0f, 3.0f), Random.Range(1.0f, 3.0f), Random.Range(1.0f, 3.0f));
         }
	}

   
}
