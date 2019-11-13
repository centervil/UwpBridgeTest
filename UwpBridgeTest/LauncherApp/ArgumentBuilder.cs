using System;

namespace LauncherApp
{
    internal class ArgumentBuilder
    {
        private string relativeExePath;

        public ArgumentBuilder(string relativeExePath, string receivedStr)
        {
            this.relativeExePath = relativeExePath;
            MakeArguments(relativeExePath, receivedStr);
        }

        private void MakeArguments(string relativeExePath, string receivedStr)
        {
            switch (relativeExePath)
            {
                case "WpfApp\\WpfApp.exe":
                    StrParamaters = @"""Called by UwpApp""";
                    break;
                default:
                    break;
            }
            StrParamaters += receivedStr;
        }

        internal string StrParamaters { get; set; }
    }
}