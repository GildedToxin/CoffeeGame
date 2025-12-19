using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class DialogueRunner : MonoBehaviour
{
    public static DialogueRunner Instance;

    public DialogueDatabase database;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerText; //setup later

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    public void Play(SpeakerType speaker, DialogueContext context, DialogueTier tier, string customerName = "")
    {
        DialogueLine line = database.GetRandomLine(speaker, context, tier);
        if (line != null)
        {
            dialogueText.text = line.text;
            speakerText.text = speaker.ToString();
        }
        else
        {
            dialogueText.text = "[NO DIALOGUE FOUND]";
            speakerText.text = "";
        }
    }

    public void Play(DialogueContext context, DialogueQuality quality, string customerName = "")
    {
        DialogueLine line = database.GetLine(context, quality);
        if (line != null)
        {
            dialogueText.text = line.text;
            speakerText.text = "Customer";
        }
        else
        {
            dialogueText.text = "[NO DIALOGUE FOUND]";
            speakerText.text = "";
        }
    }
    [Button]
    public void PlayTestDialogue()
    {
        Play(
            SpeakerType.Customer,
            DialogueContext.CustomerGreeting,
            DialogueTier.Any
        );
    }
}
