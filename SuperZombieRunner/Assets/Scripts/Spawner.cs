using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);

    // Start is called before the first frame update
    void Start()
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
    }

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
            var newTransorm = transform;
            Unity.Mathematics.Random random = new Unity.Mathematics.Random(0x6E624EB7u);

            GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransorm.position);
        }

        ResetDelay();
        StartCoroutine(EnemyGenerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetDelay()
    {        
        Unity.Mathematics.Random random = new Unity.Mathematics.Random(0x6E624EB7u);
        int iRandom = Random.Range((int)delayRange.x, (int)delayRange.y);
        delay = iRandom;
    }
}
