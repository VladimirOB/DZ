using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_Attributes
{
    // атрибут применяется только к свойствам
    [AttributeUsage(AttributeTargets.Property)]
    class Check: Attribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
    }

    static class CarsChecker
    {
        // Метод, который проверяет правильность всех свойств в переменной класса
        public static void CheckValues(Object obj)
        {
            // Получить информацию о типе
            Type objtype = obj.GetType();

            // Перебрать все существующие свойства объекта
            foreach (PropertyInfo property in objtype.GetProperties())
            {
                // Получить список атрибутов для текущего свойста
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    // Если текущий атрибут - это атрибут Check
                    if (attribute.GetType() == typeof(Check))
                    {
                        // Получить ссылку на атрибут
                        Check checkAttr = (Check)attribute;

                        if (checkAttr == null)
                            break;

                        // Если тип текущего свойства - String
                        if (property.PropertyType.Name == "String")
                        {
                            if(checkAttr.MaxLength != 0 && checkAttr.MinLength != 0)
                            {
								// Проверить значение свойства на соответствие правилу атрибута и, если правило не удовлетворено - выбросить исключение
								if (((string)property.GetValue(obj)).Length > checkAttr.MaxLength)
								{
									throw new Exception(String.Format("Max length issues: {0}", property.Name));
								}

								// Проверить значение свойства на соответствие правилу атрибута и, если правило не удовлетворено - выбросить исключение
								if (((string)property.GetValue(obj)).Length < checkAttr.MinLength)
								{
									throw new Exception(String.Format("Min length issues: {0}", property.Name));
								}
							}
                        }
                        
                        // Если тип текущего свойства - Int
                        if (property.PropertyType.Name == "Int32" || property.PropertyType.Name == "Int64")
                        {
							if (checkAttr.RangeMin != checkAttr.RangeMax)
                            {
								// Проверить значение свойства на соответствие правилу атрибута и, если правило не удовлетворено - выбросить исключение
								if (((Int32)property.GetValue(obj)) > checkAttr.RangeMax)
								{
									throw new Exception(String.Format("Max range issues: {0}", property.Name));
								}

								// Проверить значение свойства на соответствие правилу атрибута и, если правило не удовлетворено - выбросить исключение
								if (((Int32)property.GetValue(obj)) < checkAttr.RangeMin)
								{
									throw new Exception(String.Format("Min range issues: {0}", property.Name));
								}
							}
                        }
                    }
                }
            }
        }
    }
}
