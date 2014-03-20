using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class GrazyGreg : PhysicsGame
{
    PhysicsObject Greg = new PhysicsObject(140, 140);
    PhysicsObject piikki;
    
    public override void Begin()
    {
        Gravity = new Vector(0.0, -5.0);
        Level.Background.CreateGradient(Color.GreenYellow, Color.Magenta);
        Mouse.IsCursorVisible = true;
        LuoKentta();
        Camera.ZoomToLevel();

        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, Hyppy, "Hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.R, ButtonState.Pressed, restart, "Aloita alusta");

        AddCollisionHandler(Greg, "kuolema", CollisionHandler.ExplodeObject(500, true));
    }

    void LuoKentta()
    {
        ColorTileMap taso = ColorTileMap.FromLevelAsset("level2");
        taso.SetTileMethod(Color.Black, LuoSeina);
        taso.SetTileMethod(Color.FromHexCode("FF0000"), LuoPelaaja);
        taso.SetTileMethod(Color.FromHexCode("FFD800"), LuoLippu);
        taso.SetTileMethod(Color.FromHexCode("FF5F0F"), LuoPiikki);

        taso.Execute(80, 80);
    }
        
        void Hyppy()
        {
            Vector hiirenPaikka = new Vector();
            Vector hahmonPaikka = new Vector();
            hiirenPaikka = Mouse.PositionOnWorld;
            hahmonPaikka = Greg.AbsolutePosition;
            Vector suunta = hiirenPaikka - hahmonPaikka;

            Vector impulssi = Vector.FromLengthAndAngle(suunta.Magnitude, suunta.Angle + Angle.FromDegrees(180));
            Greg.Hit(impulssi);
        }
        void LuoSeina(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject seina = PhysicsObject.CreateStaticObject(leveys, korkeus);
            seina.Position = paikka;
            Image seinanKuva = LoadImage("wall");
            seina.Image = seinanKuva;
            seina.CollisionIgnoreGroup = 1;
            Add(seina);
        }
        void LuoPelaaja(Vector paikka, double leveys, double korkeus)
        {
            Greg.Position = paikka;
            Image GreginKuva = LoadImage("Greg");
            Greg.AngularVelocity = 2;
            Greg.Image = GreginKuva;
            Add(Greg);
        }
        void LuoLippu(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject lippu = PhysicsObject.CreateStaticObject(leveys, korkeus);
            lippu.Position = paikka;
            Image ovenKuva = LoadImage("flag");
            lippu.Image = ovenKuva;
            lippu.CollisionIgnoreGroup = 1;
            Add(lippu);
        }
        void LuoPiikki(Vector paikka, double leveys, double korkeus)
        {
            piikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            piikki.Position = paikka;
            Image ovenKuva = LoadImage("spike");
            piikki.Image = ovenKuva;
            piikki.CollisionIgnoreGroup = 1;
            piikki.Tag = "kuolema";
            Add(piikki);
        }
        void restart() 
        {
            ClearAll();
            Begin();
            LuoKentta();
        }



    }

