using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    // класс, использующий адаптируемый объект
    class GeneralArchiver
    {
        // коллекция объектов в класса (сюда мы хотим добавить адаптируемый объект)
        public Dictionary<string, PackAlgorithm> algorithms = new Dictionary<string, PackAlgorithm>();

        public void Add(string mask, PackAlgorithm control)
        {
            algorithms.Add(mask, control);
        }

        PackAlgorithm FindAlgByTitle(string title)
        {
            foreach (var control in algorithms)
            {

            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var control in algorithms)
            {
            
            }

            return builder.ToString();
        }
    }
}
