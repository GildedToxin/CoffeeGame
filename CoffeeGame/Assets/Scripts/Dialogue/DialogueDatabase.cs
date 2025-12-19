using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/Database")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueLine> lines;

    public DialogueLine GetRandomLine(
        SpeakerType speaker,
        DialogueContext context,
        DialogueTier tier,
        DialogueQuality quality = DialogueQuality.Any)
    {
        List<DialogueLine> valid = lines.FindAll(l =>
            l.speaker == speaker &&
            l.context == context &&
            (tier == DialogueTier.Any || l.tier == tier) &&
            (quality == DialogueQuality.Any || l.quality == quality)
        );

        if (valid.Count == 0)
            return null;

        return valid[Random.Range(0, valid.Count)];
    }
}
