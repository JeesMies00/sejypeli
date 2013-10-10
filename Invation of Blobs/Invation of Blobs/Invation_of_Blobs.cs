using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Invation_of_Blobs : PhysicsGame
{
    Vector nopeusOikealle = new Vector(0, 200);
    Vector nopeusVasemmalle = new Vector(0, -200);

    public override void Begin()
    {
        PlatformCharacter Hahmo1 = new PlatformCharacter(60, 90);
        Hahmo1.Shape = Shape.Rectangle;
        Add(Hahmo1);
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.W, ButtonState.Down,  "Pelaaja 1: Liikuta mailaa ylös", Hahmo1, nopeusOikealle);
        // jotain outoa
        Keyboard.Listen(Key.A, ButtonState.Released, , null, Hahmo1, Vector.Zero);
        Keyboard.Listen(Key.Z, ButtonState.Down, AsetaNopeus, "Pelaaja 1: Liikuta mailaa alas", Hahmo1, nopeusVasemmalle);
        Keyboard.Listen(Key.Z, ButtonState.Released, AsetaNopeus, null, Hahmo1, Vector.Zero);
    }

    void Liikkuminen
    {
    Hahmo1.Move =(New Vector 10)
    }

}
