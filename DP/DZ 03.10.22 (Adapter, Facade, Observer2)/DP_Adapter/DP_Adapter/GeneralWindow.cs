using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    // класс, использующий адаптируемый объект
    class GeneralWindow
    {
        // коллекция объектов в класса (сюда мы хотим добавить адаптируемый объект)
        public List<Control> children = new List<Control>();

        public void Add(Control control)
        {
            children.Add(control);
        }

        Control FindFirstByTitle(string title)
        {
            foreach (Control control in children)
            {
                if (control.Title == title)
                    return control;
            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Control control in children)
            {
                builder.AppendFormat("{0}. x:{1}, y:{2}, width:{3}, height:{4}\n", control.Title, control.X, control.Y, control.Width, control.Height);
            }

            return builder.ToString();
        }
    }
}
