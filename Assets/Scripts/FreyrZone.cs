using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreyrZone : MonoBehaviour

{
    private List<Enemy> enemyInZone;
    public float damage;
    public float durationTime;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        enemyInZone = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > durationTime)
        {
            Destroy(this.gameObject);
        }
        for(int i = 0;i<enemyInZone.Count;i++)
        {
            if(enemyInZone[i] != null)
            {
                enemyInZone[i].TakeDammage(damage*Time.deltaTime);
            }
            else
            {
                enemyInZone.Remove(enemyInZone[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyInZone.Add(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInZone.Remove(other.GetComponent<Enemy>());
        }
    }
}
