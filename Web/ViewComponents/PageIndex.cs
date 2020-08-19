namespace BizTalk.Monitor.Web.ViewComponents
{
    public class PageIndex
    {
        public PageIndex(int index, bool isActive)
        {
            Index = index;
            IsActive = isActive;
        }

        public int Index { get; }

        public bool IsActive { get; }


    }
}