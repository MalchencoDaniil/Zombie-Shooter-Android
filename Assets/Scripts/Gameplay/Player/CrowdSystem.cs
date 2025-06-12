using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform _cameraTargetPoint;

    [Header("Crowd Settings")]
    [SerializeField]
    private float _rowDistance = 1f;
    [SerializeField]
    private float _colDistance = 1f;

    [SerializeField]
    private float _behindDistance = 2f;

    [SerializeField]
    private int _numCols = 2;
    [SerializeField]
    private int _numRows = 1;

    private PlayerManager _playerManager;

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    public float GetCrowdDistance()
    {
        if (_playerManager._playerMeshes.Count == 0)
            return 0;

        float _distance = 0;

        if (_playerManager._playerMeshes.Count >= _numCols)
            _distance = Vector3.Distance(_playerManager._playerMeshes[0].transform.position, _playerManager._playerMeshes[_numCols - 1].transform.position);

        if (_playerManager._playerMeshes.Count < _numCols)
            _distance = Vector3.Distance(_playerManager._playerMeshes[0].transform.position, _playerManager._playerMeshes[_playerManager._playerMeshes.Count - 1].transform.position); ;

        return _distance;
    }


    public Vector3 GetCrowdCenter()
    {
        return new Vector3(0, 0, -_behindDistance);
    }

    private Vector3 Centroid()
    {
        Vector3 _centrPosition = Vector3.zero;

        foreach (Transform _meshesTransform in _playerManager._playerMeshes)
        {
            _centrPosition += _meshesTransform.position;
        }

        _centrPosition /= _playerManager._playerMeshes.Count;

        return _centrPosition;
    }

    private void LateUpdate()
    {
        if (_playerManager._playerMeshes.Count > 0)
            _cameraTargetPoint.position = Centroid();
    }

    public void PlaceRunner()
    {
        if (_playerManager._playerMeshes.Count == 0) return;

        int _cols = _numCols;

        int _rows = (int)Mathf.Ceil((float)_playerManager._playerMeshes.Count / _cols);

        float _startXOffset = (_cols - 1) / 2f * _colDistance;
        float _startZOffset = (_rows - 1) / 2f * _rowDistance;

        for (int i = 0; i < _playerManager._playerMeshes.Count; i++) 
        {
            Vector3 _childLocalPosition = CalculatePosition(i, _colDistance, _rowDistance, _cols, _rows, _startXOffset, _startZOffset);
            _playerManager._playerMeshes[i].localPosition = _childLocalPosition;
        }
    }

    private Vector3 CalculatePosition(int unitIndex, float colDist, float rowDist, int cols, int rows, float startXOffset, float startZOffset)
    {
        int _row = unitIndex / cols;
        int _col = unitIndex % cols;

        float _xOffset = _col * colDist - startXOffset;
        float _zOffset = _row * rowDist;

        return new Vector3(_xOffset, 0, _zOffset - _behindDistance);
    }
}