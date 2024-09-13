public static class RLE
{
    public static void Decode(StreamReader reader, StreamWriter writer)
    {
        int count = 0;
    
        while (!reader.EndOfStream)
        {
            var ch = (char) reader.Read();
            
            if (char.IsDigit(ch))
            {
                count = 10 * count + (int) char.GetNumericValue(ch);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    writer.Write(ch);
                }
                
                count = 0;
            }
        }
        
        writer.WriteLine();
    }
    
    public static void Encode(StreamReader reader, StreamWriter writer)
    {
        int count = 1;
        
        while (!reader.EndOfStream)
        {
            var ch = reader.Read();
            if (ch != -1 && ch == reader.Peek())
            {
                count++;
            } 
            else 
            {
                writer.Write(count);
                writer.Write((char) ch);
    
                count = 1;
            }
        }
        
        writer.WriteLine();
    }
}