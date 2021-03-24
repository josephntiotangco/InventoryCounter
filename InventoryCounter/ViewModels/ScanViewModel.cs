using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Essentials;
using InventoryCounter.Services;
using System.Windows.Input;
using InventoryCounter.Classes;

namespace InventoryCounter.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        RestService rs = new RestService(Globals.api_url);

        private string _result;
        public string Result
        {
            get { return _result; }
            set { SetValue(ref _result, value); OnPropertyChanged(nameof(Result)); }
        }
        private string _error;
        public string Error
        {
            get { return _error; }
            set { SetValue(ref _error, value); OnPropertyChanged(nameof(Error)); }
        }
        private Color _errorColor;
        public Color ErrorColor
        {
            get { return _errorColor; }
            set { SetValue(ref _errorColor, value); OnPropertyChanged(nameof(ErrorColor)); }
        }

        public ICommand ScanCommand { get; private set; }

        public ScanViewModel()
        {
            ScanCommand = new Command(async () => await Scan());
        }

        private async Task Scan()
        {
            try
            {
                var scanner = DependencyService.Get<IScanner>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    ErrorColor = Color.Blue;
                    Error = "Scan Successful!";
                    

                }
            }
            catch (Exception ex)
            {
                ErrorColor = Color.DarkRed;
                Error = ex.Message;
                Result = "";
            }
        }
    }
}
