using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameScript : MonoBehaviour
{
    private Text text;
    private MouseScript player;
    private bool startedNewText = false;
    private float timer1;
    private bool start2ndLast = false;
    private float timer2;
    private bool startLast = false;
    private float timer3;

    [SerializeField]
    private Image image;
    [SerializeField]
    [TextArea]
    private string finishedText = "";

    private void Awake()
    {
        player = FindObjectOfType<MouseScript>();
        text = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        if(player.obtainedFood >= 5)
        {
            player.FreezePlayer();
            image.color += Color.black / 200;
        }
        if(image.color == Color.black)
        {
            text.CrossFadeAlpha(0, 2, true);
            startedNewText = true;
            timer1 = Time.time + 2;
        }
        if(Time.time >= timer1 && startedNewText)
        {
            startedNewText = false;
            text.text = finishedText;
            text.CrossFadeAlpha(1, 2, true);
            start2ndLast = true;
            timer2 = Time.time + 20;
        }
        if(Time.time >= timer2 && start2ndLast)
        {
            start2ndLast = false;
            text.CrossFadeAlpha(0, 2, true);
            startLast = true;
            timer3 = Time.time + 2;
        }
        if(Time.time >= timer3 && startLast)
        {
            startLast = false;
            Application.Quit();
        }
    }
}
