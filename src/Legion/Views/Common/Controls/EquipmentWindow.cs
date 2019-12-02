using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gui.Elements;
using Gui.Services;
using Legion.Model.Types;
using Microsoft.Xna.Framework;

namespace Legion.Views.Common.Controls
{
    public class EquipmentWindow: Window
    {
        public EquipmentWindow(IGuiServices guiServices) : base(guiServices)
        {
        }

        private Character CurrentCharacter { get; set; }

        private Army _army;

        public Army Army
        {
            get => _army;
            set
            {
                _army = value;
                CurrentCharacter = _army.Characters.First();
            }
        }

        public override void Draw()
        {
            Bounds = new Rectangle(0,
                GuiServices.GameBounds.Height / 2,
                GuiServices.GameBounds.Width,
                GuiServices.GameBounds.Height);

            GuiServices.BasicDrawer.DrawBorder(Color.AntiqueWhite, Bounds);

            var bg = GuiServices.ImagesStore.GetImage("equipment.background");
            var man = GuiServices.ImagesStore.GetImage("equipment.man");

            for (var i = 0; i < 3; i++)
            {
                GuiServices.BasicDrawer.DrawImage(bg, Bounds.X + 0, Bounds.Y + (i * 50));
            }

            var X = Bounds.X + 120;
            var Y = Bounds.Y + 5;
            var X2 = Bounds.X + 120;
            var Y2 = Bounds.Y + 100;

            GuiServices.BasicDrawer.DrawBorder(Color.Black, X, Y, 105, 55);
            GuiServices.BasicDrawer.DrawBorder(Color.Black, X2, Y2, 105, 30);

            GuiServices.BasicDrawer.DrawBorder(Color.Orange, X + 5, Bounds.Y + 70, 95, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.Black, 235, Y, 75, 100);

            var btnPrev = new BrownButton(GuiServices, "   <");
            btnPrev.Bounds = new Rectangle(235, Y2 + 15, 30, 15);
            btnPrev.Clicked += args =>
            {
                args.Handled = true;
                var curIdx = Army.Characters.IndexOf(CurrentCharacter);
                curIdx--;
                if (curIdx < 0)
                {
                    curIdx = Army.Characters.Count - 1;
                }
                CurrentCharacter = Army.Characters[curIdx];
            };
            AddElement(btnPrev);

            var btnNext = new BrownButton(GuiServices, "    >");
            btnNext.Bounds = new Rectangle(280, Y2 + 15, 30, 15);
            btnNext.Clicked += args =>
            {
                args.Handled = true;
                var curIdx = Army.Characters.IndexOf(CurrentCharacter);
                curIdx++;
                if (curIdx >= Army.Characters.Count)
                {
                    curIdx = 0;
                }
                CurrentCharacter = Army.Characters[curIdx];
            };
            AddElement(btnNext);

            //GuiServices.BasicDrawer.DrawBorder(Color.Black, 235, Y2 + 15, 30, 15);
            //GuiServices.BasicDrawer.DrawBorder(Color.Black, 280, Y2 + 15, 30, 15);

            // Items
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 5, Bounds.Y + 5, 105, 125);
            GuiServices.BasicDrawer.DrawImage(man, Bounds.X + 19, Bounds.Y + 10);

            // head
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 47, Bounds.Y + 8, 20, 20);
            if (CurrentCharacter.Equipment.Head != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.Head.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 49, Bounds.Y + 10);
            }
            
            // torse
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 47, Bounds.Y + 44, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 47, Bounds.Y + 44, 20, 20);
            if (CurrentCharacter.Equipment.Torse != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.Torse.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 49, Bounds.Y + 46);
            }

            // feets
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 47, Bounds.Y + 108, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 47, Bounds.Y + 108, 20, 20);
            if (CurrentCharacter.Equipment.Feets != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.Feets.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 49, Bounds.Y + 110);
            }

            // left hand
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 7, Bounds.Y + 58, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 7, Bounds.Y + 58, 20, 20);
            if (CurrentCharacter.Equipment.LeftHand != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.LeftHand.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 9, Bounds.Y + 60);
            }

            // right hand
            GuiServices.BasicDrawer.DrawRectangle(Color.Black, Bounds.X + 87, Bounds.Y + 58, 20, 20);
            GuiServices.BasicDrawer.DrawBorder(Color.SandyBrown, Bounds.X + 87, Bounds.Y + 58, 20, 20);
            if (CurrentCharacter.Equipment.RightHand != null)
            {
                var img = GuiServices.ImagesStore.GetImageByRealName(CurrentCharacter.Equipment.RightHand.Type.Img);
                GuiServices.BasicDrawer.DrawImage(img, Bounds.X + 89, Bounds.Y + 60);
            }



            /*
           GADGET[47,8,20,20,GLOB$,5,5,15,15,13]
           Ink 5 : Box 47,8 To 67,28
           B=ARMIA(ARM,NUMER,TGLOWA)
           If B>0 : Paste Bob 49,10,BRON(B,B_BOB)+BROBY+GOBY : End If 
   
           GADGET[47,44,20,20,"",5,5,0,16,14]
           B=ARMIA(ARM,NUMER,TKORP)
           If B>0 : Paste Bob 49,46,BRON(B,B_BOB)+BROBY+GOBY : End If 
   
           GADGET[47,108,20,20,"",5,5,0,16,15]
           B=ARMIA(ARM,NUMER,TNOGI)
           If B>0 : Paste Bob 49,110,BRON(B,B_BOB)+BROBY+GOBY : End If 
   
           GADGET[7,58,20,20,"",5,5,0,16,16]
           B=ARMIA(ARM,NUMER,TLEWA)
           If B>0 : Paste Bob 9,60,BRON(B,B_BOB)+BROBY+GOBY : End If 
   
           GADGET[87,58,20,20,"",5,5,0,16,17]
           B=ARMIA(ARM,NUMER,TPRAWA)
           If B>0 : Paste Bob 89,60,BRON(B,B_BOB)+BROBY+GOBY : End If 
             */
        }
    }
}
