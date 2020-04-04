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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activate = true;
            current = Instantiate(tourelles[currentIndex], Vector3.zero, Quaternion.Euler(Vector3.left * 90));
        }
        if (activate)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Destroy(current);
                currentIndex = (currentIndex + 1) % tourelles.Length;
                current = Instantiate(tourelles[currentIndex], Vector3.zero, Quaternion.Euler(Vector3.left * 90));
            }
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
}
