using System.Text;

namespace ConsoleApp6;

public static class RLE
{
    public static string Decode(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }
    
        var result = new StringBuilder();
        int count = 0;
    
        foreach (var ch in value)
        {
            if (char.IsDigit(ch))
            {
                count = 10 * count + (int) char.GetNumericValue(ch);
            }
            else 
            {
                result.Append(new string(ch, count));
            }
        }
    
        return result.ToString();
    }
    
    // Этот кодирует
    public static string Encode(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            return line;
        }
    
        var result = new StringBuilder();
        int count = 1;
    
        for (int i = 0; i < line.Length; ++i)
        {
            if (i < line.Length - 1 && line[i] == line[i + 1])
            {
                count++;
            } 
            else 
            {
                result.Append(count);
                result.Append(line[i]);
    
                count = 1;
            }
        }
    
        return result.ToString();
    }
}