using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasil : MonoBehaviour
{
    public YggdrasilBlueprint yggdrasil;
    public Collider terrainCollider;

    private SpriteRenderer rangeSpriteRenderer;

    private bool hoverEnabled = true;

    internal Vector3 GetYggdrasilPosition()
    {
        return yggdrasil.gameObject.transform.position;
    }

    private bool activate = false;

    private RaycastHit hit;
    private Ray ray;

    BuildManager buildManager;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // prevent the parent from scaling the children
        transform.GetChild(0).parent = null;

        rangeSpriteRenderer.transform.localScale = new Vector3(yggdrasil.range * 2f , yggdrasil.range * 2f, .99f);

        HideRange();

        yggdrasil.gameObject = gameObject;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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
        ShowRange();

        //buildManager.expandableGo = gameObject;
        buildManager.SelectYggdrasil(this);

        buildManager.extendable = yggdrasil;
        //Debug.Log(yggdrasil.gameObject);
        hoverEnabled = false;
        activate = true;
    }

    private void OnMouseExit()
    {
        if (hoverEnabled)
            HideRange();
    }

    private void OnMouseOver()
    {
        if (hoverEnabled)
            ShowRange();
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Vector3 position = new Vector3(transform.position.x, transform.position.y, .5f);
        //Gizmos.DrawWireSphere(position, yggdrasil.range);
    }
}
