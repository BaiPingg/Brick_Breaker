using Brick_Breaker.Commands;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Framework.API;
using UnityEngine;
using Brick_Breaker.Models;
using Brick_Breaker.Views;
using Brick_Breaker.Mediators;

namespace Brick_Breaker
{
    public class AppConfig : IConfig
    {
        [Inject]
        public IInjector injector;

        [Inject]
        public IMediatorMap mediatorMap;

        [Inject]
        public IEventCommandMap commandMap;

        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public IContext context;

        public void Configure()
        {

            //models
            injector.Map<RoundModel>().ToSingleton<RoundModel>();
            injector.Map<ScoreModel>().ToSingleton<ScoreModel>();
            injector.Map<GridModel>().ToSingleton<GridModel>();

            //events
            commandMap.Map(GameProcedureEvent.Type.START_GAME).ToCommand<GameStartCommand>();
            commandMap.Map(RoundEvent.Type.ADD_ROUND).ToCommand<AddRoundCommand>();
            commandMap.Map(GridEvent.Type.DestroyGridItem).ToCommand<DestroyGridItemCommand>();
            commandMap.Map(GameProcedureEvent.Type.SETTLEMENT).ToCommand<GameSettlementCommand>();



            mediatorMap.Map<CurrentScoreView>().ToMediator<CurrentScoreMediator>();
            mediatorMap.Map<MaxScoreView>().ToMediator<MaxScoreMediator>();
            mediatorMap.Map<RoundView>().ToMediator<RoundMediator>();
            mediatorMap.Map<BallView>().ToMediator<BallMediator>();
            mediatorMap.Map<BrickView>().ToMediator<BrickMediator>();
            mediatorMap.Map<DeadZoneView>().ToMediator<DeadZoneMediator>();
            mediatorMap.Map<SettlementView>().ToMediator<SettlementMediator>();

            context.AfterInitializing(StartUp);
        }

        private void StartUp()
        {
            dispatcher.Dispatch(new GameProcedureEvent(GameProcedureEvent.Type.START_GAME));
        }
    }
}