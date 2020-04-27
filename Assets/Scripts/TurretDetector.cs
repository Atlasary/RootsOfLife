using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetector : MonoBehaviour
{
    private void Start()
    {
        print("hello detect");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponentInParent<TurretHabits>().DetectEnemy(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponentInParent<TurretHabits>().ReleaseEnemy(other.gameObject.GetComponent<Enemy>());
        }
    }
}
