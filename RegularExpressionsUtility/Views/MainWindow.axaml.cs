using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegularExpressionsUtility.ViewModels;
using Avalonia.Interactivity;
using System;
using System.IO;

namespace RegularExpressionsUtility.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("openFileButton").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPath;

                if(path != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    var pathStr = string.Join(@"\", path);
                    context.Input = "";

                    using (StreamReader sr = File.OpenText(pathStr))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            context.Input += s;
                        }
                    }
                }
            };

            this.FindControl<Button>("saveFileButton").Click += async delegate
            {
                var taskPath = new SaveFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string? path = await taskPath;

                if (path != null)
                {
                    var context = this.DataContext as MainWindowViewModel;

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(context.Output);
                    }
                }
            };

            this.FindControl<Button>("openRegexButton").Click += async delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                string? regex = await new RegexWindow(context.MyRegex).ShowDialog<string>((Window)this.VisualRoot);
                context.MyRegex = regex;

                //ќбновл€ем поле Input а с ним и Output
                context.Input = context.Input;
            };

        }
    }
}
