using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureTest : MonoBehaviour {
    private Texture2D texture;
    public RenderTexture tex;
    public GameObject plane;

    void Start () {
        //texture = new Texture2D(eyeCamera.targetTexture.width, eyeCamera.targetTexture.height, TextureFormat.RGB24, false);
        texture = TextureTest(tex);
        plane.GetComponent<MeshRenderer>().material.mainTexture = texture;
    }
	
	void Update () {
		
    }

   
    //private void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //   Graphics.Blit(source, destination, material);
    //}


    Camera renderCam;
    Texture2D TextureTest(RenderTexture rt)
    {

        /*
        Texture2D texture = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false, false);//textureの生成
        //renderCam.targetTexture = texture;
        //renderCam.Render();

        //RenderTexture.active = renderTex;//activeなrenderTextureを設定
        texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0, false);//読み込み
        texture.Apply();//適応

        renderCam.targetTexture = null;
        RenderTexture.active = null;
        return texture;
        */

        //reference
        RenderTexture curRT = RenderTexture.active;
        RenderTexture.active = rt;

        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        RenderTexture.active = curRT;
        return tex;
    }
}
