using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasil : MonoBehaviour
{
    public YggdrasilBlueprint yggdrasil;
    public Collider terrainCollider;

    private SpriteRenderer rangeSpriteRenderer;

    internal Vector3 GetYggdrasilPosition()
    {
        return yggdrasil.gameObject.transform.position;
    }

    BuildManager buildManager;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // prevent the parent from scaling the children
        transform.GetChild(0).parent = null;

        rangeSpriteRenderer.transform.localScale = new Vector3(yggdrasil.range * 2f , yggdrasil.range * 2f, .99f);

        HideRange();

        yggdrasil.gameObject = gameObject;


        buildManager = BuildManager.instance;
    }


    public void HideRange()
    {
        rangeSpriteRenderer.enabled = false;
    }

    public void ShowRange()
    {
        rangeSpriteRenderer.enabled = true;
    }

    private void OnMouseDown()
    {
        buildManager.SelectYggdrasil(this);
    }


}
