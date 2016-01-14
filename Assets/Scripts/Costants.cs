using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Costants{
    
    public static int Z_INDEX_BACKGROUND = 0;

    public static int Z_INDEX_OBJ_1 = 40;
    public static int Z_INDEX_OBJ_2 = 41;
    public static int Z_INDEX_OBJ_3 = 42;

    public static int Z_INDEX_HUMANS = 50; 
    public static int Z_THREATS = 50; 

    public static int Z_INDEX_LIVE_BEHIND_FOREGROUND = 98;

    public static int Z_INDEX_FOREGROUND = 99;

    public static int Z_INDEX_LIVE_OVER_FOREGROUND = 100;

    public static int Z_INDEX_OBJ_4 = 110;
    public static int Z_INDEX_OBJ_5 = 111;
    public static int Z_INDEX_OBJ_6 = 112;
    public static int Z_INDEX_OBJ_7 = 113;

    public static string LAYER_SOFT_HARD_OBJECTS = "SoftHardObjects";
    public static string LAYER_LIVE_OBJECTS = "LiveObjects";
    public static string LAYER_BACKGROUND = "Background";
    public static string LAYER_FOREGROUND = "Foreground";
    public static string LAYER_NOT_EATABLE_OBJECTS = "NotEatableObjects";

    public static float HUMAN_SPEED = 0.3f;

    //TAGS
    public static string TAG_BACKGROUND = "Background";
    public static string TAG_OBJ_COLLIDER_PHYSICS = "ObjectPhysicsCollider";
    public static string TAG_OBJ_COLLIDER_SELECTION = "ObjectPhysicsCollider";

    //COLONY
    public static float COLONY_ATTACK_FREQUENCY = 1f;

    //HUMAN
    public static float HUMAN_WAIT_TIME = 0.7f;

    //OBJECTS
    public static float OBJ_PHYSICS_ROTATION_BOUND_LEFT = -25;
    public static float OBJ_PHYSICS_ROTATION_BOUND_RIGHT = 25;

    public static float OBJ_TIME_TO_START_ATTACK = 0.5f;
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

    //CAMERA
    public static int CAMERA_MOVEMENT = 10;

}
