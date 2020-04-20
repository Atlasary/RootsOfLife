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

    void Update()
    {
        
        //while (activate)
        //{
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider == terrainCollider)
        //        {
        //            Debug.Log("I hit the floor !");
        //        }
        //    }
        //    /*
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        activate = false;
        //    }
        //    */
        //}
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

        //buildManager.expandableGo = gameObject;

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
