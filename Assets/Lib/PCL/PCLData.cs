﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

static class PCLConstants
{
    public const int NUM_KINECTS1 = 3;

    public const int K1_PCL_WIDTH = 320;
    public const int K1_PCL_HEIGHT = 240;
    public const int K2_PCL_WIDTH = 512;
    public const int K2_PCL_HEIGHT = 424;
    public const int RS_PCL_WIDTH = 640;
    public const int RS_PCL_HEIGHT = 480;

    public const int NUM_K1_PIXELS = K1_PCL_WIDTH * K1_PCL_HEIGHT;
    public const int NUM_K2_PIXELS = K2_PCL_WIDTH * K2_PCL_HEIGHT;
    public const int NUM_RS_PIXELS = RS_PCL_WIDTH * RS_PCL_HEIGHT;

}



public struct RSCloud
{
    public int numGoodPoints;
    public Vector3 pclCenter;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_RS_PIXELS)]
    public Vector3[] points;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_RS_PIXELS)]
    public int[] goodPointIndices;
};

public struct K1Cloud
{
    public int numGoodPoints;
    public Vector3 pclCenter;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_K1_PIXELS)]
    public Vector3[] points;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_K1_PIXELS)]
    public int[] goodPointIndices;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_K1_PIXELS * 4)]
    public int[] quadIndices;
    public int numQuads;
};

public struct K2Cloud
{
    public int numGoodPoints;
    public Vector3 pclCenter;
    public int numBodiesTracked;

    public Vector3 headPos;
    public Vector3 leftHandPos;
    public Vector3 rightHandPos;
    public Vector3 neckPos;
    public Vector3 torsoPos;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_K2_PIXELS)]
    public Vector3[] points;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_K2_PIXELS)]
    public int[] goodPointIndices;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = PCLConstants.NUM_K2_PIXELS * 4)]
    public int[] quadIndices;
    public int numQuads;

};


[StructLayout(LayoutKind.Sequential)]
public class PCLData
{
    public byte isReady;

    [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = PCLConstants.NUM_KINECTS1)]
    public K1Cloud[] k1Clouds;
    public K2Cloud k2Cloud;
    public RSCloud rsCloud;
};

//After Marshalling, for class use (templates, octree...)
public class PCLPointObject
{
    public Vector3 point;
    public int index;
    public PCLPointObject(Vector3 p, int index)
    {
        point = p;
        this.index = index;
    }
}



