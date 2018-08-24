using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace UnityG2Utils.VR.Input
{
    public class ViveInput : BaseInput
    {
        private SteamVRInputRx controller;

        private void Start()
        {
            controller = GetComponent<SteamVRInputRx>();

            controller.ControllerState
                .Where(s => s == SteamVRControllerState.TriggerPressDown)
                .Subscribe(_ =>
                {
                	// Triggerが惹かれたら何かをする
                });
        }
    }
}
