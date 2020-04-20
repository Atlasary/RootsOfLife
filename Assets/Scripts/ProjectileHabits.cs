using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHabits : MonoBehaviour
{
    private Enemy enemy;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            transform.LookAt(enemy.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetEnemy(Enemy _enemy)
    {
        enemy = _enemy;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
