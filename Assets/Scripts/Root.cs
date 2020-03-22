using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public RootBluePrint root;

    private SpriteRenderer rangeSpriteRenderer;
    private GameObject[] points;

    private bool hoverEnabled = true;

    BuildManager buildManager;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // prevent the parrent from scaling the children
        transform.GetChild(0).parent = null;

        rangeSpriteRenderer.transform.localScale = new Vector3(root.range * 2f, root.range * 2f, -0.05f);

        HideRange();

        //points = new GameObject[3];
        //GameObject go1 = new GameObject();
        //go1.transform.position = transform.position * (-.5f);
        //points[0] = go1;

        //GameObject go2 = new GameObject();
        //go2.transform.position = transform.position * (-.5f);
        //points[1] = go2;

        //GameObject go3 = new GameObject();
        //go3.transform.position = transform.position * (-.5f);
        //points[2] = go3;

        //Debug.Log("Root created");
        //for (int i = 0; i < points.Length; i++)
        //{
        //    //Debug.Log(points[i].transform.position);
        //}

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
        hoverEnabled = false;
        buildManager.root.prefab = gameObject;
        buildManager.root.isSelected = true;
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
