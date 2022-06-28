using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Footer : MonoBehaviour
{
    [SerializeField] MapPile _pile;
    [SerializeField] int _pileCount;
    [SerializeField] int _dragPoint;
    MapPile[] _stayMap;

    void Start()
    {
        _stayMap = new MapPile[_pileCount];
        for(int i = 0; i < _pileCount; i++)
        {
            _stayMap[i] = Instantiate(_pile, transform);
            _stayMap[i].transform.position = new Vector3(-_pileCount / 2 + i + 0.5f, transform.position.y, transform.position.z);
            _stayMap[i].TileState = ChangeState();
            _stayMap[i].TileMode = TileMode.Stay;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CelectPile();
        }
    }

    void CelectPile()
    {
        GameObject clickedGameObject = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            clickedGameObject = hit.collider.gameObject;
        }

        clickedGameObject.GetComponent<MapPile>().TileMode = TileMode.Injection;
    }

    private void Replenish()
    {
        if (transform.parent.childCount < _pileCount)
        {

        }
    }

    TileState ChangeState()
    {
        var n = Random.Range(0,Enum.GetValues(typeof(TileState)).Length);
        switch (n)
        {
            case 0: return TileState.RightTurn;
            case 1: return TileState.LeftTurn;
            default: return TileState.Cross;
        }
    }
}
