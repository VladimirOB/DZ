using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Proxy
{
    // https://ru.wikipedia.org/wiki/Заместитель_(шаблон_проектирования)
    class Program
    {
        static void Main()
        {
            //UIElement image = new Image("bitmap.jpg");

            // нет загрузки картинки
            UIElement image = new ImageProxy("bitmap.jpg");

            // будет вызван где-то в UI
            image.Draw();

            // Wait for user 
            Console.Read();
        }
    }

    // "Subject" - предок для заменяемого объекта и прокси (заместителя), задаёт правила использования
    abstract class UIElement
    {
        public abstract void Draw();
    }

    // "RealSubject" - заменяемый объект, делает полезную работу
    class Image : UIElement
    {
        public Image(string path)
        {
            // Код загрузки картинки из файла или из сети
        }

        public override void Draw()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    // "Proxy" - заместитель, добавляет или меняет функционал заменяемого объекта
    class ImageProxy : UIElement
    {
        // Ссылка на класс заменяемого объекта, т.к. часть работы будет выполнена им
        Image realSubject;

        string path;

        public ImageProxy(string path)
        {
            this.path = path;
        }

        public override void Draw()
        {
            // Use 'lazy initialization' - ленивая загрузка
            if (realSubject == null)
            {
                realSubject = new Image(path);
            }

            realSubject.Draw();
        }
    }
}
