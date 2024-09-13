using ConsoleApp6;

Console.WriteLine("Программа для кодирования и декодирования RLE (Run-Length Encoding, кодирование длин серий)");

if (!TryReadEncodingOption(out bool toEncode)) 
    return;

if (!TryReadFilePathToEncode(out string? filePathToEncode))
    return;

var directory = Path.GetDirectoryName(filePathToEncode)!;
var fileToEncodeName = Path.GetFileNameWithoutExtension(filePathToEncode);
var extension = Path.GetExtension(filePathToEncode);
var suffix = "_" + (toEncode ? "encoded" : "decoded");

var encodedFileName = fileToEncodeName + suffix + extension;
var encodedFilePath = Path.Combine(directory, encodedFileName);

using var oldFileReader = new StreamReader(File.OpenRead(filePathToEncode!));
using var newFileWriter = new StreamWriter(File.OpenWrite(encodedFilePath));

while (true)
{
    var line = oldFileReader.ReadLine();
    if (line is null)
    {
        break;
    }

    var convertedLine = toEncode ? RLE.Encode(line) : RLE.Decode(line);
    newFileWriter.WriteLine(convertedLine);
}

oldFileReader.Close();
newFileWriter.Close();

Console.WriteLine($"Файл \"{filePathToEncode}\" был конвертирован и сохранён как \"{encodedFilePath}\"");
Console.ReadKey();
return;

bool TryReadEncodingOption(out bool toEncode)
{
    Console.WriteLine("Выберите режим: ");
    toEncode = false;
    
    while (true)
    {
        Console.WriteLine("Нажмите 1 для кодирования, 0 для декодирования и 2 чтобы завершить досрочно.");
        int chosenVariant = int.Parse(Console.ReadLine()!);

        if (chosenVariant == 2)
        {
            Console.WriteLine("Вы выбрали выход. До свидания!");
            return false;
        } 
    
        if (chosenVariant is 1 or 0)
        {
            toEncode = chosenVariant == 1;
            break;
        }
    
        Console.WriteLine($"Опции \"{chosenVariant}\" нет!");
    }

    return true;
}

bool TryReadFilePathToEncode(out string? path)
{
    Console.WriteLine("Введите путь к файлу: ");

    while (true)
    {
        path = Console.ReadLine();

        if (path is null)
        {
            Console.WriteLine("Ввод был прерван. Завершаю...");
            return false;
        }

        if (string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Вы должны предоставить путь к файлу!");
            continue;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл по пути: \"{path}\" не существует!");
            continue;
        }

        break;
    }

    return true;
}