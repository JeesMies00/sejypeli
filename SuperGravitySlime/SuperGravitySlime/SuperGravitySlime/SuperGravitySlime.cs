using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class SuperGravitySlime : PhysicsGame
{
    int godMode = 0;
    int kenttanro = 1; 
    int tormays = 1;
    Vector vastaimpulssi = new Vector(0.0, -1500.0);
    Vector impulssi = new Vector(0.0, 1000.0);
    double painovoimaluku = 1.0;
    Vector painovoima2 = new Vector(0.0, 3000.0);
    Vector painovoima = new Vector(0.0, -3000.0);
    PlatformCharacter slime;
    Image pilvivaarinpain = LoadImage("palikkavaarinpain(2)");
    Image limakuva = LoadImage("slime");
    Image hellgrass = LoadImage("palikka(4)");
    Image hellgrassvaarinpain = LoadImage("palikkavaarinpain(4)");
    Image hellblock = LoadImage("eripalikka(4)");
    Image helldoor = LoadImage("loppu(4)");
    Image helldirt = LoadImage("palikka2(4)");
    Image limakuvaylosalaisin = LoadImage("slimeylosalaisin");
    Image grass = LoadImage("palikka(1)");
    Image pilvi2 = LoadImage("palikka2(2)");
    Image pilvi = LoadImage("palikka(2)");
    Image pilviovi = LoadImage("loppu(2)");
    Image grassvaarinpain = LoadImage("palikkavaarinpain(1)");
    Image dirt = LoadImage("palikka2(1)");
    Image avaruuspalikka = LoadImage("palikka(3)");
    Image avaruuspalikka2 = LoadImage("palikka2(3)");
    Image avaruusovi = LoadImage("loppu(3)");
    Image avaruuspalikkavaarinpain = LoadImage("palikkavaarinpain(3)");
    Image avaruuseripalikka = LoadImage("eripalikka(3)");
    Image ancientpalikka = LoadImage("eripalikka(1)");
    Image ancientpalikka2 = LoadImage("eripalikka(2)");
    Image puuovi = LoadImage("loppu(1)");
    Image piikkiylos = LoadImage("piikkiylös");
    Image piikkialas = LoadImage("piikkialas");
    Image piikkioikealle = LoadImage("piikkioikealle");
    Image piikkivasemmalle = LoadImage("piikkivasemmalle");
    Image sininenRinkula = LoadImage("antigravitationBlock");
    public override void Begin()
    {
        MultiSelectWindow alkuValikko = new MultiSelectWindow("", "Taso 1", "Taso 2", "Taso 3", "Taso 4", "Lopeta peli");
        Add(alkuValikko);
        alkuValikko.AddItemHandler(0, SeuraavaKentta);
        alkuValikko.AddItemHandler(1, SkipToLevel2);
        alkuValikko.AddItemHandler(2, SkipToLevel3);
        alkuValikko.AddItemHandler(3, SkipToLevel4);
        alkuValikko.AddItemHandler(4, Exit);
    }

    void SeuraavaKentta()
    {
        ClearAll();

        if (kenttanro == 1) LuoKentta("kentta1");
        else if (kenttanro == 2) LuoKentta("kentta2");
        else if (kenttanro == 3) LuoKentta("kentta3");
        else if (kenttanro == 4) LuoKentta("kentta4");
        else if (kenttanro == 5) MessageDisplay.Add("YOU WIN!");
        lisaaOhjaimet();
        
    }
    void LuoKentta(string kentannimi)
    {
        Gravity = painovoima;
        ColorTileMap kentta = ColorTileMap.FromLevelAsset(kentannimi);
        kentta.SetTileMethod(Color.FromHexCode("#000000"), LuoPalikka);
        kentta.SetTileMethod(Color.FromHexCode("#808080"), LuoPalikkaVaarinpain);
        kentta.SetTileMethod(Color.FromHexCode("#404040"), LuoPalikka2);
        kentta.SetTileMethod(Color.FromHexCode("#0094FF"), LuoEriPalikka);
        kentta.SetTileMethod(Color.FromHexCode("#FF0000"), LuoYlosPiikki);
        kentta.SetTileMethod(Color.FromHexCode("#FF6A00"), LuoAlasPiikki);
        kentta.SetTileMethod(Color.FromHexCode("#FFD800"), LuoPelaaja);
        kentta.SetTileMethod(Color.FromHexCode("#7F3300"), LuoVasemmallePiikki);
        kentta.SetTileMethod(Color.FromHexCode("#7F0000"), LuoOikeallePiikki);
        kentta.SetTileMethod(Color.FromHexCode("#B200FF"), LuoKentanLoppu);
        kentta.SetTileMethod(Color.FromHexCode("#00FFFF"), LuoAntiGravitaatioBlock);
        kentta.Execute(60.0, 60.0);
            AddCollisionHandler<PlatformCharacter, PhysicsObject>(slime, "loppu", Loppu);
            AddCollisionHandler<PlatformCharacter, PhysicsObject>(slime, "piikki", Kuolema);
        Camera.Follow(slime);
        if (kenttanro == 1)
        {
            MediaPlayer.Play("plains");
        }
        else if (kenttanro == 2)
        {
            MediaPlayer.Play("heaven");
        }
        else if (kenttanro == 3)
        {
            MediaPlayer.Play("space");
        }
        else if (kenttanro == 4)
        {
            MediaPlayer.Play("hell");
        }
        if (kenttanro == 1)
        {
            Level.Background.CreateGradient(Color.Aqua, Color.Blue);
        }
        else if (kenttanro == 2)
        {
            Level.Background.CreateGradient(Color.Pink, Color.White);
        } 
        else if (kenttanro == 3)
        {
            Level.Background.CreateStars();
        } 
        else if (kenttanro == 4)
        {
            Level.Background.CreateGradient(Color.Red, Color.BloodRed);
        }
    }

    void hyppaa()
    {
        if (painovoimaluku == 1.0)
        {
            slime.Jump(750);
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
            slime = new PlatformCharacter(65, 60);
            slime.Shape = Shape.Circle;
            slime.Image = limakuva;
            slime.Position = paikka;
                AddCollisionHandler<PlatformCharacter, PhysicsObject>(slime, Tormays);
            Add(slime);
        }
        void LuoPalikka(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikka = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikka.Position = paikka;
            if (kenttanro == 1)
            {
                palikka.Image = grass;
            }
            else if (kenttanro == 2)
            {
                palikka.Image = pilvi;
            }
            else if (kenttanro == 3)
            {
                palikka.Image = avaruuspalikka;
            }
            else if (kenttanro == 4)
            {
                palikka.Image = hellgrass;
            }
            palikka.CollisionIgnoreGroup = 1;
            
            Add(palikka);
        }
        void LuoPalikkaVaarinpain(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikkaVaarinpain = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikkaVaarinpain.Position = paikka;
            if (kenttanro == 1)
            {
                palikkaVaarinpain.Image = grassvaarinpain;
            }
            else if (kenttanro == 2)
            {
                palikkaVaarinpain.Image = pilvivaarinpain;
            }
            else if (kenttanro == 3)
            {
                palikkaVaarinpain.Image = avaruuspalikkavaarinpain;
            }
            else if (kenttanro == 4)
            {
                palikkaVaarinpain.Image = hellgrassvaarinpain;
            }
            palikkaVaarinpain.CollisionIgnoreGroup = 1;
            Add(palikkaVaarinpain);
        }
        void LuoPalikka2(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject palikka2 = PhysicsObject.CreateStaticObject(leveys, korkeus);
            palikka2.Position = paikka;
            if (kenttanro == 1)
            {
                palikka2.Image = dirt;
            }
            else if (kenttanro == 2)
            {
                palikka2.Image = pilvi2;
            }
            else if (kenttanro == 3)
            {
                palikka2.Image = avaruuspalikka2;
            }
            else if (kenttanro == 4)
            {
                palikka2.Image = helldirt;
            }
            palikka2.CollisionIgnoreGroup = 1;
            Add(palikka2);
        }
        void LuoEriPalikka(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject eripalikka = PhysicsObject.CreateStaticObject(leveys, korkeus);
            eripalikka.Position = paikka;
            if (kenttanro == 1)
            {
                eripalikka.Image = ancientpalikka;
            }
            else if (kenttanro == 2)
            {
                eripalikka.Image = ancientpalikka2;
            }
            else if (kenttanro == 3)
            {
                eripalikka.Image = avaruuseripalikka;
            }
            else if (kenttanro == 4)
            {
                eripalikka.Image = hellblock;
            }
            eripalikka.CollisionIgnoreGroup = 1;
            Add(eripalikka);
        }
        void LuoKentanLoppu(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject loppu = PhysicsObject.CreateStaticObject(leveys, korkeus);
            loppu.Position = paikka;
            if (kenttanro == 1)
            {
                loppu.Image = puuovi;
            }
            else if (kenttanro == 2)
            {
                loppu.Image = pilviovi;
            }
            else if (kenttanro == 3)
            {
                loppu.Image = avaruusovi;
            }
            else if (kenttanro == 4)
            {
                loppu.Image = helldoor;
            }
            loppu.Tag = "loppu";
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
        void LuoAntiGravitaatioBlock(Vector paikka, double leveys, double korkeus)
        {
            PhysicsObject AntiGravitaatioBlock = PhysicsObject.CreateStaticObject(leveys, korkeus);
            AntiGravitaatioBlock.Position = paikka;
            AntiGravitaatioBlock.Image = sininenRinkula;
            AntiGravitaatioBlock.IgnoresCollisionResponse = true;
            Add(AntiGravitaatioBlock);
        }
        void Kuolema(PhysicsObject tormaaja, PhysicsObject kohde)
        {
            if (godMode == 0)
            {
                slime.Destroy();
                painovoimaluku = 1;
            }
        }
        void lisaaOhjaimet()
        {
            Keyboard.Listen(Key.T, ButtonState.Pressed, Skip, "Ohita taso");
            Keyboard.Listen(Key.G, ButtonState.Pressed, GodMode, "Muutu kuolemattomaksi");
            Keyboard.Listen(Key.R, ButtonState.Pressed, Aloitaalusta, "Aloita alusta");
            Keyboard.Listen(Key.W, ButtonState.Pressed, vaihdaPainovoima, "Vaihda painovoima ylös");
            Keyboard.Listen(Key.A, ButtonState.Down, liikuvasemmalle, "Liiku vasemmalle");
            Keyboard.Listen(Key.D, ButtonState.Down, liikuoikealle, "Liiku oikealle");
            Keyboard.Listen(Key.Space, ButtonState.Down, hyppaa, "Hyppää");
            PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        }
        void Aloitaalusta()
        {
            SeuraavaKentta();
        
        }
        void Loppu(PhysicsObject tormaaja, PhysicsObject kohde)
        {
            ClearAll();
            kenttanro++;
            SeuraavaKentta();
        }
        void Skip()
        {
            ClearAll();
            kenttanro++;
            SeuraavaKentta();
        }
        void SkipToLevel2()
        {
            ClearAll();
            kenttanro = 2;
            SeuraavaKentta();
        }
        void SkipToLevel3()
        {
            ClearAll();
            kenttanro = 3;
            SeuraavaKentta();
        }
        void SkipToLevel4()
        {
            ClearAll();
            kenttanro = 4;
            SeuraavaKentta();
        }
        void GodMode()
        {
            if (godMode == 0)
            {
                godMode = 1;
                MessageDisplay.Add("Godmode ON");
            }
            else if (godMode == 1)
            {
                godMode = 0;
                MessageDisplay.Add("Godmode OFF");
            }
        }
}