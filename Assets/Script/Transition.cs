using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition Instance;

    // In = 0 -> 100
    // Out = 100 -> 0
    public GameObject fadeOutPrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        StartFade();
    }

    public void StartFade()
    {
        if (fadeOutPrefab != null)
        {
            Destroy(Instantiate(fadeOutPrefab, Vector3.zero, Quaternion.identity), 1);
        }
    }
}
