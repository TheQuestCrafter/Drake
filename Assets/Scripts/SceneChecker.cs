using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    [SerializeField]
    private DeathCount deathCount;
    [SerializeField]
    private InstructionUpdate textUpdate;
    [SerializeField]
    private string stage1Text;
    [SerializeField]
    private string stage2Text;
    [SerializeField]
    private string stage3Text;
    [SerializeField]
    private string stage4Text;

    private int storedCount;
    private Scene sceneHistory;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        sceneHistory = SceneManager.GetActiveScene();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            textUpdate.updateText(stage1Text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SceneChecking();
        sceneHistory = SceneManager.GetActiveScene();
        storedCount = deathCount.deathCount;
    }

    private void SceneChecking()
    {
        if (SceneManager.GetActiveScene() != sceneHistory)
        {
            deathCount = (DeathCount)FindObjectOfType(typeof(DeathCount));
            textUpdate = (InstructionUpdate)FindObjectOfType(typeof(InstructionUpdate));
            deathCount.TakeDeathCount(storedCount);
            Debug.Log("scene changed");

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                textUpdate.updateText(stage1Text);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                textUpdate.updateText(stage2Text);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                textUpdate.updateText(stage3Text);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                textUpdate.updateText(stage4Text);
            }
        }
    }

    public void CallTakeDeathCount()
    {
        deathCount.TakeDeathCount(storedCount);
    }
}
