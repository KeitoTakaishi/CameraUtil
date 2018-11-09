using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RadiationBlur : MonoBehaviour {

    const string SHADER_NAME = "Hidden/RadiationBlur";
    public Vector2 center = new Vector2(0.5f, 0.5f);
    [Range(0, 100)]
    public float power = 0f;
    [SerializeField, HideInInspector]
    private Shader _shader;


    public Shader shader
    {
        get {
            if(_shader == null){
                _shader = Shader.Find(SHADER_NAME);
            }
            return _shader;
        }
    }
    private Material _material;

    public Material material
    {
        get {
            if(_material == null) {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.DontSave;
            }
            return _material;
        }
    }


    private void OnDisable()
    {
        if (_material != null)
            DestroyImmediate(_material);
        _material = null;
    }

    int m_PID_blurCenter = -1;
    int m_PID_blurPower = -1;

    private void Awake()
    {
        m_PID_blurCenter = Shader.PropertyToID("_BlurCenter");
        m_PID_blurPower = Shader.PropertyToID("_BlurPower");
    }

    private void Update()
    {
        if(Time.frameCount % 60 == 1) {
            power = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            power = Random.Range(0, 30.0f);
        }
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetVector(m_PID_blurCenter, center);
        material.SetFloat(m_PID_blurPower, power);
        Graphics.Blit(source, destination, material);
    }
}
