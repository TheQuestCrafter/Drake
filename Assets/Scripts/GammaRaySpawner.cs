using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GammaRaySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject rayPrefab;
    [SerializeField]
    private float inBetweenTime = 3;
    [SerializeField]
    private float totalTime = 15;
    [SerializeField]
    private int spawnX = 7;
    [SerializeField]
    private Transform spawnerPoint;
    [SerializeField]
    private int nextScene = 3;

    private float endTimer = 3;
    private System.Random random;
    private float xHolderFloat;
    private Vector3 spawnPoint;
    private float timeStored;

    void Awake()
    {
        Debug.Log("I am awake");
        timeStored = Time.time;
        random = new System.Random();
    }
    void Start()
    {
        Debug.Log("I am started");
        //Starts the Ray Spawning sequence
        InvokeRepeating("SpawnRay", 0, inBetweenTime);
    }
    void FixedUpdate()
    {
        ///<summary>
        /// If the timer has finished the desired time given in the serialized field then it will stop spawning rays
        /// </summary>
        if (Time.time >= timeStored + totalTime + endTimer)
        {
            SceneManager.LoadScene(nextScene);
        }
        else if (Time.time >= timeStored + totalTime)
        {
            CancelInvoke();
        }
    }
    /// <summary>
    /// Sets the spawn location then spawns ray there.
    /// </summary>
    void SpawnRay()
    {
        SetSpawnX();
        Spawn();
    }

    private void Spawn()
    {
        //Instantiates the ray at the location set by SetSpawn
        var cell = Instantiate(rayPrefab, spawnPoint, spawnerPoint.rotation, this.transform);
    }

    private void SetSpawnX()
    {
        //Randomly generates a x location to spawn the ray at since the X is constantly set.
        xHolderFloat = random.Next(-spawnX, spawnX);
        spawnPoint = spawnerPoint.position;
        spawnPoint.Set(spawnerPoint.position.x + xHolderFloat, spawnerPoint.position.y, spawnerPoint.position.z);
    }
}
