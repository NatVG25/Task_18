using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string s = Console.ReadLine(); //ввод строки с консоли
            Console.WriteLine(checkBrackets(s)); //вызов метода checkBrackets
            Console.ReadKey();
        }
        static bool checkBrackets(string s) //метод checkBrackets,проверяющий строку на корректность
        {
            Stack<char> stack = new Stack<char>(); //создаем экземпляр стека, в который будем помещать соответствующие символы
            Dictionary<char, char> brackets = new Dictionary<char, char> //создаем словарь (ключ, значение) - при нахождение символа "(" в стек помещается ")" и т.д. 
            {
                {'(',')' },
                {'{','}' },
                {'[',']' }
            };
            foreach (char c in s) //перебираем все символы в строке
            {
                if (c == '[' || c == '(' || c == '{') //проверяем условие:  если встречаем одну из открытых скобок, в стек помещаем соответствующую закрытую 
                    stack.Push(brackets[c]); //Push - добавляет символ в стек

                if (c == ']' || c == ')' || c == '}') //проверяем условие:  если встречаем одну из закрытых скобок
                {
                    if (stack.Count == 0 || stack.Pop()!=c) //проверяем условие: если количество символов в стеке= 0 (стек пустой) или элемент не равен "с" (скобки не совпадают)
                    {
                        return false; //возвращаем false (прерываем метод)
                    }
                }
            }
            if (stack.Count == 0) //проверяем условие, чтобы стек был пуст
                return true;
            else
                return false;
        }
    }
}