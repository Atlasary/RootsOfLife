using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public RootBluePrint root;
    public Material spotMaterial;

    private SpriteRenderer rangeSpriteRenderer;
    private GameObject[] spots;

    public GameObject[] GetChildren()
    {
        return spots;
    }

    BuildManager buildManager;


    private void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();


        // prevent the parrent from scaling the children
        //transform.GetChild(0).parent = null;

        createInstanceRBP();

        rangeSpriteRenderer.transform.localScale = new Vector3(transform.localScale.y / 3.5f, 3, -0.05f);

        HideRange();

        float ratio = Convert.ToInt32(transform.localScale.y) / 30 + 2;
        spots = new GameObject[(int)ratio];
        
        if(ratio <= 1)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.GetComponent<Renderer>().material = spotMaterial;
            go.transform.localScale = new Vector3(1.1f, 1 / ratio, 1.1f);
            go.transform.position = new Vector3(0, 2f, 0);
            go.transform.localPosition = new Vector3(0, (1 / ratio) * 2 - 1, 0);
            go.name = "spot " + System.Guid.NewGuid();
            go.AddComponent<Spot>();
            go.transform.SetParent(transform, false);
            //go.SetActive(false);
            spots[0] = go;
        }
        else
        {
            for (float i = 1; i < ratio; i++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.GetComponent<Renderer>().material = spotMaterial;
                go.transform.localScale = new Vector3(1.1f, 1 / ratio, 1.1f);
                go.transform.position = new Vector3(0, 2f, 0);
                go.transform.localPosition = new Vector3(0, (i / ratio) * 2 - 1, 0);
                go.name = "spot " + System.Guid.NewGuid();
                go.AddComponent<Spot>();
                go.transform.SetParent(transform, false);
                //go.SetActive(false);
                spots[(int)i - 1] = go;
            }
        }
        
        buildManager = BuildManager.instance;

    }


    private void createInstanceRBP()
    {
        root.range = 2 * transform.localScale.y;
        root.gameObject = gameObject;
        root.price = 70;
    }

    public GameObject[] getSpots()
    {
        return spots;
    }
    public void HideSpots()
    {
        //foreach (GameObject spot in spots) spot.SetActive(false);
    }

    private void DisplaySpots()
    {
        //foreach (GameObject spot in spots) spot.SetActive(true);
    }

    public void HideRange()
    {
        rangeSpriteRenderer.enabled = false;
    }

    public void ShowRange()
    {
        rangeSpriteRenderer.enabled = true;
        Debug.Log("Showrange");
    }

    private void OnMouseDown()
    {
        DisplaySpots();
        buildManager.SelectRoot(this);
    }

    public void UpgradeRoot()
    {
        if (PlayerStats.money < root.upgradePrice)
        {
            Debug.Log("Not enough money ! You have " + PlayerStats.money + "$ and the root upgrade costs " + root.upgradePrice + "$");
            return;
        }
        else
        {
            Debug.Log("You have enough money ! You have " + PlayerStats.money + "$ and the root upgrade costs " + root.upgradePrice + "$");
            PlayerStats.money -= root.upgradePrice;
            Debug.Log("Now you have " + PlayerStats.money + "$");
        }

        root.range += 20;
        root.health += 20;
        root.currentHealth = root.health;
        root.isUpgraded = true;
        buildManager.DeselectRoot();
    }

    internal void RepairRoot()
    {
        // TODO : repair root
        buildManager.rootUI.Hide();
    }

    internal void SellRoot()
    {
        // TODO : sell root
        buildManager.rootUI.Hide();
    }
}
