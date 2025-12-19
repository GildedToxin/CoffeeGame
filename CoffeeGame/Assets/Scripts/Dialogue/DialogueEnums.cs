public enum SpeakerType
{
    Customer,
    Vendor
}

public enum DialogueContext
{
    // Customer
    CustomerGreeting,
    OrderServed,
    OrderFailed,
    CustomerReaction,

    // Vendor
    VendorGreeting,
    VendorOpen,
    VendorFarewell,

    IdleChatter
}

public enum DialogueTier
{
    Basic,
    Advanced,
    Specialty,
    Any
}

public enum DialogueQuality
{
    Any,
    Poor,
    Acceptable,
    Good,
    Excellent
}
