﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public RootBluePrint root;

    private SpriteRenderer rangeSpriteRenderer;
    private GameObject[] spots;

    private bool hoverEnabled = true;

    BuildManager buildManager;
    RaycastHit hit;
    Ray ray;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // prevent the parrent from scaling the children
        transform.GetChild(0).parent = null;

        root.range = 2 * transform.localScale.y;

        rangeSpriteRenderer.transform.localScale = new Vector3(root.range * 2f, root.range * 2f, -0.05f);

        HideRange();

        float ratio = Convert.ToInt32(transform.localScale.y) / 30 + 2;
        spots = new GameObject[(int)ratio];
        
        if(ratio <= 1)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.localScale = new Vector3(1.1f, 1 / ratio, 1.1f);
            go.transform.position = new Vector3(0, 2f, 0);
            go.transform.localPosition = new Vector3(0, (1 / ratio) * 2 - 1, 0);
            go.name = "spot " + 1;
            go.AddComponent<Spot>();
            go.transform.SetParent(transform, false);
            spots[0] = go;
        }
        else
        {
            for (float i = 1; i < ratio; i++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.transform.localScale = new Vector3(1.1f, 1 / ratio, 1.1f);
                go.transform.position = new Vector3(0, 2f, 0);
                go.transform.localPosition = new Vector3(0, (i / ratio) * 2 - 1, 0);
                go.name = "spot " + i;
                go.AddComponent<Spot>();
                go.transform.SetParent(transform, false);
                spots[(int)i - 1] = go;
            }
        }
        
        buildManager = BuildManager.instance;

    }

    private void Update()
    {
        
    }

    private void HideRange()
    {
        rangeSpriteRenderer.enabled = false;
    }

    private void ShowRange()
    {
        rangeSpriteRenderer.enabled = true;
    }

    private void OnMouseDown()
    {
        ShowRange();
        hoverEnabled = false;
        // on construit a partir des spots de la racine, pas du centre de la racine
        //buildManager.expandableGo = gameObject;
    }

    private void OnMouseEnter()
    {
        if(hoverEnabled)
            ShowRange();
    }

    private void OnMouseExit()
    {
        if (hoverEnabled)
            HideRange();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, root.range);
    }
}
