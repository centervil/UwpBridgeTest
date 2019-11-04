using System;

internal class ArgumentBuilder
{
    private string relativeExePath;

    public ArgumentBuilder(string relativeExePath)
    {
        this.relativeExePath = relativeExePath;
        MakeArguments(relativeExePath);
    }

    private void MakeArguments(string relativeExePath)
    {
        switch (relativeExePath)
        {
            case "WpfApp\\WpfApp.exe":
                StrParamaters = @"""Called by UwpApp""";
                break;
            default:
                break;
        }
    }

    internal string StrParamaters { get; set; }
}