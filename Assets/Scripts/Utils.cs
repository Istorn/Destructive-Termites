using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class Utils{

    public static string GetEnumDescription(Enum value)
    {
        // Get the Description attribute value for the enum value
        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(
                typeof(DescriptionAttribute), false);

        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
    }
}
