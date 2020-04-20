using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    //private int waypointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = ChoseDirection();
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        /*
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
        */
        target = ChoseDirection();
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private Transform ChoseDirection()
    {
        GameObject Yggdrasil = FindObjectOfType<Yggdrasil>().gameObject;
        List<GameObject> poi = new List<GameObject>();
        poi.Add(Yggdrasil);

        TurretHabits[] turretList = FindObjectsOfType<TurretHabits>();
        for (int i = 0; i < turretList.Length; i++)
        {
            if (isWithinRange(turretList[i].gameObject, Yggdrasil))
            {
                poi.Add(turretList[i].gameObject);
            }
        }
        Spot[] spotList = FindObjectsOfType<Spot>();
        for (int i = 0; i < spotList.Length; i++)
        {
            if (isWithinRange(spotList[i].gameObject, Yggdrasil))
            {
                poi.Add(spotList[i].gameObject);
            }
        }

        return poi[(int)Random.Range(0f,poi.Count)].transform;
    }

    private bool isWithinRange(GameObject obj, GameObject Yggdrasil)
    {
        //radius
        if(Vector3.Magnitude(Yggdrasil.transform.position - transform.position) < Vector3.Magnitude(obj.transform.position - transform.position))
        {
            return false;
        }
        //projection (hauteur du triangle)
        else if(Vector3.Angle(Yggdrasil.transform.position - transform.position, obj.transform.position - transform.position) 
            * Vector3.Magnitude(obj.transform.position - transform.position) * Mathf.PI / 180f > 100f)
        {
            return false;
        }
        return true;
    }

}
