using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public RootBluePrint root;

    private SpriteRenderer rangeSpriteRenderer;

    BuildManager buildManager;

    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // prevent the parrent from scaling the children
        transform.GetChild(0).parent = null;

        rangeSpriteRenderer.transform.localScale = new Vector3(root.range * 2f, root.range * 2f, -0.01f);

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
        Gizmos.DrawWireSphere(transform.position, root.range);
    }
}
