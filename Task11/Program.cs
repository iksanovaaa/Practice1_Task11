using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Program
    {
        static Random rnd = new Random();
        static int length;
        static int[] decoded, encoded;
        static void Main(string[] args)
        {
            bool end = false;
            do
            {
                CreateRnd();
                Print(decoded, false);
                Encoder();
                Print(encoded, true);
                Decoder();
                Print(decoded, false);
                end = CheckKey();
            } while (!end);
            
        }

        //форимрование последовательности
        public static void CreateRnd()
        {
            length = rnd.Next(4, 26);
            decoded = new int[length];
            for (int i = 0; i < length; i++)
            {
                decoded[i] = rnd.Next(2);
            }
        }
        //печать последовательности
        public static void Print(int[] arr, bool decode)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (decode) Console.WriteLine("Зашифрованная последовательность: ");
            else Console.WriteLine("Расшифрованная последовательность: ");
            Console.ResetColor();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "");
            }
            Console.WriteLine();
        }
        //шифрование последовательности
        public static void Encoder()
        {
            encoded = new int[decoded.Length];
            encoded[0] = decoded[0];
            for (int i = 1; i < encoded.Length; i++)
            {
                if (decoded[i] == decoded[i - 1]) encoded[i] = 1;
                else encoded[i] = 0;
            }
        }
        //расшифровка последовательности
        public static void Decoder()
        {
            decoded = new int[encoded.Length];
            decoded[0] = encoded[0];
            for (int i = 1; i < decoded.Length; i++)
            {
                if (encoded[i] == 1) decoded[i] = decoded[i - 1];
                else if (decoded[i - 1] == 1) decoded[i] = 0;
                else decoded[i] = 1;
            }
        }
        //выход из программы или формирование новой последоватльности
        public static bool CheckKey()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            bool next, end = false;
            int keyNum;
            Console.WriteLine("Для выхода из программы нажмите Esc, для генерации других последоавтельностей нажмите Enter.");
            do
            {
                keyNum = Console.ReadKey().KeyChar;
                next = (keyNum == 27) || (keyNum == 13);
            } while (!next);
            if (keyNum == 27) end = true;
            Console.Clear();
            Console.ResetColor();
            return end;
        }
    }
}
