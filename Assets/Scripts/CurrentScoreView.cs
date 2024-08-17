using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;
using TMPro;
namespace Brick_Breaker.Views
{
    public class CurrentScoreView : View
    {

        [SerializeField] private TextMeshProUGUI currentScoretext;
       public void SetNumbe(int num)
        {
            currentScoretext.text = num.ToString();
        }
    }
}
