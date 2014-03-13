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
    
    
    public override void Begin()
    {
        Gravity = new Vector(0.0, -5.0);
        Level.Background.CreateGradient(Color.GreenYellow, Color.Magenta);
        Mouse.IsCursorVisible = true;
        Camera.ZoomToLevel(600.0);
        //Camera.FollowedObject = Greg;
        
        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, Hyppy, "Hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    void LuoKentta()
    {
        ColorTileMap taso = ColorTileMap.FromLevelAsset("level1");
        taso.SetTileMethod(Color.Black, LuoSeina);
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
            PhysicsObject ovi = PhysicsObject.CreateStaticObject(leveys, korkeus);
            ovi.Position = paikka;
            Image ovenKuva = LoadImage("door");
            ovi.Image = ovenKuva;
            ovi.CollisionIgnoreGroup = 1;
            Add(ovi);
        }


    }

