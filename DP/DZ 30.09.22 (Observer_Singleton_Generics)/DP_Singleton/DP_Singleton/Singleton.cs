using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Singleton
{
    // непотокобезопасная, простая реализация
    /*class Singleton
    {
        private static Singleton _instance;

        // закрытый конструктор
        private Singleton()
        {
        }

        // метод возвращает экземпляр синглтона
        public static Singleton Instance()
        {
            // ленивое создание
            if (_instance == null)
            {
                // единоразовое создание экземпляра класса
                _instance = new Singleton();
            }

            // возврат существующего объекта
            return _instance;
        }
    }*/

    // потокобезопасный синглтон
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton() { }

        public static Singleton Instance()
        {
            return instance;
        }
    }
}
