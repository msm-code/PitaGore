using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

static class Utils
{
    public static void CopyClassValues<T>(T sourceComp, T targetComp)
    {
        FieldInfo[] sourceFields = sourceComp.GetType().GetFields(BindingFlags.Public |
                                                         BindingFlags.NonPublic |
                                                         BindingFlags.Instance);
        for (int i = 0; i < sourceFields.Length; i++)
        {
            var value = sourceFields[i].GetValue(sourceComp);
            sourceFields[i].SetValue(targetComp, value);
        }
    }

    public static void AddExistingComponent(this GameObject gameObject, object component)
    {
        gameObject.AddComponent(component.GetType());
        var newComponent = gameObject.GetComponent(component.GetType());
        CopyClassValues(component, newComponent);
    }

    public static void WithGuiColor(Color color, Action action)
    {
        Color old = GUI.color;
        GUI.color = color;
        action();
        GUI.color = old;
    }
}
