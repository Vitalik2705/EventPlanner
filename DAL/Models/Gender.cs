// <copyright file="Gender.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel;
using System.Reflection;

namespace DAL.Models
{
    public enum Gender
    {
        [Description("Чоловік")]
        Male = 0,
        [Description("Жінка")]
        Female = 1,
    }

    public static class GenderExtensions
    {
        public static string GetDescription(this Gender gender)
        {
            Type enumType = typeof(Gender);
            MemberInfo[] memberInfo = enumType.GetMember(gender.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return gender.ToString();
        }
    }
}
