namespace TestProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Console.WriteLine("AppDomain");
            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                Console.WriteLine("TaskScheduler");
            };
            MainPage = new AppShell();
        }
    }
}
