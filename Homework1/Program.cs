using System;
using System.Runtime.InteropServices;

namespace MessageBoxPInvoke
{
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int MessageBox(
            IntPtr hWnd,          // Дескриптор родительского окна
            string text,          // Текст сообщения
            string caption,       // Заголовок окна
            uint type             // Тип кнопок и иконок
        );

        static void Main(string[] args)
        {
            string myFullName = "Гулак Евгения Юрьевна";

            // Вызов MessageBox через P/Invoke
            MessageBox(
                IntPtr.Zero, 
                $"Привет, меня зовут: {myFullName}", 
                "Моё ФИО",                      
                0x00000040                      
            );

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}