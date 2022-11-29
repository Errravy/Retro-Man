using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerY : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] Vector2 spawnDelay;
    [SerializeField] bool right;
    bool canSpawn = true;
    void Update()
    {
        RandomSpawn();
    }
    void RandomSpawn()
    {
        if(canSpawn)
        {
            float rnd = Random.Range(spawnDelay.x,spawnDelay.y);
            if(!right){StartCoroutine(SpawnR(rnd));}
            else if(right){StartCoroutine(SpawnL(rnd));}
            
        }
    }
    IEnumerator SpawnR(float time)
    {
        int icikiwir = Random.Range(0,enemy.Length);
        canSpawn = false;
        yield return new WaitForSeconds(time);
        Instantiate(enemy[icikiwir],transform.position,Quaternion.Euler(0,0,90),transform);
        canSpawn = true;
    }
    IEnumerator SpawnL(float time)
    {
        int icikiwir = Random.Range(0,enemy.Length);
        canSpawn = false;
        yield return new WaitForSeconds(time);
        Instantiate(enemy[icikiwir],transform.position,Quaternion.Euler(0,0,-90),transform);
        canSpawn = true;
    }
    private void OnEnable() {
        canSpawn = true;
    }
}
