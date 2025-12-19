using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public void StartOrder()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Customer,
            DialogueContext.CustomerGreeting,
            DialogueTier.Any
        );
    }

    public void CompleteOrder(DialogueTier qualityTier)
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Customer,
            DialogueContext.OrderServed,
            qualityTier
        );
    }

    public void FailOrder()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Customer,
            DialogueContext.OrderFailed,
            DialogueTier.Any
        );
    }

    public void ReactToQuality(DialogueQuality quality)
    {
        DialogueRunner.Instance.Play(
            DialogueContext.CustomerReaction,
            quality
        );
    }
}
