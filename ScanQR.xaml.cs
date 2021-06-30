using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1
{
    public static class FriendQR
    {
        public static string cipher;
        public static bool isfriendqr = false;
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanQR : ContentPage
    {
        static string value = "";
         public ScanQR()
        {
            InitializeComponent();
            tick_image.IsVisible = false;

        }

        private void scan_QR_OnScanResult(ZXing.Result result) // Imported part this ZXing.Result result because QR Code data is result so you need to use result on this code 
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (result.Text.Length == 27) // Scan QR True Part
                {

                    try
                    {
                        // Use default vibration length
                        Vibration.Vibrate();

                        // Or use specified time
                        var duration = TimeSpan.FromSeconds(1);
                        Vibration.Vibrate(duration);
                    }
                    catch (FeatureNotSupportedException ex)
                    {
                        if (!string.IsNullOrEmpty(ex.Message))
                            return;

                    }
                    catch (Exception ex)
                    {
                        if (!string.IsNullOrEmpty(ex.Message))
                            return;


                    }
                    scan_QR.IsScanning = false;
                    FriendQR.isfriendqr = true;
                    FriendQR.cipher = result.Text;
                    tick_image.IsVisible = true;
                    tick_image.Source = "tick.png";
                    Navigation.PushModalAsync(new UseYourFriendCipher());
                }
                else if (result.Text.Length == 81)
                {
                    try
                    {
                        // Use default vibration length
                        Vibration.Vibrate();

                        // Or use specified time
                        var duration = TimeSpan.FromSeconds(1);
                        Vibration.Vibrate(duration);
                    }
                    catch (FeatureNotSupportedException ex)
                    {
                        if (!string.IsNullOrEmpty(ex.Message))
                            return;

                    }
                    catch (Exception ex)
                    {
                        if (!string.IsNullOrEmpty(ex.Message))
                            return;


                    }
                    scan_QR.IsScanning = false;
                    FriendQR.isfriendqr = true;
                    FriendQR.cipher = result.Text;
                    tick_image.IsVisible = true;
                    tick_image.Source = "tick.png";
                    Navigation.PushModalAsync(new UseYourFriendCipher());
                }
                else // Scan QR False Part
                {
                     
                    value = result.Text;
                    ScanQR_FalsePart();
                }
            });



        }


        public async void ScanQR_FalsePart()
        {
            
            tick_image.IsVisible = true;
            tick_image.Source = "tick_false.png";
             
            scan_QR.IsScanning = false;
            
            string result = await DisplayActionSheet("Uyarı", "Tamam", null, "Uyarı", "Okunan kod hatalı..." + " Kodun değeri: " + value);
             
            if (result.Equals("Tamam"))
            {
                scan_QR.IsScanning = true;
                tick_image.IsVisible = false;
                

            }

        }


    }
}
