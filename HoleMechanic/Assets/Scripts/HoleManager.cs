using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshCollider meshCollider;
    private Mesh _mesh;
    private List<int> VerticesIndx = new List<int>();

    private readonly List<Vector3> offSet = new List<Vector3>();


    public float standarDistance;
    public float holeSize = 1f;





    void Start()
    {
        _mesh = meshFilter.mesh;

        for (int i = 0; i < _mesh.vertices.Length; i++)
        {

            var distance = Vector3.Distance(transform.position, _mesh.vertices[i]);

            if (distance <= standarDistance)
            {
                VerticesIndx.Add(i);
                offSet.Add(_mesh.vertices[i] - transform.position);

            }

        }
    }

    void LateUpdate()
    {
        Vector3[] vertices = _mesh.vertices;

        for (int i = 0; i < VerticesIndx.Count; i++)
        {
            vertices[VerticesIndx[i]] = transform.position + offSet[i] * holeSize;
        }

        _mesh.vertices = vertices;

        meshFilter.mesh = _mesh;

        meshCollider.sharedMesh = _mesh;
    }
}
