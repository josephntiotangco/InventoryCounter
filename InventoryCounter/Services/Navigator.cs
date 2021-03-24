using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InventoryCounter.Services
{
    public class Navigator : INavigator
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel, string placeholder, int maxLength, Keyboard keyboard, string initialValue)
        {
            return await MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength: maxLength, keyboard: keyboard, initialValue: initialValue);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }
        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
