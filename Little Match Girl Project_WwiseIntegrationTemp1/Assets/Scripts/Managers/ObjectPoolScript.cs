using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour {

    public static ObjectPoolScript current;

    public GameObject prefab;
    public int poolCount = 20;
    public bool addMore = true;
    List<GameObject> pooledPrefabs;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        pooledPrefabs = new List<GameObject>();
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = (GameObject)Instantiate(prefab);
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            pooledPrefabs.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledPrefabs.Count; i++)
        {
            if (!pooledPrefabs[i].activeInHierarchy)
            {
                return pooledPrefabs[i];
            }
        }

        if (addMore)
        {
            GameObject obj = (GameObject)Instantiate(prefab);
            obj.transform.parent = gameObject.transform;
            pooledPrefabs.Add(obj);
            return obj;
        }
        return null;
    }

}//End
