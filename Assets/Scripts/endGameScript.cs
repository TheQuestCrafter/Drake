using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameScript : MonoBehaviour
{
    private SceneChecker sceneChecker;
    private DeathCount deathCount;

    [SerializeField]
    private float totalTime;
    [SerializeField]
    private float addedTime = 3;
    [SerializeField]
    private GameObject prefabKillArea;
    [SerializeField]
    private Transform spawnPoint;
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource audioSourceSiren;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Color color1 = Color.white;
    private bool bombExploded = false;
    private float colorMinus = 1;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sceneChecker = (SceneChecker)FindObjectOfType(typeof(SceneChecker));
        deathCount = (DeathCount)FindObjectOfType(typeof(DeathCount));
        totalTime = Time.time + addedTime;
    }

    void FixedUpdate()
    {
        if (totalTime <= Time.time && deathCount.deathCount <= 1)
        {
            audioSourceSiren.Stop();
            spriteRenderer.color = color1;
            audioSource.PlayOneShot(audioClip);
            deathCount.endDeath = true;
            deathCount.SetDeath();
            Instantiate(prefabKillArea, spawnPoint);
        }
    }
}
