using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LogicScript Logic;
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Logic.addScore(1);
            Debug.Log(collision.gameObject.name + " was killed");
        }
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);  
    }
}