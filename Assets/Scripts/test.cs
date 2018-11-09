using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public RenderTexture renderTex;
    private Texture buffer;
    public Material material;

    void Start()
    {
    }

    void Update()
    {
        if (Time.frameCount % 3 == 1) {
            convertRenderTexToTex2D(renderTex);
        }
    }

    void convertRenderTexToTex2D(RenderTexture rt)
    {
        this.GetComponent<Camera>().targetTexture = rt;
        this.GetComponent<Camera>().Render();

        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false, false);
        RenderTexture.active = renderTex;
        tex.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        tex.Apply();
        material.SetTexture("_buffer", tex);
    }
}
