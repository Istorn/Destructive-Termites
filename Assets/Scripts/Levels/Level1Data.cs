﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Level1Data: LevelData {

    public override void initialize()
    {
        _liveObjectsNodes = new List<Graph.Node>();
        //PIANO 0 - STANZA 0
        _liveObjectsNodes.Add(new Graph.Node(  0,  0, new Vector2(-12.50f, -4.20f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node(  1,  0, new Vector2(-12.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  2,  0, new Vector2(-11.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  3,  0, new Vector2(-11.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  4,  0, new Vector2(-10.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  5,  0, new Vector2(-10.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  6,  0, new Vector2(-09.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  7,  0, new Vector2(-09.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  8,  0, new Vector2(-08.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(  9,  0, new Vector2(-08.00f, -4.20f), Graph.Node.Type.Main));

        //PIANO 0 - STANZA 1
        _liveObjectsNodes.Add(new Graph.Node( 10,  1, new Vector2(-07.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 11,  1, new Vector2(-07.00f, -4.20f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node( 12,  1, new Vector2(-06.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 13,  1, new Vector2(-06.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 14,  1, new Vector2(-05.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 15,  1, new Vector2(-05.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 16,  1, new Vector2(-04.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 17,  1, new Vector2(-04.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 18,  1, new Vector2(-03.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 19,  1, new Vector2(-03.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 20,  1, new Vector2(-02.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 21,  1, new Vector2(-02.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 22,  1, new Vector2(-01.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 23,  1, new Vector2(-01.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 24,  1, new Vector2(-00.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 25,  1, new Vector2( 00.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 26,  1, new Vector2( 00.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 27,  1, new Vector2( 01.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 28,  1, new Vector2( 01.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 29,  1, new Vector2( 02.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 30,  1, new Vector2( 02.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 31,  1, new Vector2( 03.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 32,  1, new Vector2( 03.50f, -4.20f), Graph.Node.Type.Main));
         
        //PIANO 0 - STANZA 2
        _liveObjectsNodes.Add(new Graph.Node( 33,  2, new Vector2( 04.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 34,  2, new Vector2( 04.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 35,  2, new Vector2( 05.00f, -4.20f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node( 36,  2, new Vector2( 05.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 37,  2, new Vector2( 06.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 38,  2, new Vector2( 06.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 39,  2, new Vector2( 07.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 40,  2, new Vector2( 07.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 41,  2, new Vector2( 08.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 42,  2, new Vector2( 08.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 43,  2, new Vector2( 09.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 44,  2, new Vector2( 09.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 45,  2, new Vector2( 10.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 46,  2, new Vector2( 10.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 47,  2, new Vector2( 11.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 48,  2, new Vector2( 11.50f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 49,  2, new Vector2( 12.00f, -4.20f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 50,  2, new Vector2( 12.50f, -4.20f), Graph.Node.Type.Main));
 
        //PIANO 1 - STANZA 3
        _liveObjectsNodes.Add(new Graph.Node( 51,  3, new Vector2(-12.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 52,  3, new Vector2(-12.00f, -0.05f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node( 53,  3, new Vector2(-11.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 54,  3, new Vector2(-11.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 55,  3, new Vector2(-10.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 56,  3, new Vector2(-10.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 57,  3, new Vector2(-09.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 58,  3, new Vector2(-09.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 59,  3, new Vector2(-08.50f, -0.05f), Graph.Node.Type.Main));
        
        //PIANO 1 - STANZA 4
        _liveObjectsNodes.Add(new Graph.Node( 60,  4, new Vector2(-08.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 61,  4, new Vector2(-07.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 62,  4, new Vector2(-07.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 63,  4, new Vector2(-06.50f, -0.05f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node( 64,  4, new Vector2(-06.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 65,  4, new Vector2(-05.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 66,  4, new Vector2(-05.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 67,  4, new Vector2(-04.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 68,  4, new Vector2(-04.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 69,  4, new Vector2(-03.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 70,  4, new Vector2(-03.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 71,  4, new Vector2(-02.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 72,  4, new Vector2(-02.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 73,  4, new Vector2(-01.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 74,  4, new Vector2(-01.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 75,  4, new Vector2(-00.50f, -0.05f), Graph.Node.Type.Main));
 
        //PIANO 1 - STANZA 5
        _liveObjectsNodes.Add(new Graph.Node( 76,  5, new Vector2( 00.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 77,  5, new Vector2( 00.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 78,  5, new Vector2( 01.00f, -0.05f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node( 79,  5, new Vector2( 01.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 80,  5, new Vector2( 02.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 81,  5, new Vector2( 02.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 82,  5, new Vector2( 03.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 83,  5, new Vector2( 03.50f, -0.05f), Graph.Node.Type.Main));

        //PIANO 1 - STANZA  6
        _liveObjectsNodes.Add(new Graph.Node( 84,  6, new Vector2( 04.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 85,  6, new Vector2( 04.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 86,  6, new Vector2( 05.00f, -0.05f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node( 87,  6, new Vector2( 05.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 88,  6, new Vector2( 06.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 89,  6, new Vector2( 06.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 90,  6, new Vector2( 07.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 91,  6, new Vector2( 07.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 92,  6, new Vector2( 08.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 93,  6, new Vector2( 08.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 94,  6, new Vector2( 09.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 95,  6, new Vector2( 09.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 96,  6, new Vector2( 10.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 97,  6, new Vector2( 10.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 98,  6, new Vector2( 11.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node( 99,  6, new Vector2( 11.50f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(100,  6, new Vector2( 12.00f, -0.05f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(101,  6, new Vector2( 12.50f, -0.05f), Graph.Node.Type.Main));

        //PIANO 2 - STANZA 7
        _liveObjectsNodes.Add(new Graph.Node(102,  7, new Vector2(-12.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(103,  7, new Vector2(-12.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(104,  7, new Vector2(-11.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(105,  7, new Vector2(-11.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(106,  7, new Vector2(-10.50f,  4.11f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node(107,  7, new Vector2(-10.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(108,  7, new Vector2(-09.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(109,  7, new Vector2(-09.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(110,  7, new Vector2(-08.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(111,  7, new Vector2(-08.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(112,  7, new Vector2(-07.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(113,  7, new Vector2(-07.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(114,  7, new Vector2(-06.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(115,  7, new Vector2(-06.00f,  4.11f), Graph.Node.Type.Main));

        //PIANO 2 - STANZA 8
        _liveObjectsNodes.Add(new Graph.Node(116,  8, new Vector2(-05.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(117,  8, new Vector2(-05.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(118,  8, new Vector2(-04.50f,  4.11f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node(119,  8, new Vector2(-04.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(120,  8, new Vector2(-03.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(121,  8, new Vector2(-03.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(122,  8, new Vector2(-02.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(123,  8, new Vector2(-02.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(124,  8, new Vector2(-01.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(125,  8, new Vector2(-01.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(126,  8, new Vector2(-00.50f,  4.11f), Graph.Node.Type.Main));

        //PIANO 2 - STANZA 9
        _liveObjectsNodes.Add(new Graph.Node(127,  9, new Vector2(00.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(128,  9, new Vector2(00.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(129,  9, new Vector2(01.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(130,  9, new Vector2(01.50f,  4.11f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node(131,  9, new Vector2(02.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(132,  9, new Vector2(02.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(133,  9, new Vector2(03.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(134,  9, new Vector2(03.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(135,  9, new Vector2(04.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(136,  9, new Vector2(04.50f,  4.11f), Graph.Node.Type.Main));

        //PIANO 2 - STANZA  10
        _liveObjectsNodes.Add(new Graph.Node(137, 10, new Vector2(05.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(138, 10, new Vector2(05.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(139, 10, new Vector2(06.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(140, 10, new Vector2(06.50f,  4.11f), Graph.Node.Type.Main));
        _liveObjectsNodes.Add(new Graph.Node(141, 10, new Vector2(07.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(142, 10, new Vector2(07.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(143, 10, new Vector2(08.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(144, 10, new Vector2(08.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(145, 10, new Vector2(09.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(146, 10, new Vector2(09.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(147, 10, new Vector2(10.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(148, 10, new Vector2(10.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(149, 10, new Vector2(11.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(150, 10, new Vector2(11.50f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(151, 10, new Vector2(12.00f,  4.11f), Graph.Node.Type.Generic));
        _liveObjectsNodes.Add(new Graph.Node(152, 10, new Vector2(12.50f,  4.11f), Graph.Node.Type.Main));

        _liveObjectsLinks = new List<Graph.Connection>();
        //PIANO 0
        _liveObjectsLinks.Add(new Graph.Connection(  0,   1, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  1,   2, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  2,   3, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  3,   4, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  4,   5, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  5,   6, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  6,   7, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  7,   8, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  8,   9, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(  9,  10, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 10,  11, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 11,  12, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 12,  13, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 13,  14, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 14,  15, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 15,  16, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 16,  17, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 17,  18, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 18,  19, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 19,  20, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 20,  21, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 21,  22, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 22,  23, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 23,  24, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 24,  25, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 25,  26, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 26,  27, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 27,  28, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 28,  29, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 29,  30, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 30,  31, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 31,  32, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 32,  33, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 33,  34, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 34,  35, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 35,  36, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 36,  37, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 37,  38, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 38,  39, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 39,  40, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 40,  41, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 41,  42, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 42,  43, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 43,  44, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 44,  45, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 45,  46, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 46,  47, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 47,  48, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 48,  49, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 49,  50, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
 
        //PIANO 1
        _liveObjectsLinks.Add(new Graph.Connection( 51,  52, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 52,  53, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 53,  54, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 54,  55, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 55,  56, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 56,  57, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 57,  58, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 58,  59, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 59,  60, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 60,  61, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 61,  62, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 62,  63, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 63,  64, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 64,  65, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 65,  66, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 66,  67, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 67,  68, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 68,  69, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 69,  70, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 70,  71, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 71,  72, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 72,  73, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 73,  74, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 74,  75, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 75,  76, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 76,  77, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 77,  78, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 78,  79, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 79,  80, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 80,  81, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 81,  82, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 82,  83, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 83,  84, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 84,  85, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 85,  86, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 86,  87, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 87,  88, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 88,  89, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 89,  90, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 90,  91, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 91,  92, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 92,  93, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 93,  94, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 94,  95, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 95,  96, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 96,  97, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 97,  98, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 98,  99, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection( 99, 100, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(100, 101, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));

        //PIANO 2
        _liveObjectsLinks.Add(new Graph.Connection(102, 103, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(103, 104, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(104, 105, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(105, 106, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(106, 107, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(107, 108, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(108, 109, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(109, 110, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(110, 111, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(111, 112, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(112, 113, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(113, 114, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(114, 115, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(115, 116, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(116, 117, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(117, 118, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(118, 119, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(119, 120, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(120, 121, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(121, 122, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(122, 123, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(123, 124, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(124, 125, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(125, 126, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(126, 127, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(127, 128, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(128, 129, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(129, 130, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(130, 131, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(131, 132, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(132, 133, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(133, 134, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(134, 135, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(135, 136, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(136, 137, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(137, 138, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(138, 139, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(139, 140, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(140, 141, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(141, 142, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(142, 143, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(143, 144, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(144, 145, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(145, 146, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(146, 147, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(147, 148, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(148, 149, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(149, 150, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(150, 151, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(151, 152, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));

        _liveObjectsLinks.Add(new Graph.Connection(50, 51, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));
        _liveObjectsLinks.Add(new Graph.Connection(101, 102, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND));











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

        _objects[25] = new ObjectPlaceholder(03, Costants.Z_INDEX_OBJ_1, new Vector3(-12.49f, -0.10f, 0), "L1_F2_ROOM3_CLOSET-B_00", GenericObject.Types.Soft);
        _objects[26] = new ObjectPlaceholder(03, Costants.Z_INDEX_OBJ_1, new Vector3(-09.05f, -0.60f, 0), "L1_F2_ROOM3_BEED2_00", GenericObject.Types.Soft);
        _objects[27] = new ObjectPlaceholder(03, Costants.Z_INDEX_OBJ_4, new Vector3(-09.20f, -0.27f, 0), "L1_F2_ROOM3_POSTER3_00", GenericObject.Types.Soft);

        _objects[28] = new ObjectPlaceholder(04, Costants.Z_INDEX_OBJ_1, new Vector3(-01.68f, -0.57f, 0), "L1_F2_HALL2_RACK", GenericObject.Types.Soft);
        _objects[29] = new ObjectPlaceholder(04, Costants.Z_INDEX_OBJ_2, new Vector3(-00.95f,  0.45f, 0), "L1_F2_HALL2_PLANT_", GenericObject.Types.Soft);

        _objects[30] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_1, new Vector3( 01.30f,  0.26f, 0), "L1_F2_ROOM4_BOOKSHELF", GenericObject.Types.Soft);
        _objects[31] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_1, new Vector3( 03.54f, -0.40f, 0), "L1_F2_ROOM4_BED", GenericObject.Types.Soft);
        _objects[32] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 00.95f,  1.02f, 0), "L1_F2_ROOM4_TOY1_", GenericObject.Types.Hard);
        _objects[33] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 01.30f,  1.02f, 0), "L1_F2_ROOM4_TOY2_", GenericObject.Types.Hard);
        _objects[34] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 01.62f,  1.02f, 0), "L1_F2_ROOM4_TOY3_", GenericObject.Types.Hard);
        _objects[35] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_2, new Vector3( 01.26f,  0.15f, 0), "L1_F2_ROOM4_TOY4_", GenericObject.Types.Hard);
        _objects[36] = new ObjectPlaceholder(05, Costants.Z_INDEX_OBJ_4, new Vector3( 00.94f, -1.19f, 0), "L1_F2_ROOM4_ARMCHAIR", GenericObject.Types.Soft);

        _objects[37] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_1, new Vector3( 06.89f, -0.47f, 0), "L1_F2_ROOM5_DESK2", GenericObject.Types.Soft);
        _objects[38] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_1, new Vector3( 07.01f,  0.28f, 0), "L1_F2_ROOM5_POSTER4_00", GenericObject.Types.Hard);
        _objects[39] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_1, new Vector3( 08.78f,  0.28f, 0), "L1_F2_ROOM5_POSTER5_00", GenericObject.Types.Hard);
        _objects[40] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_2, new Vector3( 06.63f,  0.06f, 0), "L1_F2_ROOM5_PC_00", GenericObject.Types.Hard);
        _objects[41] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_2, new Vector3( 07.76f, -0.29f, 1), "L1_F2_ROOM5_PRINTER_00", GenericObject.Types.Hard);
        _objects[42] = new ObjectPlaceholder(06, Costants.Z_INDEX_OBJ_3, new Vector3( 06.87f, -0.53f, 0), "L1_F2_ROOM5_CHAIR-BLACK", GenericObject.Types.Hard);

        _objects[43] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-11.39f,  3.38f, 0), "L1_F3_ROOM1_BED", GenericObject.Types.Soft);
        _objects[44] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-09.07f,  3.38f, 0), "L1_F3_ROOM1_DESK", GenericObject.Types.Soft);
        _objects[45] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-06.50f,  4.17f, 0), "L1_F3_ROOM1_CLOSET-S_00", GenericObject.Types.Soft);
        _objects[46] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_1, new Vector3(-08.76f,  5.16f, 0), "L1_F3_ROOM1_POSTER1", GenericObject.Types.Soft, true);
        _objects[47] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_2, new Vector3(-09.24f,  3.34f, 0), "L1_F3_ROOM1_CHAIR-BLACK", GenericObject.Types.Hard);
        _objects[48] = new ObjectPlaceholder(07, Costants.Z_INDEX_OBJ_2, new Vector3(-08.92f,  3.76f, 0), "L1_F3_ROOM1_PC_00", GenericObject.Types.Hard);

        _objects[49] = new ObjectPlaceholder(08, Costants.Z_INDEX_OBJ_1, new Vector3(-02.58f,  4.24f, 0), "L1_F3_HALL1_POSTER2", GenericObject.Types.Soft);

        _objects[50] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 01.46f,  4.47f, 0), "L1_F3_BATHROOM_SHOWER", GenericObject.Types.Hard);
        _objects[51] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 03.11f,  3.46f, 0), "L1_F3_BATHROOM_SINK", GenericObject.Types.Soft);
        _objects[52] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 03.10f,  3.97f, 0), "L1_F3_BATHROOM_MIRROR_00", GenericObject.Types.Hard);
        _objects[53] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_1, new Vector3( 04.12f,  4.13f, 0), "L1_F3_BATHROOM_CLOSET-S_00", GenericObject.Types.Hard);
        _objects[54] = new ObjectPlaceholder(09, Costants.Z_INDEX_OBJ_4, new Vector3( 01.02f,  3.06f, 0), "L1_F3_BATHROOM_TOILET", GenericObject.Types.Hard);

        _objects[55] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_1, new Vector3( 06.90f,  4.62f, 0), "L1_F3_ROOM2_LAMPx3_00", GenericObject.Types.Hard);
        _objects[56] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_1, new Vector3( 08.15f,  4.62f, 0), "L1_F3_ROOM2_LAMPx3_00", GenericObject.Types.Hard);
        _objects[57] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_1, new Vector3( 09.40f,  4.62f, 0), "L1_F3_ROOM2_LAMPx3_00", GenericObject.Types.Hard);
        _objects[58] = new ObjectPlaceholder(10, Costants.Z_INDEX_OBJ_4, new Vector3( 08.28f,  3.16f, 0), "L1_F3_ROOM2_BILLARD", GenericObject.Types.Soft);
    }
}
