using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class GrazyGreg : PhysicsGame
{
    int kenttaNro = 1;
    PhysicsObject Greg;
    PhysicsObject piikki;
    
    public override void Begin()
    {
        Gravity = new Vector(0.0, -50.0);
        Level.Background.CreateGradient(Color.GreenYellow, Color.Magenta);
        Mouse.IsCursorVisible = true;
        LuoKentta("level1");
        Camera.ZoomToLevel();
        MediaPlayer.Play("MidnightSun");
        MediaPlayer.IsRepeating = true;
        

        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, Hyppy, "Hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.R, ButtonState.Pressed, restart, "Aloita alusta");
        Keyboard.Listen(Key.S, ButtonState.Pressed, skip, "Skippaa taso");

        AddCollisionHandler(Greg, "maali", lippuunTormaaminen);
        AddCollisionHandler(Greg, "kuolema", CollisionHandler.ExplodeObject(500, true));
    }

    void SeuraavaKentta()
    {
        ClearAll();
        if (kenttaNro == 1) LuoKentta("level1");
        else if (kenttaNro == 2) LuoKentta("level2");
        else if (kenttaNro == 3) LuoKentta("level3");
        else if (kenttaNro == 4) LuoKentta("level4");
        else if (kenttaNro == 5) LuoKentta("level5");
        else if (kenttaNro == 6) LuoKentta("level6");
        else if (kenttaNro == 7) LuoKentta("level7");
        else if (kenttaNro == 8) LuoKentta("level8");
        else if (kenttaNro == 9) LuoKentta("levelSaku9000");

        else if (kenttaNro > 10) ConfirmExit();

        Gravity = new Vector(0.0, -50.0);
        Level.Background.CreateGradient(Color.GreenYellow, Color.Magenta);
        Mouse.IsCursorVisible = true;

        Camera.ZoomToLevel();

        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, Hyppy, "Hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.R, ButtonState.Pressed, restart, "Aloita alusta");
        Keyboard.Listen(Key.S, ButtonState.Pressed, skip, "Skippaa taso");

        AddCollisionHandler(Greg, "maali", lippuunTormaaminen);
        AddCollisionHandler(Greg, "kuolema", CollisionHandler.ExplodeObject(500, true));

        
    }

    void LuoKentta(string kentannimi)
    {


        ColorTileMap taso = ColorTileMap.FromLevelAsset (kentannimi);
        taso.SetTileMethod(Color.Black, LuoSeina);
        taso.SetTileMethod(Color.FromHexCode("FF0000"), LuoPelaaja);
        taso.SetTileMethod(Color.FromHexCode("FFD800"), LuoLippu);
        taso.SetTileMethod(Color.FromHexCode("FF5F0F"), LuoPiikki);

        taso.Execute(80, 80);

        MessageDisplay.Add("Playing Midnight Sun By DJVI");
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
            SoundEffect hyppyaani = LoadSoundEffect("Jump");
            hyppyaani.Play();
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
            Greg = new PhysicsObject(140, 140);
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
            lippu.Tag = "maali";
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
            SeuraavaKentta();
        }

        void lippuunTormaaminen(PhysicsObject pelaaja, PhysicsObject kohde)
        {
            kenttaNro++;
            SeuraavaKentta();
        }
        void skip()
        {
            kenttaNro++;
            SeuraavaKentta();
        }



    }

