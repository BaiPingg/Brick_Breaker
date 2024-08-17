using UnityEngine;
using Brick_Breaker.Models;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Brick_Breaker.Events;

namespace Brick_Breaker.Commands
{   /// <summary>
    /// 销毁网格对象
    /// </summary>
    public class DestroyGridItemCommand : ICommand
    {
        [Inject] public GridEvent eve;
        [Inject] public GridModel gridModel;
        [Inject] public ScoreModel scoreModel;

        [Inject] public IEventDispatcher dispatcher;

        public void Execute()
        {
            var target = gridModel.brickItems[eve.x, eve.y];
            if (target != null)
            {
                switch (target.destroyType)
                {
                    case DestroyType.OWN:
                        Des(100, eve.x, eve.y);
                        break;
                    case DestroyType.HORIZONTAL:
                        for (int i = 0; i < gridModel.brickItems.GetLength(0); i++)
                        {
                            for (int j = 0; j < gridModel.brickItems.GetLength(1); j++)
                            {
                                if (i == eve.x && gridModel.brickItems[i, j] != null)
                                {
                                    Des(200, i, j);
                                }
                            }
                        }

                        break;
                    case DestroyType.VERTICAL:
                        for (int i = 0; i < gridModel.brickItems.GetLength(0); i++)
                        {
                            for (int j = 0; j < gridModel.brickItems.GetLength(1); j++)
                            {
                                if (j == eve.y && gridModel.brickItems[i, j] != null)
                                {
                                    Des(200, i, j);
                                }
                            }
                        }
                        break;
                }

            }
        }

        private void Des(int score, int x, int y)
        {
            scoreModel.currentScore += score;
            dispatcher.Dispatch(new CurrentScoreEvent(CurrentScoreEvent.Type.SCORE_UPDATE, scoreModel.currentScore));
            gridModel.brickItems[x, y] = null;
            dispatcher.Dispatch(new GridEvent(GridEvent.Type.DestroyBrick, x, y));
        }

    }
}
