using Microsoft.Win32;

object? edition = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition", null);
object? customer = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null);

Console.WriteLine($"Welcome to the {edition} ConsoleApp1.");
Console.WriteLine($"  Registered our {customer} customer.");
Console.WriteLine();

string path = GetCountFilePath();
string oldText = string.Empty;

while (!Console.KeyAvailable)
{
    string text;

    try
    {
        text = File.ReadAllText(path);
    }
    catch (Exception e)
    {
        text = e.Message;
    }

    if (text != oldText)
    {
        Console.WriteLine(text);
        oldText = text;
    }

    Thread.Sleep(1000);
}

static string GetCountFilePath()
{
    var folder = String.Empty;
    var filename = String.Empty;

    try
    {
        folder = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFileFolder", null) as string;
    }
    catch
    {
    }

    try
    {
        filename = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFileFilename", null) as string;
    }
    catch
    {
    }

    if (String.IsNullOrEmpty(folder))
    {
        folder = AppContext.BaseDirectory;
    }

    if (String.IsNullOrEmpty(filename))
    {
        filename = "WindowsService1.txt";
    }

    folder = Path.GetFullPath(folder);

    Directory.CreateDirectory(folder);

    var path = Path.Combine(folder, filename);
    return path;
}