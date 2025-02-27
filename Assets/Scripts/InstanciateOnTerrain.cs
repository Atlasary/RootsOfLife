﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateOnTerrain : MonoBehaviour
{
    public TurretBlueprint[] tourelles;
    private GameObject current;
    public Collider terrainCollider;
    private bool activate = false;

    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == terrainCollider || (hit.collider.gameObject.name == "Range" && hit.collider.gameObject != current.transform.GetChild(1).gameObject))
                {
                    current.transform.position = hit.point;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(tourelles[currentIndex].gameObject, current.transform.position, current.transform.rotation);
                activate = false;
                Destroy(current);
            }
        }
    }

    public void TurretSwitch(int index)
    {
        currentIndex = index;
        activate = true;
        TurretBlueprint tbp = tourelles[index];
        if (PlayerStats.money < tbp.price)
        {
            Debug.Log("Not enough money ! You have " + PlayerStats.money + "$ and the turret costs " + tbp.price + "$");
            return;
        }
        else
        {
            Debug.Log("You have enough money ! You have " + PlayerStats.money + "$ and the turret costs " + tbp.price + "$");
            PlayerStats.money -= tbp.price;
            Debug.Log("Now you have " + PlayerStats.money + "$");
        }

        current = Instantiate(tbp.preview, Vector3.zero, Quaternion.Euler(Vector3.left * 90));

        Debug.Log("is null ? " + current.name);
    }
}
