using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Invation_of_Blobs : PhysicsGame
{
    public override void Begin()
    {
        ColorTileMap Level1 = ColorTileMap.FromLevelAsset("Level1");

        Level1.SetTileMethod(Color.DarkGreen, LuoGrass);
        Level1.SetTileMethod(Color.Brown, LuoDirt);
        Level1.SetTileMethod(Color.White, LuoPilvi);
        Level1.SetTileMethod(Color.Yellow, LuoAurinkoa);
        Level1.SetTileMethod(Color.Magenta, LuoPotion);
        Level1.SetTileMethod(Color.Gray, LuoWarriorBlob);
        Level1.SetTileMethod(Color.LightGreen, LuoBlob);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

        void LuoGrass()
        {
            //Luo ruoho
        }
    }
}
