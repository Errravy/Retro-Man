using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] Vector2 spawnDelay;
    bool canSpawn = true;
    private void Start() {
        Debug.Log("icikiwir");
    }
    void Update()
    {
        RandomSpawn();
    }
    void RandomSpawn()
    {
        if(canSpawn)
        {
            float rnd = Random.Range(spawnDelay.x,spawnDelay.y);
            StartCoroutine(Spawn(rnd));
        }
    }
    IEnumerator Spawn(float time)
    {
        int icikiwir = Random.Range(0,enemy.Length);
        canSpawn = false;
        yield return new WaitForSeconds(time);
        Instantiate(enemy[icikiwir],transform.position,Quaternion.identity);
        canSpawn = true;
    }
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        canSpawn = true;
    }   
}
