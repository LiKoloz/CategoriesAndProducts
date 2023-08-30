namespace BlazorApp.Models
{
    public class DataService
    {
        private Category data = new Category();

        public event Action MyEvent;
        public void TriggerEvent()
        {
            MyEvent?.Invoke();
        }
        public Category GetData()
        {
            return data;
        }

        public void SetData(Category newData)
        {
            data = newData;
        }
    }
}
