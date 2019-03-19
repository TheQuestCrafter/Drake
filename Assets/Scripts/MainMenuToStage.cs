using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuToStage : MonoBehaviour
{
    [SerializeField]
    private int firstStage;

    public void SceneChanger()
    {
        SceneManager.LoadScene(firstStage);
    }
}
