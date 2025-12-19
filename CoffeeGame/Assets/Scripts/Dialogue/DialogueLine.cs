using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public SpeakerType speaker;       
    public DialogueContext context;   
    public DialogueTier tier;         
    public DialogueQuality quality;  
    [TextArea] public string text;   //The dialogue content
}
