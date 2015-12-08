using UnityEngine;
using System.Collections;
using System.Linq;

public class Level1Data: LevelData {

    public override void initialize()
    {
        _liveObjectsNodes = new Graph.Node[53];
        //PIANO 0 - STANZA 0
        _liveObjectsNodes[0] = new Graph.Node(0, 0, new Vector2(-5.50f, -2.60f), Graph.Node.Type.Main);
        _liveObjectsNodes[1] = new Graph.Node(1, 0, new Vector2(-5.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[2] = new Graph.Node(2, 0, new Vector2(-4.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[3] = new Graph.Node(3, 0, new Vector2(-4.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[4] = new Graph.Node(4, 0, new Vector2(-3.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[5] = new Graph.Node(5, 0, new Vector2(-3.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[6] = new Graph.Node(6, 0, new Vector2(-2.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[7] = new Graph.Node(7, 0, new Vector2(-2.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[8] = new Graph.Node(8, 0, new Vector2(-1.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[9] = new Graph.Node(9, 0, new Vector2(-1.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[10] = new Graph.Node(10, 0, new Vector2(-0.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[11] = new Graph.Node(11, 0, new Vector2(0.00f, -2.60f), Graph.Node.Type.Main);
        _liveObjectsNodes[12] = new Graph.Node(12, 0, new Vector2(0.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[13] = new Graph.Node(13, 0, new Vector2(1.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[14] = new Graph.Node(14, 0, new Vector2(1.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[15] = new Graph.Node(15, 0, new Vector2(2.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[16] = new Graph.Node(16, 0, new Vector2(2.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[17] = new Graph.Node(17, 0, new Vector2(3.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[18] = new Graph.Node(18, 0, new Vector2(3.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[19] = new Graph.Node(19, 0, new Vector2(4.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[20] = new Graph.Node(20, 0, new Vector2(4.50f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[21] = new Graph.Node(21, 0, new Vector2(5.00f, -2.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[22] = new Graph.Node(22, 0, new Vector2(5.50f, -2.60f), Graph.Node.Type.Main);
        //SCALA PIANO 0 - 1
        _liveObjectsNodes[23] = new Graph.Node(23, 0, new Vector2(0.50f, -2.10f), Graph.Node.Type.Generic);
        _liveObjectsNodes[24] = new Graph.Node(24, 0, new Vector2(1.00f, -1.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[25] = new Graph.Node(25, 0, new Vector2(1.50f, -1.10f), Graph.Node.Type.Generic);
        _liveObjectsNodes[26] = new Graph.Node(26, 0, new Vector2(2.00f, -0.60f), Graph.Node.Type.Generic);
        _liveObjectsNodes[27] = new Graph.Node(27, 0, new Vector2(2.50f, -0.10f), Graph.Node.Type.Generic);
        _liveObjectsNodes[28] = new Graph.Node(28, 0, new Vector2(3.00f, 0.40f), Graph.Node.Type.Generic);
        _liveObjectsNodes[29] = new Graph.Node(29, 0, new Vector2(3.50f, 1.10f), Graph.Node.Type.Generic);
        //PIANO 1 - STANZA 1
        _liveObjectsNodes[30] = new Graph.Node(30, 1, new Vector2(4.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[31] = new Graph.Node(31, 1, new Vector2(4.50f, 1.30f), Graph.Node.Type.Main);
        _liveObjectsNodes[32] = new Graph.Node(32, 1, new Vector2(5.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[33] = new Graph.Node(33, 1, new Vector2(5.50f, 1.30f), Graph.Node.Type.Main);
        _liveObjectsNodes[34] = new Graph.Node(34, 1, new Vector2(4.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[35] = new Graph.Node(35, 1, new Vector2(3.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[36] = new Graph.Node(36, 1, new Vector2(3.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[37] = new Graph.Node(37, 1, new Vector2(2.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[38] = new Graph.Node(38, 1, new Vector2(2.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[39] = new Graph.Node(39, 1, new Vector2(1.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[40] = new Graph.Node(40, 1, new Vector2(1.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[41] = new Graph.Node(41, 1, new Vector2(0.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[42] = new Graph.Node(42, 1, new Vector2(0.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[43] = new Graph.Node(43, 1, new Vector2(-0.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[44] = new Graph.Node(44, 1, new Vector2(-1.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[45] = new Graph.Node(45, 1, new Vector2(-1.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[46] = new Graph.Node(46, 1, new Vector2(-2.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[47] = new Graph.Node(47, 1, new Vector2(-2.50f, 1.30f), Graph.Node.Type.Main);
        //PIANO 1 - STANZA 2
        _liveObjectsNodes[48] = new Graph.Node(48, 2, new Vector2(-3.00f, 1.30f), Graph.Node.Type.Main);
        _liveObjectsNodes[49] = new Graph.Node(49, 2, new Vector2(-3.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[50] = new Graph.Node(50, 2, new Vector2(-4.00f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[51] = new Graph.Node(51, 2, new Vector2(-4.50f, 1.30f), Graph.Node.Type.Generic);
        _liveObjectsNodes[52] = new Graph.Node(52, 2, new Vector2(-5.00f, 1.30f), Graph.Node.Type.Main);

        _liveObjectsLinks = new Graph.Connection[52];
        _liveObjectsLinks[0] = new Graph.Connection(0, 1, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[1] = new Graph.Connection(1, 2, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[2] = new Graph.Connection(2, 3, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[3] = new Graph.Connection(3, 4, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[4] = new Graph.Connection(4, 5, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[5] = new Graph.Connection(5, 6, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[6] = new Graph.Connection(6, 7, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[7] = new Graph.Connection(7, 8, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[8] = new Graph.Connection(8, 9, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[9] = new Graph.Connection(9, 10, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[10] = new Graph.Connection(10, 11, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[11] = new Graph.Connection(11, 12, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[12] = new Graph.Connection(12, 13, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[13] = new Graph.Connection(13, 14, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[14] = new Graph.Connection(14, 15, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[15] = new Graph.Connection(15, 16, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[16] = new Graph.Connection(16, 17, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[17] = new Graph.Connection(17, 18, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[18] = new Graph.Connection(18, 19, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[19] = new Graph.Connection(19, 20, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[20] = new Graph.Connection(20, 21, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[21] = new Graph.Connection(21, 22, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);

        _liveObjectsLinks[22] = new Graph.Connection(11, 23, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[23] = new Graph.Connection(23, 24, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[24] = new Graph.Connection(24, 25, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[25] = new Graph.Connection(25, 26, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[26] = new Graph.Connection(26, 27, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[27] = new Graph.Connection(27, 28, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[28] = new Graph.Connection(28, 29, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[29] = new Graph.Connection(29, 30, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[30] = new Graph.Connection(30, 31, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);

        _liveObjectsLinks[31] = new Graph.Connection(31, 32, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[32] = new Graph.Connection(32, 33, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);

        _liveObjectsLinks[33] = new Graph.Connection(31, 34, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[34] = new Graph.Connection(34, 35, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[35] = new Graph.Connection(35, 36, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[36] = new Graph.Connection(36, 37, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[37] = new Graph.Connection(37, 38, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[38] = new Graph.Connection(38, 39, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);
        _liveObjectsLinks[39] = new Graph.Connection(39, 40, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND);

        _liveObjectsLinks[40] = new Graph.Connection(40, 41, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[41] = new Graph.Connection(41, 42, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[42] = new Graph.Connection(42, 43, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[43] = new Graph.Connection(43, 44, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[44] = new Graph.Connection(44, 45, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[45] = new Graph.Connection(45, 46, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[46] = new Graph.Connection(46, 47, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[47] = new Graph.Connection(47, 48, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[48] = new Graph.Connection(48, 49, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[49] = new Graph.Connection(49, 50, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[50] = new Graph.Connection(50, 51, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);
        _liveObjectsLinks[51] = new Graph.Connection(51, 52, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND);

        _rooms = new Room[3];
        _rooms[0] = new Room(0);
        _rooms[1] = new Room(1);
        _rooms[2] = new Room(2);

        _termitesNodes = new Graph.Node[0];

        _termitesLinks = new Graph.Connection[0];

        _cameraSettings = new Vector3[3];
        _cameraSettings[0] = new Vector3( 7.31f, -2.93f, -50); //new Vector3(0, -0.625f, -1);
        _cameraSettings[1] = new Vector3(-7.31f, -2.93f, -1);//new Vector2(0, -0.625f);
        _cameraSettings[2] = new Vector3( 7.31f,  1.65f, -1);//new Vector2(0, -0.625f);

        _humans = new HumanPlaceholder[0];

        _availableTermites = 500;

        _floorColliders = new Vector2[3][];

        Vector2[] points = new Vector2[2];
        points[0] = new Vector2(-10.3f,  2.90f);
        points[1] = new Vector2( 14.1f,  2.90f);
        _floorColliders[0] = points;

        points = new Vector2[2];
        points[0] = new Vector2(-10.3f, -1.20f);
        points[1] = new Vector2(14.1f, -1.20f);
        _floorColliders[1] = points;

        points = new Vector2[2];
        points[0] = new Vector2(-10.3f, -5.30f);
        points[1] = new Vector2(14.1f, -5.30f);
        _floorColliders[2] = points;

        _objects = new ObjectPlaceholder[59];
        _objects[00] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_1, new Vector3(-10.12f, -3.73f, 0), "L1_F1_KITCHEN_RACK2_00", GenericObject.Types.Soft);
        _objects[01] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_1, new Vector3(-10.12f, -4.44f, 0), "L1_F1_KITCHEN_RACK1_00", GenericObject.Types.Soft);
        _objects[02] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_2, new Vector3(-07.98f, -3.85f, 0), "L1_F1_KITCHEN_FRIDGE_00", GenericObject.Types.Hard);
        _objects[03] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_2, new Vector3(-12.08f, -4.43f, 0), "L1_F1_KITCHEN_LAMPx3_00", GenericObject.Types.Hard);
        _objects[04] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_2, new Vector3(-11.28f, -4.43f, 0), "L1_F1_KITCHEN_LAMPx3_00", GenericObject.Types.Hard);
        _objects[05] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_4, new Vector3(-12.00f, -5.19f, 0), "L1_F1_KITCHEN_CHAIR2_00", GenericObject.Types.Hard);
        _objects[06] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_4, new Vector3(-11.24f, -5.19f, 0), "L1_F1_KITCHEN_CHAIR2_00", GenericObject.Types.Hard);
        _objects[07] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_5, new Vector3(-11.94f, -5.71f, 0), "L1_F1_KITCHEN_TABLE_00", GenericObject.Types.Hard);
        _objects[08] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_6, new Vector3(-12.78f, -6.16f, 0), "L1_F1_KITCHEN_CHAIR1_00", GenericObject.Types.Hard);
        _objects[09] = new ObjectPlaceholder(00, Costants.Z_INDEX_OBJ_6, new Vector3(-11.74f, -6.16f, 0), "L1_F1_KITCHEN_CHAIR1_00", GenericObject.Types.Hard);

        _objects[10] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_1, new Vector3(-00.21f, -3.61f, 0), "L1_F1_LIVING_POSTER5_00", GenericObject.Types.Soft);
        _objects[11] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_1, new Vector3(-00.25f, -4.32f, 0), "L1_F1_LIVING_COACH1_00", GenericObject.Types.Soft);
        _objects[12] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_1, new Vector3( 02.68f, -4.42f, 0), "L1_F1_LIVING_SHELF_00", GenericObject.Types.Soft);
        _objects[13] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_2, new Vector3( 03.10f, -4.10f, 0), "L1_F1_LIVING_TV_00", GenericObject.Types.Hard);
        _objects[14] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_4, new Vector3(-03.39f, -5.83f, 0), "L1_F1_LIVING_COACH2_00", GenericObject.Types.Soft);
        _objects[15] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_4, new Vector3( 02.00f, -6.13f, 0), "L1_F1_LIVING_COACH3_00", GenericObject.Types.Soft);
        _objects[16] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_4, new Vector3(-02.00f, -5.60f, 0), "L1_F1_LIVING_LAMP_00", GenericObject.Types.Hard);
        _objects[17] = new ObjectPlaceholder(01, Costants.Z_INDEX_OBJ_4, new Vector3(-00.38f, -5.8f, 0), "L1_F1_LIVING_TABLE2_00", GenericObject.Types.Hard);

        _objects[18] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_1, new Vector3( 06.81f, -3.65f, 0), "L1_F1_GARAGE_SHELF_00", GenericObject.Types.Soft);
        _objects[19] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_2, new Vector3( 05.84f, -2.90f, 0), "L1_F1_GARAGE_BOX1", GenericObject.Types.Soft);
        _objects[20] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_2, new Vector3( 08.64f, -2.90f, 1), "L1_F1_GARAGE_BOX2", GenericObject.Types.Hard);
        _objects[21] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_3, new Vector3( 05.20f, -3.72f, 0), "L1_F1_GARAGE_BOX3", GenericObject.Types.Soft);
        _objects[22] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_2, new Vector3( 05.68f, -3.72f, 0), "L1_F1_GARAGE_BOX3", GenericObject.Types.Soft);
        _objects[23] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_2, new Vector3( 07.28f, -3.72f, 0), "L1_F1_GARAGE_BOX3", GenericObject.Types.Soft);
        _objects[24] = new ObjectPlaceholder(02, Costants.Z_INDEX_OBJ_4, new Vector3( 08.58f, -5.50f, 0), "L1_F1_GARAGE_CAR_00", GenericObject.Types.Hard);

        _objects[25] = new ObjectPlaceholder(03, Costants.Z_INDEX_OBJ_1, new Vector3(-12.49f, -0.1f, 0), "L1_F2_ROOM3_CLOSET-B_00", GenericObject.Types.Soft);
        _objects[26] = new ObjectPlaceholder(03, Costants.Z_INDEX_OBJ_1, new Vector3(-09.05f, -0.60f, 0), "L1_F2_ROOM3_BEED2_00", GenericObject.Types.Soft);
        _objects[27] = new ObjectPlaceholder(03, Costants.Z_INDEX_OBJ_4, new Vector3(-09.20f, -0.27f, 0), "L1_F2_ROOM3_POSTER3_00", GenericObject.Types.Soft);

        _objects[28] = new ObjectPlaceholder(04, Costants.Z_INDEX_OBJ_1, new Vector3(-01.68f, -0.57f, 0), "L1_F2_HALL2_RACK_00", GenericObject.Types.Soft);
        _objects[29] = new ObjectPlaceholder(04, Costants.Z_INDEX_OBJ_2, new Vector3(-01.68f,  0.40f, 0), "L1_F2_HALL2_PLANT_", GenericObject.Types.Soft);

        _objects[30] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_1, new Vector3( 01.30f,  0.26f, 0), "L1_F2_ROOM4_BOOKSHELF_00", GenericObject.Types.Soft);
        _objects[31] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_1, new Vector3( 03.54f, -0.40f, 0), "L1_F2_ROOM4_BED_00", GenericObject.Types.Soft);
        _objects[32] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 00.95f,  1.02f, 0), "L1_F2_ROOM4_TOY1_", GenericObject.Types.Hard);
        _objects[33] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 01.30f,  1.02f, 0), "L1_F2_ROOM4_TOY2_", GenericObject.Types.Hard);
        _objects[34] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 01.62f,  1.02f, 0), "L1_F2_ROOM4_TOY3_", GenericObject.Types.Hard);
        _objects[35] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 01.26f,  0.15f, 0), "L1_F2_ROOM4_TOY4_", GenericObject.Types.Hard);
        _objects[36] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_4, new Vector3( 00.94f, -1.19f, 0), "L1_F2_ROOM4_ARMCHAIR_00", GenericObject.Types.Soft);

        _objects[37] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_1, new Vector3( 06.89f, -0.47f, 0), "L1_F2_ROOM5_DESK2_00", GenericObject.Types.Soft);
        _objects[38] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_1, new Vector3( 07.01f,  0.28f, 0), "L1_F2_ROOM5_POSTER4_00", GenericObject.Types.Hard);
        _objects[39] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_1, new Vector3( 08.78f,  0.28f, 0), "L1_F2_ROOM5_POSTER5_00", GenericObject.Types.Hard);
        _objects[40] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_2, new Vector3( 06.63f,  0.06f, 0), "L1_F2_ROOM5_PC_00", GenericObject.Types.Hard);
        _objects[41] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_2, new Vector3( 07.76f, -0.29f, 1), "L1_F2_ROOM5_PRINTER_00", GenericObject.Types.Hard);
        _objects[42] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_3, new Vector3( 06.87f, -0.53f, 0), "L1_F2_ROOM5_CHAIR-BLACK_00", GenericObject.Types.Hard);

        _objects[43] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-11.39f,  3.38f, 0), "L1_F3_ROOM1_BED_00", GenericObject.Types.Soft);
        _objects[44] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-09.07f,  3.38f, 0), "L1_F3_ROOM1_DESK", GenericObject.Types.Soft);
        _objects[45] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-06.50f,  4.17f, 0), "L1_F3_ROOM1_CLOSET-S_00", GenericObject.Types.Soft);
        _objects[46] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-08.76f,  5.16f, 0), "L1_F3_ROOM1_POSTER1_00", GenericObject.Types.Soft);
        _objects[47] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_2, new Vector3(-09.24f,  3.34f, 0), "L1_F3_ROOM1_CHAIR-BLACK_00", GenericObject.Types.Hard);
        _objects[48] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_2, new Vector3(-08.92f,  3.76f, 0), "L1_F3_ROOM1_PC_00", GenericObject.Types.Hard);

        _objects[49] = new ObjectPlaceholder(08, Costants.Z_INDEX_OBJ_1, new Vector3(-02.58f,  4.24f, 0), "L1_F3_HALL1_POSTER2_00", GenericObject.Types.Soft);

        _objects[50] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 01.46f,  4.47f, 0), "L1_F3_BATHROOM_SHOWER_00", GenericObject.Types.Hard);
        _objects[51] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 03.11f,  3.46f, 0), "L1_F3_BATHROOM_SINK_00", GenericObject.Types.Soft);
        _objects[52] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 03.10f,  3.97f, 0), "L1_F3_BATHROOM_MIRROR_00", GenericObject.Types.Hard);
        _objects[53] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 04.12f,  4.13f, 0), "L1_F3_BATHROOM_CLOSET-S_00", GenericObject.Types.Hard);
        _objects[54] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_4, new Vector3( 01.02f,  3.06f, 0), "L1_F3_BATHROOM_TOILET_00", GenericObject.Types.Hard);

        _objects[55] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_1, new Vector3( 06.90f,  4.62f, 0), "L1_F3_ROOM2_LAMPx3_00", GenericObject.Types.Hard);
        _objects[56] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_1, new Vector3( 08.15f,  4.62f, 0), "L1_F3_ROOM2_LAMPx3_00", GenericObject.Types.Hard);
        _objects[57] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_1, new Vector3( 09.40f,  4.62f, 0), "L1_F3_ROOM2_LAMPx3_00", GenericObject.Types.Hard);
        _objects[58] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_4, new Vector3( 08.28f,  3.16f, 0), "L1_F3_ROOM2_BILLARD_00", GenericObject.Types.Soft);
    }
}
