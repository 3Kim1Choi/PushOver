using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    Mesh mesh;
    Vector3 origin = Vector3.zero;
    float startingAngle;
    public float fov;
    int rayCount = 30;
    bool playing;
    [SerializeField] Minigame3Player player;
    public float viewDistance = 20f;
    public LayerMask layerMask;

    private void Start() {
        mesh = new Mesh(); 
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 90;
        playing = true;
    }

    private void LateUpdate() {
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            float angleRad = angle * (Mathf.PI/180f);
            Vector3 angleVec = new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, angleVec, viewDistance, layerMask);
            vertex = origin + angleVec * viewDistance;
            if (raycastHit2D.collider == null) {
                vertex = origin + angleVec * viewDistance;
            } else {
                vertex = raycastHit2D.point;
                if (raycastHit2D.collider.gameObject.CompareTag("Player") && playing) {
                    playing = false;
                    player.Caught();
                }
            }
            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                
                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        
        mesh.RecalculateBounds();
    }

    public void SetOrigin(Vector3 origin) {
        this.origin = origin;
    }

    public void setAimDirection(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        n = Mathf.RoundToInt(n) + 90;
        if (n < 0) n += 360;
        startingAngle = n - fov/2f;
    }
}
