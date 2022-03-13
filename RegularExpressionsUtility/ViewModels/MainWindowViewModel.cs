using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Text.RegularExpressions;

namespace RegularExpressionsUtility.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string regex = "";
        string input = "";
        string output = "";
        public string MyRegex
        {
            get => regex;
            set
            {
                if(value != null)
                {
                    regex = value;
                }
            }
        }

        public string Output
        {
            get => output;
            set
            {
                if(MyRegex != "")
                {
                    this.RaiseAndSetIfChanged(ref output, value);
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref output, "Регулярное выражение не введено!");
                }
            }
        }

        public string Input
        {
            get => input;
            set {
                Output = "";
                if (MyRegex != "")
                {
                    Regex rgx = new Regex(MyRegex);
                    foreach (Match match in rgx.Matches(value))
                    {
                        Output += match.Value + "\n";
                    }
                    if (Output == "")
                    {
                        Output = "Ничего не найдено!";
                    }
                }
                this.RaiseAndSetIfChanged(ref input, value);
            }
        }
    }
}
