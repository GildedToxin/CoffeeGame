using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/Database")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueLine> lines;

    public DialogueLine GetRandomLine(SpeakerType speaker, DialogueContext context, DialogueTier tier, string customerName = "")
    {
        List<DialogueLine> matches = lines.FindAll(l =>
            l.speaker == speaker &&
            l.context == context &&
            (l.tier == tier || l.tier == DialogueTier.Any) &&
            (string.IsNullOrEmpty(l.customerName) || l.customerName == customerName)
        );

        if (matches.Count == 0) return null;

        return matches[Random.Range(0, matches.Count)];
    }

    public DialogueLine GetLine(DialogueContext context, DialogueQuality quality, string customerName = "")
    {
        List<DialogueLine> matches = lines.FindAll(l =>
            l.context == context &&
            (l.quality == quality || l.quality == DialogueQuality.Any) &&
            (string.IsNullOrEmpty(l.customerName) || l.customerName == customerName)
        );

        if (matches.Count == 0) return null;

        return matches[Random.Range(0, matches.Count)];
    }
}
