namespace GB_CSharp_StreamsBuffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3) {
                Console.WriteLine(".Extension Text(lower case) Path");
                return;
            }
            FindFiles(args[0], args[1], args[2]);
        }    

       public static void FindFiles(string fileExtension, string textFile, string pathFile)
       {
            try
            {
                foreach (var file in Directory.GetFiles(pathFile))
                {
                    if (Path.GetExtension(file) == fileExtension && File.ReadAllText(file).ToLower().Contains(textFile))
                    {
                        Console.WriteLine(file);
                    }
                }
                foreach (var dir in Directory.GetDirectories(pathFile))
                {
                    FindFiles(fileExtension, textFile, dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message} ");
            }
       }
    }
}