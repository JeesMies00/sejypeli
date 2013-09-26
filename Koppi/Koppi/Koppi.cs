using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Koppi : PhysicsGame
{
    IntMeter pisteLaskuri;
    IntMeter elamat = new IntMeter(3, 0, 6);
    int level = 1;
    int omenoitaIlmassa = 1;

    public override void Begin()
    {
        LuoPisteLaskuri();
        LuoElamaLaskuri();
        UusiOmena(level);
        omenoitaIlmassa = level;

        PhysicsObject pohja = Level.CreateBottomBorder(0.5, true);
        AddCollisionHandler(pohja, PutosiMaahan);
        Level.CreateLeftBorder(0.1, false);
        Level.CreateRightBorder(0.1, false);
        Gravity = new Vector(0.0, -100.0);
        Camera.ZoomToLevel(1);
        Level.Background.Color = Color.DarkGreen;
        IsMouseVisible = true;

        // TODO: Kirjoita ohjelmakoodisi tähän

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    void OmenaaKlikattu(PhysicsObject klikattuOmena)
    {
        klikattuOmena.Destroy();
        pisteLaskuri.AddValue(1);
        omenoitaIlmassa = omenoitaIlmassa - 1;
    }

    void LuoPisteLaskuri()
    {
        pisteLaskuri = new IntMeter(0);
        Label pisteNaytto = new Label();
        pisteNaytto.X = Screen.Left + 100;
        pisteNaytto.Y = Screen.Top - 100;
        pisteNaytto.Title = "Pisteet";
        pisteNaytto.BindTo(pisteLaskuri);
        Add(pisteNaytto);
    }

    void PutosiMaahan(PhysicsObject maa, PhysicsObject omena)
{
    if (omena.Color != Color.Black)
    {
    elamat.AddValue(-1);
    omena.FadeColorTo(Color.Black, 1);
    omenoitaIlmassa = omenoitaIlmassa - 1;
    }
    
}
    void LuoElamaLaskuri()
    {
        Label elamaNaytto = new Label();
        elamaNaytto.BindTo(elamat);
        elamaNaytto.X =Screen.Right - 100.0;
        elamaNaytto.Y =Screen.Top - 100.0;
        elamaNaytto.Title = "Elämät";
        Add(elamaNaytto);
    }

    void UusiOmena(int omenoita)
    {
 PhysicsObject omena = new PhysicsObject(50, 50);
        omena.Shape = Shape.Circle;
        omena.Color = Color.Red;
        GameObject lehti = new GameObject(20, 20);
        lehti.Shape = Shape.Star;
        lehti.Color = Color.Green;
        omena.Restitution = 0.5;
        omena.Y = 400;
        Add(omena);
        lehti.Y = 25;
        omena.Add(lehti);
        Mouse.ListenOn(omena, MouseButton.Left, ButtonState.Pressed, OmenaaKlikattu, "omenaa klikattu", omena);

        omena.Hit(RandomGen.NextVector(50, 100));
    }
}

