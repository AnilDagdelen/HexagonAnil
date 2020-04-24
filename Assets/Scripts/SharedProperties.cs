using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SharedPropertiesHelper : MonoBehaviour
{
    public static class SharedProperties
    {
        public static List<Color> GridColors = new List<Color>() { Color.red, Color.blue,Color.green, Color.yellow, Color.cyan };
        public static Tuple<int, int> BoardSize = new Tuple<int, int>(8, 9);
    }
}
