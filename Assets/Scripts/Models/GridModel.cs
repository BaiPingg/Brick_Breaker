using Brick_Breaker.Views;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            for (int i = 0; i < brickItems.GetLength(0); i++)
            {
                for (int j = 0; j < brickItems.GetLength(1); j++)
                {
                    var x = Random.Range(0, 100);
                    if (x > 90)
                    {
                        brickItems[i, j] = new BrickItem(i, j, DestroyType.HORIZONTAL);
                    }
                    else if (x > 80)
                    {
                        brickItems[i, j] = new BrickItem(i, j, DestroyType.VERTICAL);
                    }
                    else if (x > 70)
                    {
                        brickItems[i, j] = null;
                    }
                    else
                        brickItems[i, j] = new BrickItem(i, j, DestroyType.OWN);
                }
            }
        }
        public async Task GenerateItems()
        {
            var sample = Resources.Load<GameObject>("BrickSample");
            for (int i = 0; i < brickItems.GetLength(0); i++)
            {
                for (int j = 0; j < brickItems.GetLength(1); j++)
                {
                    if (brickItems[i, j] == null)
                        continue;
                    var go = GameObject.Instantiate(sample, root.transform);
                    var view = go.GetComponent<BrickView>();
                    view.x = i;
                    view.y = j;
                    go.transform.position = root.transform.position + new Vector3(i * cellSize, -j * cellSize, 0);
                    if (brickItems[i, j] .destroyType == DestroyType.HORIZONTAL)
                    {
                        go.GetComponent<SpriteRenderer>().color = Color.blue;
                    }
                    if (brickItems[i, j].destroyType == DestroyType.VERTICAL)
                    {
                        go.GetComponent<SpriteRenderer>().color = Color.cyan;
                    }
                    await UniTask.Yield();
                }
            }
        }
    }

    public enum DestroyType
    {
        OWN,
        HORIZONTAL,
        VERTICAL
    }

    public class BrickItem
    {
        public int x;
        public int y;
        public DestroyType destroyType;

        public BrickItem(int x, int y, DestroyType destroyType)
        {
            this.x = x;
            this.y = y;
            this.destroyType = destroyType;
        }
    }
}