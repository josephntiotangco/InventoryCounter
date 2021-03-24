using InventoryCounter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryCounter.Classes
{
    public static class Globals
    {
        public static string api_url;
        public static string api_endpoint;
        public static string api_entity;

        public static string app_setting_json = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app_settings.json");

        public static AppSetting current_settings;
    }
}
