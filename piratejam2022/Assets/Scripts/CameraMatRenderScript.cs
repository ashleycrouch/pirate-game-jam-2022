using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DitheringCameraScript : MonoBehaviour
{
    public Material ditherMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Creates a material for dithering with.
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // RenderTexture main = RenderTexture.GetTemporary(820, 470);
        // Graphics.Blit(src, main, ditherMat);
        // Graphics.Blit(main, dest);

        // RenderTexture.ReleaseTemporary(main);

        Graphics.Blit(src, dest, ditherMat);
    }
}
