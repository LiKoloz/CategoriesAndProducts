namespace BlazorApp.Models
{
    public class CategoryService
    {
        private List<Category> data = new();

        public event Action ChangeEvent;

        public void TriggerEvent()
        {
            ChangeEvent?.Invoke();
        }

        public List<Category> GetData()
        {
            return data;
        }

        public void SetData(List<Category> newData)
        {
            data = newData;
        }
    }
}
