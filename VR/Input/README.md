# SteamVRInputRx
Input receiver from VR controllers such as Vive controller as Rx Stream

## Requirements
* UniRx
* SteamVR Plugin

## Usage
```
SteamVRInputRx is a MonoBehaviour.  
Attach SteamVRInputRx.cs to VR controller.
```

``` CS

            var controller = GetComponent<SteamVRInputRx>();

            controller.ControllerState
                .Where(s => s == SteamVRControllerState.TriggerPressDown)
                .Subscribe(_ =>
                {
                	// Trigger Press
                });
```