using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;
using UnityEngine.UI;
using Brick_Breaker.Events;

namespace Brick_Breaker.Views
{

    public class SettlementView : EventView
    {
        public Button restartBtn;

        private void OnEnable()
        {
            restartBtn.onClick.AddListener(OnRestartBtnClick);
        }

        private void OnRestartBtnClick()
        {
            dispatcher.Dispatch(new GameProcedureEvent(GameProcedureEvent.Type.START_GAME));
            Destroy(gameObject);
        }
        private void OnDisable()
        {
            restartBtn.onClick.RemoveListener(OnRestartBtnClick);
        }
    }
}
