using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class pong : PhysicsGame
{
    PhysicsObject pallo;

    public override void Begin()
    {
        LuoKentta();

        AloitaPeli();

        // TODO: Kirjoita ohjelmakoodisi tähän

        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    void LuoKentta()
    {
        pallo = new PhysicsObject(40, 40);
        pallo.Shape = Shape.Circle;
        pallo.Restitution = 1.0;
        pallo.X = -200.0;
        pallo.Y = 0.0;
        Add(pallo);

        LuoMaila(Level.Left + 20.0, 0.0);
        LuoMaila(Level.Right - 20.0, 0.0);

        Level.CreateBorders(1.0, false);

        Level.Background.Color = Color.LimeGreen;

        Camera.ZoomToLevel();
    }
    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);
    }
    void LuoMaila(double x, double y)
    {
        PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        maila.Shape = Shape.Rectangle;
        maila.X = x;
        maila.Y = y;
        maila.Restitution = 1.0;
        Add(maila);
    }
    void AsetaOhjaimet();

}
