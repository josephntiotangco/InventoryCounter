using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace InventoryCounter.ViewModels
{
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
        private string _deviceId;
        public string DeviceId
        {
            get { return _deviceId; }
            set { SetValue(ref _deviceId, value); OnPropertyChanged(nameof(DeviceId)); }
        }
        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set { SetValue(ref _barcode, value); OnPropertyChanged(nameof(Barcode)); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetValue(ref _description, value); OnPropertyChanged(nameof(Description)); }
        }
        private int _systemQuantity;
        public int SystemQuantity
        {
            get { return _systemQuantity; }
            set { SetValue(ref _systemQuantity, value); OnPropertyChanged(nameof(SystemQuantity)); }
        }
        private int _actualQuantity;
        public int ActualQuantity
        {
            get { return _actualQuantity; }
            set { SetValue(ref _actualQuantity, value); OnPropertyChanged(nameof(ActualQuantity)); }
        }
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetValue(ref _username, value); OnPropertyChanged(nameof(Username)); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); OnPropertyChanged(nameof(Password)); }
        }

        private string _api_url;
        public string API_url
        {
            get { return _api_url; }
            set { SetValue(ref _api_url, value); OnPropertyChanged(nameof(API_url)); }
        }
        private string _api_endpoint;
        public string API_endpoint
        {
            get { return _api_endpoint; }
            set { SetValue(ref _api_endpoint, value); OnPropertyChanged(nameof(API_endpoint)); }
        }
        private string _api_entity;
        public string API_entity
        {
            get { return _api_entity; }
            set { SetValue(ref _api_entity, value); OnPropertyChanged(nameof(API_entity)); }
        }
    }
}
