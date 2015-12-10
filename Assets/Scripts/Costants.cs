using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Costants{
    
    public static int Z_INDEX_BACKGROUND = 0;

    public static int Z_INDEX_OBJ_1 = 40;
    public static int Z_INDEX_OBJ_2 = 41;
    public static int Z_INDEX_OBJ_3 = 42;

    public static int Z_INDEX_HUMANS = 50;

    public static int Z_INDEX_OBJ_4 = 60;
    public static int Z_INDEX_OBJ_5 = 61;
    public static int Z_INDEX_OBJ_6 = 62;

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
    public static float OBJ_TIME_TO_ADD_500_ATTACKERS = 0.10f;

    public static float OBJ_TIME_INTERVAL_FLASHING = 0.6f;

    public static float INDICATOR_START_ATTACK_OFFSET_V = -5.0f;
    public static float INDICATOR_START_ATTACK_WIDTH = 70.0f;
    public static float INDICATOR_START_ATTACK_HEIGHT = 25.0f;

    public static float INDICATOR_ATTACK_ATTACKERS_WIDTH = 45.0f;
    public static float INDICATOR_ATTACK_ATTACKERS_HEIGHT = 20.0f;
    public static float INDICATOR_ATTACK_ATTACKERS_OFFSET_V = 5.0f;


    public static float INDICATOR_ATTACK_BOOSTER_OFFSET = 0.10f;
    public static float INDICATOR_ATTACK_BOOSTER_RADIUS = 7.5f;
    public static float INDICATOR_ATTACK_BOOSTER_ANGLE = 45.0f;
}
