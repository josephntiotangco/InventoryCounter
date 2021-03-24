using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace InventoryCounter.Services
{
    public interface INavigator
    {
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task<Page> PopAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel, string placeholder, Int32 maxLength, Keyboard keyboard, string initialValue);
        Task DisplayAlert(string title, string message, string ok);
    }
}
