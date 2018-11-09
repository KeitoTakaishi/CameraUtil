using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackcs : MonoBehaviour {

    public Material material;

	void Start () {
		
	}
	
	void Update () {
        material.SetInt("FrameNum", Time.frameCount);
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
