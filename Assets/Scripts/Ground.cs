using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    BuildManager buildManager;
    Vector3 origin;

    public RootBluePrint rootPrefab;
    

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (buildManager.yggdrasil.isSelected)
        {
            Vector3 origin = buildManager.yggdrasil.go.transform.position;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

            //Vector3 origin = transform.position;
            Vector3 destination = hit.point;

            buildManager.BuildRootFromAToB(rootPrefab, origin, destination);
            buildManager.yggdrasil.isSelected = false;
        }

        if (buildManager.root.isSelected)
        {
            Vector3 origin = buildManager.root.prefab.transform.position;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

            //Vector3 origin = transform.position;
            Vector3 destination = hit.point;


            buildManager.BuildRootFromAToB(rootPrefab, origin, destination);
            buildManager.root.isSelected = false;
        }
    }

}
