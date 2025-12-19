using UnityEngine;
using TMPro;

public class DialogueRunner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialogueText;

    public void PlayLine(DialogueLine line)
    {
        dialogueText.text = line.text;
        //Implement animation and such later...
    }
}