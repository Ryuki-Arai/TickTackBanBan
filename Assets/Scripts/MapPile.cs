using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPile : MonoBehaviour
{
    [SerializeField] TileState _tileState;
    [SerializeField] TileMode _tileMode;
    [SerializeField] MeshRenderer _tileMesh;
    [SerializeField] TileMaterial _tileMaterial;

    public TileState TileState
    {
        get { return _tileState; }
        set { _tileState = value; }
    }

    public TileMode TileMode
    {
        get { return _tileMode; }
        set { _tileMode = value; }
    }

    private void OnValidate()
    {
        InitTile();
        CheckState();
    }

    private void CheckState()
    {
        if (_tileMode == TileMode.Stay)
        {

        }
        else if (_tileMode == TileMode.Injection)
        {

        }
        else if (_tileMode == TileMode.Map)
        {
            if(transform.parent.gameObject != null)
            {
                transform.parent.gameObject.GetComponent<LayoutList>().AddLayoutList(this.gameObject);
            }
        }
    }

    private void InitTile()
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetType() == typeof(LayoutList))
        {
            this.gameObject.transform.parent = other.transform;
            other.GetComponent<LayoutList>().AddLayoutList(this.gameObject);
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
