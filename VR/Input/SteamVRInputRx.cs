using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace UnityG2Utils.VR.Input
{
    public class SteamVRInputRx : MonoBehaviour
    {
        private SteamVR_TrackedObject controller;


        private ReactiveProperty<Vector2> _padPressPosition = new ReactiveProperty<Vector2>(Vector2.zero);
        /// <summary>
        /// タッチパッドの押されている位置を表す.
        /// </summary>
        public ReactiveProperty<Vector2> PadPressPosition { get { return _padPressPosition; } }

        private ReactiveProperty<SteamVRControllerState> _controllerState = new ReactiveProperty<SteamVRControllerState>(SteamVRControllerState.None);
        /// <summary>
        /// コントローラーの状態を表す.
        /// </summary>
        public ReactiveProperty<SteamVRControllerState> ControllerState { get { return _controllerState; } }

        private void Start()
        {
            controller = GetComponent<SteamVR_TrackedObject>();

            var deviceObservable = this.UpdateAsObservable()
                    .Select(_ => SteamVR_Controller.Input((int)controller.index));

            deviceObservable.Subscribe(device =>
            {
                // Trigger
                if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ControllerState.Value = SteamVRControllerState.TriggerTouchDown;
                }
                if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ControllerState.Value = SteamVRControllerState.TriggerTouching;
                }
                if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ControllerState.Value = SteamVRControllerState.TriggerTouchUp;
                }

                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ControllerState.Value = SteamVRControllerState.TriggerPressDown;
                }
                if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ControllerState.Value = SteamVRControllerState.TriggerPressing;
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ControllerState.Value = SteamVRControllerState.TriggerPressUp;
                }

                // Pad
                if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ControllerState.Value = SteamVRControllerState.PadTouchDown;
                }
                if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ControllerState.Value = SteamVRControllerState.PadTouching;
                }
                if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ControllerState.Value = SteamVRControllerState.PadTouchUp;
                }

                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ControllerState.Value = SteamVRControllerState.PadPressDown;

                    // 方向を取得
                    var axis = device.GetAxis();
                    ControllerState.Value = GetTouchDirection(axis);
                    PadPressPosition.Value = axis;
                }
                if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ControllerState.Value = SteamVRControllerState.PadPressing;
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ControllerState.Value = SteamVRControllerState.PadPressUp;
                }

                // Menu
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
                {
                    ControllerState.Value = SteamVRControllerState.MenuPressDown;
                }
                if (device.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
                {
                    ControllerState.Value = SteamVRControllerState.MenuPressing;
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
                {
                    ControllerState.Value = SteamVRControllerState.MenuPressUp;
                }

                // Grip
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
                {
                    ControllerState.Value = SteamVRControllerState.GripPressDown;
                }
                if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
                {
                    ControllerState.Value = SteamVRControllerState.GripPressing;
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
                {
                    ControllerState.Value = SteamVRControllerState.GripPressUp;
                }
            });
        }

        private SteamVRControllerState GetTouchDirection(Vector2 axis)
        {
            SteamVRControllerState state;

            float angle = CalcVectorAngle(new Vector2(1, 0), axis);

            // 上
            if (-135 <= angle && angle <= -45)
            {
                state = SteamVRControllerState.PadPressDownOnUp;
            }
            // 下
            else if (45 <= angle && angle <= 135)
            {
                state = SteamVRControllerState.PadPressDownOnDown;
            }
            // 左
            else if ((135 <= angle && angle <= 180) || (-180 <= angle && angle <= -135))
            {
                state = SteamVRControllerState.PadPressDownOnLeft;
            }
            // 右 
            else
            {
                state = SteamVRControllerState.PadPressDownOnRight;
            }

            return state;
        }

        private float CalcVectorAngle(Vector2 from, Vector2 to)
        {
            Vector3 cross = Vector3.Cross(from, to);
            float angle = Vector2.Angle(from, to);
            return cross.z > 0 ? -angle : angle;
        }
    }
}
