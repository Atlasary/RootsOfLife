using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasil : MonoBehaviour
{
    public YggdrasilBlueprint yggdrasil;

    private SpriteRenderer rangeSpriteRenderer;

    private bool hoverEnabled = true;

    BuildManager buildManager;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // prevent the parent from scaling the children
        transform.GetChild(0).parent = null;

        rangeSpriteRenderer.transform.localScale = new Vector3(yggdrasil.range * 2f , yggdrasil.range * 2f, .99f);

        HideRange();

        buildManager = BuildManager.instance;
        buildManager.yggdrasil.go = gameObject;
    }

    private void Update()
    {
        //if (isInRange) Debug.Log("worked");
        //if (isTouched())
        //{
        //    Debug.Log("Can build");
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        //    {
        //        if (hit.collider == collider)
        //        {
        //            //Do your thing.
        //        }
        //    }
        //}
    }

    
    //private bool isTouched()
    //{
    //    bool result = false;
    //    if(Input.touchCount == 1)
    //    {
    //        if(Input.touches[0].phase == TouchPhase.Ended)
    //        {
    //            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    //            Vector2 touchPos = new Vector2(wp.x, wp.y);
    //            if(collider == Physics2D.OverlapPoint(touchPos))
    //            {
    //                result = true;
    //            }
    //        }
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector2 mousePos = new Vector2(wp.x, wp.y);
    //        if (Collider2D == Physics2D.OverlapPoint(mousePos))
    //        {
    //            result = true;
    //        }
    //    }
    //    return result;
    //}

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
        buildManager.yggdrasil.isSelected = true;
        hoverEnabled = false;
    }

    private void OnMouseEnter()
    {
        if (hoverEnabled)
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
        Vector3 position = new Vector3(transform.position.x, transform.position.y, .5f);
        Gizmos.DrawWireSphere(position, yggdrasil.range);
    }
}
