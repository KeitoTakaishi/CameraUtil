using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
   
    public Material material;

    void Start()
    {
    }

    void Update()
    {
        //convertRenderTexToTex2D(renderTex);
    }

   

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
