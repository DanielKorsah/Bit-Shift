using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zero, one;

    public float Spawnrate = 0.2f;
    int PoolSize = 9;

    private float counter;
    private int zeroIndex = 0;
    private int oneIndex = 0;

    private List<GameObject> zeroPool = new List<GameObject>();
    private List<GameObject> onePool = new List<GameObject>();

    void Start()
    {
        //set up pooling, spawn bellow screen
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject zeroObj = Instantiate(zero, transform.position - new Vector3(0, 11, 0), Quaternion.identity);
            zeroPool.Add(zeroObj);
            GameObject oneObj = Instantiate(one, transform.position - new Vector3(0, 11, 0), Quaternion.identity);
            onePool.Add(oneObj);
        }

    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= Spawnrate)
        {
            //move a 1 or zero to top
            if (Random.value > 0.5f)
            {
                zeroPool[zeroIndex].transform.position = transform.position;
                zeroIndex++;
                if (zeroIndex >= PoolSize)
                    zeroIndex = 0;
            }
            else
            {
                onePool[oneIndex].transform.position = transform.position;
                oneIndex++;
                if (oneIndex >= PoolSize)
                    oneIndex = 0;
            }

            counter = 0;
        }

    }

    //drop pooled obkjects from the top
    void Drop()
    {
        if (Random.value < 0.5f)
            Instantiate(zero, transform.position, Quaternion.identity);
        else
            Instantiate(one, transform.position, Quaternion.identity);
    }
}