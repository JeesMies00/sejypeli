using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class BulletHell : PhysicsGame
{
    PhysicsObject ammus;
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
    Image normalBulletKuva = LoadImage("normalBullet");
    AssaultRifle pelaajanAse;
    PhysicsObject vihollinen;
    Timer luotiAjastin = new Timer();
    Timer damageKuvanAjastin = new Timer();
    DoubleMeter elamalaskuri;
    PhysicsObject normalBullet1 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet2 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet3 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet4 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet5 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet6 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet7 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet8 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet9 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet10 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet11 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet12 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet13 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet14 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet15 = new PhysicsObject(20, 20);
    PhysicsObject normalBullet16 = new PhysicsObject(20, 20);
    Vector luodinNopeus = new Vector(-10000, 0);
    TimeSpan luodinAika = new TimeSpan(100);
    

    public override void Begin()
    {
        damageKuvanAjastin.Interval = 0.05;
        luotiAjastin.Interval = 1;
        damageKuvanAjastin.Timeout += muutaKuva;
        SmoothTextures = false;
        luoKentta();
        luoElamaLaskuri();
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

        normalBullet1.X = 260;
        normalBullet2.X = 260;
        normalBullet3.X = 260;
        normalBullet4.X = 260;
        normalBullet5.X = 260;
        normalBullet6.X = 260;
        normalBullet7.X = 260;
        normalBullet8.X = 260;
        normalBullet9.X = 260;
        normalBullet10.X = 260;
        normalBullet11.X = 260;
        normalBullet12.X = 260;
        normalBullet13.X = 260;
        normalBullet14.X = 260;
        normalBullet15.X = 260;
        normalBullet16.X = 260;
        normalBullet1.Y = Screen.Top - 300;
        normalBullet2.Y = Screen.Top - 330;
        normalBullet3.Y = Screen.Top - 360;
        normalBullet4.Y = Screen.Top - 390;
        normalBullet5.Y = Screen.Top - 420;
        normalBullet6.Y = Screen.Top - 450;
        normalBullet7.Y = Screen.Top - 480;
        normalBullet8.Y = Screen.Top - 510;
        normalBullet9.Y = Screen.Top - 540;
        normalBullet10.Y = Screen.Top - 570;
        normalBullet11.Y = Screen.Top - 600;
        normalBullet12.Y = Screen.Top - 630;
        normalBullet13.Y = Screen.Top - 660;
        normalBullet14.Y = Screen.Top - 690;
        normalBullet15.Y = Screen.Top - 720;
        normalBullet16.Y = Screen.Top - 750;
        normalBullet1.Image = normalBulletKuva;
        normalBullet2.Image = normalBulletKuva;
        normalBullet3.Image = normalBulletKuva;
        normalBullet4.Image = normalBulletKuva;
        normalBullet5.Image = normalBulletKuva;
        normalBullet6.Image = normalBulletKuva;
        normalBullet7.Image = normalBulletKuva;
        normalBullet8.Image = normalBulletKuva;
        normalBullet9.Image = normalBulletKuva;
        normalBullet10.Image = normalBulletKuva;
        normalBullet11.Image = normalBulletKuva;
        normalBullet12.Image = normalBulletKuva;
        normalBullet13.Image = normalBulletKuva;
        normalBullet14.Image = normalBulletKuva;
        normalBullet15.Image = normalBulletKuva;
        normalBullet16.Image = normalBulletKuva;

        teeHyokkays();
        hyokkays1();
        
    }



    void luoKentta()
    {
        ColorTileMap ruudut = ColorTileMap.FromLevelAsset("level");
        ruudut.SetTileMethod(Color.Black, luoReuna);
        ruudut.SetTileMethod(Color.FromHexCode("#0026FF"), luoPelaaja);
        ruudut.SetTileMethod(Color.Red, luoVihollinen);
        ruudut.Execute(20, 20);
        
        Camera.ZoomToLevel();
        Level.Background.CreateStars();
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
        ammus = ase.Shoot();
        //ammus.IgnoresCollisionWith(normalBullet1);
    }

    void AmmusOsui(PhysicsObject ammus, PhysicsObject kohde)
    {
        ammus.Destroy();

        if (kohde.Tag == vihollinen.Tag)
        {
            vihollinen.Image = damageKuva;
            elamalaskuri.Value -= 1;
            damageKuvanAjastin.Start();
            
        }

    }

    void muutaKuva()
    {
        vihollinen.Image = vihollisenKuva;
    }

    void luoElamaLaskuri()
    {
        elamalaskuri = new DoubleMeter(250);
        elamalaskuri.MaxValue = 250;
        elamalaskuri.LowerLimit += tapaVihollinen;
        ProgressBar elamaPalkki = new ProgressBar(1200, 40);
        elamaPalkki.Y = Screen.Top - 80;
        elamaPalkki.Color = Color.Transparent;
        elamaPalkki.BarColor = Color.Blue;
        elamaPalkki.BorderColor = Color.White;
        elamaPalkki.BindTo(elamalaskuri);
        Add(elamaPalkki);
    }

    void tapaVihollinen()
    {
        vihollinen.Destroy();
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
       
        Add(normalBullet1);
        Add(normalBullet4);
        normalBullet1.Push(luodinNopeus, luodinAika);
        normalBullet4.Push(luodinNopeus, luodinAika);
        Add(normalBullet2);
        Add(normalBullet5);
        
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
