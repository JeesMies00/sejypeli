using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class SuperGravitySlime : PhysicsGame
{
    PhysicsObject gravitypalikka = PhysicsObject.CreateStaticObject(60, 60);
    int tormays = 1;
    Vector vastaimpulssi = new Vector(0.0, -1500.0);
    Vector impulssi = new Vector(0.0, 1000.0);
    double painovoimaluku = 1.0;
    Vector painovoima2 = new Vector(0.0, 3000.0);
    Vector painovoima = new Vector(0.0, -3000.0);
    PlatformCharacter slime = new PlatformCharacter(70.0, 55.0);
    Image limakuva = LoadImage("slime");
    Image limakuvaylosalaisin = LoadImage("slimeylosalaisin");
    Image grass = LoadImage("palikka(1)");
    Image dirt = LoadImage("palikka2(1)");
    Image ancientpalikka = LoadImage("eripalikka(1)");
    Image lippu = LoadImage("loppu(1)");
    Image piikkiylos = LoadImage("piikkiylös");
    Image piikkialas = LoadImage("piikkialas");
    Image piikkioikealle = LoadImage("piikkioikealle");
    Image piikkivasemmalle = LoadImage("piikkivasemmalle");
    public override void Begin()
    {
        
        LuoKentta();

        

    }

    void LuoKentta()
    {
        Gravity = painovoima;
        ColorTileMap kentta = ColorTileMap.FromLevelAsset("kentta1");
        kentta.SetTileMethod(Color.FromHexCode("#000000"), LuoPalikka);
        kentta.SetTileMethod(Color.FromHexCode("#404040"), LuoPalikka2);
        kentta.SetTileMethod(Color.FromHexCode("#123456"), LuoEriPalikka);
        kentta.SetTileMethod(Color.FromHexCode("#FF0000"), LuoYlosPiikki);
        kentta.SetTileMethod(Color.FromHexCode("#FF6A00"), LuoAlasPiikki);
        kentta.SetTileMethod(Color.FromHexCode("#FFD800"), LuoPelaaja);
        kentta.SetTileMethod(Color.FromHexCode("#7F3300"), LuoVasemmallePiikki);
        kentta.SetTileMethod(Color.FromHexCode("#7F0000"), LuoOikeallePiikki);
        kentta.SetTileMethod(Color.FromHexCode("#123456"), LuoKentanLoppu);
        kentta.SetTileMethod(Color.FromHexCode("#00137F"), LuoGravityPalikka);
        kentta.Execute(60.0, 60.0);
        Camera.Follow(slime);
        lisaaOhjaimet();
    }

    void hyppaa()
    {
        if (painovoimaluku == 1.0)
        {
            slime.Jump(1500.0);
        }
        else if (tormays == 1)
        {
            slime.Hit(vastaimpulssi);
            tormays = 0;
        }
    }

    void liikuvasemmalle()
    {
        slime.Walk(-400.0);
    }

    void liikuoikealle()
    {
        slime.Walk(400.0);
    }

    void vaihdaPainovoima()
    {
        if (painovoimaluku == 1.0)
        {
            if (tormays == 1)
            {
                painovoimaluku = 2.0;
                tormays = 0;
                Gravity = painovoima2;
                slime.Image = limakuvaylosalaisin;
                gravitypalikka.Move(painovoima2);
            }
        }
        else if (tormays == 1)
        {
            painovoimaluku = 1.0;
            tormays = 0;
            Gravity = painovoima;
            slime.Image = limakuva;
        }
    }
        void Tormays(PhysicsObject tormaaja, PhysicsObject kohde)
        {
            tormays = 1;
        }

        void LuoPelaaja(Vector paikka, double leveys, double korkeus)
        {
            slime.Shape = Shape.Circle;
            slime.Image = limakuva;
            slime.Position = paikka;
            Add(slime);
        }
        void LuoPalikka(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikka = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikka.Position = paikka;
            palikka.Image = grass;
            palikka.CollisionIgnoreGroup = 1;
            Add(palikka);
        }
        void LuoPalikka2(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikka2 = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikka2.Position = paikka;
            palikka2.Image = dirt;
            palikka2.CollisionIgnoreGroup = 1;
            Add(palikka2);
        }
        void LuoEriPalikka(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject eripalikka = PhysicsObject.CreateStaticObject(leveys, korkeus);
            eripalikka.Position = paikka;
            eripalikka.Image = ancientpalikka;
            eripalikka.CollisionIgnoreGroup = 1;
            Add(eripalikka);
        }
        void LuoKentanLoppu(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject loppu = PhysicsObject.CreateStaticObject(leveys, korkeus);
            loppu.Position = paikka;
            loppu.Image = lippu;
            loppu.Tag = "loppu";
            loppu.Image = lippu;
            loppu.IgnoresCollisionResponse = true;
            Add(loppu);
        }
        void LuoYlosPiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject YlosPiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            YlosPiikki.Position = paikka;
            YlosPiikki.Image = piikkiylos;
            YlosPiikki.Tag = "piikki";
            YlosPiikki.CollisionIgnoreGroup = 1;
            Add(YlosPiikki);
        }
        void LuoAlasPiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject AlasPiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            AlasPiikki.Position = paikka;
            AlasPiikki.Image = piikkialas;
            AlasPiikki.Tag = "piikki";
            AlasPiikki.CollisionIgnoreGroup = 1;
            Add(AlasPiikki);
        }
        void LuoVasemmallePiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject VasemmallePiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            VasemmallePiikki.Position = paikka;
            VasemmallePiikki.Image = piikkivasemmalle;
            VasemmallePiikki.Tag = "piikki";
            VasemmallePiikki.CollisionIgnoreGroup = 1;
            Add(VasemmallePiikki);
        }
        void LuoOikeallePiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject OikeallePiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            OikeallePiikki.Position = paikka;
            OikeallePiikki.Image = piikkioikealle;
            OikeallePiikki.Tag = "piikki";
            OikeallePiikki.CollisionIgnoreGroup = 1;
            Add(OikeallePiikki);
        }
        void Kuolema(PhysicsObject tormaaja, PhysicsObject kohde)
        {
            //ClearAll();
            //LuoKentta();

        }
        void lisaaOhjaimet()
        {
            AddCollisionHandler<PlatformCharacter, PhysicsObject>(slime, "piikki", Kuolema);
            AddCollisionHandler<PlatformCharacter, PhysicsObject>(slime, Tormays);
            Keyboard.Listen(Key.W, ButtonState.Pressed, vaihdaPainovoima, "Vaihda painovoima ylös");
            Keyboard.Listen(Key.A, ButtonState.Down, liikuvasemmalle, "Liiku vasemmalle");
            Keyboard.Listen(Key.D, ButtonState.Down, liikuoikealle, "Liiku oikealle");
            Keyboard.Listen(Key.Space, ButtonState.Down, hyppaa, "Hyppää");
            PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        }
        void LuoGravityPalikka(Vector paikka, double leveys, double korkeus)
        {
            
            gravitypalikka.Position = paikka;
            gravitypalikka.Color = Color.Beige;
            gravitypalikka.CollisionIgnoreGroup = 1;
            Add(gravitypalikka);
        }


}