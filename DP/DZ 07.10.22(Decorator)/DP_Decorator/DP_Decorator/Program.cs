using System;

namespace DP_Decorator
{
    class MainApp
    {
        static void Main()
        {
            // Создание текстового поля и его декораторов
            TextBox textBox = new TextBox();

            Border border = new Border(textBox);
            ScrollBar scrollBar = new ScrollBar(border);

            // Отрисовка тестового поля и его декораторов
            scrollBar.Draw();

            /*
            TextBox -> BorderTextBox -> BorderTextBoxScrollBar
                -> ScrollBarTextBox
                -> ShadowTextBox -> ShadowBorderTextBox
                -> TextBox3D 
            */

            Console.WriteLine();

            /*Button button = new Button();
            Border border2 = new Border(button);
            ScrollBar scrollBar2 = new ScrollBar(border2);*/

            new ScrollBar(new Border(new Button())).Draw();

            // Wait for user 
            Console.Read();
        }
    }
}
