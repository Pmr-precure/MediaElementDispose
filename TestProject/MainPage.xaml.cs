using RestSharp;
using System.Security.Cryptography.X509Certificates;

namespace TestProject
{
    public partial class MainPage : ContentPage
    {
        RestClient WebServiceClient;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
              
           
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await InitClient();
        }

        public async Task InitClient()
        {
            // Load the certificate
            X509Certificate2 certificate = null;

            try
            {
                // Get the stream of the certificate from the Assets folder
                using (var stream = await FileSystem.OpenAppPackageFileAsync("mycert.pem"))
                {
                    if (stream != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            // Copy the stream to a MemoryStream
                            await stream.CopyToAsync(memoryStream);
                            memoryStream.Position = 0; // Reset the stream position

                            // Create the certificate from the memory stream (assumes PEM format)
                            certificate = new X509Certificate2(memoryStream.ToArray(),"1234");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

            if (certificate == null)
            {
                return;
            }

        

            // Set up the RestClient options
            var options = new RestClientOptions("https://google.com")
            {
                
               
            };
           
    

            options.ClientCertificates ??= new();

            options.ClientCertificates.Add(certificate);


            var webServiceClient = new RestClient(options);

            WebServiceClient = webServiceClient;
       
        }


    }

}
