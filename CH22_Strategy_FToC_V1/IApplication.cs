namespace CH22_Strategy_FToC_V1
{
    internal interface IApplication
    {
        bool IsDone { get; }
        void Init();
        void Idle();
        void Cleanup();
    }
}