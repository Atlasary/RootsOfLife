using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorBehaviour : MonoBehaviour
{
    public List<GameObject> transformInto;
    // Start is called before the first frame update
    void Start()
    {
        transformInto[0].SetActive(true);
        transformInto[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Range")
        {
            transformInto[0].SetActive(false);
            transformInto[1].SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Range")
        {
            transformInto[0].SetActive(true);
            transformInto[1].SetActive(false);
        }
    }
}
