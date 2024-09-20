namespace TestProject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
  
           
        }
        

        private void OnCounterClicked(object sender, EventArgs e)
        {
           
            App.Current.MainPage = new MainPage();
        }

        private void ContentPage_Unloaded(object sender, EventArgs e)
        {
            mediaElement?.Handler?.DisconnectHandler();
        }
    }

}
