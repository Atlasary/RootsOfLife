using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public IExtendable extendable;

    private Root selectedRoot;
    public RootUI rootUI;

    private Yggdrasil selectedYggdrasil;
    public YggdrasilUI yggdrasilUI;

    private Spot selectedSpot;
    public SpotUI spotUI;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    internal void BuildRootTo(RootBluePrint rootPrefab, Vector3 destination)
    {
        if (PlayerStats.money < rootPrefab.price)
        {
            Debug.Log("Not enough money ! You have " + PlayerStats.money + "$ and the root costs " + rootPrefab.price + "$");
            return;
        }
        else
        {
            Debug.Log("You have enough money ! You have " + PlayerStats.money + "$ and the root costs " + rootPrefab.price + "$");
            PlayerStats.money -= rootPrefab.price;
            Debug.Log("Now you have " + PlayerStats.money + "$");
        }

        if(extendable is SpotBluerint)
        {
            Debug.Log("HideSpot");
            //GameObject[] spots = ((SpotBluerint)extendable).parent.getSpots();
            //foreach (GameObject spot in spots) spot.SetActive(false);
        }


        Vector3 origin = extendable.GetGameObject().transform.position;

        if (!isWithinRange(origin, destination))
        {
            Debug.Log("You can build too far !");
            return;
        }
        
        float x = destination.x - origin.x;
        float z = destination.z - origin.z;

        Vector3 offset = new Vector3(x, 0, z);

        Vector3 position = offset / 2.0f;
        position.x += origin.x;
        position.z += origin.z;

        // Génère une taille en fonction de clique de la souris et l'origine
        float dist = Vector3.Distance(destination, origin) / 2f;

        Vector3 scale = new Vector3(10f, dist, 10f);
        rootPrefab.gameObject.transform.localScale = scale;

        // Crée un angle à partir d'un offset
        float angle = Vector3.Angle(offset, transform.forward);

        // Corrige l'angle si jamais destination.x < origin.x car Vector3.Angle(from, to) ne retourne qu'un angle sur 180°, il faut donc l'inverser quand on est dans les négatifs
        if (destination.x < origin.x) angle = -angle;

        // Fait un angle de 90 degés pour que a racine soit bien orientée
        Quaternion spawnRotation = Quaternion.Euler(90, angle, 0);

        // Instancie une racine
        GameObject root = Instantiate(rootPrefab.gameObject, position, spawnRotation);

    }

    private bool isWithinRange(Vector3 origin, Vector3 destination)
    {
        float dist = Vector3.Distance(origin, destination);
        if (dist > extendable.getRange()) return false;
        return true;
    }

    public void SelectSpot(Spot spot)
    {
        if(selectedSpot == spot)
        {
            DeselectSpot();
            return;
        }

        selectedSpot = spot;
        extendable = selectedSpot.spot;

        DeselectRoot();

        DeselectYggdrasil();

        spotUI.SetTarget(spot);
    }

    public void SelectRoot(Root root)
    {
        if (selectedRoot == root)
        {
            DeselectRoot();
            return;
        }

        selectedRoot = root;
        selectedRoot.ShowRange();
        extendable = null;

        DeselectSpot();

        DeselectYggdrasil();

        rootUI.SetTarget(root);
    }

    public void SelectYggdrasil(Yggdrasil yggdrasil)
    {
        if (selectedYggdrasil == yggdrasil)
        {
            DeselectYggdrasil();
            return;
        }

        selectedYggdrasil = yggdrasil;
        selectedYggdrasil.ShowRange();
        extendable = selectedYggdrasil.yggdrasil;

        DeselectRoot();

        DeselectSpot();

        yggdrasilUI.SetTarget(yggdrasil);
    }

    public void DeselectSpot()
    {
        selectedSpot = null;
        spotUI.Hide();
    }

    public void DeselectRoot()
    {
        /*
        bool isChild = false;
        if (selectedRoot != null)
        {
            if(selectedSpot != null)
            {
                foreach (GameObject child in selectedRoot.GetChildren())
                {
                    if (child != null && child.name == selectedSpot.name) isChild = true;
                }
            }
            if (!isChild) selectedRoot.HideRange();
        }
        */
        if (selectedRoot != null)
        {
            selectedRoot.HideRange();
        }

        selectedRoot = null;
        rootUI.Hide();
    }

    public void DeselectYggdrasil()
    {
        if(selectedYggdrasil != null)
            selectedYggdrasil.HideRange();
        selectedYggdrasil = null;
        yggdrasilUI.Hide();
    }



    
}
