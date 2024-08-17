using Brick_Breaker.Models;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Brick_Breaker.Events;

namespace Brick_Breaker.Commands
{
    /// <summary>
    /// 新增回合数
    /// </summary>
    public class AddRoundCommand : ICommand
    {

        [Inject] public RoundModel roundModel;

        [Inject] public IEventDispatcher dispatcher;
        public void Execute()
        {
            roundModel.currentRound++;
            dispatcher.Dispatch(new RoundEvent(RoundEvent.Type.ROUND_UPDATE, roundModel.currentRound));
        }
    }
}
