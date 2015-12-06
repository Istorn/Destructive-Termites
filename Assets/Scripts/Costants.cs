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

    //OBJECTS
    public static float OBJ_TIME_TO_START_ATTACK = 1f;
    public static float OBJ_TTIME_TO_ADD_ATTACKERS = 0.10f;

    public static int OBJ_CURSOR_INDICATOR_OFFSET_V = -5;
    public static int OBJ_CURSOR_INDICATOR_WIDTH = 70;
    public static int OBJ_CURSOR_INDICATOR_HEIGHT = 25;
    
}
