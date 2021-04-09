using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenBallet : MonoBehaviour
{
    [SerializeField] private Material _lineMaterial;
    private Pen _penScript;
    private bool _isActive;
    private GameObject _player;
    private float _distance;
    private float _lifeTime = 30;

    void Start()
    {
        _isActive = true;
        _player = GameObject.FindWithTag("Player");
        _penScript = GameObject.FindWithTag("GunScripts").GetComponent<Pen>();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0)) Move();
        if (Input.GetMouseButtonUp(0)) FinishDrawing();

        // Destroy the line 30seconds after finishing drawing
        if (!_isActive)
        {
            _lifeTime -= Time.deltaTime;
            if (_lifeTime < 0) Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (!_isActive) return;
        _distance = _penScript.DISTANCE;
        transform.position = Camera.main.ScreenToWorldPoint(
           new Vector3(
           Input.mousePosition.x,
           Input.mousePosition.y,
           Camera.main.WorldToScreenPoint(_player.transform.position).z + _distance
           ));
    }

    private void FinishDrawing()
    {
        AddColider(gameObject);
        _isActive = false;
    }

    private void AddColider(GameObject pen)
    {
        GetComponent<TrailRenderer>().material = _lineMaterial;
        GameObject line = new GameObject("line");
        line.transform.SetParent(pen.transform);
        MeshCollider meshCollider = line.AddComponent<MeshCollider>();
        var trailRenderer = pen.GetComponent<TrailRenderer>();
        // Meshが無いとBakeMeshできないので、適当なMeshインスタンスを生成
        Mesh mesh = new Mesh();
        trailRenderer.BakeMesh(mesh, Camera.main, true);
        meshCollider.sharedMesh = mesh;
        // Ray以外は当たらないようにする
        meshCollider.convex = true;
        //meshCollider.isTrigger = true;
        // 終点に球のゲームオブジェクトが見えてるとかっこ悪いので透明化
        pen.GetComponent<Renderer>().enabled = false;
    }

}
