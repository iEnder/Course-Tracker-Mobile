using System.Reflection;
using Xamarin.Forms;

namespace C971_CourseTracker.ViewModels
{
    public class BaseModifyModel : BaseModel
    {
        public Command CancelCommand { get; }
        public Command SaveCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public bool IsNew { get; set; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete(Models.BaseDataModel data)
        {
            await CourseDB.DeleteItem(data);
            await Shell.Current.GoToAsync("..");
        }

        protected async void OnSave(Models.BaseDataModel data)
        {
            if (ValidateSave(data))
            {
                if (IsNew)
                {
                    await CourseDB.AddItem(data);
                }
                else
                {
                    await CourseDB.UpdateItem(data);
                }
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Field cannot be blank.", "OK");
            }
        }

        // Validates all string based fields in the object are not empty
        protected bool ValidateSave(Models.BaseDataModel data)
        {
            if (data != null)
            {
                foreach (PropertyInfo pi in data.GetType().GetProperties())
                {
                    if (pi.PropertyType == typeof(string))
                    {
                        string value = (string)pi.GetValue(data);
                        if (string.IsNullOrEmpty(value))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public BaseModifyModel(bool _new)
        {
            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command<Models.BaseDataModel>(OnSave);
            DeleteCommand = new Command<Models.BaseDataModel>(OnDelete);
            IsNew = _new;
        }
    }
}
