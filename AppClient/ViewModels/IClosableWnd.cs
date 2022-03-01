namespace AppClient.ViewModels
{
    public interface IClosableWnd
    {
        public bool CloseWindow { get; set; }
        public void Close();
    }
}
