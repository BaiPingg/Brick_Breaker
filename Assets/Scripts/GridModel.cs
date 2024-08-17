using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Brick_Breaker.Models
{
    public class GridModel
    {
        public BrickItem[,] brickItems;
        public float cellSize;
        public GameObject root;
        public void GenerateBricks(int width, int height, float cellSize, GameObject root)
        {
            brickItems = new BrickItem[width, height];
            this.cellSize = cellSize;
            this.root = root;
        }
        public void GenerateItems()
        {
            for (int i = 0; i < brickItems.GetLength(0); i++)
            {
                for (int j = 0; j < brickItems.GetLength(1); j++)
                {

                }
            }
        }
    }

    public class BrickItem
    {
    }
}