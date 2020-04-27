using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yggdrasil : MonoBehaviour
{
    public YggdrasilBlueprint yggdrasil;
    public Collider terrainCollider;

    private SpriteRenderer rangeSpriteRenderer;

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

    public void UpgradeYggdrasil()
    {
        if (PlayerStats.money < yggdrasil.upgradePrice)
        {
            Debug.Log("Not enough money ! You have " + PlayerStats.money + "$ and the root upgrade costs " + yggdrasil.upgradePrice + "$");
            return;
        }
        else
        {
            Debug.Log("You have enough money ! You have " + PlayerStats.money + "$ and the root upgrade costs " + yggdrasil.upgradePrice + "$");
            PlayerStats.money -= yggdrasil.upgradePrice;
            Debug.Log("Now you have " + PlayerStats.money + "$");
        }

        yggdrasil.range += 20;
        PlayerStats.lives += 50;
        yggdrasil.isUpgraded = true;
        buildManager.DeselectYggdrasil();
    }
}
