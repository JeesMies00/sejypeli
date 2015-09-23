using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class BulletHell : PhysicsGame
{
    
    PhysicsObject pelaaja = new PhysicsObject(30, 30);
    PhysicsObject bullet = new PhysicsObject(10, 10);
    Vector oikealle = new Vector(300, 0);
    Vector vasemmalle = new Vector(-300, 0);
    Vector ylos = new Vector(0, 300);
    Vector alas = new Vector(0, -300);
    Image pelaajanKuva = LoadImage("alus");
    Image reunanKuva = LoadImage("reuna");
    Image vihollisenKuva = LoadImage("silmapallot");
    Image damageKuva = LoadImage("silmapallot(damaged)");
    AssaultRifle pelaajanAse;
    PhysicsObject vihollinen;
    int vihollisenElama = 1000;
    Timer damageKuvanAjastin = new Timer();
    

    public override void Begin()
    {
        damageKuvanAjastin.Interval = 0.05;
        damageKuvanAjastin.Timeout += muutaKuva;
        SmoothTextures = false;
        luoKentta();
        Keyboard.Listen(Key.D, ButtonState.Down, liiku, "Liiku oikealle", pelaaja, oikealle);
        Keyboard.Listen(Key.A, ButtonState.Down, liiku, "Liiku vasemmalle", pelaaja, vasemmalle);
        Keyboard.Listen(Key.W, ButtonState.Down, liiku, "Liiku ylös", pelaaja, ylos);
        Keyboard.Listen(Key.S, ButtonState.Down, liiku, "Liiku alas", pelaaja, alas);
        Keyboard.Listen(Key.D, ButtonState.Released, pysahdy, "Liiku oikealle");
        Keyboard.Listen(Key.A, ButtonState.Released, pysahdy, "Liiku vasemmalle");
        Keyboard.Listen(Key.W, ButtonState.Released, pysahdy, "Liiku ylös");
        Keyboard.Listen(Key.S, ButtonState.Released, pysahdy, "Liiku alas");

        Keyboard.Listen(Key.Enter, ButtonState.Down, ammu, "Ammu", pelaajanAse);
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

        teeHyokkays();
    }



    void luoKentta()
    {
        ColorTileMap ruudut = ColorTileMap.FromLevelAsset("level");
        ruudut.SetTileMethod(Color.Black, luoReuna);
        ruudut.SetTileMethod(Color.FromHexCode("#0026FF"), luoPelaaja);
        ruudut.SetTileMethod(Color.Red, luoVihollinen);
        ruudut.Execute(20, 20);
        
        Camera.ZoomToLevel();
    }

    void luoPelaaja(Vector paikka, double leveys, double korkeus)
    {
        pelaaja.Image = pelaajanKuva;
        pelaaja.CanRotate = false;
        pelaaja.Restitution = 0;
        pelaaja.Position = paikka;
        pelaajanAse = new AssaultRifle(0.01, 0.01);
        pelaajanAse.ProjectileCollision = AmmusOsui;
        pelaaja.Add(pelaajanAse);
        Add(pelaaja);

    }

    void luoReuna(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject reuna = PhysicsObject.CreateStaticObject(leveys, korkeus);
        reuna.Position = paikka;
        reuna.Image = reunanKuva;
        Add(reuna);
    }
    void luoVihollinen(Vector paikka, double leveys, double korkeus)
    {
        
        vihollinen = PhysicsObject.CreateStaticObject(200, 400);
        vihollinen.Position = paikka;
        vihollinen.Image = vihollisenKuva;
        vihollinen.Tag = "vihollinen";
        Add(vihollinen);
    }

    void liiku(PhysicsObject pelaaja, Vector nopeus)
    {
        pelaaja.Velocity = nopeus;
        bullet.Velocity = nopeus;
    }

    
    void pysahdy()
    {
        pelaaja.Velocity = Vector.Zero;
    }

    void ammu(AssaultRifle ase)
    {
        PhysicsObject ammus = ase.Shoot();
    }

    void AmmusOsui(PhysicsObject ammus, PhysicsObject kohde)
    {
        ammus.Destroy();

        if (kohde.Tag == vihollinen.Tag)
        {
            vihollinen.Image = damageKuva;
            vihollisenElama = vihollisenElama - 1;
            damageKuvanAjastin.Start();
            
        }

        if (vihollisenElama == 0)
        {
            vihollinen.Destroy();
        }
    }

    void muutaKuva()
    {
        vihollinen.Image = vihollisenKuva;
    }

    void teeHyokkays()
    {
        int hyokkaysLuku = RandomGen.NextInt(1, 6);
        if (hyokkaysLuku == 1)
        { 
        
        }
        if (hyokkaysLuku == 2)
        {

        }
        if (hyokkaysLuku == 3)
        {

        }
        if (hyokkaysLuku == 4)
        {

        }
        if (hyokkaysLuku == 5)
        {

        }
    }

    void hyokkays1()
    { 
    
    }

    void hyokkays2()
    {

    }

    void hyokkays3()
    {

    }

    void hyokkays4()
    {

    }

    void hyokkays5()
    {

    }
}
