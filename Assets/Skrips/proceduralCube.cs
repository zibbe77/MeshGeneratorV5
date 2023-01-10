using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class proceduralCube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    public float scale = 1f;
    float adjScale;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        adjScale = scale * 0.5f;
    }

    void Start()
    {
        MakeCube(adjScale);
        UppdateMesh();
    }

    //skappar cube
    void MakeCube(float cubeScale)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        //loppar igenom allas sidor
        for (int i = 0; i < 6; i++)
        {
            MakeFace(i, cubeScale);
        }
    }

    void MakeFace(int dir, float facescale)
    {
        vertices.AddRange(CubeMeshData.FaceVertices(dir, facescale));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }

    void UppdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}
