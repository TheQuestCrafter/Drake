using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private int maxNum;
    [SerializeField]
    private int minNum;
    [SerializeField]
    private int maxNum1;
    [SerializeField]
    private int minNum1;
    [SerializeField]
    private int maxNum2;
    [SerializeField]
    private int minNum2;
    [SerializeField]
    private int maxNum3;
    [SerializeField]
    private int minNum3;
    [SerializeField]
    private int maxNum4;
    [SerializeField]
    private int minNum4;
    [SerializeField]
    private int maxNum5;
    [SerializeField]
    private int minNum5;

    public bool endDeath = false;
    private int randomNumber;
    private System.Random random;
    [SerializeField]
    public int deathCount = 10000000;
    private string uiText;
    private bool alive = true;
    private float storedTime;

    [SerializeField]
    private float timeAfterDeath = 3;
    private SceneChecker sceneChecker;

    void Start()
    {
        random = new System.Random();
    }

    void FixedUpdate()
    {
        UpdateDeathCount();
        DisplayDeathCount();
    }

    private void DisplayDeathCount()
    {
        randomNumber = random.Next(minNum, maxNum);
        deathCount = deathCount - randomNumber;

        if (alive == true)
        {
            deathCount = Mathf.Clamp(deathCount, 1, 1000000000);
        }

        deathCount = Mathf.Clamp(deathCount, 0, 1000000000);
        uiText = "Species Left: " + deathCount;

        if (deathCount <= 0)
        {
            uiText = "All life has ended.";
            storedTime = Time.time;

            /*if(Time.time >= storedTime + timeAfterDeath)
            {
                Application.Quit();
                Debug.Log("Application Quit");
            }*/

        }

        text.text = uiText;
    }

    private void UpdateDeathCount()
    {
        minNum = minNum1;
        maxNum = maxNum1;

        if (deathCount >= 9925000)
        {
            minNum = minNum5;
            maxNum = maxNum5;
        }
        if (endDeath)
        {
            minNum = minNum1;
            maxNum = maxNum1;
        }
        if (deathCount <= 100000)
        {
            minNum = minNum2;
            maxNum = maxNum2;
        }
        if (deathCount <= 1000)
        {
            minNum = minNum3;
            maxNum = maxNum3;
        }
        if (deathCount <= 100)
        {
            minNum = minNum4;
            maxNum = maxNum4;
        }
    }

    public void SetDeath()
    {
        if(deathCount<=1000 || endDeath)
            alive = false;
        else
        {
            sceneChecker = (SceneChecker)FindObjectOfType(typeof(SceneChecker));
            sceneChecker.CallTakeDeathCount();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeDeathCount(int newCount)
    {
        deathCount = newCount;
    }
}
