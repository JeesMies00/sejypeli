using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class UusiPeli : PhysicsGame
{

    public override void Begin()
    {
        PhysicsObject Greg = new PhysicsObject(70, 100);
        Add(Greg);

        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

}