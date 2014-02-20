using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class GrazyGreg : PhysicsGame
{
    PhysicsObject Greg = new PhysicsObject(100, 140);
    
    
    public override void Begin()
    {
        Gravity = new Vector(0.0, -5.0);
        Level.Background.CreateGradient(Color.GreenYellow, Color.Magenta);
        Mouse.IsCursorVisible = true;
        
        Image GreginKuva = LoadImage("Greg");
        Greg.Image = GreginKuva;
        Add(Greg);

        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, Hyppy, "Hyppää");
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

        void Hyppy()
        {

            Vector impulssi = new Vector();

            Greg.Hit(impulssi);
        }
    }

