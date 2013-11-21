using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class InvationOfBlobs : PhysicsGame
{
    PlatformCharacter Pelaaja;
    void LuoRuoho(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Ruoho = PhysicsObject.CreateStaticObject(30, 30);
        Ruoho.Color = Color.Green;
        Ruoho.CollisionIgnoreGroup = 1;
        Ruoho.Position = paikka;
        Add(Ruoho);
    }
    void LuoDirt(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Dirt = PhysicsObject.CreateStaticObject(30, 30);
        Dirt.Color = Color.Brown;
        Dirt.CollisionIgnoreGroup = 1;
        Dirt.Position = paikka;
        Add(Dirt);
    }
    void LuoPilvi(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Pilvi = PhysicsObject.CreateStaticObject(30, 30);
        Pilvi.Color = Color.White;
        Pilvi.CollisionIgnoreGroup = 1;
        Pilvi.Position = paikka;
        Add(Pilvi);
    }
    void LuoAurinkoa(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Aurinkoa = PhysicsObject.CreateStaticObject(30, 30);
        Aurinkoa.Color = Color.Yellow;
        Aurinkoa.CollisionIgnoreGroup = 1;
        Aurinkoa.Position = paikka;
        Add(Aurinkoa);
    }
    void LuoPotion(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Potion = PhysicsObject.CreateStaticObject(30, 30);
        Potion.Image = LoadImage("HealingPotion");
        Potion.Position = paikka;
        Add(Potion);
    }
    void LuoWarriorBlob(Vector paikka, double korkeus, double leveys)
    {
        PlatformCharacter WarriorBlob = new PlatformCharacter(30.0, 30.0);
        WarriorBlob.Image = LoadImage("WarriorBlob");
        WarriorBlob.Position = paikka;
        PlatformWandererBrain tasoaivot = new PlatformWandererBrain();
        WarriorBlob.Brain = tasoaivot;
        Add(WarriorBlob);
    }
    void LuoBlob(Vector paikka, double korkeus, double leveys)
    {
        PlatformCharacter Blob = new PlatformCharacter(30.0, 30.0);
        Blob.Image = LoadImage("Blob");
        Blob.Position = paikka;
        PlatformWandererBrain tasoaivot = new PlatformWandererBrain();
        Blob.Brain = tasoaivot;
        Add(Blob);
    }
    void LuoOvi(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Ovi = PhysicsObject.CreateStaticObject(30.0, 30.0);
        Ovi.Image = LoadImage("Ovi");
        Ovi.Position = paikka;
        Add(Ovi);
    }
    void LuoAvain(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject Avain = PhysicsObject.CreateStaticObject(30.0, 30.0);
        Avain.Image = LoadImage("Avain");
        Avain.Position = paikka;
        Add(Avain);
    }
    void LuoPelaaja(Vector paikka, double korkeus, double leveys)
    {
        Pelaaja = new PlatformCharacter(30.0, 30.0);
        Pelaaja.Image = LoadImage("PlayerCarrot");
        Pelaaja.Weapon = new PlasmaCannon(25, 10);
        Pelaaja.Weapon.Ammo.Value = 100000;
        Pelaaja.Weapon.ProjectileCollision = AmmusOsui;
        Pelaaja.Position = paikka;
        Add(Pelaaja);
    }
    void LuoLentoBlob(Vector paikka, double korkeus, double leveys)
    {
        PlatformCharacter LentoBlob = new PlatformCharacter(30.0, 30.0);
        LentoBlob.Image = LoadImage("LentoBlob");
        LentoBlob.Position = paikka;
        Add(LentoBlob);
    }
    void LuoVihreaSateenkaariOsa(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject VihreaSateenkaariOsa = PhysicsObject.CreateStaticObject(30.0, 30.0);
        VihreaSateenkaariOsa.Color = Color.LimeGreen;
        VihreaSateenkaariOsa.CollisionIgnoreGroup = 1;
        VihreaSateenkaariOsa.Position = paikka;
        Add(VihreaSateenkaariOsa);
    }
    void LuoPunainenSateenkaariOsa(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject PunainenSateenkaariOsa = PhysicsObject.CreateStaticObject(30.0, 30.0);
        PunainenSateenkaariOsa.Color = Color.Red;
        PunainenSateenkaariOsa.CollisionIgnoreGroup = 1;
        PunainenSateenkaariOsa.Position = paikka;
        Add(PunainenSateenkaariOsa);
    }
    void LuoSininenSateenkaariOsa(Vector paikka, double korkeus, double leveys)
    {
        PhysicsObject SininenSateenkaariOsa = PhysicsObject.CreateStaticObject(30.0, 30.0);
        SininenSateenkaariOsa.Color = Color.Blue;
        SininenSateenkaariOsa.CollisionIgnoreGroup = 1;
        SininenSateenkaariOsa.Position = paikka;
        Add(SininenSateenkaariOsa);
    }

    void PelaajaOikealle()
    {
        Pelaaja.Walk(200);
    }
    void PelaajaVasemmalle()
    {
        Pelaaja.Walk(-200);
    }
    void PelaajaHyppaa()
    {
        Pelaaja.Jump(1050);
    }
    
    IntMeter pisteet;
    void LuoPisteLaskuri()
    {
        pisteet = new IntMeter(0);

        Label pistenaytto = new Label();
        pistenaytto.X = Screen.Right - 100;
        pistenaytto.Y = Screen.Top - 100;
        pistenaytto.Title = "Points";
        pistenaytto.BindTo(pisteet);
        Add(pistenaytto);
    }
    IntMeter elamat;
    void LuoElamaLaskuri()
    {
        elamat = new IntMeter(5);

        Label elamanaytto = new Label();
        elamanaytto.X = Screen.Left + 100;
        elamanaytto.Y = Screen.Top - 100;
        elamanaytto.Title = "Health";
        elamanaytto.BindTo(elamat);
        Add(elamanaytto);
    }
    void AmmusOsui(PhysicsObject ammus, PhysicsObject kohde)
    {
        ammus.Destroy();
        kohde.Destroy();
    }
    void AmmuAseella(PlatformCharacter Pelaaja)
    {
        PhysicsObject ammus = Pelaaja.Weapon.Shoot();
    }
    void Tahtaa(AnalogState hiirenliike)
    {
        Vector suunta = (Mouse.PositionOnWorld - Pelaaja.Weapon.AbsolutePosition).Normalize();
        Pelaaja.Weapon.Angle = suunta.Angle;
    }
    public override void Begin()
    {
        LuoElamaLaskuri();
        LuoPisteLaskuri();
        Gravity = new Vector(0.0, -800.0);
        ColorTileMap Level1 = ColorTileMap.FromLevelAsset("Level1");
        Mouse.IsCursorVisible = true;
        Level1.SetTileMethod(Color.FromHexCode("267F00"), LuoRuoho);
        Level1.SetTileMethod(Color.FromHexCode("7F3300"), LuoDirt);
        Level1.SetTileMethod(Color.FromHexCode("FFFFFF"), LuoPilvi);
        Level1.SetTileMethod(Color.FromHexCode("FFD800"), LuoAurinkoa);
        Level1.SetTileMethod(Color.FromHexCode("B200FF"), LuoPotion);
        Level1.SetTileMethod(Color.Gray, LuoWarriorBlob);
        Level1.SetTileMethod(Color.FromHexCode("4CFF00"), LuoBlob);
        Level1.SetTileMethod(Color.Black, LuoOvi);
        Level1.SetTileMethod(Color.FromHexCode("7F6A00"), LuoAvain);
        Level1.SetTileMethod(Color.FromHexCode("FF5F0F"), LuoPelaaja);
        Level1.SetTileMethod(Color.FromHexCode("00FFFF"), LuoLentoBlob);
        Level1.SetTileMethod(Color.FromHexCode("00FF21"), LuoVihreaSateenkaariOsa);
        Level1.SetTileMethod(Color.FromHexCode("FF0000"), LuoPunainenSateenkaariOsa);
        Level1.SetTileMethod(Color.FromHexCode("0094FF"), LuoSininenSateenkaariOsa);

        Level1.Execute(30, 30);
        
        Camera.Zoom(0.6);//muista myös (0.45)

        Mouse.ListenMovement(0.1, Tahtaa, "Tähtää");
        Keyboard.Listen(Key.D, ButtonState.Down, PelaajaOikealle, "Pelaaja liikkuu oikealle");
        Keyboard.Listen(Key.A, ButtonState.Down, PelaajaVasemmalle, "Pelaaja liikkuu vasemmalle");
        Keyboard.Listen(Key.W, ButtonState.Pressed, PelaajaHyppaa, "Pelaaja hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Space, ButtonState.Down, AmmuAseella, "Ammu", Pelaaja);
    }
}
