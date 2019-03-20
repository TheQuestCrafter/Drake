using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFallingSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    [SerializeField]
    private float inBetweenTime = 3;
    [SerializeField]
    private float totalTime = 15;
    [SerializeField]
    private int spawnX = 7;
    [SerializeField]
    Transform spawnerPoint;
    private System.Random random;
    private float xHolderFloat;
    private Vector3 spawnPoint;
    private float timeDelay;

    void Awake()
    {
        timeDelay = Time.time + inBetweenTime;
        random = new System.Random();
    }
    void Start()
    {
        //Starts the ray Spawning sequence
        InvokeRepeating("SpawnCell", 0, inBetweenTime);
    }
    void FixedUpdate()
    {
        ///<summary>
        /// If the timer has finished the desired time given in the serialized field then it will stop spawning cells
        /// </summary>
        if (Time.time >= totalTime)
        {
            CancelInvoke();
        }
    }
    /// <summary>
    /// Sets the spawn location then spawns cells there.
    /// </summary>
    void SpawnCell()
    {
        SetSpawnX();
        Spawn();
    }

    private void Spawn()
    {
        //Instantiates the cells at the location set by SetSpawn
        var cell = Instantiate(cellPrefab, spawnPoint, spawnerPoint.rotation, this.transform);
    }

    private void SetSpawnX()
    {
        //Randomly generates a x location to spawn the cell at since the X is constantly set.
        xHolderFloat = random.Next(-spawnX, spawnX);
        spawnPoint = spawnerPoint.position;
        spawnPoint.Set(spawnerPoint.position.x + xHolderFloat, spawnerPoint.position.y, spawnerPoint.position.z);
    }
}
