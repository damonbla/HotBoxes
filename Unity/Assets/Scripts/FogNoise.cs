// this script is from http://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html
// edited for my own needs

using UnityEngine;
using System.Collections;

public class FogNoise : MonoBehaviour {
    public int pixWidth;
    public int pixHeight;
    public float xOrg;
    public float yOrg;
    public float scale = 1.0F;
    private Texture2D noiseTex;
    private Color[] pix;
    void Start() {
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        renderer.material.mainTexture = noiseTex;
    }
    void CalcNoise() {
        float y = 0.0F;
        while (y < noiseTex.height) {
            float x = 0.0F;
            while (x < noiseTex.width) {
                float xCoord = xOrg + x / noiseTex.width * scale + Time.time * 0.2f;
                float yCoord = yOrg + y / noiseTex.height * scale - Time.time * 0.2f;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample - 0.4f, sample - 0.2f, sample - 0.3f, sample - 0.2f);
                x++;
            }
            y++;
        }
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }
    void Update() {
        CalcNoise();
    }
}