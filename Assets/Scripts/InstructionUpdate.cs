using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionUpdate : MonoBehaviour
{
    [SerializeField]
    private Text instructionText;

    public void updateText(string newInstruction)
    {
        instructionText.text = newInstruction;
    }
}
