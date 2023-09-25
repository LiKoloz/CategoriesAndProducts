namespace BlazorApp.Services
{
    public class DeleteCategoryService
    {
        private bool data = false;

        public event Action MyEvent;
        public void TriggerEvent()
        {
            MyEvent?.Invoke();
        }
        public bool GetData()
        {
            return data;
        }

        public void SetData(bool newData)
        {
            data = newData;
        }
    }
}
