using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public LogicScript Logic;
    public int SpawnSide;
    public double SpawnTime;
    double SpawnTimeDef = 0.2;
    public GameObject EnemyPreFab;
    public GameObject[] EnemyMax;
    private Camera cam;


    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        SpawnSide = Random.Range(0, 4);
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var EnemyMax = GameObject.FindGameObjectsWithTag("Enemy");
        if (SpawnTime <= 0 && Logic.GameOverScreen.activeInHierarchy == false && EnemyMax.Length < 40) 
        {
                SpawnTime = SpawnTimeDef;
                SpawnSide = Random.Range(0, 4);

            cam.ScreenToWorldPoint()
                if (SpawnSide == 0)
                {
                    Instantiate(EnemyPreFab, new Vector3(-12f, Random.Range(-6f, 6f), 0f), Quaternion.identity);

                }
                else if (SpawnSide == 1)
                {
                    Instantiate(EnemyPreFab, new Vector3(12f, Random.Range(-6f, 6f), 0f), Quaternion.identity);

                }
                else if (SpawnSide == 2)
                {
                    Instantiate(EnemyPreFab, new Vector3(Random.Range(-12f, 12f), 6f, 0f), Quaternion.identity);

                }
                else if (SpawnSide == 3)
                {
                    Instantiate(EnemyPreFab, new Vector3(Random.Range(-12f, 12f), -6f, 0f), Quaternion.identity);

                }
            
        } 
        else
        {
            SpawnTime -= Time.deltaTime;
        }
    }
}
