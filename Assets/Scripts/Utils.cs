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
            return attributes[0].Description;
        else
            return value.ToString();
    }

    public static string GetEnumCategory(Enum value)
    {
        // Get the Category attribute value for the enum value
        CategoryAttribute[] attributes =
            (CategoryAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(
                typeof(CategoryAttribute), false);

        if (attributes.Length > 0)
            return attributes[0].Category;
        else
            return value.ToString();
    }

    public static T RandomEnumValue<T>(T[] excluded = null)
    {
        List<T> copy = Enum.GetValues(typeof(T)).Cast<T>().Select(v => v).ToList();
        do
        {
            int index = UnityEngine.Random.Range(0, copy.Count);
            if ((excluded == null) || (!excluded.Contains(copy[index])))
                return copy[index];
            else
                copy.RemoveAt(index);
        }
        while (copy.Count > 0);
        return default(T);
    }

    public static List<T> RandomEnumValues<T>(int n, bool repeat, T[] excluded = null)
    {
        List<T> copy = Enum.GetValues(typeof(T)).Cast<T>().Select(v => v).ToList();
        List<T> values = new List<T>();
        if (repeat)
        {
            do
            {
                int index = UnityEngine.Random.Range(0, copy.Count);
                if ((excluded == null) || (!excluded.Contains(copy[index])))
                    values.Add(copy[index]);
                else
                    copy.RemoveAt(index);
            }
            while ((copy.Count > 0) && (values.Count < n));
        }
        else
        {
            do
            {
                int index = UnityEngine.Random.Range(0, copy.Count);
                if ((excluded == null) || (!excluded.Contains(copy[index])))
                    values.Add(copy[index]);
                copy.RemoveAt(index);
            }
            while ((copy.Count > 0) && (values.Count < n));
        }
        return values;
    }

    public static Dictionary<T, int> groupCountList<T>(List<T> list)
    {
        return list.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
    }

    public static IEnumerator WaitForRealTime(float delay)
    {
        while (true)
        {
            float pauseEndTime = Time.realtimeSinceStartup + delay;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            break;
        }
    }
}
