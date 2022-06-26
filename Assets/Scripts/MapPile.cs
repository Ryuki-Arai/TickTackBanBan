using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPile : MonoBehaviour
{
    [SerializeField] TileState _tileState;
    [SerializeField] MeshRenderer _tileMesh;
    [SerializeField] TileMaterial _tileMaterial;

    public TileState TileState
    {
        get { return _tileState; }
        set { _tileState = value; }
    }

    private void OnValidate()
    {
        SetTile();
    }

    private void SetTile()
    {
        if (_tileMesh == null) return;
        if (_tileState == TileState.Cross)
        {
            _tileMesh.material = _tileMaterial.closs;
        }
        else if (_tileState == TileState.LeftTurn)
        {
            _tileMesh.material = _tileMaterial.leftTurn;
        }
        else if (_tileState == TileState.RightTurn)
        {
            _tileMesh.material = _tileMaterial.rightTurn;
        }
    }

    [Serializable]
    public class TileMaterial
    {
        public Material closs;
        public Material leftTurn;
        public Material rightTurn;
    }
}
