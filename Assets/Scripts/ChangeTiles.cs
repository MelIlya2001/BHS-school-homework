using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


/*[RequireComponent(typeof(Controller))]
public class ChangeTiles : MonoBehaviour
{
    

    [Serializable]
    public class TileMapPlan
    {
        public GameObject _tilemap_collider;
        public GameObject _tilemap_no_collider;
        public bool _isActive;

        private bool _collider_active => _tilemap_collider.GetComponent<TilemapCollider2D>().enabled;
        private int _order_layer => _tilemap_collider.GetComponent<TilemapRenderer>().sortingOrder;
        
    }   


    [SerializeField] private List<TileMapPlan> _tiles;

    private int _active_tile_index;
    private Controller _controller;
    private float _designed_change;
    


    void Awake()
    {
        _controller = GetComponent<Controller>();

        if (_tiles.Count > 0)
            _active_tile_index = _tiles.FindIndex(tile => tile._isActive == true) | 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        _designed_change = _controller.input.RetrieveSwitchTileInput();
        if (_designed_change != 0)
        {
            _tiles[_active_tile_index]._isActive = false;
            _tiles[_active_tile_index]._tilemap_collider.GetComponent<TilemapCollider2D>().enabled = false;


            if (_designed_change > 0)
                _active_tile_index = (_active_tile_index == _tiles.Count - 1) ? 0 : _active_tile_index + 1;          
            else
                _active_tile_index = (_active_tile_index == 0) ? _tiles.Count - 1 : _active_tile_index - 1;
            
            SwapTiles(_active_tile_index);
        }
    } 

    void SwapTiles(int index)
    {
        _tiles[index]._isActive = true;
        _tiles[index]._tilemap_collider.GetComponent<TilemapCollider2D>().enabled = true;
        
    }
}*/
