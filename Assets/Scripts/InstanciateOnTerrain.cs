using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateOnTerrain : MonoBehaviour
{
    public GameObject[] tourelles;
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
                if (hit.collider == terrainCollider)
                {
                    current.transform.position = hit.point;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                activate = false;
            }
        }
    }

    public void TurretSwitch(int index)
    {
        Debug.Log("help");
        activate = true;
        current = Instantiate(tourelles[index], Vector3.zero, Quaternion.Euler(Vector3.left * 90));
    }
}
