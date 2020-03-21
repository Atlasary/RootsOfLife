using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasil : MonoBehaviour
{
    public float range = 90f;

    private SpriteRenderer rangeSpriteRenderer;

    BuildManager buildManager;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // prevent the parrent from scaling the children
        transform.GetChild(0).parent = null;

        rangeSpriteRenderer.transform.localScale = new Vector3(range * 2f , range * 2f, .99f);

        HideRange();

        buildManager = BuildManager.instance;
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
    }

    private void OnMouseEnter()
    {
        ShowRange();
    }

    private void OnMouseExit()
    {
        HideRange();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, .5f);
        Gizmos.DrawWireSphere(position, range);
    }
}
