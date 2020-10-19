using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Utilities
{
    public class ClassReflectionUtilities
    {

        public static string GetEnumDescription(Enum value)
        {
            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;
        }

        public static String[] GetEnumerableOptions(Type enumObj)
        {
            List<String> result = new List<string>();
            foreach (Enum obj in Enum.GetValues(enumObj))
            {
                result.Add(GetEnumDescription(obj));
            }
            return result.ToArray();
        }

        public static Enum GetEnumerableTypeByDescription(Type sourceEnum, String description)
        {
            foreach (Enum obj in Enum.GetValues(sourceEnum))
            {
                if(GetEnumDescription(obj).Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
