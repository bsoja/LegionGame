using System.Collections.Generic;
using Gui.Elements;
using Gui.Input;
using Gui.Services;
using Legion.Model;
using Legion.Views.Terrain.Layers;
using Microsoft.Xna.Framework.Input;

namespace Legion.Views.Terrain
{
    public class TerrainView : View
    {
        private readonly IViewSwitcher _viewSwitcher;

        public TerrainView(IGuiServices guiServices,
            TerrainLayer terrainLayer, 
            CharactersLayer charactersLayer,
            IViewSwitcher viewSwitcher) : base(guiServices)
        {
            _viewSwitcher = viewSwitcher;
            Layers = new List<Layer> { terrainLayer, charactersLayer };
        }

        protected override IEnumerable<Layer> Layers { get; }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _viewSwitcher.OpenMap(null);
            }
        }
    }
}

/*
Procedure RYSUJ_SCENERIE[TYP,WIES]
   SCENERIA=TYP
   Screen 0
   Screen Hide 0
   'Auto View Off 
   Cls 20
   LX=20 : LY=20 : LSZER=600 : LWYS=490
   If WIES=-1
      D=1
   Else 
      D=2
   End If 
   If WIES>-1 : FUNDAMENTY[WIES] : End If 
   'las   
   If TYP=1
      _LOAD[KAT$+"dane/scen-las","dane:scen-las","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-las","dane:muzyka/mus-las","Dane",7]
      Music 1
      For I=1 To Rnd(12)+1
         X=Rnd(47) : Y=Rnd(3)
         R=Rnd(10)
         If R<5 : CO=37 : End If 
         If R=5 : CO=36 : End If 
         If R=6 : CO=36 : End If 
         If R=7 : CO=32 : End If 
         If R=8 : CO=32 : End If 
         If R=9 : C0=39 : End If 
         If R=10 : CO=0 : End If 
         GLEBA(X,Y)=CO
      Next I
      
      For Y=0 To 11
         For X=0 To 15
            Paste Bob X*50,Y*50,BIBY+1
         Next X
      Next Y
      
      WIDOCZNOSC=150
      For I=0 To 30
         X=Rnd(620)+20
         Y=(I*20)
         NR=Rnd(1)+5
         Paste Bob X,Y,BIBY+NR
      Next I
      For I=0 To 15/D
         B=Rnd(2)+2
         Gosub LOSUJ
         Paste Bob X,Y,BIBY+B
         Set Zone 60+I,X+4,Y+4 To X+28,Y+22
         '         Ink 10 : Box X+4,Y+4 To X+28,Y+22
      Next I
      If WIES=-1
         For J=0 To 3
            X2=Rnd(640)
            For I=0 To 18
               X=X2+Rnd(100)-50
               Y=(J*100)+(I*4)-60
               NR=Rnd(2)+7
               Paste Bob X,Y,NR+BIBY
            Next I
            ZX1=X2-50 : ZY1=(J*100)-60
            ZX2=ZX1+190 : ZY2=ZY1+130
            ZX3=ZX1+40 : ZX4=ZX2-45 : ZY3=ZY1+130 : ZY4=ZY1+180
            If ZX1<0 : ZX1=0 : End If 
            If ZY1<0 : ZY1=0 : End If 
            If ZX2>640 : ZX2=640 : End If 
            If ZY2>512 : ZY2=512 : End If 
            If ZX3<0 : ZX3=0 : End If 
            If ZY3<0 : ZY3=0 : End If 
            If ZX4>640 : ZX4=640 : End If 
            If ZY4>512 : ZY4=512 : End If 
            
            '         Ink 10 : Box ZX3,ZY3 To ZX4,ZY4
            '         Ink 2 : Box ZX1,ZY1 To ZX2,ZY2 
            Set Zone 90+J,ZX1,ZY1 To ZX2,ZY2
            Set Zone 94+J,ZX3,ZY3 To ZX4,ZY4
         Next J
      End If 
   End If 
   'Step
   If TYP=2
      WIDOCZNOSC=500
      _LOAD[KAT$+"dane/scen-step","dane:scen-step","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-step","dane:muzyka/mus-step","Dane",7]
      Music 1
      For I=1 To Rnd(6)+1
         X=Rnd(47) : Y=Rnd(3)
         R=Rnd(10)
         If R<5 : CO=37 : End If 
         If R=5 : CO=36 : End If 
         If R=6 : CO=36 : End If 
         If R=7 : CO=32 : End If 
         If R=8 : CO=32 : End If 
         If R=9 : C0=39 : End If 
         If R=10 : CO=0 : End If 
         GLEBA(X,Y)=CO
      Next I
      
      For Y=0 To 11
         For X=0 To 15
            Paste Bob X*50,Y*50,BIBY+1
         Next X
      Next Y
      For I=1 To 20
         B=BIBY+2+Rnd(1)
         Gosub LOSUJ
         Paste Bob X,Y,B
      Next 
      For I=1 To 3
         B=BIBY+4
         Gosub LOSUJ2
         Paste Bob X,Y,B
         Set Zone 60+I,X+4,Y To X+60,Y+36
      Next 
      '      For I=1 To 2
      '         B=BIBY+5 
      '         Gosub LOSUJ2 
      '         Bob 60+I,X,Y,B 
      '      Next  
   End If 
   'ska�y 
   If TYP=4
      WIDOCZNOSC=250
      _LOAD[KAT$+"dane/scen-skaly","dane:scen-skaly","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-gory","dane:muzyka/mus-gory","Dane",7]
      Music 1
      For I=1 To 50 : X=Rnd(47) : Y=Rnd(3) : GLEBA(X,Y)=64+Rnd(4) : Next I
      For Y=0 To 10
         For X=0 To 12
            Paste Bob X*50,Y*50,BIBY+1
         Next X
      Next Y
      For I=1 To 6
         Paste Bob Rnd(600)+20,Rnd(490)+20,BIBY+10
      Next I
      For I=1 To 50 : B=BIBY+2+Rnd(1) : Gosub LOSUJ : Paste Bob X,Y,B : Next I
      For I=1 To 5/D
         B=BIBY+7+Rnd(1)
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 30+I,X+20,Y+12 To X+90,Y+37
         '         Ink 3 : Box X+20,Y+12 To X+90,Y+37 
         PLAPKI(I,0)=1
      Next I
      For I=1 To 5/D
         B=BIBY+6
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 35+I,X+16,Y+10 To X+50,Y+25
         '         Ink 3 : Box X+16,Y+10 To X+50,Y+25 
         PLAPKI(I+5,0)=1
      Next I
      For I=1 To 20/(D*2)
         B=BIBY+4+Rnd(1)
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 60+I,X,Y To X+48,Y+36
      Next I
      For I=1 To 5/D
         B=BIBY+9
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 85+I,X+10,Y To X+86,Y+62
      Next I
   End If 
   'pustynia
   If TYP=3
      WIDOCZNOSC=500
      _LOAD[KAT$+"dane/scen-pustynia","dane:scen-pustynia","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-pustnia","dane:muzyka/mus-pustnia","Dane",7]
      For I=1 To Rnd(2)+1
         X=Rnd(47) : Y=Rnd(3)
         R=Rnd(2)
         If R=1 : CO=35 : End If 
         If R=9 : CO=39 : End If 
         GLEBA(X,Y)=CO
      Next I
      
      Music 1
      For Y=0 To 10
         For X=0 To 12
            Paste Bob X*50,Y*50,BIBY+1
         Next X
      Next Y
      For I=1 To 40
         B=BIBY+2+Rnd(3)
         Gosub LOSUJ
         Paste Bob X,Y,B
      Next I
      For I=1 To 10
         B=BIBY+6
         Gosub LOSUJ
         Paste Bob X,Y,B
      Next I
      For I=1 To 10/D
         B=BIBY+7+Rnd(1)
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 60+I,X,Y To X+48,Y+35
      Next I
      For I=1 To 5/D
         B=BIBY+9
         AG1:
         Gosub LOSUJ
         If Zone(X+60,Y+40)>0 : Goto AG1 : End If 
         Paste Bob X,Y,B
         Set Zone 70+I,X,Y To X+64,Y+45
      Next I
      
   End If 
   'lodowiec
   If TYP=5
      WIDOCZNOSC=400
      _LOAD[KAT$+"dane/scen-lodowiec","dane:scen-lodowiec","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-zima","dane:muzyka/mus-zima","Dane",7]
      Music 1
      'zimno---------------- 
      For I=1 To 10
         If ARMIA(ARM,I,TE)>0
            If ARMIA(ARM,I,TNOGI)=0 and ARMIA(ARM,I,TKORP)=0
               Add ARMIA(ARM,I,TE),-Rnd(10)-10,5 To ARMIA(ARM,I,TE)
            End If 
         End If 
      Next 
      '--------------------- 
      For Y=0 To 10
         For X=0 To 12
            Paste Bob X*50,Y*50,BIBY+1
         Next X
      Next Y
      For I=1 To 30
         B=BIBY+2
         Gosub LOSUJ
         Paste Bob X,Y,B
      Next I
      For I=1 To 15
         B=BIBY+3
         Gosub LOSUJ
         Paste Bob X,Y,B
      Next I
      For I=1 To 5/D
         B=BIBY+6
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 30+I,X+8,Y To X+60,Y+40
         PLAPKI(I,0)=3
      Next I
      For I=1 To 10/D
         B=BIBY+4
         Gosub LOSUJ2
         Paste Bob X,Y,B
         Set Zone 65+I,X,Y To X+32,Y+40
      Next I
      B=BIBY+7
      Gosub LOSUJ2
      Paste Bob X,Y,B
      Set Zone 65+I,X,Y To X+64,Y+82
      If WIES=-1
         For J=0 To 3
            X2=Rnd(640)
            For I=0 To 10
               X=X2+Rnd(80)-40
               Y=(J*100)+(I*4)-60
               B=BIBY+5
               Paste Bob X,Y,B
            Next I
            ZX1=X2-30 : ZY1=(J*100)-50
            ZX2=ZX1+100 : ZY2=ZY1+100
            If ZX1<0 : ZX1=0 : End If 
            If ZY1<0 : ZY1=0 : End If 
            If ZX2>640 : ZX2=640 : End If 
            If ZY2>512 : ZY2=512 : End If 
            'Ink 10 : Box ZX3,ZY3 To ZX4,ZY4 
            'Ink 2 : Box ZX1,ZY1 To ZX2,ZY2
            Set Zone 90+J,ZX1,ZY1 To ZX2,ZY2
         Next J
      End If 
   End If 
   'bagna 
   If TYP=7
      WIDOCZNOSC=250
      Gosub OBCINANIE
      _LOAD[KAT$+"dane/scen-bagno","dane:scen-bagno","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-bagna","dane:muzyka/mus-bagna","Dane",7]
      Music 1
      For I=1 To Rnd(10)+1
         X=Rnd(47) : Y=Rnd(3)
         R=Rnd(2)
         If R=1 : CO=34 : End If 
         If R=9 : CO=33 : End If 
         GLEBA(X,Y)=CO
      Next I
      
      For Y=0 To 11
         For X=0 To 15
            Paste Bob X*50,Y*50,BIBY+1
         Next X
      Next Y
      For I=1 To 15
         B=BIBY+2+Rnd(1)
         Gosub LOSUJ
         Paste Bob X,Y,B
      Next 
      For I=1 To 2
         B=BIBY+4
         Gosub LOSUJ2
         Paste Bob X,Y,B
         Set Zone 60+I,X+25,Y To X+54,Y+20
      Next 
      For I=1 To 3
         B=BIBY+5
         Gosub LOSUJ2
         Paste Bob X,Y,B
         Set Zone 62+I,X+15,Y To X+35,Y+30
      Next 
      For I=1 To 6
         B=BIBY+6
         Gosub LOSUJ
         Paste Bob X,Y,B
         Set Zone 65+I,X+4,Y To X+44,Y+40
      Next 
      For I=1 To 5
         Gosub LOSUJ2
         Set Zone 30+I,X,Y To X+64,Y+48
         PLAPKI(I,0)=2
         '         Ink 3 : Box X,Y To X+64,Y+48 
      Next 
   End If 
   
   'jaskinia
   If TYP=8
      WIDOCZNOSC=100
      _LOAD[KAT$+"dane/scen-jaskinia","dane:scen-jaskinia","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-jaskinia","dane:muzyka/mus-jaskinia","Dane",7]
      LX=40 : LSZER=530 : LY=75 : LWYS=470
      Music 1
      For Y=0 To 6
         For X=0 To 4
            Paste Bob X*144,Y*75,BIBY+1
         Next 
      Next 
      'rozrzucanie z�ota 
      For I=1 To Rnd(8)+2
         X=Rnd(29)+70 : Y=Rnd(3)
         BB=BIBY+12
         CO=Rnd(3)+80
         If Rnd(3)=1
            CO=Rnd(MX_WEAPON)
            BB=BIBY+11
         End If 
         GLEBA(X,Y)=CO
         XB=(X mod 10)*64+Rnd(30)
         YB=(X/10)*50+Rnd(20)
         Paste Bob XB,YB,BB
      Next I
      For I=0 To 1 : Paste Bob I*112,0,BIBY+10 : Next : Paste Bob 200,-10,BIBY+9
      Set Zone 60,0,0 To 230,70
      For I=4 To 5 : Paste Bob I*112,0,BIBY+10 : Next : Paste Bob 420,-10,Hrev(BIBY+9)
      Set Zone 61,420,0 To 640,70
      For I=0 To 15 : Paste Bob 0,(I*30)+Rnd(10),BIBY+9 : Next 
      Set Zone 62,0,0 To 40,512
      B2=Hrev(BIBY+9)
      For I=0 To 15 : Paste Bob 600,(I*30)+Rnd(10),B2 : Next 
      Set Zone 63,600,0 To 640,512
      For I=1 To 40
         Gosub LOSUJ2
         Paste Bob X,Y,BIBY+2+Rnd(3)
      Next 
      For I=1 To 10
         Gosub LOSUJ2
         Paste Bob X,Y,BIBY+8
         Set Zone 64+I,X,Y To X+32,Y+28
      Next 
      For J=1 To 4
         X2=Rnd(640)
         For I=0 To 30
            X=X2+Rnd(60)-30
            Y=(J*80)+(I*2)-60
            B=BIBY+7
            Paste Bob X,Y,B
         Next I
         ZX1=X2-15 : ZY1=(J*80)-50
         ZX2=ZX1+65 : ZY2=ZY1+80
         If ZX1<0 : ZX1=0 : End If 
         If ZY1<0 : ZY1=0 : End If 
         If ZX2>640 : ZX2=640 : End If 
         If ZY2>512 : ZY2=512 : End If 
         'Ink 10 : Box ZX3,ZY3 To ZX4,ZY4 
         '            Ink 2 : Box ZX1,ZY1 To ZX2,ZY2
         Set Zone 80+J,ZX1,ZY1 To ZX2,ZY2
      Next J
      
   End If 
   If TYP=9
      'grobowiec 
      WIDOCZNOSC=120
      _LOAD[KAT$+"dane/scen-grobowiec","dane:scen-grobowiec","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-jaskinia","dane:muzyka/mus-jaskinia","Dane",7]
      Music 1
      For Y=0 To 10
         For X=0 To 10
            Paste Bob X*60,Y*52,BIBY+1
         Next 
      Next 
      For I=1 To 50 : Gosub LOSUJ2 : Paste Bob X,Y,BIBY+2 : Next 
      For I=1 To 25 : Gosub LOSUJ2 : Paste Bob X,Y,BIBY+3 : Next 
      For I=1 To 5 : Gosub LOSUJ2 : Paste Bob X,Y,BIBY+8 : Next 
      'rozrzucanie z�ota 
      For I=1 To Rnd(8)+2
         X=Rnd(99) : Y=Rnd(3)
         BB=BIBY+12
         CO=Rnd(3)+80
         GLEBA(X,Y)=CO
         XB=(X mod 10)*64+Rnd(30)
         YB=(X/10)*50+Rnd(20)
         Paste Bob XB,YB,BB
      Next I
      If PRZYGODY(TRWA_PRZYGODA,P_TYP)=9
         RAN=55
         I=0
      Else 
         Paste Bob 6*60,0,BIBY+4 : Set Zone 61,6*60,0 To 6*60+78,80
         Paste Bob 9*60,0,BIBY+4 : Set Zone 62,9*60-18,0 To 9*60+60,80
         Paste Bob 6*60,0,BIBY+9
         Paste Bob 9*60,0,BIBY+9
         Paste Bob 7*60,0,BIBY+6
         Paste Bob 520,0,BIBY+6
         Paste Bob 7*60,40,BIBY+6
         Paste Bob 520,40,BIBY+6
         
         Paste Bob 452,30,BIBY+8
         '         Box 6*60,0 To 6*60+78,80 
         '         Box 9*60-18,0 To 9*60+60,80
         Set Zone 60,6*60,0 To 9*60+60,180
         '         Box 6*60,0 To 9*60+60,180
         I=3
         RAN=45
      End If 
      J=0
      For Y=0 To 20
         For X=0 To 10
            LOS=Rnd(RAN)
            XB=X*60 : YB=Y*25
            If I<39
               If(LOS=1 or LOS=2) and Zone(XB+4,YB+18)<>60
                  Inc I
                  Paste Bob XB,YB,BIBY+4
                  Set Zone 60+I,XB,YB To XB+60,YB+80
               End If 
               
               If LOS=0 and Zone(XB+4,YB+18)<>60
                  Inc I
                  Paste Bob XB,YB,BIBY+9
                  Set Zone 60+I,XB,YB To XB+60,YB+80
               End If 
               
               If LOS=3 and Zone(XB+4,YB+18)<>60
                  Inc I
                  Paste Bob XB,YB,BIBY+5
                  Set Zone 60+I,XB+5,YB To XB+35,YB+30
                  'Box XB+5,YB To XB+34,YB+30
               End If 
               If LOS=4 and Zone(XB+4,YB+4)=0
                  Inc I
                  Paste Bob XB,YB,BIBY+6
                  Set Zone 60+I,XB+5,YB To XB+18,YB+38
                  'Box XB+5,YB To XB+18,YB+38
               End If 
               If LOS=5 and J<9 and Zone(XB+4,YB+4)=0
                  Inc J
                  Set Zone 30+J,XB,YB+14 To XB+34,YB+38
                  PLAPKI(J,0)=5
                  PLAPKI(J,1)=XB
                  PLAPKI(J,2)=YB
                  PLAPKI(J,3)=XB+34
                  PLAPKI(J,4)=YB+38
                  'Paste Bob XB,YB,BIBY+7
                  'Box XB,YB+14 To XB+34,YB+38 
               End If 
               If LOS=7 and J<9 and Zone(XB+4,YB+4)=0
                  Inc J
                  Set Zone 30+J,XB+13,YB+8 To XB+45,YB+35
                  PLAPKI(J,0)=4
                  PLAPKI(J,1)=XB+5
                  PLAPKI(J,2)=YB+5
                  PLAPKI(J,3)=XB+48+5
                  PLAPKI(J,4)=YB+35
                  'Paste Bob XB+5,YB+5,BIBY+10 
                  'Box XB+13,YB+8 To XB+45,YB+35 
               End If 
               If LOS=6 and Zone(XB+4,YB+4)=0 and Rnd(2)=0
                  SEKTOR[XB+15,YB+10]
                  GLEBA(Param,Rnd(3))=Rnd(MX_WEAPON)
                  Paste Bob XB,YB,BIBY+11
               End If 
            End If 
         Next X
      Next Y
      Reset Zone 60
   End If 
   
   If TYP=10
      'grota w�adcy
      WIDOCZNOSC=500
      _LOAD[KAT$+"dane/scen-grota","dane:scen-grota","Dane",1] : Get Bob Palette 
      _LOAD[KAT$+"dane/muzyka/mus-grota","dane:muzyka/mus-grota","Dane",7]
      Shift Down 3,20,23,1
      Music 1
      For Y=0 To 8
         For X=0 To 9
            Paste Bob X*64,Y*64,BIBY+1
         Next 
      Next 
      For Y=2 To 8
         For X=2 To 7
            Paste Bob X*64,Y*40,BIBY+2
         Next 
      Next 
      For Y=1 To 4
         Paste Bob 128,Y*64,BIBY+3
         Paste Bob 496,Y*64,Hrev(BIBY+3)
      Next Y
      For X=2 To 7
         Paste Bob X*64,64,BIBY+4
         Paste Bob X*64,304,BIBY+5
      Next 
      For Y=0 To 12
         X=-Rnd(20)
         Paste Bob X,Rnd(10)+20+Y*40,BIBY+7
         Paste Bob X,Y*40,BIBY+6
         
         X=Rnd(20)
         Paste Bob X+560,Rnd(10)+20+Y*40,Hrev(BIBY+7)
         Paste Bob X+560,Y*40,Hrev(BIBY+6)
         
      Next Y
      
      XB=100 : YB=322
      Set Zone 31,XB,YB To XB+420,YB+100
      PLAPKI(1,0)=6
      PLAPKI(1,1)=XB
      PLAPKI(1,2)=YB
      PLAPKI(1,3)=XB+34
      PLAPKI(1,4)=115
      '      Ink 10
      '      Box XB,YB To XB+420,YB+100
      
      XB=100 : YB=0
      Set Zone 32,XB,YB To XB+420,YB+63
      PLAPKI(2,0)=6
      PLAPKI(2,1)=XB
      PLAPKI(2,2)=YB
      PLAPKI(2,3)=XB+34
      PLAPKI(2,4)=0
      '      Ink 10
      '      Box XB,YB To XB+420,YB+63 
      
      XB=0 : YB=0
      Set Zone 33,XB,YB To XB+118,YB+340
      PLAPKI(3,0)=6
      PLAPKI(3,1)=XB
      PLAPKI(3,2)=YB
      PLAPKI(3,3)=XB+34
      PLAPKI(3,4)=85
      '      Ink 10
      '      Box XB,YB To XB+118,YB+340
      
      XB=522 : YB=0
      Set Zone 34,XB,YB To XB+100,YB+340
      PLAPKI(4,0)=6
      PLAPKI(4,1)=XB
      PLAPKI(4,2)=YB
      PLAPKI(4,3)=XB+34
      PLAPKI(4,4)=85
      '      Ink 10
      '      Box XB,YB To XB+100,YB+340
      
   End If 
   
   If WIES>=0
      RYSUJ_WIES[WIES]
      'doda� domy (9)
      BSIBY=BIBY+12+9
   End If 
   If WIES<-1
      RYSUJ_MUR[WIES]
      'doda� mury (2)  
      BSIBY=BIBY+12+2
   End If 
   'wytnij strza�y
   Screen 2
   Cls 0
   For I=1 To 20
      Get Bob BSIBY+I,0,0 To 31,31
   Next I
   Screen 0
   
   Goto OVER
   '------
   LOSUJ:
   If Rnd(1)=0
      B=Hrev(B)
   End If 
   LOSUJ2:
   X=LX+Rnd(LSZER)
   If WIES<-1
      Y=Rnd(300)+200
   Else 
      Y=LY+Rnd(LSZER)
   End If 
   If Zone(X,Y)>120 : Goto LOSUJ2 : End If 
   Return 
   '------
   OBCINANIE:
   
   Screen Hide 1 : Screen Hide 2 : View 
   Screen 2
   For I=BUBY+4 To BUBY+163
      Cls 0
      Paste Bob 0,0,I
      Get Sprite I,0,0 To 32,32 : Wait Vbl 
      Hot Spot I,$12
   Next 
   Screen Show 1
   Screen 0
   Return 
   OVER:
   Screen Show 0
End Proc
Procedure FUNDAMENTY[NR]
   For I=2 To 20
      TYP=MIASTA(NR,I,M_LUDZIE)
      If TYP>0
         X=MIASTA(NR,I,M_X)
         Y=MIASTA(NR,I,M_Y)
         SZER=BUDYNKI(TYP,0)
         WYS=BUDYNKI(TYP,1)
         Set Zone 120+I,X,Y To X+SZER,Y+WYS+40
      End If 
   Next 
End Proc
Procedure RYSUJ_WIES[NR]
   WIDOCZNOSC=250
   Dim SOR(6)
   _LOAD[KAT$+"dane/scen-domy","dane:scen-domy","Dane",1]
   For I=2 To 20
      TYP=MIASTA(NR,I,M_LUDZIE)
      If TYP>0
         X=MIASTA(NR,I,M_X)
         Y=MIASTA(NR,I,M_Y)
         
         SZER=BUDYNKI(TYP,0)
         WYS=BUDYNKI(TYP,1)
         B=BUDYNKI(TYP,4)
         DR=BUDYNKI(TYP,6)
         Paste Bob X,Y,BIBY+12+B
         Set Zone 120+I,X,Y To X+SZER,Y+WYS
         If DR>0
            Set Zone 100+I,X+DR,Y+WYS-32 To X+DR+32,Y+WYS
            '            Ink 3 : Box X+DR,Y+WYS-32 To X+DR+32,Y+WYS
            
            RANGA=MIASTA(NR,I,M_CZYJE)
            If TYP=4
               SOR(0)=1 : SOR(1)=2 : SOR(2)=3 : SOR(3)=4 : SOR(4)=5 : SOR(5)=7 : SOR(6)=13
            End If 
            If TYP=5
               SOR(0)=1 : SOR(1)=3 : SOR(2)=2 : SOR(3)=2 : SOR(4)=11 : SOR(5)=7 : SOR(6)=6
            End If 
            If TYP=6
               SOR(0)=12 : SOR(1)=12 : SOR(2)=12 : SOR(3)=12 : SOR(4)=12 : SOR(5)=12 : SOR(6)=12
            End If 
            If TYP=7
               SOR(0)=4 : SOR(1)=5 : SOR(2)=8 : SOR(3)=9 : SOR(4)=10 : SOR(5)=15 : SOR(6)=16
            End If 
            If TYP=8
               SOR(0)=13 : SOR(1)=13 : SOR(2)=13 : SOR(3)=18 : SOR(4)=18 : SOR(5)=18 : SOR(6)=18
            End If 
            If TYP=9
               SOR(0)=17 : SOR(1)=17 : SOR(2)=17 : SOR(3)=17 : SOR(4)=17 : SOR(5)=17 : SOR(6)=17
            End If 
            S=0
            If TYP<9
               For Y=0 To 1
                  For X=0 To 9
                     If Rnd(3)=1
                        SKLEP(I,S)=0
                     Else 
                        AGAIN:
                        BR=Rnd(MX_WEAPON)
                        For B=0 To 6
                           If BRON(BR,B_TYP)=SOR(B) and BRON(BR,B_CENA)<1000
                              Goto JEST
                           End If 
                        Next B
                        Goto AGAIN
                        JEST:
                        SKLEP(I,S)=BR
                     End If 
                     Inc S
                  Next X
               Next Y
            End If 
         End If 
      End If 
   Next I
   
   
End Proc
Procedure RYSUJ_MUR[TYP]
   WIDOCZNOSC=400
   If TYP=-2
      _LOAD[KAT$+"dane/mur2","dane:mur2","Dane",1]
      SILA=220
   End If 
   If TYP=-3
      _LOAD[KAT$+"dane/mur1","dane:mur1","Dane",1]
      SILA=300
   End If 
   If TYP=-4
      _LOAD[KAT$+"dane/mur3","dane:mur3","Dane",1]
      SILA=400
   End If 
   
   For I=0 To 9
      Paste Bob I*64,10,BIBY+12+1
      Set Zone 21+I,I*64,140 To(I*64)+64,200
      MUR(I)=SILA
   Next I
End Proc
 */