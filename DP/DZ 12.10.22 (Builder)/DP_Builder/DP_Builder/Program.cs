using System;
using System.Collections;

namespace Builder
{
    public class MainApp
    {
        public static void Main()
        {
            // класс-пользователь построителей
            GraphicsEditor editor = new GraphicsEditor();

            IDocumentBuilder b1 = new JpegBuilder();
            IDocumentBuilder b2 = new BmpBuilder();
            IDocumentBuilder b3 = new GifBuilder();

            // загрузка внешнего файла и построение внутреннего документа
            editor.Load(@"c:\picture.jpg", b1);

            // Использование построенного документа
            editor.Show();

            editor.Load(@"c:\picture.bmp", b2);
            editor.Show();

            // Wait for user 
            Console.Read();
        }
    }

    // "Director" 

    class GraphicsEditor
    {
        // Product - внутренний графический документ редактора
        BitmapDocument bitmap = null;

        public void Load(string filename, IDocumentBuilder builder)
        {
            builder.ReadHeader(filename);
            builder.ReadBody();

            bitmap = builder.GetResult();
        }

        public void Show()
        {
            bitmap?.Show();
        }
    }

    // "Builder" - задаёт правила для всех построителей
    interface IDocumentBuilder
    {
        void ReadHeader(string filename);
        void ReadBody();
        BitmapDocument GetResult();
    }

    // "ConcreteBuilder1" 

    class JpegBuilder : IDocumentBuilder
    {
        private BitmapDocument product = new BitmapDocument();

        public void ReadHeader(string filename)
        {
            product.Add("Jpeg Header");
        }

        public void ReadBody()
        {
            product.Add("Picture points");
        }

        public BitmapDocument GetResult()
        {
            return product;
        }
    }

    // "ConcreteBuilder2" 

    class BmpBuilder : IDocumentBuilder
    {
        private BitmapDocument product = new BitmapDocument();

        public void ReadHeader(string filename)
        {
            product.Add("Bmp Header");
        }

        public void ReadBody()
        {
            product.Add("Picture points");
        }

        public BitmapDocument GetResult()
        {
            return product;
        }
    }

    class GifBuilder : IDocumentBuilder
    {
        private BitmapDocument product = new BitmapDocument();

        public void ReadHeader(string filename)
        {
            product.Add("Gif Header");
        }

        public void ReadBody()
        {
            product.Add("Picture points");
        }

        public BitmapDocument GetResult()
        {
            return product;
        }
    }

    // "Product"
    class BitmapDocument
    {
        ArrayList points = new ArrayList();

        public void Add(string part)
        {
            points.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in points)
                Console.WriteLine(part);
        }
    }
}
