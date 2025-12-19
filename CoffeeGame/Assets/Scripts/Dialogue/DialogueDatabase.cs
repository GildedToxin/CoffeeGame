using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/Database")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueLine> lines;

    public DialogueLine GetRandomLine(SpeakerType speaker, DialogueContext context, DialogueTier tier)
    {
        var matches = lines.FindAll(l =>
            l.speaker == speaker &&
            l.context == context &&
            (l.tier == tier || l.tier == DialogueTier.Any)
        );

        if (matches.Count == 0)
            return null;

        return matches[Random.Range(0, matches.Count)];
    }

    public DialogueLine GetLine(DialogueContext context, DialogueQuality quality = DialogueQuality.Any)
    {
        var matches = lines.FindAll(l =>
            l.context == context &&
            (l.quality == quality || l.quality == DialogueQuality.Any)
        );

        if (matches.Count == 0)
            return null;

        return matches[Random.Range(0, matches.Count)];
    }
}
