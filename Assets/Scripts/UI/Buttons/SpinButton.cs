using Spin.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spin.UI
{
    public class SpinButton : ButtonBase
    {
        [SerializeField] private SpinController _spinController;
        protected override void TaskOnClick()
        {
            _spinController.StartSpin();
        }
    }
}
