/* Object Pooling Spawner
 * Ricardo III Ticlao
 * 28/08/2018
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSpawnerScript : MonoBehaviour {

    public bool isSpawning;
    public string pressKey;
    KeyCode kc;

    public string spawnEvent;
    public string pool;
    public float startWait;
    public int prefabCount;
    public float spawnWait;
    public int waveCount;
    public float waveWait;
    public bool areaSpawn;
    public Transform[] spawnPoints;
    Vector3 spawnArea;

    List<GameObject> pooledPrefabs;

    private void OnEnable()
    {
        EventManager.StartListening(spawnEvent, StartSpawning);
        EventManager.StartListening("DisableSpawner", TurnOFF);
    }

    private void OnDisable()
    {
        EventManager.StopListening(spawnEvent, StartSpawning);
        EventManager.StopListening("DisableSpawner", TurnOFF);
        StopAllCoroutines();
    }

    private void Awake()
    {
        kc = (KeyCode)System.Enum.Parse(typeof(KeyCode), pressKey);
    }

    void TurnOFF()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(kc))
        {
            ManualSpawn();
        }
    }

    void ManualSpawn()
    {
        Vector3 spawnArea = new Vector3((Random.Range(-1f, 1f)), (Random.Range(-1f, 1f)),
                        (Random.Range(-1f, 1f)));
        spawnArea = transform.TransformPoint(spawnArea * .5f);

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject objPool = GameObject.Find(pool);
        GameObject obj = objPool.GetComponent<ObjectPoolScript>().GetPooledObject();
        obj.transform.position = spawnArea;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    public void StartSpawning()
    {

        StartCoroutine(SpawnWaves());
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        if (areaSpawn)
        {
            yield return new WaitForSeconds(startWait);
   //         print("Next Wave Incoming");
            for (int level = 0; level < waveCount; level++)
            {
                for (int i = 0; i < prefabCount; i++)
                {
                    isSpawning = true;
                    spawnArea = new Vector3((Random.Range(-1f, 1f)), (Random.Range(-1f, 1f)),
                          (Random.Range(-1f, 1f)));
                    spawnArea = transform.TransformPoint(spawnArea * .5f);

                    int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                    GameObject objPool = GameObject.Find(pool);
                    GameObject obj = objPool.GetComponent<ObjectPoolScript>().GetPooledObject();
                   

                    GameObject spawn = GameObject.Find("Spawns");
                    GameObject sObj = spawn.GetComponent<ObjectPoolScript>().GetPooledObject();
                    

                    if (obj != null)
                    {
                        obj.transform.position = spawnArea;
                        obj.transform.rotation = transform.rotation;
                        sObj.transform.position = obj.transform.position;
                        sObj.transform.rotation = transform.rotation; 

                        sObj.SetActive(true);
                        yield return new WaitForSeconds(spawnWait);
                        obj.SetActive(true);
                    }
                    else
                    {
                        yield return null;
                    }

   //                 StartCoroutine(Spawn());

                    
                }
                isSpawning = false;
                yield return new WaitForSeconds(waveWait);
            }
        }
        if (!areaSpawn)
        {
            yield return new WaitForSeconds(startWait);
      //      print("Next Wave Incoming");
            for (int level = 0; level < waveCount; level++)
            {
                for (int i = 0; i < prefabCount; i++)
                {

                    int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                    GameObject objPool = GameObject.Find(pool);
                    GameObject obj = objPool.GetComponent<ObjectPoolScript>().GetPooledObject();
                    obj.transform.position = spawnPoints[spawnPointIndex].position;
                    obj.transform.rotation = spawnPoints[spawnPointIndex].rotation;
                    obj.SetActive(true);

                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }
    }

    IEnumerator Spawn()
    {
        GameObject objPool = GameObject.Find(pool);
        GameObject obj = objPool.GetComponent<ObjectPoolScript>().GetPooledObject();
        obj.transform.position = spawnArea;
        obj.transform.rotation = transform.rotation;

        GameObject spawn = GameObject.Find("Spawns");
        GameObject sObj = spawn.GetComponent<ObjectPoolScript>().GetPooledObject();
        sObj.transform.position = obj.transform.position;
        sObj.transform.rotation = transform.rotation;

        if (obj != null)
        {

            sObj.SetActive(true);

            yield return new WaitForSeconds(1f);
            obj.SetActive(true);
        }
        else
        {
            yield return null;
        }
    }

}//End
