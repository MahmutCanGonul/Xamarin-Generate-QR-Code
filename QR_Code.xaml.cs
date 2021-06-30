using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QR_Code : ContentPage
    {
        public QR_Code()
        {
            InitializeComponent();
            your_QR.BarcodeValue = QR_CODE.result; // Now we can use that our QR Code name  QR_CODE.result is my object so you just write  your_QR.BarcodeValue = "string"

        }
    }
}
