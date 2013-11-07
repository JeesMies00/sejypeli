using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Invation_of_Blobs : PhysicsGame
{
    void LuoRuoho(double korkeus, double leveys)
    {
        PhysicsObject Ruoho = PhysicsObject.CreateStaticObject(30, 30);
        Ruoho.Color = Color.Green;
        Ruoho.CollisionIgnoreGroup = 1;
        Add(Ruoho);
    }
    void LuoDirt(double korkeus, double leveys)
    {
        PhysicsObject Dirt = PhysicsObject.CreateStaticObject(30, 30);
        Dirt.Color = Color.Brown;
        Dirt.CollisionIgnoreGroup = 1;
        Add(Dirt);
    }
    void LuoPilvi(double korkeus, double leveys)
    {
        PhysicsObject Pilvi = PhysicsObject.CreateStaticObject(30, 30);
        Pilvi.Color = Color.White;
        Pilvi.CollisionIgnoreGroup = 1;
        Add(Pilvi);
    }
    void LuoAurinkoa(double korkeus, double leveys)
    {
        PhysicsObject Aurinkoa = PhysicsObject.CreateStaticObject(30, 30);
        Aurinkoa.Color = Color.Yellow;
        Aurinkoa.CollisionIgnoreGroup = 1;
        Add(Aurinkoa);
    }
    void LuoPotion(double korkeus, double leveys)
    {
        PhysicsObject Potion = PhysicsObject.CreateStaticObject(30, 30);
        Potion.Image = LoadImage("HealingPotion");
        Add(Potion);
    }
    void LuoWarriorBlob(double korkeus, double leveys)
    {
        PlatformCharacter WarriorBlob = new PlatformCharacter(30.0, 30.0);
        WarriorBlob.Image = LoadImage("WarriorBlob");
        Add(WarriorBlob);
    }
    void LuoBlob(double korkeus, double leveys)
    {
        PlatformCharacter Blob = new PlatformCharacter(30.0, 30.0);
        Blob.Image = LoadImage("Blob");
        Add(Blob);
    }
    void LuoOvi(double korkeus, double leveys)
    {
        PhysicsObject Ovi = PhysicsObject.CreateStaticObject(30.0, 30.0);
        Ovi.Image = LoadImage("Ovi");
        Add(Ovi);
    }
    void LuoAvain(double korkeus, double leveys)
    {
        PhysicsObject Avain = PhysicsObject.CreateStaticObject(30.0, 30.0);
        Avain.Image = LoadImage("Avain");
        Add(Avain);
    }
    void LuoPelaaja(double korkeus, double leveys)
    {
        PlatformCharacter Pelaaja = new PlatformCharacter(30.0, 30.0);
        Pelaaja.Image = LoadImage("PlayerCarrot");
        Add(Pelaaja);
    }
    void LuoLentoBlob(double korkeus, double leveys)
    {
        PlatformCharacter LentoBlob = new PlatformCharacter(30.0, 30.0);
        LentoBlob.Image = LoadImage("LentoBlob");
        Add(LentoBlob);
    }
    void LuoVihreaSateenkaariOsa(double korkeus, double leveys)
    {
        PhysicsObject VihreaSateenkaariOsa = PhysicsObject.CreateStaticObject(30.0, 30.0);
        VihreaSateenkaariOsa.Color = Color.LightGreen;
        VihreaSateenkaariOsa.CollisionIgnoreGroup = 1;
        Add(VihreaSateenkaariOsa);
    }
    void LuoPunainenSateenkaariOsa(double korkeus, double leveys)
    {
        PhysicsObject PunainenSateenkaariOsa = PhysicsObject.CreateStaticObject(30.0, 30.0);
        PunainenSateenkaariOsa.Color = Color.LightGreen;
        PunainenSateenkaariOsa.CollisionIgnoreGroup = 1;
        Add(PunainenSateenkaariOsa);
    }
    void LuoSininenSateenkaariOsa(double korkeus, double leveys)
    {
        PhysicsObject SininenSateenkaariOsa = PhysicsObject.CreateStaticObject(30.0, 30.0);
        SininenSateenkaariOsa.Color = Color.Blue;
        SininenSateenkaariOsa.CollisionIgnoreGroup = 1;
        Add(SininenSateenkaariOsa);
    }

    public override void Begin()
    {
        ColorTileMap Level1 = ColorTileMap.FromLevelAsset("Level1");

        Level1.SetTileMethod(Color.DarkGreen, LuoRuoho);
        Level1.SetTileMethod(Color.Brown, LuoDirt);
        Level1.SetTileMethod(Color.White, LuoPilvi);
        Level1.SetTileMethod(Color.Yellow, LuoAurinkoa);
        Level1.SetTileMethod(Color.Magenta, LuoPotion);
        Level1.SetTileMethod(Color.Gray, LuoWarriorBlob);
        Level1.SetTileMethod(Color.LightGreen, LuoBlob);
        Level1.SetTileMethod(Color.Black, LuoOvi);
        Level1.SetTileMethod(Color.DarkYellow, LuoAvain);
        Level1.SetTileMethod(Color.Orange, LuoPelaaja);
        Level1.SetTileMethod(Color.LightBlue, LuoLentoBlob);
        Level1.SetTileMethod(Color.LightGreen, LuoVihreaSateenkaariOsa);
        Level1.SetTileMethod(Color.Red, LuoPunainenSateenkaariOsa);
        Level1.SetTileMethod(Color.Blue, LuoSininenSateenkaariOsa);

        Level1.Execute(30, 30);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

    }
}
