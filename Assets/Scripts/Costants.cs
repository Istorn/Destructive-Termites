using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Costants{
    
    public static int Z_INDEX_BACKGROUND = 0;

    public static int Z_INDEX_HUMANS = 50;

    public static int Z_INDEX_LIVE_BEHIND_FOREGROUND = 98;

    public static int Z_INDEX_FOREGROUND = 99;

    public static int Z_INDEX_LIVE_OVER_FOREGROUND = 100;
    

    public static string LAYER_SOFT_HARD_OBJECTS = "SoftHardObjects";
    public static string LAYER_LIVE_OBJECTS = "LiveObjects";
    public static string LAYER_BACKGROUND = "Background";
    public static string LAYER_FOREGROUND = "Foreground";

    public static float HUMAN_SPEED = 0.3f;

    public static float TIME_TO_WAIT_TO_START_ATTACK = 1f;
    public static float TIME_TO_WAIT_ADD_TERMITES_TO_ATTACK = 0.3f;
}
