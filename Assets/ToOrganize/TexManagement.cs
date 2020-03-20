using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexManagement : MonoBehaviour
{
    private Texture2D tex2D;
    private int cpt = 0;
    private Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[100*100];
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.red;
        }

        colors[100*100/2-50] = Color.green;
        colors[100 * 100 / 2 - 150+1] = Color.green;
        colors[100 * 100 / 2 - 150-1] = Color.green;
        colors[100 * 100 / 2 + 50-1] = Color.green;
        colors[100 * 100 / 2 + 50+1] = Color.green;

        tex2D = new Texture2D(100,100);
    }

    // Update is called once per frame
    void Update()
    {
        if(cpt%5==0)
            Colorize();
        cpt++;
        tex2D.SetPixels(colors);
        tex2D.Apply();
        this.GetComponent<Renderer>().material.SetTexture("_MainTex", tex2D);
    }

    void Colorize()
    {
        Color[] temp = new Color[colors.Length];
        colors.CopyTo(temp,0);
        int c = (int) Mathf.Sqrt(colors.Length);
        for (int i = 0; i < c; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (colors[c*i+j] == Color.green)
                {
                    if(i!=(c-1))
                        temp[c * (i+1) + j] = Color.green;
                    if(i!=0)
                        temp[c * (i - 1) + j] = Color.green;
                    if(j!=c-1)
                        temp[c * i + j+1] = Color.green;
                    if(j!=0)
                        temp[c * i + j-1] = Color.green;
                }
            }
        }
        colors = temp;
    }
}
