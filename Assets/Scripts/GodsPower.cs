using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsPower : MonoBehaviour
{
    public GameObject thorLigntning;
    public GameObject freyrWrath;
    public GameObject odinHealth;
    public float odinHeal;
    public Collider terrainCollider;
    private GameObject current;
    private bool activate,odin,thor;

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
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
            {
                if (hit.collider == terrainCollider || (hit.collider.gameObject.name == "Range"))
                {
                    Instantiate(current, hit.point, Quaternion.identity);
                    activate = false;
                }
            }
        }
        else if (thor)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    print("lighting is coming");
                    StartCoroutine(Lightning(hit.point));
                    hit.collider.gameObject.GetComponent<Enemy>().TakeDammage(1000);
                    thor = false;
                }
            }
        }
        else if (odin)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Turret")
                {
                    print("heal is coming");
                    StartCoroutine(Health(hit.point));
                    hit.collider.gameObject.GetComponent<TurretHabits>().Heal(odinHeal);
                    odin = false;
                }
            }
        }
    }

    public void Thor()
    {
        current = thorLigntning;
        thor = true;
    }

    public void Freyr()
    {
        current = freyrWrath;
        activate = true;
    }

    public void Odin()
    {
        odin = true;
    }

    private IEnumerator Lightning(Vector3 pos)
    {
        GameObject obj = Instantiate(thorLigntning, pos, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(obj);
    }
    private IEnumerator Health(Vector3 pos)
    {
        GameObject obj = Instantiate(odinHealth, pos, Quaternion.identity);
        obj.transform.Rotate(Vector3.left*90);
        yield return new WaitForSeconds(2);
        Destroy(obj);
    }
}
