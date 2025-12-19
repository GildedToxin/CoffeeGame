using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string id;
    public SpeakerType speaker; //For customer or vendor types
    public DialogueContext context; //For differentiating order reaction shop etc whatever we want
    public DialogueTier tier; //Basic, Advanced, Specialty
    public DialogueQuality quality; //Poor -> Acceptable -> Good -> Excellent
    public string text;
}
