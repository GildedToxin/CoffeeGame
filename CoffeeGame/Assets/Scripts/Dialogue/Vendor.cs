using UnityEngine;

public class Vendor : MonoBehaviour
{
    public void Greet()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Vendor,
            DialogueContext.VendorGreeting,
            DialogueTier.Any
        );
    }

    public void OpenShop()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Vendor,
            DialogueContext.VendorOpen,
            DialogueTier.Any
        );
    }

    public void Farewell()
    {
        DialogueRunner.Instance.Play(
            SpeakerType.Vendor,
            DialogueContext.VendorFarewell,
            DialogueTier.Any
        );
    }
}
