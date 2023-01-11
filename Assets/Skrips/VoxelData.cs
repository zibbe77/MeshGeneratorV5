using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData
{
    int[,] data = new int[,] { { 0, 1, 1 }, { 1, 1, 1 }, { 1, 1, 0 } };

    public int Width
    {
        get { return data.GetLength(0); }
    }
    public int Depth
    {
        get { return data.GetLength(1); }
    }

    public int GetCell(int x, int z)
    {
        return data[x, z];
    }

    public int GetNaighbor(int x, int z, Dictionary dir)
    {
        DataCoordinate checkOffset = offset[(int)dir];
        DataCoordinate neighborCoord = new DataCoordinate(x + checkOffset.x, 0 + checkOffset.y, z + checkOffset.z);

        if (neighborCoord.x < 0 || neighborCoord.x >= Width || neighborCoord != 0 || neighborCoord.z < 0 || neighborCoord.z >= Depth)
        {
            return 0;
        }
        else
        {
            return GetCell(neighborCoord.x, neighborCoord.z);
        }
    }

    struct DataCoordinate
    {
        public int x;
        public int y;
        public int z;

        public DataCoordinate(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        DataCoordinate[] offset =
        {
            new DataCoordinate(0,0,1),
            new DataCoordinate(1,0,0),
            new DataCoordinate(0,0,-1),
            new DataCoordinate(-1,0,0),
            new DataCoordinate(0,1,0),
            new DataCoordinate(0,-1,0),



        };
    }

}

public enum Direction
{
    North,
    East,
    South,
    West,
    Up,
    down,
}
