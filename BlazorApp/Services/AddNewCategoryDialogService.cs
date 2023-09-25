using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorApp.Services
{
    public class AddNewCategoryDialogService
    {
        private string newTitle;
        private int? newPatherId;
        public event Action ChangeEvent;

        public void TriggerEvent()
        {
            ChangeEvent?.Invoke();
        }

        public string GetNewName()
        {
            return newTitle;
        }

        public int? GetNewPatherId()
        {
            return newPatherId;
        }


        public void SetData(string newTitle, int? newPatherId)
        {
           this.newPatherId = newPatherId;
            this.newTitle = newTitle;
        }
    }
}
