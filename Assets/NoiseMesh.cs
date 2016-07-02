﻿using UnityEngine;
using System.Collections;

public class NoiseMesh : MonoBehaviour {

    Mesh m;
    int numVertices;
    Vector3[] initVertices;
    float[] seeds;
    
    [Range(0,10)]
    public float speed = 1f;

    [Range(0,2)]
    public float amplitude = .1f;

	// Use this for initialization
	void Start () { 
        m = GetComponent<MeshFilter>().mesh;
        numVertices = m.vertexCount;
        initVertices = new Vector3[numVertices];
        seeds = new float[numVertices];

        for(int i=0;i<numVertices;i++)
        {
            initVertices[i] = m.vertices[i];
            seeds[i] = Random.value;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3[] vertices = m.vertices;

        for (int i = 0; i < numVertices; i++)
        {
            Vector3 target = initVertices[i]+Random.insideUnitSphere*amplitude;
            vertices[i] = Vector3.Lerp(vertices[i], target, Time.deltaTime * seeds[i] * speed);
        }

        m.vertices = vertices;
    }
}