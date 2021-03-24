using InventoryCounter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using InventoryCounter.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using InventoryCounter.Classes;

namespace InventoryCounter.ViewModels
{
    public class AppSettingViewModel : BaseViewModel
    {
        private INavigator _nav;
        AppSetting app_setting = new AppSetting();

        public ICommand SaveCommand { get; private set; }

        public AppSettingViewModel(INavigator nav)
        {
            _nav = nav;

            DeviceId = DependencyService.Get<IDeviceID>().GetId();

            SaveCommand = new Command(async () => await Save());
        }
        private bool ValidateInput()
        {
            if(DeviceId != "" && API_endpoint != "" && API_entity != "" && API_url != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ResetValues()
        {
            API_url = "";
            API_entity = "";
            API_endpoint = "";
        }
        private bool Load()
        {
            string setting_obj = "";
            if (File.Exists(Globals.app_setting_json))
            {
                using (StreamReader file = File.OpenText(Globals.app_setting_json))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject obj = (JObject)JToken.ReadFrom(reader);

                    setting_obj = obj.ToString();

                    Globals.current_settings = JsonConvert.DeserializeObject<AppSetting>(setting_obj);

                    if(app_setting.device_id != DeviceId)
                    {
                        return false;
                    }
                    else
                    {
                        API_endpoint = Globals.current_settings.api_endpoint;
                        API_entity = Globals.current_settings.api_entity;
                        API_url = Globals.current_settings.api_url;
                        return true;
                    }

                }
            }
            else
            {
                return false;
            }
        }
        private async Task Save()
        {
            string setting_obj = "";

            if (File.Exists(Globals.app_setting_json))
                File.Delete(Globals.app_setting_json);

            if (ValidateInput())
            {
                app_setting = new AppSetting
                {
                    device_id = DeviceId,
                    api_endpoint = API_endpoint,
                    api_entity = API_entity,
                    api_url = API_url
                };

                setting_obj = JsonConvert.SerializeObject(app_setting);
                JObject obj = JObject.Parse(setting_obj);

                using (StreamWriter file = File.CreateText(Globals.app_setting_json))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    obj.WriteTo(writer);
                }

                ResetValues();

                if (Load())
                {
                    await _nav.DisplayAlert("Settings", "Settings has been saved and loaded.", "OK");
                }
            }
            
        }
    }
}
