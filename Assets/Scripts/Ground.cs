using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    BuildManager buildManager;

    public RootBluePrint rootPrefab;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        Vector3 origin = transform.position;
        Vector3 destination = hit.point;
        buildManager.BuildRootFromAToB(rootPrefab, origin, destination);
    }

}
