namespace CH22_Strategy_BubbleSorter_V1
{
    public interface ISortHandle
    {
        void Swap(int index);
        bool OutOfOrder(int index);
        int Length { get;  }
        void SetArray(object array);
    }
}