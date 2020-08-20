using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.AnonymousType_Kortegi_ValueTuple_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            //анонимные типы для создания объектов определенного но без указания определенного класса которого мы используем(синтаксический сахар)
            //свойства для чтения у него

            // var - для объявления анонимных типов var i = 5;
            var product = new //анонимный тип
            {
                Name = "Молоко", // свойства
                Energy = 10
            };
            //product.Energy = 55; //будет ошибка потому, что свойства только для чтения
            Console.WriteLine(product.Name); //читает только свойства 

            // 2 особенность аноним типов
            var eat = new Eat()
            {
                Name = "Мясо"
            };
            var product2 = new
            {
                eat.Name, // можем подставить(передать) из другого класса
                Energy = 11
            };
            Console.WriteLine(product2.Name); //читает только свойства 

            //кортежи позволяют нам задавать своеобразные коллекции элементов различных типов( такие же как анон тип)
            //tuple - набор возвращ кортежей различного типа
            Tuple<int, string> tuple = new Tuple<int, string>(5, "Hi"); //tuple - ссылочный тип (в куче) медленее
            // защищены от записи свойства точно также как и анон тип
            Console.WriteLine(tuple.Item1); //первый элемент
            Console.WriteLine(tuple.Item2); //второй элемент

            var tuple2 = (6, "Hello");// можно так задавать - это уже ValueTuple - значимый тип ( в стеке )  быстрее так как в оператичной памяти
            Console.WriteLine(tuple2.Item1); //первый элемент
            Console.WriteLine(tuple2.Item2); //второй элемент

            //В ValueTuple - мы можем менять имена элементов( не item1, а что то другое). в Tuple такого сделать нельзя
            var tuple3 = (Name: "Tomato", Energy: 20);
            Console.WriteLine(tuple3.Name); //первый элемент
            Console.WriteLine(tuple3.Energy); //второй элемент

            //ValueTuple мы можем изменять значение полей
            tuple3.Energy = 30;
            Console.WriteLine(tuple3.Name); //первый элемент
            Console.WriteLine(tuple3.Energy); //второй элемент


            var result = GetData();
            Console.WriteLine(result.Name); //задали имя элементу внизу в GetData и вывели

            Console.ReadKey();
        }

        public static (int Number, string Name, bool Flag) GetData()
        {
            var number = 7821; //метод получения данных
            var name = Guid.NewGuid().ToString(); //метод получения данных
            bool b = number > 500; //проверка условия

            return (number,name,b); //возвращаем кортеж

        }
    }
}
