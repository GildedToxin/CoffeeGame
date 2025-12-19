using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public string customerName = "Customer";

    public void StartOrder()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Customer,
            DialogueContext.CustomerGreeting,
            DialogueTier.Any,
            customerName
        );
    }

    public void CompleteOrder(DialogueTier qualityTier)
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Customer,
            DialogueContext.OrderServed,
            qualityTier,
            customerName
        );
    }

    public void FailOrder()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Customer,
            DialogueContext.OrderFailed,
            DialogueTier.Any,
            customerName
        );
    }

    public void ReactToQuality(DialogueQuality quality)
    {
        DialogueRunner.Instance.Play(
            DialogueContext.CustomerReaction,
            quality,
            customerName
        );
    }

    public void CompleteOrder() => CompleteOrder(DialogueTier.Basic);
    public void CompleteOrderAdvanced() => CompleteOrder(DialogueTier.Advanced);
    public void CompleteOrderSpecialty() => CompleteOrder(DialogueTier.Specialty);

    public void ReactPoor() => ReactToQuality(DialogueQuality.Poor);
    public void ReactAcceptable() => ReactToQuality(DialogueQuality.Acceptable);
    public void ReactGood() => ReactToQuality(DialogueQuality.Good);
    public void ReactExcellent() => ReactToQuality(DialogueQuality.Excellent);
}
