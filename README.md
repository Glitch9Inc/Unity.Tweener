# Unity.Tweener

Unity.Tweener is a robust and versatile tweening library for Unity, designed to simplify and enhance your animation workflows. With support for a wide range of tweening operations, including position, rotation, scale, color, and more, this toolkit offers an efficient solution for creating smooth and natural animations in your Unity projects.

## Features

- **Ease of Use**: Simple and intuitive API for creating tweens.
- **Versatile Tweens**: Supports position, scale, rotation, color, alpha, size, and fill amount tweens.
- **Various Easing Functions**: Includes multiple easing functions such as Linear, Quad, Cubic, Quart, Quint, Sine, Expo, Circ, Elastic, Back, and Bounce.
- **Editor and Runtime Support**: Works in both the Unity editor and during runtime.
- **Flexible Duration and Delay**: Customize the duration and delay of tweens.
- **Callback Support**: Execute actions on tween updates and completion.

### Installation

#### Step 1: Download or Clone the Repository

1. Download or clone the repository.
2. Copy the `Glitch9.Toolkits.Tweener` folder into your Unity project's `Assets` directory.

#### Step 2: Install Editor Coroutines Package

To use the editor coroutine features provided by the Glitch9 Tweener, you need to install the `Editor Coroutines` package from the Unity Package Manager.

1. Open Unity and go to `Window` > `Package Manager`.
2. In the Package Manager, click on the `+` button in the top left corner and select `Add package from git URL...`.
3. Enter the following URL: `https://github.com/Unity-Technologies/com.unity.editorcoroutines` and click `Add`.

   ![Package Manager](https://docs.unity3d.com/uploads/Main/PackageManagerUI_add_git.png)

4. The `Editor Coroutines` package will be installed, allowing you to use editor coroutines in your project.

## Usage

### Basic Example

```csharp
using UnityEngine;
using Glitch9.Toolkits.Tweener;

public class Example : MonoBehaviour
{
    public RectTransform rectTransform;

    void Start()
    {
        // Move the RectTransform to a new position over 1 second
        rectTransform.TweenPos(new Vector3(100, 100, 0), 1f)
                     .SetEase(Ease.OutQuad)
                     .OnComplete(() => Debug.Log("Tween complete!"));
    }
}
```
### Customizing Tweens

```csharp
rectTransform.TweenPos(new Vector3(200, 200, 0), 2f)
             .SetEase(Ease.InOutSine)
             .SetDelay(0.5f)
             .OnComplete(() => Debug.Log("Move complete!"));
```

### Available Tween Types

- **Position**: `TweenPos`, `TweenLocalPos`, `TweenAnchorPos`
- **Rotation**: `TweenRotation`
- **Scale**: `TweenScale`
- **Color**: `TweenColor`
- **Alpha**: `FadeIn`, `FadeOut`
- **Size**: `TweenSizeDelta`, `TweenOffsetMin`, `TweenOffsetMax`
- **Fill Amount**: `TweenFillAmount`

### Easing Functions

Choose from a variety of easing functions to create different animation effects:

- **Linear**
- **Quad** (In, Out, InOut)
- **Cubic** (In, Out, InOut)
- **Quart** (In, Out, InOut)
- **Quint** (In, Out, InOut)
- **Sine** (In, Out, InOut)
- **Expo** (In, Out, InOut)
- **Circ** (In, Out, InOut)
- **Elastic** (In, Out, InOut)
- **Back** (In, Out, InOut)
- **Bounce** (In, Out, InOut)
- **Flash** (In, Out, InOut)

### Contributing
Contributions are welcome! If you have any improvements or bug fixes, please open an issue or submit a pull request.

### License
This project is licensed under the MIT License. See the LICENSE file for details.

