using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class BulletHell : PhysicsGame
{
    //PhysicsObject ammus = new PhysicsObject(10,10);
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
    Image homingBulletKuva = LoadImage("homingBullet");
    AssaultRifle pelaajanAse;
    PhysicsObject vihollinen;
    Timer luotiAjastin = new Timer();
    Timer damageKuvanAjastin = new Timer();
    int pelaajanElama = 3;
    
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

    PhysicsObject homingBullet = new PhysicsObject(200, 200);

    PhysicsObject reuna;
    

    Vector luodinNopeusNormaali = new Vector(-150, 0);
    Vector luodinNopeusNopea = new Vector(-300, 0);
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
        normalBullet1.Y = 1000;
        normalBullet2.Y = 1000;
        normalBullet3.Y = 1000;
        normalBullet4.Y = 1000;
        normalBullet5.Y = 1000;
        normalBullet6.Y = 1000;
        normalBullet7.Y = 1000;
        normalBullet8.Y = 1000;
        normalBullet9.Y = 1000;
        normalBullet10.Y = 1000;
        normalBullet11.Y = 1000;
        normalBullet12.Y = 1000;
        normalBullet13.Y = 1000;
        normalBullet14.Y = 1000;
        normalBullet15.Y = 1000;
        normalBullet16.Y = 1000;
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

        normalBullet1.Tag = "luoti";
        normalBullet2.Tag = "luoti";
        normalBullet3.Tag = "luoti";
        normalBullet4.Tag = "luoti";
        normalBullet5.Tag = "luoti";
        normalBullet6.Tag = "luoti";
        normalBullet7.Tag = "luoti";
        normalBullet8.Tag = "luoti";
        normalBullet9.Tag = "luoti";
        normalBullet10.Tag = "luoti";
        normalBullet11.Tag = "luoti";
        normalBullet12.Tag = "luoti";
        normalBullet13.Tag = "luoti";
        normalBullet14.Tag = "luoti";
        normalBullet15.Tag = "luoti";
        normalBullet16.Tag = "luoti";
        homingBullet.Tag = "luoti";

        Add(normalBullet1);
        Add(normalBullet2);
        Add(normalBullet3);
        Add(normalBullet4);
        Add(normalBullet5);
        Add(normalBullet6);
        Add(normalBullet7);
        Add(normalBullet8);
        Add(normalBullet9);
        Add(normalBullet10);
        Add(normalBullet11);
        Add(normalBullet12);
        Add(normalBullet13);
        Add(normalBullet14);
        Add(normalBullet15);
        Add(normalBullet16);


        homingBullet.X = 170;
        homingBullet.Y = 10;
        homingBullet.Image = homingBulletKuva;
        FollowerBrain homingAivot = new FollowerBrain(pelaaja);
        homingBullet.CanRotate = false;
        homingBullet.Brain = homingAivot;
        
        //teeHyokkays();
        //hyokkays1();
        hyokkays2();
        //hyokkays3();
    }



    void luoKentta()
    {
        ColorTileMap ruudut = ColorTileMap.FromLevelAsset("level");
        ruudut.SetTileMethod(Color.Black, luoReuna);
        ruudut.SetTileMethod(Color.FromHexCode("#0026FF"), luoPelaaja);
        ruudut.SetTileMethod(Color.Red, luoVihollinen);
        ruudut.Execute(20, 20);
        
        AddCollisionHandler(pelaaja, "luoti", pelaajaOsuiLuotiin);
        
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
        reuna = PhysicsObject.CreateStaticObject(leveys, korkeus);
        reuna.Position = paikka;
        reuna.Image = reunanKuva;
        reuna.Tag = "reuna";
        Add(reuna);
        AddCollisionHandler(reuna, "luoti", tuhoaLuoti);
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
        PhysicsObject ammus = new PhysicsObject(10, 10);
        ammus = ase.Shoot();
        
        //ammus.IgnoresCollisionWith(normalBullet1);
        pelaaja.IgnoresCollisionResponse = true;
        if (ammus != null)
        {
            Add(ammus);
            ammus.IgnoresCollisionResponse = true;
            homingBullet.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(homingBullet);
            normalBullet1.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet1);
            normalBullet2.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet2);
            normalBullet3.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet3);
            normalBullet4.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet4);
            normalBullet5.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet5);
            normalBullet6.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet6);
            normalBullet7.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet7);
            normalBullet8.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet8);
            normalBullet9.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet9);
            normalBullet10.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet10);
            normalBullet11.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet11);
            normalBullet12.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet12);
            normalBullet13.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet13);
            normalBullet14.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet14);
            normalBullet15.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet15);
            normalBullet16.IgnoresCollisionWith(ammus);
            ammus.IgnoresCollisionWith(normalBullet16);
        }
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

    void tuhoaLuoti(PhysicsObject reuna, PhysicsObject kohde)
    {
        kohde.Destroy();
    }

    void tuhoaHomingBullet()
    {
        homingBullet.Y = 1000;
    }

    void pelaajaOsuiLuotiin(PhysicsObject pelaaja, PhysicsObject kohde)
    {
        pelaajanElama = pelaajanElama - 1;
        if (pelaajanElama == 0)
        {
            pelaaja.Destroy();
            MultiSelectWindow gameOverValikko = new MultiSelectWindow("GAME OVER", "RETRY", "QUIT");
            gameOverValikko.ItemSelected += painettiinValikonNappia;
            Add(gameOverValikko);

        }

    }

    void painettiinValikonNappia(int valinta)
    {
        switch (valinta)
        {
            case 0:
                restart();
                break;
            case 1:
                Exit();
                break; 
        }
    }

    void restart()
    {
        ClearAll();
        Begin();
    }
    void teeHyokkays()
    {
        int hyokkaysLuku = RandomGen.NextInt(1, 4);
        if (hyokkaysLuku == 1)
        {
            hyokkays1();
        }
        if (hyokkaysLuku == 2)
        {
            hyokkays2();
        }
        if (hyokkaysLuku == 3)
        {
            hyokkays3();
        }
        if (hyokkaysLuku == 4)
        {
            hyokkays4();
        }
        if (hyokkaysLuku == 5)
        {
            hyokkays5();
        }

    }

    void hyokkays1()
    {
        Add(homingBullet);
        Timer.SingleShot(7.0, tuhoaHomingBullet);
        Timer.SingleShot(8.0, teeHyokkays);
    }
    

    void hyokkays2()
    {
        //cluster
        Timer.SingleShot(1.0, laukaiseNormalBullet5);
        Timer.SingleShot(1.0, laukaiseNormalBullet10);
        Timer.SingleShot(2.0, laukaiseNormalBullet12);
        Timer.SingleShot(2.0, laukaiseNormalBullet7);
        Timer.SingleShot(2.0, laukaiseNormalBullet3);
        Timer.SingleShot(3.0, laukaiseNormalBullet1);
        Timer.SingleShot(3.0, laukaiseNormalBullet8);
        Timer.SingleShot(3.0, laukaiseNormalBullet16);
        Timer.SingleShot(3.5, laukaiseNormalBullet13);
        Timer.SingleShot(3.5, laukaiseNormalBullet4);
        Timer.SingleShot(4.0, laukaiseNormalBullet6);
        Timer.SingleShot(4.0, laukaiseNormalBullet11);
        Timer.SingleShot(4.0, laukaiseNormalBullet2);
        Timer.SingleShot(5.0, laukaiseNormalBullet9);
        Timer.SingleShot(5.0, laukaiseNormalBullet14);
        Timer.SingleShot(8.0, teeHyokkays);
    }

    void hyokkays3()
    {
        //rows
        int valiLuku = RandomGen.NextInt(1, 6);
        if (valiLuku == 1)
        {
            Timer.SingleShot(1.0, laukaiseNormalBullet1Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet2Nopea);
            
            Timer.SingleShot(1.0, laukaiseNormalBullet5Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet6Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet7Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet8Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet9Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet10Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet11Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet12Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet13Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet14Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet15Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet16Nopea);
        }
        if (valiLuku == 2)
        {
            Timer.SingleShot(1.0, laukaiseNormalBullet1Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet2Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet3Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet4Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet5Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet6Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet7Nopea);
            
            Timer.SingleShot(1.0, laukaiseNormalBullet10Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet11Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet12Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet13Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet14Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet15Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet16Nopea);
        }
        if (valiLuku == 3)
        {
            Timer.SingleShot(1.0, laukaiseNormalBullet1Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet2Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet3Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet4Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet5Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet6Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet7Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet8Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet9Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet10Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet11Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet12Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet13Nopea);
            
            Timer.SingleShot(1.0, laukaiseNormalBullet16Nopea);
        }
        if (valiLuku == 4)
        {
            Timer.SingleShot(1.0, laukaiseNormalBullet1Nopea);
            
            Timer.SingleShot(1.0, laukaiseNormalBullet4Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet5Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet6Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet7Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet8Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet9Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet10Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet11Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet12Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet13Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet14Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet15Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet16Nopea);
        }
        if (valiLuku == 5)
        {
            Timer.SingleShot(1.0, laukaiseNormalBullet1Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet2Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet3Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet4Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet5Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet6Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet7Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet8Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet9Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet10Nopea);
            
            Timer.SingleShot(1.0, laukaiseNormalBullet13Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet14Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet15Nopea);
            Timer.SingleShot(1.0, laukaiseNormalBullet16Nopea);
            
        }

        Timer.SingleShot(6.0, teeHyokkays);
    }

    void hyokkays4()
    {

    }

    void hyokkays5()
    {

    }

    void laukaiseNormalBullet1()
    {
        normalBullet1.Y = Screen.Top - 300;
        normalBullet1.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet2()
    {
        normalBullet1.Y = Screen.Top - 330;
        normalBullet2.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet3()
    {
        normalBullet1.Y = Screen.Top - 360;
        normalBullet3.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet4()
    {
        normalBullet1.Y = Screen.Top - 390;
        normalBullet4.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet5()
    {
        normalBullet1.Y = Screen.Top - 420;
        normalBullet5.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet6()
    {
        normalBullet1.Y = Screen.Top - 450;
        normalBullet6.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet7()
    {
        normalBullet1.Y = Screen.Top - 480;
        normalBullet7.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet8()
    {
        normalBullet1.Y = Screen.Top - 510;
        normalBullet8.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet9()
    {
        normalBullet1.Y = Screen.Top - 540;
        normalBullet9.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet10()
    {
        normalBullet1.Y = Screen.Top - 570;
        normalBullet10.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet11()
    {
        normalBullet1.Y = Screen.Top - 600;
        normalBullet11.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet12()
    {
        normalBullet1.Y = Screen.Top - 630;
        normalBullet12.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet13()
    {
        normalBullet1.Y = Screen.Top - 660;
        normalBullet13.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet14()
    {
        normalBullet1.Y = Screen.Top - 690;
        normalBullet14.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet15()
    {
        normalBullet1.Y = Screen.Top - 720;
        normalBullet15.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet16()
    {
        normalBullet1.Y = Screen.Top - 750;
        normalBullet16.Move(luodinNopeusNormaali);
    }
    void laukaiseNormalBullet1Nopea()
    {
        normalBullet1.IgnoresCollisionResponse = true;
        Add(normalBullet1);
        normalBullet1.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet2Nopea()
    {
        Add(normalBullet2);
        normalBullet2.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet3Nopea()
    {
        Add(normalBullet3);
        normalBullet3.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet4Nopea()
    {
        Add(normalBullet4);
        normalBullet4.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet5Nopea()
    {
        Add(normalBullet5);
        normalBullet5.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet6Nopea()
    {
        Add(normalBullet6);
        normalBullet6.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet7Nopea()
    {
        Add(normalBullet7);
        normalBullet7.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet8Nopea()
    {
        Add(normalBullet8);
        normalBullet8.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet9Nopea()
    {
        Add(normalBullet9);
        normalBullet9.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet10Nopea()
    {
        Add(normalBullet10);
        normalBullet10.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet11Nopea()
    {
        Add(normalBullet11);
        normalBullet11.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet12Nopea()
    {
        Add(normalBullet12);
        normalBullet12.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet13Nopea()
    {
        Add(normalBullet13);
        normalBullet13.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet14Nopea()
    {
        Add(normalBullet14);
        normalBullet14.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet15Nopea()
    {
        Add(normalBullet15);
        normalBullet15.Move(luodinNopeusNopea);
    }
    void laukaiseNormalBullet16Nopea()
    {
        Add(normalBullet16);
        normalBullet16.Move(luodinNopeusNopea);
    }


}
