using my_mvvm_app.ViewModel;

namespace my_mvvm_app.Droid
{
    public static class App
    {
        private static ViewModelLocator locator;

        public static ViewModelLocator Locator => 
            locator ?? (locator = new ViewModelLocator());
    }
}