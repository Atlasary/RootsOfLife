using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHabits : MonoBehaviour
{
    private float life;
    private List<Enemy> enemyList;
    private bool isReady;
    private float initScale;

    public float startlife;
    public float damage;
    public float loadTime;
    public float range;
    public GameObject projectile;
    public GameObject lifebar;

    // Start is called before the first frame update
    void Start()
    {
        life = startlife;
        lifebar.gameObject.SetActive(false);
        enemyList = new List<Enemy>();
        isReady = true;
        InitiateRange();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyList.Count != 0)
        {
            if(enemyList[0] == null)
            {
                enemyList.Remove(enemyList[0]);
            }
            if (isReady)
            {
                isReady = false;
                StartCoroutine("Shoot");
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if(life == startlife)
        {
            lifebar.gameObject.SetActive(true);
        }
        life -= damage;
        lifebar.transform.localScale = new Vector3(initScale * life / startlife, lifebar.transform.localScale.y, lifebar.transform.localScale.z);
        if (life < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void DetectEnemy(Enemy enemy)
    {
        print("DetectEnemy");
        if(!enemyList.Contains(enemy))
        {
            print("addenemy");
            enemyList.Add(enemy);
        }
    }

    public void ReleaseEnemy(Enemy enemy)
    {
        print("ReleaseEnemy");
        if (enemyList.Contains(enemy))
        {
            print("release enemy");
            enemyList.Remove(enemy);
        }
    }

    private IEnumerator Shoot()
    {
        Instantiate(projectile, transform.position,Quaternion.identity).GetComponent<ProjectileHabits>().SetEnemy(enemyList[0]);
        enemyList[0].TakeDammage(damage);
        print("enemy " + enemyList[0] + " just got " + damage + " damage.");
        yield return new WaitForSeconds(loadTime);
        isReady = true;
    }

    private void InitiateRange()
    {
        print(GetComponentInChildren<TurretDetector>().gameObject.name);
        GetComponentInChildren<TurretDetector>().gameObject.transform.localScale = new Vector3(range * 80f / this.transform.localScale.x, range * 80f / this.transform.localScale.y,1);
    }

}
