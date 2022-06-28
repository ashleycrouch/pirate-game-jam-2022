using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DitheringCameraScript : MonoBehaviour
{
    public Material ditherMat;
    public Material thresholdMat;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Creates a material for dithering with.
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        RenderTexture large = RenderTexture.GetTemporary(1640, 940, 0, RenderTextureFormat.ARGB32);
        RenderTexture main = RenderTexture.GetTemporary(820, 470, 0, RenderTextureFormat.ARGB32);
        large.filterMode = FilterMode.Bilinear;
        main.filterMode = FilterMode.Bilinear;

        Vector3[] corners = new Vector3[4];
        camera.CalculateFrustumCorners(new Rect(0,0,1,1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, corners);

        for(int i = 0; i < 4; i++) {
            corners[i] = transform.TransformVector(corners[i]);
            corners[i].Normalize();
        }
        Graphics.Blit(src, large, ditherMat);
        Graphics.Blit(large, main, thresholdMat);
        //Graphics.Blit(src, normal, mat);
        Graphics.Blit(main, dest);

        RenderTexture.ReleaseTemporary(large);
        RenderTexture.ReleaseTemporary(main);
    }
}
