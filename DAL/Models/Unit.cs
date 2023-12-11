using System.ComponentModel;
using System.Reflection;

namespace DAL.Models
{

    public static class UnitExtensions
    {
        public static string GetDescription(this Unit unit)
        {
            Type enumType = typeof(Unit);
            MemberInfo[] memberInfo = enumType.GetMember(unit.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return unit.ToString();
        }

        public static Unit GetEnumValueFromDescription(string description)
        {
            Type enumType = typeof(Unit);
            Array enumValues = Enum.GetValues(enumType);

            foreach (var enumValue in enumValues)
            {
                Unit unitEnumValue = (Unit)enumValue;
                string enumDescription = unitEnumValue.GetDescription();

                if (enumDescription.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    return unitEnumValue;
                }
            }

            throw new ArgumentException("Description not found in enum.", nameof(description));
        }
    }
    public enum Unit
    {
        [Description("СтЛ")]
        TableSpoon = 1,
        [Description("ЧЛ")]
        TeaSpoon = 2,
        [Description("Шт")]
        Piece = 3,
        [Description("Г")]
        Gram = 4,
        [Description("Л")]
        Liter = 5,
        [Description("Скл")]
        Glass = 6
    }
}
