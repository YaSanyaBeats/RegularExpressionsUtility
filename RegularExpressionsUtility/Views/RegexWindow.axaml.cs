using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegularExpressionsUtility.ViewModels;

namespace RegularExpressionsUtility.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow(string regexStr) : this()
        {
            this.FindControl<TextBox>("regexTextBox").Text = regexStr;
        }
        public RegexWindow()
        {
            InitializeComponent();

            #if DEBUG
                this.AttachDevTools();
            #endif
            
            this.FindControl<Button>("okButton").Click += delegate
            {
                var regexStr = this.FindControl<TextBox>("regexTextBox").Text;
                if(regexStr != null)
                {
                    Close(regexStr);
                }
                else
                {
                    Close("");
                }
            };

            this.FindControl<Button>("cancelButton").Click += delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
