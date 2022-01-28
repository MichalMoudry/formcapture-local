namespace FormCaptureLocalWasm.Models.Enums
{
    public enum QueueTask
    {
        Start,
        Scan,
        Identification,
        Recognition,
        Verification,
        Export,
        VerificationError,
        IdentificationError,
        Finished,
        Deprecated
    }
}