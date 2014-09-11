using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class SuperGravitySlime : PhysicsGame
{
    int tormays = 1;
    Vector vastaimpulssi = new Vector(0.0, -1000.0);
    Vector impulssi = new Vector(0.0, 1000.0);
    double painovoimaluku = 1.0;
    Vector painovoima2 = new Vector(0.0, 3000.0);
    Vector painovoima = new Vector(0.0, -3000.0);
    PlatformCharacter slime = new PlatformCharacter(70.0, 55.0);

    public override void Begin()
    {
        Gravity = painovoima;

        slime.Color = Color.Green;
        slime.Shape = Shape.Circle;


        AddCollisionHandler<PlatformCharacter, PhysicsObject>(slime, Tormays);
        Keyboard.Listen(Key.W, ButtonState.Pressed, vaihdaPainovoima, "Vaihda painovoima ylös");
        Keyboard.Listen(Key.A, ButtonState.Down, liikuvasemmalle, "Liiku vasemmalle");
        Keyboard.Listen(Key.D, ButtonState.Down, liikuoikealle, "Liiku oikealle");
        Keyboard.Listen(Key.Space, ButtonState.Down, hyppaa, "Hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

    }

    void LuoKentta()
    {
        ColorTileMap kentta = ColorTileMap.FromLevelAsset("kentta1");
        kentta.SetTileMethod(Color.FromHexCode("#000000"), LuoPalikka);
        kentta.SetTileMethod(Color.FromHexCode("#040404"), LuoPalikka2);
        kentta.SetTileMethod(Color.FromHexCode("#FF0000"), LuoYlosPiikki);
        kentta.SetTileMethod(Color.FromHexCode("#FF6A00"), LuoAlasPiikki);
        kentta.SetTileMethod(Color.FromHexCode("#FFD800"), LuoPelaaja);
        kentta.SetTileMethod(Color.FromHexCode("#7F3300"), LuoVasemmallePiikki);
        kentta.SetTileMethod(Color.FromHexCode("#7F0000"), LuoOikeallePiikki);

        kentta.Execute(60.0, 60.0);
    }

    void hyppaa()
    {
        if (painovoimaluku == 1.0)
        {
            slime.Jump(1250.0);
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
            painovoimaluku = 2.0;
            Gravity = painovoima2;
        }
        else
        {
            painovoimaluku = 1.0;
            Gravity = painovoima;
        }
    }
        void Tormays(PhysicsObject tormaaja, PhysicsObject kohde)
        {
            tormays = 1;
        }

        void LuoPelaaja(Vector paikka, double leveys, double korkeus)
        {
            slime.Position = paikka;
            Add(slime);
        }
        void LuoPalikka(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikka = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikka.Position = paikka;
            palikka.Color = Color.Green;
            palikka.CollisionIgnoreGroup = 1;
            Add(palikka);
        }
        void LuoPalikka2(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikka2 = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikka2.Position = paikka;
            palikka2.Color = Color.Brown;
            palikka2.CollisionIgnoreGroup = 1;
            Add(palikka2);
        }
        void LuoEriPalikka(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject eripalikka = PhysicsObject.CreateStaticObject(leveys, korkeus);
            eripalikka.Position = paikka;
            eripalikka.Color = Color.Brown;
            eripalikka.CollisionIgnoreGroup = 1;
            Add(eripalikka);
        }
        void LuoKentanLoppu(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject loppu = PhysicsObject.CreateStaticObject(leveys, korkeus);
            loppu.Position = paikka;
            loppu.Tag = "loppu";
            loppu.IgnoresCollisionResponse = true;
            Add(loppu);
        }
        void LuoYlosPiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject YlosPiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            YlosPiikki.Position = paikka;
            YlosPiikki.Shape = Shape.Triangle;
            YlosPiikki.CollisionIgnoreGroup = 1;
            Add(YlosPiikki);
        }
        void LuoAlasPiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject AlasPiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            AlasPiikki.Position = paikka;
            AlasPiikki.Shape = Shape.Triangle;
            AlasPiikki.CollisionIgnoreGroup = 1;
            Add(AlasPiikki);
        }
        void LuoVasemmallePiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject VasemmallePiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            VasemmallePiikki.Position = paikka;
            VasemmallePiikki.Shape = Shape.Triangle;
            VasemmallePiikki.CollisionIgnoreGroup = 1;
            Add(VasemmallePiikki);
        }
        void LuoOikeallePiikki(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject OikeallePiikki = PhysicsObject.CreateStaticObject(leveys, korkeus);
            OikeallePiikki.Position = paikka;
            OikeallePiikki.Shape = Shape.Triangle;
            OikeallePiikki.CollisionIgnoreGroup = 1;
            Add(OikeallePiikki);
        }
}