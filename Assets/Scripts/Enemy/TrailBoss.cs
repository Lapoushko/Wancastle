using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBoss : MonoBehaviour
{
    public float timeDestroy;
    float timeBtwSpawns;
    public float startTimeBtsSpawns;
    public GameObject[] echo;
    MovePlayer player;

    void Start()
    {
        player = GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, echo.Length);
            GameObject instance = (GameObject)Instantiate(echo[rand], transform.position, Quaternion.identity);
            Destroy(instance, timeDestroy);
            timeBtwSpawns = startTimeBtsSpawns;
        }
        else timeBtwSpawns -= Time.deltaTime;
    }
}
