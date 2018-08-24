using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityG2Utils.VR.Input
{

    /// <summary>
    /// コントローラーの状態を表す.
    /// </summary>
    public enum SteamVRControllerState
    {
        None,

        /// <summary>
        /// 浅くトリガーを引いた.
        /// </summary>
        TriggerTouchDown,

        /// <summary>
        /// 浅くトリガーを引いている.
        /// </summary>
        TriggerTouching,

        /// <summary>
        /// 浅くトリガーを引いた状態からトリガーを離した.
        /// </summary>
        TriggerTouchUp,

        /// <summary>
        /// 深くトリガーを引いた.
        /// </summary>
        TriggerPressDown,

        /// <summary>
        /// 深くトリガーを引いている.
        /// </summary>
        TriggerPressing,

        /// <summary>
        /// 深くトリガーを引いた状態からトリガーを離した.
        /// </summary>
        TriggerPressUp,

        /// <summary>
        /// タッチパッドを押した.
        /// </summary>
        PadPressDown,

        /// <summary>
        /// タッチパッドの上を押した.
        /// </summary>
        PadPressDownOnUp,

        /// <summary>
        /// タッチパッドの下を押した.
        /// </summary>
        PadPressDownOnDown,

        /// <summary>
        /// タッチパッドの左を押した.
        /// </summary>
        PadPressDownOnLeft,

        /// <summary>
        /// タッチパッドを押した.
        /// </summary>
        PadPressDownOnRight,

        /// <summary>
        /// タッチパッドを押している.
        /// </summary>
        PadPressing,

        /// <summary>
        /// タッチパッドを押した状態から離した.
        /// </summary>
        PadPressUp,

        /// <summary>
        /// タッチパッドを触った.
        /// </summary>
        PadTouchDown,

        /// <summary>
        /// タッチパッドを触っている.
        /// </summary>
        PadTouching,

        /// <summary>
        /// タッチパッドを触っている状態から離した.
        /// </summary>
        PadTouchUp,

        /// <summary>
        /// メニューボタンを押した.
        /// </summary>
        MenuPressDown,

        /// <summary>
        /// メニューボタンを押している.
        /// </summary>
        MenuPressing,

        /// <summary>
        /// メニューボタンを離した.
        /// </summary>
        MenuPressUp,

        /// <summary>
        /// グリップボタンを押した.
        /// </summary>
        GripPressDown,

        /// <summary>
        /// グリップボタンを押している.
        /// </summary>
        GripPressing,

        /// <summary>
        /// グリップボタンを離した.
        /// </summary>
        GripPressUp,
    }

}
