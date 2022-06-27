using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var tile = other.gameObject.GetComponent<MapPile>().TileState;
        if (tile == TileState.RightTurn)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y - 90f, 0);
        }
        else if (tile == TileState.LeftTurn)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y + 90f, 0);
        }
    }
}
