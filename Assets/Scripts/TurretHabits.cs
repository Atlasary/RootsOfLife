using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHabits : MonoBehaviour
{
    private float life;
    private List<Enemy> enemyList;
    private bool isReady;

    public float startlife;
    public float damage;
    public float loadTime;
    public float range;
    public GameObject projectile;
    public Image lifebar;
    public GameObject lifebarBG;

    // Start is called before the first frame update
    void Start()
    {
        GameObject rangeObj = GetComponentInChildren<TurretDetector>().gameObject;
        rangeObj.GetComponent<SpriteRenderer>().enabled = false;
        life = startlife;
        lifebarBG.gameObject.SetActive(false);
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
            lifebarBG.gameObject.SetActive(true);
        }
        life -= damage;
        lifebar.fillAmount = life / startlife;
        if (life < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Heal(float amount)
    {
        life += amount;
        if (life > startlife)
        {
            life = startlife;
            lifebarBG.gameObject.SetActive(false);
        }
        lifebar.fillAmount = life / startlife;
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
        GetComponentInChildren<TurretDetector>().gameObject.transform.localScale = new Vector3(range * 80f / this.transform.localScale.x, range * 80f / this.transform.localScale.y,1);
    }

    private void OnMouseOver()
    {
        GameObject rangeObj = GetComponentInChildren<TurretDetector>().gameObject;
        rangeObj.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        GameObject rangeObj = GetComponentInChildren<TurretDetector>().gameObject;
        rangeObj.GetComponent<SpriteRenderer>().enabled = false;
    }
}
