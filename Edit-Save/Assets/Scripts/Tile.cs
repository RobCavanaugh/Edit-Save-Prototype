using UnityEngine;
using Newtonsoft.Json;

public class Tile : ScriptableObject
{
    [JsonProperty("X")]
    public int x { get; set; }
    [JsonProperty("Y")]
    public int y { get; set; }

    public Tile() { }
    public Tile (int _x, int _y)
    {
        x = _x;
        y = _y;
    }
    public GameObject gameObject;
    public enum TileType
    {
        FLOOR,
        OBSTACLE
    };
    [JsonProperty("Type")]
    public TileType Type { get; set; }

}