' V = V + A
' V<BASE Then V = TOP
' V> TOP Then V = BASE

Set Buffer 150
'słoma off 
Request Wb : Hide On : Erase All : Led Off : Auto View Off 
Amos Lock : Break Off 
KAT$=Dir$
Global KAT$,LEWY,PRAWY
LEWY=1+Mouse Key : PRAWY=2+Mouse Key
If Exist(KAT$+"rtdd") : Exec KAT$+"rtdd" : End If 
Assign "fonts:" To KAT$+"fonts"
Get Fonts 
M_X=Sin(2)
Dim ARMIA(40,10,30),WOJNA(5,5),GRACZE(4,3)
Dim ARMIA$(40,10),IMIONA$(4)
Dim AN(4)
Dim VEKTOR#(20,5)
Dim PREFS(10)
Dim MIASTA(50,20,6),MIASTA$(50),MUR(10),SKLEP(20,21),STRZALY(10),ZNAKI$(30)
Dim BOARD#(125),LITERY#(100)
Global ARMIA(),ARMIA$(),VEKTOR#(),AN(),PREFS(),MIASTA(),MIASTA$(),MUR()
Global GRACZE(),WOJNA(),SKLEP(),IMIONA$(),STRZALY(),ZNAKI$(),BOARD#(),LITERY#()
'--
Global TEM,TX,TY,TSI,TSZ,TCELX,TCELY,TTRYB,TE,TKLAT,TP,TBOB,TAMO
Global TLEWA,TPRAWA,TNOGI,TGLOWA,TKORP,TPLECAK,TMAG,TDOSW,TRASA,TWAGA,TMAGMA
'--
Global M_X,M_Y,M_LUDZIE,M_PODATEK,M_CZYJE,M_MORALE,M_MUR
M_X=1 : M_Y=2 : M_LUDZIE=3 : M_PODATEK=4 : M_CZYJE=5 : M_MORALE=6 : M_MUR=0
'--
Global OX,OY,NUMER,ARM,WRG,SX,SY,MSX,MSY,FONT,FONR,FONTSZ,LOK,DZIEN,FON1,FON2
Global AMIGA,WPI$,WPI,WPI#,IMIONA,ODLEG,WIDOCZNOSC,BUBY,BIBY,PIKIETY,POTWORY
Global CENTER_V,SCENERIA,LAST_GAD,KANAL,POWER,REZULTAT,GOBY,MUZYKA,KONIEC_INTRA
CENTER_V=100
'--
Global BOMBA1#,BOMBA3,BOMBA4,BSIBY
SPEED_CHECK
Dim RASY(20,7),RASY$(20)
Dim BRON(120,11),BRON$(120),BRON2$(25)
Dim GLEBA(110,4),PLAPKI(10,4)
Dim BUDYNKI(12,6),BUDYNKI$(12),GUL$(10)
Dim ROZMOWA$(5,5),ROZMOWA2$(50),PRZYGODY$(20,10),IM_PRZYGODY$(3),PRZYGODY(3,10)
Global ROZMOWA$(),ROZMOWA2$(),PRZYGODY$(),IM_PRZYGODY$(),PRZYGODY(),GUL$(),TRWA_PRZYGODA
P_TYP=0 : P_X=1 : P_Y=2 : P_TERMIN=3 : P_KIERUNEK=4 : P_LEVEL=5 : P_CENA=6 : P_NAGRODA=7 : P_BRON=8 : P_TEREN=9 : P_STAREX=10
Global P_TYP,P_X,P_Y,P_TERMIN,P_KIERUNEK,P_LEVEL,P_CENA,P_NAGRODA,P_BRON,P_TEREN,P_STAREX
BROBY=15
Global RASY(),RASY$(),BRON(),BRON$(),BRON2$(),GLEBA(),BROBY,BUDYNKI(),BUDYNKI$(),PLAPKI()
ARM=0 : WRG=40
B_SI=1 : B_PAN=2 : B_SZ=3 : B_EN=4 : B_TYP=5 : B_WAGA=6
B_PLACE=7 : B_DOSW=8 : B_MAG=9 : B_CENA=10 : B_BOB=11
Global B_SI,B_PAN,B_SZ,B_EN,B_TYP,B_WAGA
Global B_PLACE,B_DOSW,B_MAG,B_CENA,B_BOB
Global OKX,OKY,SPX,SPY,REAL_KONIEC,KONIEC_AKCJI,WYNIK_AKCJI,KTO_ATAKUJE,TESTING,CELOWNIK
Global GAME_OVER,_MODULO,BOMBA2#,SUPERVISOR,MX_WEAPON
TEM=0 : TX=1 : TY=2 : TSI=3 : TSZ=4 : TCELX=5 : TCELY=6 : TTRYB=7 : TE=8 : TP=9
TBOB=10 : TKLAT=11 : TAMO=12 : TLEWA=16 : TPRAWA=17 : TNOGI=15 : TGLOWA=13
TPLECAK=18 : TKORP=14 : TMAG=26 : TDOSW=27 : TRASA=28 : TWAGA=29 : TMAGMA=30
AN(0)=0 : AN(1)=1 : AN(2)=0 : AN(3)=2
KTO_ATAKUJE=-1
WCZYTAJ_BRON
WCZYTAJ_RASY
WCZYTAJ_BUDYNKI
WCZYTAJ_ROZMOWE
WCZYTAJ_PRZYGODY
WCZYTAJ_GULE
FONTSZ=5
PREFS(1)=1 : PREFS(2)=1 : PREFS(4)=1
'TESTING=True
'Goto BITWA
'Goto PRZYGODA 
_INTRO
EKRAN_WYBOR
Repeat 
   If Mouse Zone=21
      Rainbow 1,3,140,23
      Rainbow 2,3,163,23
      Rainbow 3,3,187,23
      Bob 1,,190,1 : View 
      Bob Update : Wait Vbl 
      If Mouse Click=1
         Rainbow Del : View 
         Fade 1 : Wait 15
         Screen Open 0,192,200,32,Lowres : Flash Off : Curs Off : Cls 0
         Double Buffer : Bob Update On : Priority Off 
         Screen Display 0,200,,,
         Get Bob Palette : Colour 3,$462
         Set Rainbow 0,1,528,"(3,1,1)","(3,1,1)","(3,1,1)"
         Bob 1,0,60,2 : Bob 2,0,60,3 : Bob Update 
         Rainbow 0,20,110,26
         A$="S: Move -128,0,387; Move 0,0,50; Move 128,0,387; Move 0,0,50; Jump S"
         B$="S: Move -387,0,387; Move 0,0,50; Move 387,0,387; Move 0,0,50; Jump S"
         Channel 1 To Bob 1 : Channel 2 To Bob 2
         Amal 1,A$ : Amal 2,B$
         Amal On 2 : Amal On 1
         OKX=0 : OKY=0
         Set Font FON2
         Ink 28,0 : Text OKX+10,OKY+20,"Podaj swoje imię:"
         View 
         WPISZ[OKX+30,OKY+40,28,0,12]
         If WPI$<>""
            IMIONA$(1)=WPI$
         Else 
            ROB_IMIE : IMIONA$(1)=Param$
         End If 
         For I=1 To 3
            Ink 0 : Bar OKX+2,OKY+2 To 200,70
            Ink 28,0 : Text OKX+2,OKY+20,"Imię"+Str$(I)+"-go przeciwnika"
            WPISZ[OKX+30,OKY+40,28,0,12]
            If WPI$<>""
               IMIONA$(I+1)=WPI$
            Else 
               ROB_IMIE : IMIONA$(I+1)=Param$
            End If 
         Next I
         Rainbow Del : View 
         Fade 2 : _TRACK_FADE[1]
         Bob Update Off : Amal Off 
         DZIEN=1
         POWER=5 : SX=0 : SY=0
         For I=1 To 4 : GRACZE(I,1)=5000 : Next I
         GRACZE(1,3)=20 : GRACZE(2,3)=16 : GRACZE(3,3)=18 : GRACZE(4,3)=22
         PREFS(1)=1 : PREFS(2)=1 : PREFS(4)=1
         Screen Close 0
         SETUP0
         ZROB_MIASTA
         ZROB_ARMIE
         View 
         Gosub MAIN
         EKRAN_WYBOR
      End If 
   End If 
   If Mouse Zone=22
      Rainbow 2,3,140,23
      Rainbow 3,3,187,23
      Rainbow 1,3,163,23
      Bob 1,,237,1 : View 
      Bob Update : Wait Vbl 
      If Mouse Click=1
         OKX=320 : OKY=180
         Get Block 100,OKX,OKY,176,180
         Ink 0 : Bar 320,180 To 480,350
         Ink 7 : Box 320,180 To 480,350
         Ink 5 : Box 321,181 To 479,349
         Set Font FON2
         'USTAW_FONT["bodacious",42]
         Gr Writing 0
         GADGET[OKX+10,OKY+8,120,15,A$,K1,0,K2,31,-1]
         If Exist(KAT$+"archiwum")
            PAT$=KAT$+"archiwum/"
         Else 
            REQUEST["archiwum:","Archiwum"]
            PAT$="archiwum:"
         End If 
         For I=0 To 4
            If Exist(PAT$+"zapis"+Str$(I+1))
               Open In 1,PAT$+"zapis"+Str$(I+1)
               NAME$=Input$(1,20)
               NAME$=NAME$-Chr$(0)
               Close 1
            Else 
               NAME$="Pusty Slot"
            End If 
            Ink 7 : Text OKX+20,OKY+28+(I*25),NAME$
            Set Zone 1+I,0,0 To 640,OKY+28+(I*25)
         Next 
         Text OKX+20,OKY+28+(5*25),"Exit"
         Set Zone 6,0,200 To 640,500
         KONIEC2=False
         Repeat 
            STREFA=Mouse Zone
            Bob 1,,OKY+((STREFA-1)*25),1 : Bob Update : Wait Vbl 
            If Mouse Click=1
               If STREFA=6
                  KONIEC2=True
                  For I=1 To 19
                     Reset Zone I
                  Next I
                  Put Block 100 : Screen Swap : Put Block 100
               End If 
               If STREFA>0 and STREFA<6 and Exist(PAT$+"zapis"+Str$(STREFA))
                  KONIEC2=True
                  NSAVE=STREFA
                  Reserve As Work 10,60000
                  MEM=Start(10)+20
                  If Exist(KAT$+"archiwum/zapis"+Str$(NSAVE))
                     Bload KAT$+"archiwum/zapis"+Str$(NSAVE),Start(10)
                  Else 
                     REQUEST["archiwum:zapis"+Str$(NSAVE),"Archiwum"]
                     Bload "archiwum:zapis"+Str$(NSAVE),Start(10)
                  End If 
                  ODCZYT[MEM]
                  Del Block : Rainbow Del : View 
                  Fade 2 : _TRACK_FADE[1]
                  Screen Close 0
                  SX=0 : SY=0
                  SETUP0
                  VISUAL_OBJECTS
                  Gosub MAIN
                  EKRAN_WYBOR
               End If 
            End If 
         Until KONIEC2
      End If 
   End If 
   If Mouse Zone=23
      Rainbow 2,3,140,23
      Rainbow 3,3,163,23
      Rainbow 1,3,187,23
      Bob 1,,285,1 : View 
      Bob Update : Wait Vbl 
      If Mouse Click=1
         KONIEC=True
      End If 
   End If 
Until KONIEC
Rainbow Del : View 
Fade 2 : _TRACK_FADE[1]
Screen Close 0
Erase All 
Led On 
Assign "fonts:" To "Sys:fonts"
If Exist(KAT$+"rtdd") : Exec KAT$+"rtdd" : End If 
Edit 

' PGJ: obsluga klikniec w: miasto/armię/przygodę
MAIN:
GAME_OVER=False
REAL_KONIEC=False
Do 
   A$=Inkey$
   KLAW=Scancode
   If KLAW>75 and KLAW<80
      KLAWSKROL[KLAW]
   End If 
   If BOMBA1#<=0 : BOMBA1#=MIASTA(52,0,0) : End If 
   Clear Key 
   X=X Mouse : Y=Y Mouse
   Wait Vbl 
   If Mouse Key=PRAWY
      If X>SPX-16 and Y>SPY-16 and X<SPX+16 and Y<SPY+16
         While Mouse Key=PRAWY
            SPX=X Mouse
            SPY=Y Mouse
            Sprite 2,SPX,SPY,1
            Wait Vbl 
         Wend 
      Else 
         SKROL[0]
      End If 
   End If 
   
   '   If A$="p" : For I=1 To 4 : OBLICZ_POWER[I] : Pen GRACZE(I,3)+1 : Print Param : Next : End If 
   
   STREFA=Mouse Zone
   If PREFS(5)=1
      If STREFA>69 and STREFA<121
         Gr Writing 3
         X=MIASTA(STREFA-70,0,M_X)
         Y=MIASTA(STREFA-70,0,M_Y)
         Box X-8,Y-8 To X+8,Y+8 : Wait 2 : Box X-8,Y-8 To X+8,Y+8
         Box X-7,Y-7 To X+7,Y+7 : Wait 2 : Box X-7,Y-7 To X+7,Y+7
         Gr Writing 0
      End If 
      If STREFA>19 and STREFA<61
         Gr Writing 3
         X=ARMIA(STREFA-20,0,TX)
         Y=ARMIA(STREFA-20,0,TY)
         Box X-4,Y-7 To X+4,Y : Wait 2 : Box X-4,Y-7 To X+4,Y
         Gr Writing 0
      End If 
   End If 
   If Mouse Click=1
      STREFA=Mouse Zone
      If X>SPX-14 and Y>SPY-14 and X<SPX+14 and Y<SPY-1
         MAPA_AKCJA
         STREFA=0
      End If 
      If X>SPX-14 and Y>SPY+1 and X<SPX+14 and Y<SPY+15
         OPCJE
         STREFA=0
      End If 
      If STREFA>19 and STREFA<61
         ARMIA[STREFA-20]
      End If 
      If STREFA>69 and STREFA<121
         MIASTO[STREFA-70]
      End If 
      If STREFA>120 and STREFA<125
         PRZYGODA_INFO[STREFA-121]
      End If 
   End If 
   Exit If REAL_KONIEC or GAME_OVER
Loop 
Fade 2
If PREFS(3)=1
   _TRACK_FADE[1]
End If 
'   Wait 25
'End If  
'sprzątamy po sobie
CLEAR_TABLES
Erase All 
Sam Stop 
Sprite Off 
If GAME_OVER : EXTRO : End If 
Return 
'----------------------------- 


Procedure BITWA[A,B,X1,Y1,T1,X2,Y2,T2,SCENERIA,WIES]
   ARM=A : WRG=B
   PL2=ARMIA(B,0,TMAG)
   Sprite Off 2
   SETUP["","Bitwa",""]
   If ARMIA(B,0,TMAG)=5
      For I=1 To 16
         Del Bob POTWORY+1
      Next I
      _LOAD[KAT$+"dane/potwory/szkielet","dane:potwory/szkielet","Dane",1]
      _LOAD[KAT$+"dane/potwory/szkielet.snd","dane:potwory/szkielet.snd","Dane",9]
   End If 
   RYSUJ_SCENERIE[SCENERIA,WIES]
   AGRESJA=ARMIA(B,0,TKORP)
   For I=1 To 10 : ARMIA(WRG,I,TKORP)=AGRESJA : Next I
   USTAW_WOJSKO[A,X1,Y1,T1]
   USTAW_WOJSKO[B,X2,Y2,T2]
   MAIN_ACTION
   If TESTING Then Pop Proc
   SETUP0
   VISUAL_OBJECTS
   Sprite 2,SPX,SPY,1
   
End Proc
Procedure BITWA_SYMULOWANA[A,B]
   S1=ARMIA(A,0,TSI)+Rnd(100)
   S2=ARMIA(B,0,TSI)+Rnd(100)
   DS=S1-S2
   If DS>=0
      WINNER=A : LOSER=B
      S3=S2/15
   Else 
      WINNER=B : LOSER=A
      S3=S2/15
   End If 
   ZABIJ_ARMIE[LOSER]
   If LOSER<40 : B_CLEAR[LOSER] : End If 
   For I=1 To 10
      Add ARMIA(WINNER,I,TE),-S3
      If ARMIA(WINNER,I,TE)<0 : ARMIA(WINNER,I,TE)=0 : End If 
      If ARMIA(WINNER,I,TE)>0
         Inc WOJ
         Add SILA,ARMIA(WINNER,I,TSI)
         Add SILA,ARMIA(WINNER,I,TE)
         Add SPEED,ARMIA(WINNER,I,TSZ)
      End If 
   Next I
   SPEED=((SPEED/WOJ)/5)
   ARMIA(WINNER,0,TSZ)=SPEED
   ARMIA(WINNER,0,TSI)=SILA
   ARMIA(WINNER,0,TE)=WOJ
End Proc[LOSER]
Procedure MAIN_ACTION
   KONIEC_AKCJI=False
   WYNIK_AKCJI=0
   'przeładowanie łuków 
   For I=1 To 10 : STRZALY(I)=10 : Next I
   Screen 2 : Get Palette 0
   Screen 0
   Change Mouse BUBY+6 : Show On 
   Screen 1 : USTAW_FONT["defender2",8] : Screen To Front 1
   NUMER=1
   EKRAN1
   Screen 0
   MARKERS
   SELECT[ARM,NUMER]
   X1=ARMIA(ARM,NUMER,TX)
   Y1=ARMIA(ARM,NUMER,TY)
   CENTER[X1,Y1,0]
   
   'Auto View On :  
   View 
   Bob Update : Wait Vbl 
   
   Do 
      Screen 0
      HY=Y Mouse
      If Mouse Click=1
         STREFA0=Mouse Zone
         If STREFA0<11 and STREFA0>0
            NUMER=STREFA0
            SELECT[ARM,NUMER]
         End If 
         If STREFA0>10 and STREFA0<21
            Screen 1
            WYKRESY[WRG,STREFA0-10]
            While Mouse Key=LEWY : Wend 
            If NUMER>0 : WYKRESY[ARM,NUMER] : End If 
         End If 
      End If 
      
      A$=""
      A$=Inkey$
      KLAW=Scancode
      If Mouse Key=PRAWY : SKROL[0] : End If 
      If KLAW>75 and KLAW<80
         KLAWSKROL[KLAW]
      End If 
      If KLAW>=80 and KLAW<90
         SELECT[ARM,KLAW-79]
         CENTER[ARMIA(ARM,NUMER,TX),ARMIA(ARM,NUMER,TY),2]
      End If 
      If A$<>""
         HY=300
      End If 
      Exit If KONIEC_AKCJI
      While HY>275
         Screen 1
         If A$<>"" or Mouse Click=1 and NUMER>0
            GADUP[LAST_GAD]
            STREFA=Mouse Zone
            A$=Upper$(A$)
            If A$="R" : STREFA=1 : End If 
            If A$="A" : STREFA=2 : End If 
            If A$="S" : STREFA=3 : End If 
            If A$="G" : STREFA=4 : End If 
            If A$=" " : STREFA=10 : End If 
            If(Key State(69) and IMIONA$(1)="Marcin ®") or ARMIA(ARM,0,TE)=0 or KONIEC_AKCJI : Exit 2 : End If 
            If STREFA=20 or STREFA=21 : BRON_INFO[STREFA] : End If 
            If STREFA>0 and STREFA<11
               GADDOWN[STREFA]
               LAST_GAD=STREFA
               If STREFA=1
                  RUCH
               End If 
               If STREFA=2
                  _ATAK[2]
               End If 
               If STREFA=3
                  STRZAL
               End If 
               If STREFA=4
                  _ATAK[6]
               End If 
               If STREFA=10
                  AKCJA
               End If 
               If STREFA=5
                  GADGET[170,2,20,20,"bob9",2,0,19,5,0]
                  WYBOR[0]
               End If 
               If STREFA=9
                  GADGET[147,2,20,20,"bob15",2,0,19,5,0]
                  ROZKAZ
                  If KONIEC_AKCJI
                     Exit 2
                  End If 
               End If 
            End If 
         End If 
         A$=""
         A$=Inkey$
         Clear Key 
         HY=Y Mouse
      Wend 
   Loop 
   '------------------
   Screen 0 : Fade 2
   Screen 1 : 
   For J=0 To 25 : Screen Display 1,130,275+J,320,25-J : Wait Vbl : View : Next 
   Screen Close 1
   For J=0 To 110
      For I=0 To 4
         GLEBA(J,I)=0
      Next I
   Next J
   WOJ1=0 : WOJ2=0
   'update------------
   For I=1 To 10
      If ARMIA(WRG,I,TE)>0
         Inc WOJ2
         Add SILA2,ARMIA(WRG,I,TSI)
         Add SPEED2,ARMIA(WRG,I,TSZ)
      Else 
         ARMIA(WRG,I,TE)=0
      End If 
      If ARMIA(ARM,I,TE)>0
         Inc WOJ1
         Add SILA,ARMIA(ARM,I,TSI)
         Add SPEED,ARMIA(ARM,I,TSZ)
      Else 
         ARMIA(ARM,I,TE)=0
      End If 
      ARMIA(ARM,I,TTRYB)=0
      ARMIA(WRG,I,TTRYB)=0
   Next I
   If WOJ1>0 : SPEED=((SPEED/WOJ1)/5) : End If 
   If WOJ2>0 : SPEED2=((SPEED2/WOJ2)/5) : End If 
   ARMIA(ARM,0,TE)=WOJ1
   ARMIA(ARM,0,TSI)=SILA
   ARMIA(ARM,0,TSZ)=SPEED
   ARMIA(WRG,0,TE)=WOJ2
   ARMIA(WRG,0,TSI)=SILA2
   ARMIA(WRG,0,TSZ)=SPEED2
   KTO_ATAKUJE=-1
   _M_FADE[1]
   Erase All 
   Sam Stop 
   Screen Close 2
   Screen Close 0
End Proc

Procedure GADGET[X,Y,SZER,WYS,TX$,K1,K2,K3,K4,STREFA]
   DEEPX=1 : DEEPY=1
   DLUGTX=Len(TX$)
   X1=X+SZER
   Y1=Y+WYS
   If STREFA>0
      Set Zone STREFA,X,Y To X1,Y1
   End If 
   Ink K1
   Bar X,Y To X1,Y1
   Ink K3
   Bar X+DEEPX,Y+DEEPY To X1-DEEPX,Y1-DEEPY
   Ink K2
   Polyline X,Y1 To X1,Y1 To X1,Y
   If TX$<>""
      If Upper$(Left$(TX$,3))="BOB"
         BNR=Val(Mid$(TX$,4,2))
         Paste Bob X,Y,BNR
      Else 
         If CIENIE>0 and CIENIE<4
            Ink K2,K3
            Text X+FONT/2,Y+FONT+FONT/3,TX$
            Ink K4,K3
            Text(X+FONT/2)+CIENIE,(Y+FONT+FONT/3)+CIENIE,TX$
         Else 
            Ink K4,K3
            Text X+FONT/2,Y+FONT+FONT/3,TX$
         End If 
      End If 
   End If 
   If STREFA=0
      '      If mouse key=lewy 
      '         Talk Stop  
      '         Sam Play 2,10
      '       End If 
      While Mouse Key=LEWY
      Wend 
   End If 
End Proc
Procedure USTAW_FONT[FONTNAME$,WIEL]
   FONT=8
   Repeat 
      Inc I
      FON$=Left$(Font$(I),Len(FONTNAME$))
      WIEL$=Mid$(Font$(I),28,6)
      If Upper$(FON$)=Upper$(FONTNAME$) and Val(WIEL$)=WIEL
         Set Font I
         FONR=I
         FONT=Val(WIEL$)
      End If 
   Until Font$(I)=""
End Proc
Procedure _GET_XY[TRYB,X1,Y1]
   
   If TRYB=1
      Gr Writing 2
   End If 
   If TRYB=2
      Sprite 0,X Mouse,Y Mouse,49
      Hide 
      A$="S: Move XM-X,YM-Y,1 ; Jump S"
      B$="Anim 0,(49,4)(46,4)(41,4)(46,4)"
      Amal 0,B$
   Else 
      Change Mouse CELOWNIK
   End If 
   Screen 0
   Repeat 
      HY=Y Mouse
      OX=X Screen(X Mouse)
      OY=Y Screen(Y Mouse)
      If TRYB=1
         Draw X1,Y1 To OX,OY
         Wait Vbl 
         Draw X1,Y1 To OX,OY
      End If 
      If TRYB=2
         If Mouse Zone>0 and Mouse Zone<21
            Amal On 0 : Sprite 0,X Mouse,Y Mouse, : Wait Vbl 
         Else 
            Amal Freeze 
            Sprite 0,X Mouse,Y Mouse,49 : Wait Vbl 
         End If 
      End If 
      If Mouse Key=PRAWY
         If TRYB=2 : Sprite Off 0 : Amal Freeze : End If 
         SKROL[1]
         If TRYB=2 : Amal 0,B$ : Hide On : Sprite 0,X Mouse,Y Mouse,49 : End If 
      End If 
      A$=Inkey$
      KLAW=Scancode
      If KLAW>75 and KLAW<80
         KLAWSKROL[KLAW]
      End If 
   Until Mouse Click=1
   If TRYB=2
      Amal Off 0
      Show On 
   End If 
   If TRYB=1
      Gr Writing 0
   End If 
   Change Mouse BUBY+6
End Proc
Procedure WPISZ[X,Y,K1,K2,ILE]
   Ink K2,K1
   Bar X,Y-Text Base To X+(ILE*FONTSZ),Y+(FONT/3)
   Clear Key 
   If Screen=0
      NX=SX : NY=SY
   Else 
      NX=0 : NY=0
   End If 
   Repeat 
      K$=Inkey$
      If Key State(65)=0 and Len(SUMA$)<ILE and Key State(68)=0 and DLT<100
         Ink K1,K2
         Text X,Y,K$
         SUMA$=SUMA$+K$
         DZ=Text Length(K$)
         DLT=Text Length(SUMA$)
         X=X+DZ
         If Len(SUMA$)<ILE
            X Mouse=X Hard(X)-NX
            Y Mouse=Y Hard(Y)-NY
         End If 
      End If 
      If Len(SUMA$)>=0 and Key State(65)
         K$=Right$(SUMA$,1)
         DZ=Text Length(K$)
         X=X-DZ
         X Mouse=X Hard(X)-NX
         Y Mouse=Y Hard(Y)-NY
         Ink K2 : Text X,Y,K$
         DL=Len(SUMA$)-1
         SUMA$=Left$(SUMA$,DL)
         DLT=Text Length(SUMA$)
         While Key State(65)
         Wend 
         Clear Key 
      End If 
      SC=Scancode
   Until SC=68 or SC=67 or Mouse Click=2
   WPI=Val(SUMA$)
   WPI#=Val(SUMA$)
   WPI$=SUMA$
End Proc


Procedure EKRAN1
   Screen 1
   Cls 0 : Paste Bob 0,0,1
   GADGET[200,2,20,20,"bob3",2,0,19,5,1]
   GADGET[222,2,20,20,"bob4",2,0,19,5,2]
   GADGET[244,2,20,20,"bob5",2,0,19,5,3]
   GADGET[266,2,20,20,"bob6",2,0,19,5,4]
   GADGET[297,2,20,20,"bob7",2,0,19,5,10]
   GADGET[170,2,20,20,"bob2",2,0,19,5,5]
   GADGET[147,2,20,20,"bob8",2,0,19,5,9]
   GADGET[2,2,140,20,"",0,1,19,16,0]
End Proc
Procedure WYBOR[WT]
   Screen 1
   Screen Hide : View 
   Screen Display 1,130,162,320,140
   For I=0 To 3
      Paste Bob 0,I*50,GOBY+1
   Next I
   If Rnd(89)=1
      Reset Zone 
      Screen Show : View : ZAB
      For I=0 To 3 : Paste Bob 0,I*50,GOBY+1 : Next I
   End If 
   Set Rainbow 1,15,512,"","","(8,1,1)"
   Rainbow 1,1,165,160
   Colour 0,$210
   X=120
   Y=5
   X2=120
   Y2=100
   If WT=0 : MSY=MSY+113 : End If 
   XB=ARMIA(ARM,NUMER,TX) : YB=ARMIA(ARM,NUMER,TY)
   GADGET[X,Y,105,55,"",5,0,8,8,-1]
   GADGET[X2,Y2,105,30,"",5,0,8,8,-1]
   
   GADGET[X+5,70,95,20,"",0,5,19,19,-1]
   GADGET[235,Y,75,100,"",0,5,19,19,-1]
   GADGET[235,Y2+15,30,15,"   <",5,0,8,1,21]
   GADGET[280,Y2+15,30,15,"    >",5,0,8,1,22]
   '--------------strefy doświadczenia
   For I=0 To 4
      Set Zone 25+I,237,28+I*10 To 277,37+I*10
   Next I
   GADGET[5,5,105,125,"",0,5,15,15,-1]
   Paste Bob 19,10,GOBY+38
   Get Sprite GOBY+42,47,8 To 47+15,28 : Wait Vbl 
   If WT=1
      GLOB$="bob86"
   Else 
      GLOB$="bob42"
   End If 
   Set Zone 20,235,5 To 310,18
   Gosub RYSUJ
   WAGA[ARM,NUMER]
   Gosub WYPISZ
   Screen Show : View 
   Do 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA>0 and STREFA<5
            BR=ARMIA(ARM,NUMER,TPLECAK+STREFA-1)
            If BR>0
               GADGET[5+X+((STREFA-1)*25),Y+5,20,20,"",0,5,0,16,0]
               ARMIA(ARM,NUMER,TPLECAK+STREFA-1)=0
               Gosub PICK
            End If 
         End If 
         If STREFA>4 and STREFA<9
            BR=ARMIA(ARM,NUMER,TPLECAK+STREFA-1)
            If BR>0
               GADGET[5+X+((STREFA-5)*25),Y+30,20,20,"",0,5,0,16,0]
               ARMIA(ARM,NUMER,TPLECAK+STREFA-1)=0
               Gosub PICK
            End If 
         End If 
         If STREFA>8 and STREFA<13
            BR=GLEBA(SEK,STREFA-9)
            If BR>0
               GADGET[5+X2+((STREFA-9)*25),Y2+5,20,20,"",0,5,0,16,0]
               GLEBA(SEK,STREFA-9)=0
               Gosub PICK
            End If 
         End If 
         If STREFA=13
            BR=ARMIA(ARM,NUMER,TGLOWA)
            If BR>0
               GADGET[47,8,20,20,GLOB$,5,5,15,15,0]
               Ink 5 : Box 47,8 To 67,28
               PRZELICZ[STREFA-13,-1]
               Gosub WYPISZ
               ARMIA(ARM,NUMER,TGLOWA+STREFA-13)=0
               Gosub PICK
            End If 
         End If 
         If STREFA=14
            BR=ARMIA(ARM,NUMER,TGLOWA+STREFA-13)
            If BR>0
               GADGET[47,44,20,20,"",5,5,0,16,0]
               PRZELICZ[STREFA-13,-1]
               Gosub WYPISZ
               ARMIA(ARM,NUMER,TGLOWA+STREFA-13)=0
               Gosub PICK
            End If 
         End If 
         If STREFA=15
            BR=ARMIA(ARM,NUMER,TGLOWA+STREFA-13)
            If BR>0
               GADGET[47,8+((STREFA-13)*50),20,20,"",5,5,0,16,0]
               PRZELICZ[STREFA-13,-1]
               Gosub WYPISZ
               ARMIA(ARM,NUMER,TGLOWA+STREFA-13)=0
               Gosub PICK
            End If 
         End If 
         
         If STREFA=16
            BR=ARMIA(ARM,NUMER,TLEWA)
            If BR>0
               GADGET[7,58,20,20,"",5,5,0,16,16]
               PRZELICZ[3,-1]
               Gosub WYPISZ
               ARMIA(ARM,NUMER,TLEWA)=0
               Gosub PICK
            End If 
         End If 
         If STREFA=17
            BR=ARMIA(ARM,NUMER,TPRAWA)
            If BR>0
               GADGET[87,58,20,20,"",5,5,0,16,17]
               PRZELICZ[4,-1]
               Gosub WYPISZ
               ARMIA(ARM,NUMER,TPRAWA)=0
               Gosub PICK
            End If 
         End If 
         If STREFA=20
            WPISZ[237,15,3,19,11]
            ARMIA$(ARM,NUMER)=WPI$
         End If 
         If STREFA=25 and ARMIA(ARM,NUMER,TDOSW)>=1 and ARMIA(ARM,NUMER,TEM)<((20+RASY(RASA,0))*3)+20
            Inc ARMIA(ARM,NUMER,TEM)
            Dec ARMIA(ARM,NUMER,TDOSW)
            Ink 19 : Bar 295,88 To 306,95 : Ink 16,19
            Text 270,35,Str$(ARMIA(ARM,NUMER,TE))+"/"+Str$(ARMIA(ARM,NUMER,TEM))-" "+" "
            Text 295,95,Str$(ARMIA(ARM,NUMER,TDOSW))
         End If 
         If STREFA=26 and ARMIA(ARM,NUMER,TDOSW)>=3 and ARMIA(ARM,NUMER,TSI)<(RASY(RASA,1)/2)+40
            Inc ARMIA(ARM,NUMER,TSI)
            Add ARMIA(ARM,NUMER,TDOSW),-3
            Ink 19 : Bar 295,88 To 306,95 : Ink 16,19
            Text 290,45,Str$(ARMIA(ARM,NUMER,TSI))+" "
            Text 295,95,Str$(ARMIA(ARM,NUMER,TDOSW))
         End If 
         If STREFA=27 and ARMIA(ARM,NUMER,TDOSW)>=4 and ARMIA(ARM,NUMER,TSZ)<RASY(RASA,2)+30
            Inc ARMIA(ARM,NUMER,TSZ)
            Add ARMIA(ARM,NUMER,TDOSW),-3
            Ink 19 : Bar 295,88 To 306,95 : Ink 16,19
            Text 290,55,Str$(ARMIA(ARM,NUMER,TSZ))+" "
            Text 295,95,Str$(ARMIA(ARM,NUMER,TDOSW))
         End If 
         If STREFA=28 and ARMIA(ARM,NUMER,TDOSW)>=3
            Inc ARMIA(ARM,NUMER,TP)
            Add ARMIA(ARM,NUMER,TDOSW),-3
            Ink 19 : Bar 295,88 To 306,95 : Ink 16,19
            Text 290,65,Str$(ARMIA(ARM,NUMER,TP))+" "
            Text 295,95,Str$(ARMIA(ARM,NUMER,TDOSW))
         End If 
         If STREFA=29 and ARMIA(ARM,NUMER,TDOSW)>=2 and ARMIA(ARM,NUMER,TMAGMA)<RASY(RASA,3)+30
            Inc ARMIA(ARM,NUMER,TMAGMA)
            Add ARMIA(ARM,NUMER,TDOSW),-2
            Ink 19 : Bar 295,88 To 306,95 : Ink 16,19
            Text 270,75,Str$(ARMIA(ARM,NUMER,TMAG))+"/"+Str$(ARMIA(ARM,NUMER,TMAGMA))-" "+" "
            Text 295,95,Str$(ARMIA(ARM,NUMER,TDOSW))
         End If 
         
      End If 
      If Mouse Key=LEWY
         STREFA=Mouse Zone
         If STREFA=21
            GADGET[235,Y2+15,30,15,"   <",0,5,11,2,0]
            GADGET[235,Y2+15,30,15,"   <",5,0,8,1,-1]
            AG1:
            Add NUMER,-1,1 To 10
            If ARMIA(ARM,NUMER,TE)<=0 : Goto AG1 : End If 
            If WT=0
               Screen 0
               XB=ARMIA(ARM,NUMER,TX) : YB=ARMIA(ARM,NUMER,TY)
               CENTER[XB,YB,2]
               Bob 50,XB,YB,1+BUBY : Bob Update 
               Screen 1
            End If 
            RASA=ARMIA(ARM,NUMER,TRASA)
            WAGA[ARM,NUMER] : Wait Vbl : Gosub RYSUJ : Gosub WYPISZ
         End If 
         If STREFA=22
            GADGET[280,Y2+15,30,15,"    >",0,5,11,2,0]
            GADGET[280,Y2+15,30,15,"    >",5,0,8,1,-1]
            AG2:
            Add NUMER,1,1 To 10
            If ARMIA(ARM,NUMER,TE)<=0 : Goto AG2 : End If 
            If WT=0
               Screen 0
               XB=ARMIA(ARM,NUMER,TX) : YB=ARMIA(ARM,NUMER,TY)
               CENTER[XB,YB,2]
               Bob 50,XB,YB,1+BUBY : Bob Update 
               Screen 1
            End If 
            RASA=ARMIA(ARM,NUMER,TRASA)
            WAGA[ARM,NUMER] : Wait Vbl : Gosub RYSUJ : Gosub WYPISZ
         End If 
      End If 
      Exit If Mouse Key=PRAWY
      
   Loop 
   Goto OVER
   '----------- 
   PICK:
   Gosub PICK_2
   Repeat 
      XM=X Screen(X Mouse)
      YM=Y Screen(Y Mouse)
      
      Sprite 53,X Mouse,Y Mouse,BB+GOBY : Wait Vbl 
      If Mouse Click=1
         I=Zone(XM,YM)
         If I<>0
            Sprite Off 53 : Wait Vbl 
            Hot Spot BB,$0
         End If 
         If I>0 and I<5
            BR1=ARMIA(ARM,NUMER,TPLECAK+I-1)
            TYP=BRON(BR,B_TYP)
            If TYP=17
               ARMIA(ARM,NUMER,TPLECAK+I-1)=0
               Add ARMIA(ARM,0,TAMO),BRON(BR,B_DOSW),ARMIA(ARM,0,TAMO) To 320
            Else 
               Paste Bob X+7+((I-1)*25),Y+7,BB+GOBY
               ARMIA(ARM,NUMER,TPLECAK+I-1)=BR
            End If 
         If BR1=0 : KONIEC=True : Else : BR=BR1 : Gosub PICK_2 : End If 
            
         End If 
         If I>4 and I<9
            BR1=ARMIA(ARM,NUMER,TPLECAK+I-1)
            TYP=BRON(BR,B_TYP)
            If TYP=17
               ARMIA(ARM,NUMER,TPLECAK+I-1)=0
               Add ARMIA(ARM,0,TAMO),BRON(BR,B_DOSW),ARMIA(ARM,0,TAMO) To 320
            Else 
               Paste Bob X+7+((I-5)*25),Y+32,BB+GOBY
               ARMIA(ARM,NUMER,TPLECAK+I-1)=BR
            End If 
         If BR1=0 : KONIEC=True : Else : BR=BR1 : Gosub PICK_2 : End If 
         End If 
         If I>8 and I<13
            BR1=GLEBA(SEK,I-9)
            Paste Bob X2+7+((I-9)*25),Y2+7,BB+GOBY : Wait Vbl 
            GLEBA(SEK,I-9)=BR
         If BR1=0 : KONIEC=True : Else : BR=BR1 : Gosub PICK_2 : End If 
         End If 
         If I=13 or I=15
            BR1=ARMIA(ARM,NUMER,TGLOWA+(I-13))
            PLACE=BRON(BR,B_PLACE)
            TYP=BRON(BR,B_TYP)
            If PLACE=I-12 and BR1=0
               ARMIA(ARM,NUMER,TGLOWA+(I-13))=BR
               PRZELICZ[I-13,1]
               If TYP=13 or TYP=18
                  ARMIA(ARM,NUMER,TGLOWA+(I-13))=0
               Else 
                  Make Mask BB+GOBY
                  Paste Bob 49,10+((I-13)*50),BB+GOBY
               End If 
               KONIEC=True
            End If 
         End If 
         If I=14
            BR1=ARMIA(ARM,NUMER,TGLOWA+(I-13))
            PLACE=BRON(BR,B_PLACE)
            TYP=BRON(BR,B_TYP)
            If PLACE=I-12 and BR1=0
               ARMIA(ARM,NUMER,TGLOWA+(I-13))=BR
               PRZELICZ[I-13,1]
               If TYP=13
                  ARMIA(ARM,NUMER,TGLOWA+(I-13))=0
               Else 
                  Paste Bob 49,46,BB+GOBY
               End If 
               KONIEC=True
            End If 
         End If 
         
         If I=16
            BR1=ARMIA(ARM,NUMER,TLEWA)
            BR2=ARMIA(ARM,NUMER,TPRAWA)
            PLACE=BRON(BR,B_PLACE)
            If BR1=0
               If PLACE=4 or(PLACE=6 and BR2=0)
                  Paste Bob 9,60,BB+GOBY
                  ARMIA(ARM,NUMER,TLEWA)=BR
                  PRZELICZ[3,1]
                  KONIEC=True
               End If 
            End If 
         End If 
         
         If I=17
            BR1=ARMIA(ARM,NUMER,TPRAWA)
            BR2=ARMIA(ARM,NUMER,TLEWA)
            PLACE=BRON(BR,B_PLACE)
            If BR1=0
               If PLACE=4 or(PLACE=6 and BR2=0)
                  Paste Bob 89,60,BB+GOBY
                  ARMIA(ARM,NUMER,TPRAWA)=BR
                  KONIEC=True
                  PRZELICZ[4,1]
               End If 
            End If 
         End If 
         
      End If 
   Until KONIEC
   WAGA[ARM,NUMER]
   Gosub WYPISZ
   KONIEC=False
   Show On 
   Return 
   '----------
   PICK_2:
   Hide On 
   BB=BRON(BR,B_BOB)+BROBY
   Hot Spot BB,$11
   TYP=BRON(BR,B_TYP)
   No Mask BB+GOBY
   Ink 19 : Bar X+6,71 To X+98,88
   Ink 3,19 : Text 130,78,BRON2$(TYP) : Text 192,78,"W:"+Str$(BRON(BR,B_WAGA))
   Text 130,87,BRON$(BR)
   Return 
   
   '----------------- 
   RYSUJ:
   If WT=0
      SEKTOR[ARMIA(ARM,NUMER,TX),ARMIA(ARM,NUMER,TY)] : SEK=Param
   Else 
      SEK=0
   End If 
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
   
   For I=0 To 3
      GADGET[5+X+(I*25),Y+5,20,20,"",0,5,0,16,1+I]
      GADGET[5+X+(I*25),Y+30,20,20,"",0,5,0,16,5+I]
      GADGET[5+X2+(I*25),Y2+5,20,20,"",0,5,0,16,9+I]
      
      B1=ARMIA(ARM,NUMER,TPLECAK+I)
      '      Print B1,BRON(B1,B_BOB) 
      If B1>0
         BB1=BRON(B1,B_BOB)+BROBY
         Paste Bob X+7+(I*25),Y+7,BB1+GOBY
      End If 
      B2=ARMIA(ARM,NUMER,TPLECAK+I+4)
      If B2>0
         BB2=BRON(B2,B_BOB)+BROBY
         Paste Bob X+7+(I*25),Y+32,BB2+GOBY
      End If 
      B3=GLEBA(SEK,I)
      If B3>0
         BB3=BRON(B3,B_BOB)+BROBY
         Paste Bob X2+7+(I*25),Y2+7,BB3+GOBY
      End If 
   Next I
   Return 
   
   WYPISZ:
   'Wait Vbl  
   Gr Writing 1
   Ink 19,19 : Bar 236,Y+1 To 236+73,Y+98
   EN$=Str$(ARMIA(ARM,NUMER,TE))+"/"+Str$(ARMIA(ARM,NUMER,TEM))-" "
   MAG$=Str$(ARMIA(ARM,NUMER,TMAG))+"/"+Str$(ARMIA(ARM,NUMER,TMAGMA))-" "
   Ink 3,19
   Text 237,15,ARMIA$(ARM,NUMER)
   Text 237,25,RASY$(ARMIA(ARM,NUMER,TRASA))
   Text 237,35,"Energia:"
   Text 237,45,"Siła:"
   Text 237,55,"Szybkośc:"
   Text 237,65,"Odporność:"
   Text 237,75,"Magia:"
   Text 237,95,"Doświadczenie:"
   If ARMIA(ARM,NUMER,TWAGA)>ARMIA(ARM,NUMER,TEM)
      Ink 20,19
   End If 
   Text 237,85,"Obciążenie:"
   
   Ink 16,19
   Text 270,35,EN$
   Text 290,45,Str$(ARMIA(ARM,NUMER,TSI))
   Text 290,55,Str$(ARMIA(ARM,NUMER,TSZ))
   Text 290,65,Str$(ARMIA(ARM,NUMER,TP))
   Text 270,75,MAG$
   Text 290,85,Str$(ARMIA(ARM,NUMER,TWAGA))
   Text 295,95,Str$(ARMIA(ARM,NUMER,TDOSW))
   Return 
   '----------------- 
   OVER:
   Rainbow Del 1
   If WT=0
      MSY=278
      Screen 0 : CENTER[XB,YB,0] : Screen 1
      Screen Display 1,130,275,320,25 : View 
      Colour 0,$0
      EKRAN1
      SELECT[ARM,NUMER]
   End If 
End Proc
Procedure ROZKAZ
   KONIEC=False
   Screen 1
   Paste Bob 0,0,1
   Reset Zone 
   GADGET[8,4,70,15,"Obrona",26,24,25,30,1]
   GADGET[82,4,70,15,"Atak",26,24,25,30,2]
   GADGET[156,4,70,15,"Odwrót",26,24,25,30,3]
   GADGET[230,4,70,15,"Koniec Akcji",26,24,25,30,4]
   While Mouse Key=LEWY : Wend 
   Repeat 
      HY=Y Mouse
      If HY>275
         A$=Inkey$
         KLAW=Scancode
         If KLAW>75 and KLAW<80
            KLAWSKROL[KLAW]
         End If 
         MYSZ=Mouse Key
         If MYSZ=LEWY
            STREFA=Mouse Zone
            If STREFA=1
               GADGET[8,4,70,15,"Obrona",23,26,24,30,0]
               GADGET[8,4,70,15,"Obrona",26,24,25,30,0]
               KONIEC=True
               For I=1 To 10
                  ARMIA(ARM,I,TTRYB)=0
               Next 
            End If 
            If STREFA=2
               KONIEC=True
               GADGET[82,4,70,15,"Atak",23,26,24,30,0]
               GADGET[82,4,70,15,"Atak",26,24,25,30,0]
               For I=1 To 10
                  If ARMIA(ARM,I,TE)>0
                     X1=ARMIA(ARM,I,TX)
                     Y1=ARMIA(ARM,I,TY)
                     STARAODL=WIDOCZNOSC
                     WIDAC=False
                     For J=1 To 10
                        If ARMIA(WRG,J,TE)>0
                           X2=ARMIA(WRG,J,TX)
                           Y2=ARMIA(WRG,J,TY)
                           ODL[X1,Y1,X2,Y2]
                           
                           If ODLEG<STARAODL
                              TARGET=J
                              CX=X2 : CY=Y2
                              STARAODL=ODLEG
                              WIDAC=True
                           End If 
                        End If 
                     Next J
                     If WIDAC
                        ARMIA(ARM,I,TTRYB)=2
                        ARMIA(ARM,I,TCELX)=TARGET
                        ARMIA(ARM,I,TCELY)=WRG
                     End If 
                  End If 
               Next 
            End If 
            
            If STREFA=4
               KONIEC=True
               KONIEC_AKCJI=True
               WYNIK_AKCJI=0
               For I=1 To 10
                  If ARMIA(ARM,I,TE)>0
                     X=ARMIA(ARM,I,TX)
                     Y=ARMIA(ARM,I,TY)
                     If X>22 and X<610 and Y>30 and Y<500
                        KONIEC=False
                        KONIEC_AKCJI=False
                     End If 
                  End If 
               Next I
               If KONIEC=False
                  WYNIK_AKCJI=1
                  KONIEC=True : KONIEC_AKCJI=True
                  For I=1 To 10
                     If ARMIA(WRG,I,TE)>0 and ARMIA(WRG,I,TKORP)>90
                        KONIEC=False
                        KONIEC_AKCJI=False : WYNIK_AKCJI=0
                     End If 
                  Next 
               End If 
               If KONIEC_AKCJI
                  GADGET[230,4,70,15,"Koniec Akcji",23,26,24,30,0]
                  GADGET[230,4,70,15,"Koniec Akcji",26,24,25,30,0]
               End If 
            End If 
            If STREFA=3
               GADGET[156,4,70,15,"Odwrót",23,26,24,30,0]
               GADGET[156,4,70,15,"Odwrót",26,24,25,30,0]
               
               For I=1 To 10
                  If ARMIA(ARM,I,TE)>0
                     X=ARMIA(ARM,I,TX)
                     Y=ARMIA(ARM,I,TY)
                     ODL=400
                     If X<ODL : ODL=X : CY=Y : CX=17 : End If 
                     If Y<ODL : ODL=Y : CY=22 : CX=X : End If 
                     If 640-X<ODL : ODL=640-X : CY=Y : CX=623 : End If 
                     If 512-Y<ODL : ODL=512-Y : CY=512 : CX=X : End If 
                     ARMIA(ARM,I,TTRYB)=1
                     ARMIA(ARM,I,TCELX)=CX
                     ARMIA(ARM,I,TCELY)=CY
                  End If 
               Next I
               KONIEC=True
            End If 
         End If 
         If MYSZ=PRAWY
            KONIEC=True
         End If 
      Else 
         HY=Y Mouse
         A$=Inkey$
         KLAW=Scancode
         If KLAW>75 and KLAW<80
            KLAWSKROL[KLAW]
         End If 
         If Mouse Key=PRAWY : SKROL[0] : End If 
      End If 
   Until KONIEC
   Reset Zone 
   EKRAN1
   SELECT[ARM,NUMER]
End Proc

Procedure SELECT[A,NR]
   Screen 1
   TRYB=ARMIA(A,NR,TTRYB)
   NUMER=NR
   If ARMIA(A,NR,TE)<=0
      JEST=False
      For I=1 To 10
         If ARMIA(ARM,I,TE)>0 : NUMER=I : NR=I : I=10 : JEST=True : End If 
      Next 
   Else 
      JEST=True
   End If 
   If Not JEST : KONIEC_AKCJI=True : Goto OVER : End If 
   GADE=TRYB
   If TRYB=4 or TRYB=5
      GADE=3
   End If 
   If TRYB=6
      GADE=4
   End If 
   'CHECK[LAST_GAD] 
   GADUP[LAST_GAD]
   GADDOWN[GADE]
   LAST_GAD=GADE
   X=ARMIA(A,NR,TX)
   Y=ARMIA(A,NR,TY)
   If TRYB=1 or TRYB=3 or TRYB=4
      X2=ARMIA(ARM,NUMER,TCELX)
      Y2=ARMIA(ARM,NUMER,TCELY)
   End If 
   If TRYB=2 or TRYB=5 or TRYB=6
      TARGET=ARMIA(ARM,NUMER,TCELX)
      B=ARMIA(ARM,NUMER,TCELY)
      X2=ARMIA(B,TARGET,TX)
      Y2=ARMIA(B,TARGET,TY)
   End If 
   If TRYB=3 or TRYB=4
      Y22=12
   Else 
      Y22=0
   End If 
   Screen 0
   Bob 50,X,Y,1+BUBY
   If TRYB<>0
      Bob 51,X2,Y2+Y22,2+BUBY
   Else 
      Bob Off 51 : Bob Update : Wait Vbl 
   End If 
   Bob Update : Wait Vbl 
   Screen 1 : WYKRESY[A,NR]
   OVER:
End Proc

Procedure WCZYTAJ_BRON
   For I=1 To 19
      Read A$
      BRON2$(I)=A$
   Next I
   MX_WEAPON=120
   For I=1 To MX_WEAPON
      Read A$
      'Print I,A$ : Wait Key 
      BRON$(I)=A$
      For J=1 To 11
         Read A
         BRON(I,J)=A
      Next J
   Next I
   _MODULO=50+Rnd(130)
   DANE1:
   Data "topór","miecz","tarcza","łuk","strzały"
   Data "zbroja","hełm","buty","oszczep","maczuga"
   Data "młot","czar","zioła","kosztowności","katapulta"
   Data "głaz","żywność","mixtura","skóra"
   DANE2:
   'nazwa            s p s e t w g d mag,cena,bob     
   Data "lekki     ",5,1,0,0,2,2,4,1,0,100,28
   Data "stalowy   ",7,2,0,0,2,6,4,2,0,150,2
   Data "srebrny   ",12,3,0,0,2,5,4,5,0,500,2
   Data "długi     ",10,5,0,0,2,9,4,3,0,200,2
   Data "ognisty   ",15,5,0,0,2,4,4,9,9,800,20
   Data "Smoczy Ząb",25,8,0,0,2,5,4,9,2,3000,20
   Data "Szczerbiec",50,15,0,0,2,5,4,9,5,10000,20
   '-topory          s p s e t w g d mag cena 
   Data "zwykły    ",6,2,0,0,1,7,4,0,0,120,3
   Data "szturmowy ",9,3,0,0,1,15,4,0,0,190,3
   Data "chromowany",12,5,0,0,1,15,4,8,0,350,3
   '10
   Data "złoty     ",25,10,0,0,1,12,4,9,0,1100,3
   '-młoty            s p s e t  w  g d mag cena  
   Data "kamienny  ",7,2,0,0,11,16,4,0,0,150,4
   Data "ciężki    ",10,3,0,0,11,30,4,1,0,300,4
   Data "diamentowy",25,5,0,0,11,25,4,2,0,1050,4
   Data "goblinów  ",30,5,0,0,11,20,4,5,0,1500,4
   '-tarcze          s p s e t w g d mag cena 
   Data "drewniana ",0,8,0,0,3,3,4,0,0,50,1
   Data "stalowa   ",0,15,0,0,3,8,4,0,0,150,15
   Data "szturmowa ",0,19,0,0,3,15,4,0,0,300,15
   Data "gremlinów ",0,25,0,0,3,10,4,0,0,900,1
   '-łuki            s p s e t w g d mag cena 
   Data "zwykły    ",10,0,0,0,4,1,4,0,0,80,5
   '20
   Data "wyborowy  ",15,0,0,0,4,2,4,0,0,190,5
   Data "elfów     ",20,0,0,0,4,1,4,0,0,400,5
   '-hełmy
   Data "szpiczasty",0,5,0,0,7,1,1,0,0,100,8
   Data "rogaty    ",2,5,0,0,7,2,1,0,0,170,8
   'buty             s p s e t w g d mag cena 
   Data "skórzane  ",0,0,5,0,8,1,3,0,0,100,9
   Data "podkute   ",0,2,12,0,8,1,3,0,0,100,9
   'zbroje            s p s e t w g d mag cena    
   Data "lekka     ",0,10,0,0,6,10,2,0,0,200,7
   Data "kolczuga  ",0,18,0,0,6,12,2,0,0,400,7
   Data "stalowa   ",0,13,0,0,6,20,2,0,0,300,7
   Data "ciężka    ",0,22,0,0,6,30,2,0,0,400,18
   '30
   Data "srebrna   ",0,28,0,0,6,15,2,0,0,900,18
   'zioła              s p s e t  w g d mag cena    
   Data "sterydius   ",0,2,0,2,13,0,1,0,0,300,12
   Data "furialis    ",2,0,5,2,13,0,1,0,0,500,12
   Data "kreci korzeń",-5,0,0,-40,13,0,1,0,0,5000,12
   Data "rycyna      ",0,0,8,-5,13,0,1,0,0,400,12
   Data "szpinak     ",3,0,0,0,13,0,1,0,0,300,12
   Data "liść bobkowy",0,0,0,30,13,0,1,0,0,200,12
   Data "trawa       ",0,0,0,0,13,0,1,0,30,400,12
   'strzały          s p s e t w g d mag cena   
   Data "zwykłe    ",15,0,0,0,5,0,4,0,0,50,6
   Data "zatrute   ",20,0,0,0,5,0,4,10,0,100,6
   '40
   Data "magiczne  ",25,0,0,0,5,0,4,0,20,200,6
   'czary               s p s e  t w g d mag cena   
   Data "Pocisk (5)  ",25,0,0,0,12,0,4,1,5,200,14
   Data "Piguła (8)  ",45,0,0,0,12,0,4,1,8,350,14
   Data "Oddech Chaosu (12)",20,0,0,0,12,0,4,1,12,600,14
   Data "Płomienie (15)",35,0,0,0,12,0,4,2,15,700,14
   Data "Błyskawica (20)",55,0,0,0,12,0,4,2,20,900,14
   Data "Intuicja (3) ",0,0,0,0,12,0,4,3,3,120,13
   Data "Leczenie (5) ",0,0,0,10,12,0,4,2,5,200,13
   Data "Uzdrowienie (20)",0,0,0,100,12,0,4,2,20,900,13
   Data "światłość (40)",10,0,0,0,12,0,4,5,40,500,13
   '50
   Data "wszechwiedza (15)",0,0,0,0,12,0,4,6,15,450,13
   Data "Gniew Boży (50)",70,0,0,0,12,0,4,7,50,2500,14
   Data "spowolnienie (10)",0,0,-20,0,12,0,4,2,10,350,14
   'buty           s p s e t w g d mag cena   
   Data "lekkie  ",0,0,8,0,8,1,3,0,0,50,9
   Data "bojowe  ",2,4,7,0,8,3,3,0,0,150,9
   'maczuga             s p s e  t w g d mag cena   
   Data "piszczel ogra",7,2,0,0,10,4,4,0,0,50,11
   Data "drewniana    ",4,1,0,0,10,1,4,0,0,20,11
   Data "kolczasta    ",9,2,0,0,10,4,4,0,0,80,11
   Data "zbójecka     ",11,3,0,0,10,3,4,0,0,100,11
   'katapulty            s p sz e t   w  g d mag cena bb      
   Data "oblężnicza   ",60,20,0,0,15,150,4,0,0,500,32
   '60
   Data "burząca      ",40,10,0,0,15,120,4,0,0,450,32
   Data "lekka        ",30,6,0,0,15,50,4,0,0,600,32
   Data "ogrów        ",90,15,0,0,15,60,4,0,0,1150,32
   'głazy               s p sz e t   w g d mag cena bb      
   Data "mały         ",10,0,0,0,16,10,4,0,0,2,33
   Data "duży         ",20,0,0,0,16,20,4,0,0,4,33
   Data "średni       ",15,0,0,0,16,18,4,0,0,4,33
   Data "granitowy    ",40,0,0,0,16,20,4,0,0,20,33
   Data "marmurowy    ",30,0,0,0,16,19,4,0,0,15,33
   'hełmy            s p s e t w g d mag cena bb    
   Data "Klingoński",2,6,0,0,7,2,1,0,0,600,19
   Data "Magiczny  ",2,6,3,0,7,-40,1,0,0,870,8
   '70    
   'mixtury             s p s e  t  w g d mag cena bb     
   Data "ple ple      ",0,0,0,20,18,1,1,0,0,150,16
   Data "trucizna     ",-10,-10,0,-90,18,1,1,0,0,500,16
   Data "owcze móżdżki",5,2,0,-5,18,1,1,0,0,300,16
   Data "miód         ",4,0,0,30,18,1,1,0,0,490,16
   Data "halucinum    ",0,0,0,0,18,1,1,0,50,450,16
   Data "uzdrawiająca ",0,0,0,70,18,1,1,0,0,350,16
   'żywność              s p s e  t w g d mag cena bb     
   Data "mięso z dzika ",0,0,0,0,17,2,4,35,0,20,22
   Data "mięso gargoyli",0,0,0,0,17,2,4,85,0,50,22
   Data "mięso wilka   ",0,0,0,0,17,2,4,20,0,40,22
   'kosztowności     s p s e  t w g d mag cena bb     
   Data "złoto     ",0,0,0,0,14,0,4,0,0,2000,21
   '80
   Data "kamienie  ",0,0,0,0,14,0,4,0,0,1500,21
   Data "monety    ",0,0,0,0,14,0,4,0,0,3000,21
   Data "diamenty  ",0,0,0,0,14,0,4,0,0,5000,21
   'skóry            s p s e  t w g d mag cena bb   
   Data "z dzika   ",0,5,0,0,19,0,2,0,0,200,24
   Data "gargoyli  ",0,9,0,0,19,0,2,0,0,1450,24
   Data "wilcza    ",0,8,0,0,19,0,2,0,0,350,24
   
   Data "cudowne ",1,3,20,0,8,2,3,0,0,500,9
   'ubranie          s p s e t w g d mag cena bb      
   'czary2             s p s e t w g d mag cena bb      
   Data "Nawrócenie (60)",0,0,0,0,12,0,4,8,60,2000,14
   Data "Eksplozja (25)",40,0,0,0,12,0,4,9,25,998,14
   
   Data "ścierwo  ",0,0,0,0,17,2,4,20,0,20,22
   '90
   'zbroje2           s p s e t w g d mag cena    
   Data "łuskowa   ",0,12,0,0,6,7,2,0,0,800,7
   Data "świetlista",10,30,0,0,6,12,2,0,0,2300,7
   Data "ogrowa    ",0,43,0,0,6,70,2,0,0,1700,18
   Data "Vingrena  ",12,32,0,0,6,30,2,0,0,2400,18
   'oszczepy             s p s e t w g d mag cena     
   Data "wielorybniczy",17,1,0,0,9,3,4,0,0,300,10
   Data "długi        ",10,1,0,0,9,4,4,0,0,200,10
   Data "Wilczy kieł  ",20,2,0,0,9,5,4,0,0,1100,10
   Data "Stirgrist    ",30,3,0,0,9,8,4,0,0,1700,10
   'mixtury 2         s p s e  t  w g d mag cena bb     
   Data "wino       ",0,0,0,-10,18,1,1,0,10,70,16
   Data "trole mleko",0,1,12,-10,18,1,1,0,0,500,16
   '100 
   Data "woda      ",0,0,0,10,18,1,1,0,0,10,16
   Data "motorolum ",0,0,18,0,18,1,1,0,0,800,16
   Data "krew      ",-20,0,-20,-20,18,1,1,0,0,300,16
   Data "umkoum ",3,0,0,0,18,1,1,0,0,80,16
   'pterodon
   Data "udziec",0,0,0,0,17,2,4,25,0,20,22
   Data "błoniasta ",0,3,0,0,19,0,2,0,0,280,24
   '-łuki            s p s e t w g d mag cena 
   Data "Sokoli",38,0,0,0,4,1,4,0,0,1180,5
   'strzały              s p s e t w g d mag cena   
   Data "Sokole Szpony",35,0,0,0,5,0,4,0,0,1150,6
   'hełmy            s p s e t w g d mag cena bb    
   Data "Sorasila  ",8,10,5,0,7,0,1,0,0,1220,19
   'czary3                  s p s e  t w g  d mag cena bb         
   Data "Niepewność  (12)",20,0,0,0,12,0,4,10,12,200,14
   '110 
   Data "Uspokojenie (20)",50,0,0,0,12,0,4,10,12,600,14
   'dodatkowy stuff 
   'miecze            s p s e t w g d mag cena    
   Data "Wiedźminów ",8,3,0,0,2,7,4,1,0,120,2
   Data "Szerszeń   ",14,1,1,0,2,8,4,1,0,700,2
   Data "Chaosu     ",13,1,-2,0,2,9,4,1,0,650,28
   'topory
   Data "orków    ",10,7,0,0,1,37,4,0,0,120,3
   Data "srebrny  ",14,5,0,0,1,27,4,0,0,620,3
   Data "wojenny  ",8,3,0,0,1,20,4,0,0,190,3
   'młoty 
   Data "bitewny  ",9,2,0,0,11,26,4,0,0,250,4
   Data "stalowy  ",11,5,0,0,11,18,4,0,0,450,4
   Data "granitowy",13,7,0,0,11,39,4,0,0,730,4
End Proc
Procedure WCZYTAJ_RASY
   For I=0 To 19
      Read A$
      RASY$(I)=A$
      For J=0 To 7
         Read A : RASY(I,J)=A
      Next J
   Next I
   
   DANE:
   '                e  s sz m b1 b2 int bob     
   Data "człowiek",30,25,25,20,2,0,10,18+63+48
   Data "ork",45,30,15,10,1,0,5,18+63+32
   Data "elf",10,10,50,35,4,0,12,18+63+112+16
   Data "kobold",20,50,15,15,11,0,8,18+63+16
   Data "amazonka",20,20,40,20,9,0,7,18+63+96
   Data "ogre",65,25,8,2,15,0,3,18+63+64
   Data "trol",40,10,40,10,10,0,5,18+63
   Data "paladyn",20,20,20,40,2,0,13,18+63+80
   Data "mag",10,10,10,70,0,0,13,18+63+112+32
   Data "wieśniak",10,10,10,10,0,0,3,18+63+112
   'potworki       e  s  sz p1 p2 od czar bob           
   Data "gargoil",100,80,25,78,85,50,0,18+63+128+32
   Data "szkielet",60,70,30,0,0,45,44,18+63+128+32
   Data "wilk    ",20,35,40,79,86,20,0,18+63+128+32
   Data "dzik    ",20,30,20,77,84,30,0,18+63+128+32
   Data "gloom   ",30,15,20,0,0,80,0,18+63+128+32
   Data "warpun  ",45,40,20,105,106,30,0,18+63+128+32
   Data "skirial",100,85,15,90,102,70,43,18+63+128+32
   Data "humanoid",40,40,30,0,0,35,42,18+63+128+32
   Data "pająk   ",1,170,40,0,0,2,42,18+63+128+32
   Data "boss",200,190,40,0,0,90,46,241
   'smok,jaszczur,golem,upiór,kronk,pająk 
   
End Proc
Procedure WCZYTAJ_BUDYNKI
   For I=1 To 9
      Read A$
      BUDYNKI$(I)=A$
      For J=0 To 6
         Read A
         BUDYNKI(I,J)=A
      Next J
   Next I

   DANE:
   '               szer wys cena czas b1 b2 drzwi 
   Data "studnia   ",64,50,0,0,3,0,0
   Data "szubienica",32,56,0,0,7,0,0
   Data "beczka    ",20,28,0,0,9,0,0
   Data "sklep     ",112,80,7000,7,5,6,42
   Data "zbrojownia",112,100,10000,7,8,6,42
   Data "świątynia ",104,103,9000,7,6,6,40
   Data "myśliwy   ",64,130,8000,7,2,6,20
   Data "alchemik  ",96,90,6000,7,4,6,40
   Data "spichlerz ",96,100,4000,7,1,6,30
   Data "karczma"

End Proc
Procedure WCZYTAJ_GULE
   Restore DANE : For I=0 To 9 : Read A$ : GUL$(I)=A$ : Next I
   DANE:
   Data "zbuntowani"
   Data "niezadowoleni"
   Data "poddani"
   Data "lojalni"
   Data "fanatycy"
   Data "spokój"
   Data "panika"
   Data "obrona"
   Data "atak"
   Data "psycho"
   
End Proc

Procedure PRZELICZ[I,ZNAK]
   B=ARMIA(ARM,NUMER,TGLOWA+I)
   TYP=BRON(B,B_TYP)
   TYP2=RASY(ARMIA(ARM,NUMER,TRASA),4)
   If TYP<>4 and TYP<>5 and TYP<>12 and TYP<>15 and TYP<>16
      RASA=ARMIA(ARM,NUMER,TRASA)
      SI=BRON(B,B_SI)
      PAN=BRON(B,B_PAN)
      SZ=BRON(B,B_SZ)
      EN=BRON(B,B_EN)
      If TYP=13 or TYP=18
         MAG=BRON(B,B_MAG)
         MAGIA=ARMIA(ARM,NUMER,TMAG)
         MAGMA=ARMIA(ARM,NUMER,TMAGMA)
         Add MAGIA,MAG
         If MAGIA>ARMIA(ARM,NUMER,TMAGMA)
            MAGIA=MAGMA
         End If 
         ARMIA(ARM,NUMER,TMAG)=MAGIA
         MXSI=(RASY(RASA,1)/2)+30
         MXSZ=RASY(RASA,2)+20
         If ARMIA(ARM,NUMER,TSI)+SI>MXSI : SI=MXSI-ARMIA(ARM,NUMER,TSI) : End If 
         If ARMIA(ARM,NUMER,TSZ)+SZ>MXSZ : SZ=MXSZ-ARMIA(ARM,NUMER,TSZ) : End If 
      End If 
      Add ARMIA(ARM,NUMER,TSI),SI*ZNAK
      Add ARMIA(ARM,NUMER,TP),PAN*ZNAK
      Add ARMIA(ARM,NUMER,TSZ),SZ*ZNAK
      Add ARMIA(ARM,NUMER,TAMO),SZ*ZNAK
      Add ARMIA(ARM,NUMER,TE),EN*ZNAK
      If TYP=TYP2
         Add ARMIA(ARM,NUMER,TSI),4*ZNAK
      End If 
      If ARMIA(ARM,NUMER,TSI)>100 : ARMIA(ARM,NUMER,TSI)=100 : End If 
      If ARMIA(ARM,NUMER,TE)>ARMIA(ARM,NUMER,TEM) : ARMIA(ARM,NUMER,TE)=ARMIA(ARM,NUMER,TEM) : End If 
      If ARMIA(ARM,NUMER,TE)<1 : ARMIA(ARM,NUMER,TE)=1 : End If 
   End If 
End Proc
Procedure WAGA[A,NR]
   WAGA=0
   For I=0 To 12
      B=ARMIA(A,NR,TGLOWA+I)
      If B>0
         Add WAGA,BRON(B,B_WAGA)
      End If 
   Next I
   ARMIA(A,NR,TWAGA)=WAGA
   DW=ARMIA(A,NR,TEM)-WAGA
   If DW<0
      ARMIA(A,NR,TSZ)=ARMIA(A,NR,TAMO)-20
      If ARMIA(A,NR,TSZ)<=0 : ARMIA(A,NR,TSZ)=1 : End If 
   Else 
      ARMIA(A,NR,TSZ)=ARMIA(A,NR,TAMO)
   End If 
End Proc
Procedure SEKTOR[X,Y]
   XSEK=(X/64)
   YSEK=(Y/50)
   SEK=XSEK+(YSEK*10)
End Proc[SEK]

Procedure GADUP[GN]
   SC=Screen
   Screen 1
   If GN=1 or GN=-1
      GADGET[200,2,20,20,"bob3",2,0,19,5,-1]
   End If 
   If GN=2 or GN=-1
      GADGET[222,2,20,20,"bob4",2,0,19,5,-1]
   End If 
   If GN=3 or GN=-1
      GADGET[244,2,20,20,"bob5",2,0,19,5,-1]
   End If 
   If GN=4 or GN=-1
      GADGET[266,2,20,20,"bob6",2,0,19,5,-1]
   End If 
   If GN=10 or GN=-1
      GADGET[297,2,20,20,"bob7",2,0,19,5,-1]
   End If 
   Screen SC
End Proc
Procedure GADDOWN[GN]
   SC=Screen
   Screen 1
   If GN=1
      GADGET[200,2,20,20,"bob10",0,2,16,4,0]
   End If 
   If GN=2
      GADGET[222,2,20,20,"bob11",0,2,16,4,0]
   End If 
   If GN=3
      GADGET[244,2,20,20,"bob12",0,2,16,4,0]
   End If 
   If GN=4
      GADGET[266,2,20,20,"bob13",0,2,16,4,0]
   End If 
   If GN=10
      GADGET[297,2,20,20,"bob14",0,2,16,4,0]
   End If 
   Screen SC
End Proc

Procedure AKCJA
   Screen 0
   Bob Off 50
   Bob Off 51
   MARKERS_OFF
   WOJ=0
   MUZYKA=True
   Repeat 
      If Mouse Key=PRAWY
         Screen 0
         SKROL[0]
      End If 
      A$=""
      A$=Inkey$
      KLAW=Scancode
      If KLAW>75 and KLAW<80
         KLAWSKROL[KLAW]
      End If 
      HALAS=0
      For I=1 To 10
         If ARMIA(ARM,I,TE)>0
            Inc WOJ
            TRYB=ARMIA(ARM,I,TTRYB)
            If TRYB=0
               BAZA=ARMIA(ARM,I,TBOB)
               If KTO_ATAKUJE=ARM
                  BNR=BAZA+1
               Else 
                  BNR=BAZA+7
               End If 
               Bob I,,,BNR
               Goto SKIP1
            End If 
            If TRYB=1
               A_RUCH[ARM,I]
               Goto SKIP1
            End If 
            If TRYB=2
               A_ATAK[ARM,I]
               Inc HALAS
               Goto SKIP1
            End If 
            If TRYB=3
               A_STRZAL[ARM,I]
               Goto SKIP1
            End If 
            If TRYB=4 or TRYB=5
               A_CZAR[ARM,I]
               Inc HALAS
               Goto SKIP1
            End If 
            If TRYB=6
               A_ROZMOWA[ARM,I]
               Goto SKIP1
            End If 
            If TRYB=7 or TRYB=8
               A_LOT[ARM,I,TRYB]
               Goto SKIP1
            End If 
            SKIP1:
         Else 
            CZEKAJ
         End If 
         
         
         If ARMIA(WRG,I,TE)>0
            TRYB=ARMIA(WRG,I,TTRYB)
            If TRYB=0
               WYDAJ_ROZKAZ[I]
               Goto SKIP2
            End If 
            If TRYB=1
               A_RUCH[WRG,I]
               If Rnd(20)=1 : WYDAJ_ROZKAZ[I] : End If 
               Goto SKIP2
            End If 
            If TRYB=2
               A_ATAK[WRG,I]
               Inc HALAS
               If Rnd(10)=1 : WYDAJ_ROZKAZ[I] : End If 
               Goto SKIP2
            End If 
            If TRYB=3
               A_STRZAL[WRG,I]
               Goto SKIP2
            End If 
            If TRYB=4 or TRYB=5
               A_CZAR[WRG,I]
               Inc HALAS
               Goto SKIP2
            End If 
            If TRYB=7 or TRYB=8
               A_LOT[WRG,I,TRYB]
               Goto SKIP2
            End If 
            SKIP2:
         Else 
            CZEKAJ
         End If 
         
      Next I
      Bob Update : Wait Vbl 
      If HALAS>3 and MUZYKA
         Music Stop 
         MUZYKA=False
      End If 
      
      If HALAS<=3 and MUZYKA=False
         MUZYKA=True
         Music 1
      End If 
      
   Until Mouse Key=LEWY or Inkey$=" " or WOJ=0
   Sam Loop Off 
   If Not MUZYKA : Sam Stop : Music 1 : End If 
   MARKERS
   If WOJ=0 : ARMIA(ARM,0,TE)=0 : WYNIK_AKCJI=2 : End If 
   GADUP[10]
   STREFA0=Mouse Zone
   If STREFA0<11 and STREFA0>0
      NUMER=STREFA0
   End If 
   SELECT[ARM,NUMER]
End Proc
Procedure MARKERS
   For I=1 To 10
      If ARMIA(ARM,I,TE)>0
         X=ARMIA(ARM,I,TX)
         Y=ARMIA(ARM,I,TY)-45
         Bob 20+I,X,Y,PIKIETY+18+10
      End If 
   Next I
   Bob Update : Wait Vbl 
End Proc
Procedure MARKERS_OFF
   For I=1 To 10
      Bob Off 20+I
   Next I
   Bob Update : Wait Vbl 
End Proc

Procedure RUCH
   _GET_XY[0,0,0]
   Screen 0
   Bob Off 30+NUMER
   Add OY,8
   If OX>623 Then OX=623
   If OX<17 Then OX=17
   If OY>508 Then OY=508
   If OY<22 Then OY=22
   STREFA=Zone(OX,OY)
   If STREFA<21 or STREFA>100 and STREFA<120 or STREFA>30 and STREFA<41
      ARMIA(ARM,NUMER,TCELX)=OX
      ARMIA(ARM,NUMER,TCELY)=OY
      ARMIA(ARM,NUMER,TTRYB)=1
      Bob 51,OX,OY,2+BUBY : Bob Update : Wait Vbl 
   End If 
   While Mouse Key=LEWY : Wend 
End Proc
Procedure A_RUCH[A,I]
   Screen 0
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   X1=ARMIA(A,I,TX)
   Y1=ARMIA(A,I,TY)
   X2=ARMIA(A,I,TCELX)
   Y2=ARMIA(A,I,TCELY)
   BAZA=ARMIA(A,I,TBOB)
   KLATKA=ARMIA(A,I,TKLAT)
   SPEED=ARMIA(A,I,TSZ)/10
   SPEED2=3-SPEED
   If SPEED2<=0 Then SPEED2=1
   If SPEED<=0 Then SPEED=1
   If SPEED>7 Then SPEED=7
   Add KLATKA,1,0 To(SPEED2*4)-1
   ARMIA(A,I,TKLAT)=KLATKA
   KLATKA=KLATKA/SPEED2
   KLATKA=AN(KLATKA)
   BNR=BAZA+7
   ROZX=X2-X1
   ROZY=Y2-Y1
   STREFA=Zone(X1,Y1+1)
   STREFA2=Zone(X1,Y1+30)
   RASA=ARMIA(A,I,TRASA)
   KLIN=2
   If RASA>9 and Rnd(40)=1
      Sam Bank 5
      FX[1]
      Sam Bank 4
   End If 
   If STREFA2>20 and STREFA2<31
      Limit Bob I2,0,0 To 640,114
   Else 
      Limit Bob I2,0,0 To 640,512
   End If 
   If STREFA>100 and STREFA<120 and A=ARM
      MIASTO=ARMIA(A,0,TNOGI)-70
      SKLEP[MIASTO,STREFA-100,A,I]
      Add Y1,8
      Goto SKIP
   End If 
   If STREFA>30 and STREFA<41
      PLAPKA[STREFA-30,A,I,X1,Y1]
      If Param=1
         Goto OVER
      End If 
   End If 
   If Abs(ROZX)>4
      ZNX=Sgn(ROZX)
      If ZNX=-1 : BNR=BAZA+4+KLATKA : T=-17 : End If 
      If ZNX=1 : BNR=BAZA+10+KLATKA : T=17 : End If 
      ST=Zone(X1+T,Y1)
      If ST=0 or(ST>100 and ST<120 or ST>30 and ST<41) and A=ARM
         Add X1,ZNX*SPEED
         Dec KLIN
      End If 
   End If 
   If Abs(ROZY)>4
      ZNY=Sgn(ROZY)
      If ZNY=-1 : B2=BAZA+1+KLATKA : T=-21 : End If 
      If ZNY=1 : B2=BAZA+7+KLATKA : T=2 : End If 
      ST=Zone(X1,Y1+T)
      If ST=0 or(ST>100 and ST<120 or ST>30 and ST<41) and A=ARM
         Add Y1,ZNY*SPEED
         BNR=B2
         Dec KLIN
      End If 
   End If 
   
   If Abs(ROZX)<=4 and Abs(ROZY)<=4
      ARMIA(A,I,TTRYB)=0
      KLIN=0
   End If 
   
   SKIP:
   ARMIA(A,I,TX)=X1
   ARMIA(A,I,TY)=Y1
   
   Set Zone I2,X1-15,Y1-15 To X1+15,Y1
   Bob I2,X1,Y1,BNR
   If KLIN=2 and A=WRG
      X2=X1+Rnd(120)-60
      Y2=Y1+Rnd(100)-50
      If X2<20 : X2=20 : End If 
      If X2>620 : X2=620 : End If 
      If Y2<20 : Y2=20 : End If 
      If Y2>510 : Y2=510 : End If 
      ARMIA(A,I,TCELX)=X2
      ARMIA(A,I,TCELY)=Y2
      ARMIA(A,I,TTRYB)=1
   End If 
   
   OVER:
End Proc
Procedure A_ATAK[A,I]
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   X1=ARMIA(A,I,TX)
   Y1=ARMIA(A,I,TY)
   BAZA=ARMIA(A,I,TBOB)
   BNR=BAZA+7
   TARGET=ARMIA(A,I,TCELX)
   B=ARMIA(A,I,TCELY)
   ENP=ARMIA(B,TARGET,TE)
   If ENP<=0
      ARMIA(A,I,TTRYB)=0
      Goto OVER
   End If 
   X2=ARMIA(B,TARGET,TX)
   Y2=ARMIA(B,TARGET,TY)
   SPEED=ARMIA(A,I,TSZ)/10
   KLATKA=ARMIA(A,I,TKLAT)
   SPEED2=3-SPEED
   If SPEED2<=0 Then SPEED2=1
   If SPEED<=0 Then SPEED=1
   If SPEED>7 Then SPEED=7
   Add KLATKA,1,0 To(SPEED2*4)-1
   ARMIA(A,I,TKLAT)=KLATKA
   KLATKA=KLATKA/SPEED2
   KLATKA=AN(KLATKA)
   STREFA=Zone(X1,Y1+1)
   STREFA2=Zone(X1,Y1+30)
   RASA=ARMIA(A,I,TRASA)
   KLIN=2
   If RASA>9 and Rnd(40)=1
      Sam Bank 5
      FX[1]
      Sam Bank 4
   End If 
   If STREFA>30 and STREFA<41
      PLAPKA[STREFA-30,A,I,X1,Y1]
      If Param=1
         Goto OVER
      End If 
   End If 
   If STREFA2>20 and STREFA2<31
      Limit Bob I2,0,0 To 640,114
   Else 
      Limit Bob I2,0,0 To 640,512
   End If 
   
   ROZX=X2-X1
   ROZY=Y2-Y1
   
   If Abs(ROZX)>33
      ZNX=Sgn(ROZX)
      If ZNX=-1 : BNR=BAZA+4+KLATKA : T=-17 : End If 
      If ZNX=1 : BNR=BAZA+10+KLATKA : T=17 : End If 
      ST=Zone(X1+T,Y1)
      If ST=0 or ST>30 and ST<41 and A=ARM
         Add X1,ZNX*SPEED
         Dec KLIN
      End If 
   End If 
   If Abs(ROZY)>21
      ZNY=Sgn(ROZY)
      If ZNY=-1 : BNR=BAZA+1+KLATKA : T=-21 : End If 
      If ZNY=1 : BNR=BAZA+7+KLATKA : T=2 : End If 
      ST=Zone(X1,Y1+T)
      If ST=0 or ST>30 and ST<41 and A=ARM
         Add Y1,ZNY*SPEED
         Dec KLIN
      End If 
   End If 
   
   If Abs(ROZX)<=33 and Abs(ROZY)<=21
      KLIN=0
      ZNX=Sgn(ROZX)
      B2=BAZA+13+Rnd(2)
      If ZNX=-1
         BNR=BAZA+5+Rnd(1)
      Else 
         BNR=BAZA+11+Rnd(1) : B2=Hrev(B2)
      End If 
      
      If B=WRG : ARMIA(WRG,TARGET,TGLOWA)=1 : End If 
      If A=WRG : ARMIA(WRG,I,TGLOWA)=1 : End If 
      'auto-defence system 
      If ARMIA(B,TARGET,TTRYB)=0 or(B=WRG and ARMIA(B,TARGET,TTRYB)=1)
         ARMIA(B,TARGET,TCELX)=I
         ARMIA(B,TARGET,TCELY)=A
         ARMIA(B,TARGET,TTRYB)=2
      End If 
      '------------------- 
      ODP=ARMIA(B,TARGET,TP)
      SILA=ARMIA(A,I,TSI)
      MOC=100-ARMIA(A,I,TDOSW)
      MOC2=100-ARMIA(B,TARGET,TDOSW)
      'BRO1=BRON(ARMIA(A,I,TLEWA),B_WAGA)
      'BRO2=BRON(ARMIA(A,I,TPRAWA),B_WAGA) 
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If SPEED<1 : SPEED=1 : End If 
      RASA2=ARMIA(B,TARGET,TRASA)
      If Rnd(SPEED)=0
         Ink 10 : Plot X2+Rnd(20)-10,Y2+Rnd(6)-2
         BNR=B2
         OPOR=ODP-Rnd(((ODP*MOC2)/100)+1)
         CIOS=(SILA-Rnd((SILA*MOC)/100))-OPOR
         CIOS=CIOS/2
         'CHECK[CIOS] 
         If CIOS<=0 : CIOS=1 : End If 
         Add ENP,-CIOS
         If RASA2<10 : PRZELOT=Rnd(1) : End If 
         If CIOS>13 and PRZELOT=1
            ARMIA(B,TARGET,TTRYB)=7
            CELX=X2+ROZX : If CELX<20 : CELX=20 : End If : If CELX>620 : CELX=620 : End If 
            CELY=Y2+ROZY : If CELY<20 : CELY=20 : End If : If CELY>500 : CELY=500 : End If 
            ARMIA(B,TARGET,TCELX)=CELX
            ARMIA(B,TARGET,TCELY)=CELY
         End If 
         
         If ENP<=0
            If CIOS>20 and PRZELOT=1
               ARMIA(B,TARGET,TTRYB)=8
               ENP=5
            Else 
               ZABIJ[B,TARGET,0]
            End If 
            MUNDRY=RASY(RASA,6)
            Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
            ARMIA(A,I,TTRYB)=0
            If A=WRG : Add ARMIA(A,I,TKORP),Rnd(20) : End If 
         End If 
         ARMIA(B,TARGET,TE)=ENP
         KANAL=Rnd(3)
         If RASA<10
            SAM=Rnd(4)+1
         Else 
            Sam Bank 5
            SAM=2
         End If 
         FX[SAM]
         Sam Bank 4
      End If 
   End If 
   ARMIA(A,I,TX)=X1
   ARMIA(A,I,TY)=Y1
   If ARMIA(A,I,TE)>0 : Bob I2,X1,Y1,BNR : Set Zone I2,X1-15,Y1-15 To X1+15,Y1 : End If 
   If KLIN>1 and A=WRG
      X2=X1+Rnd(120)-60
      Y2=Y1+Rnd(100)-50
      If X2<20 : X2=20 : End If 
      If X2>620 : X2=620 : End If 
      If Y2<20 : Y2=20 : End If 
      If Y2>510 : Y2=510 : End If 
      ARMIA(A,I,TCELX)=X2
      ARMIA(A,I,TCELY)=Y2
      ARMIA(A,I,TTRYB)=1
   End If 
   OVER:
End Proc
Procedure A_STRZAL[A,I]
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   SILA=VEKTOR#(I2,0)
   XP#=VEKTOR#(I2,3)
   YP#=VEKTOR#(I2,4)
   VX#=VEKTOR#(I2,1)
   VY#=VEKTOR#(I2,2)
   XP#=XP#+(VX#*2)
   YP#=YP#+(VY#*2)
   VEKTOR#(I2,3)=XP#
   VEKTOR#(I2,4)=YP#
   If SILA<0
      BB=PIKIETY+21+Rnd(3)
      SILA=-SILA
      ODLOT=Rnd(1)
      SAM=14
   Else 
      SAM=11
      ODLOT=0
      BB=BSIBY+I2
   End If 
   Screen 0
   Bob I2+30,XP#,YP#,BB
   STREFA=Zone(XP#,YP#)
   'trafienie w gościa
   If STREFA>0 and STREFA<>I2 and STREFA<21
      If STREFA>10
         Add STREFA,-10
         B=WRG
      Else 
         B=ARM
      End If 
      Bob Off I2+30
      ARMIA(A,I,TTRYB)=0
      X1=ARMIA(B,STREFA,TX)
      Y1=ARMIA(B,STREFA,TY)
      ENP=ARMIA(B,STREFA,TE)
      ODP=ARMIA(B,STREFA,TP)
      RASA2=ARMIA(B,STREFA,TRASA)
      If RASA2>9 : ODLOT=0 : End If 
      'oszczepy lądują na glebie 
      OSZ=VEKTOR#(I2,5)
      If BRON(OSZ,B_TYP)=9
         SEKTOR[X1,Y1] : SEK=Param
         For I=0 To 3
            If GLEBA(SEK,I)=0
               GLEBA(SEK,I)=OSZ
               I=4
            End If 
         Next I
      End If 
      '----------- 
      MOC=100-ARMIA(A,I,TDOSW)
      CIOS=SILA-Rnd((SILA*MOC)/100)-Rnd(ODP+2)
      'CHECK[CIOS] 
      If CIOS<=0 : CIOS=1 : End If 
      
      Add ENP,-CIOS
      If ODLOT=1
         ARMIA(B,STREFA,TTRYB)=7
         CELX=X1+VX#*8 : If CELX<20 : CELX=20 : End If : If CELX>620 : CELX=620 : End If 
         CELY=Y1+VY#*8 : If CELY<20 : CELY=20 : End If : If CELY>500 : CELY=500 : End If 
         ARMIA(B,STREFA,TCELX)=CELX
         ARMIA(B,STREFA,TCELY)=CELY
      End If 
      If ENP<=0
         MUNDRY=RASY(ARMIA(A,I,TRASA),6)
         Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
         If A=WRG : Add ARMIA(A,I,TKORP),Rnd(20) : End If 
         If ODLOT=1
            ARMIA(B,STREFA,TTRYB)=8
            ENP=2
         Else 
            ZABIJ[B,STREFA,0]
         End If 
      End If 
      ARMIA(B,STREFA,TE)=ENP
      FX[SAM]
   End If 
   'trafienie w mur 
   If STREFA>20 and STREFA<31 and KTO_ATAKUJE=A
      Bob Off I2+30
      FX[14]
      ARMIA(A,I,TTRYB)=0
      Add MUR(STREFA-21),-SILA
      If MUR(STREFA-21)<=0
         X=(STREFA-21)*64
         Reset Zone STREFA
         Autoback 2 : Paste Bob X,111,BIBY+12+2 : Wait Vbl : Autoback 1
      End If 
   End If 
   If XP#>640 or XP#<0 or YP#>512 or YP#<0 or STREFA>40
      Bob Off I2+30
      ARMIA(A,I,TTRYB)=0
   End If 
End Proc
Procedure A_CZAR[A,I]
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   BR=VEKTOR#(I2,0)
   SILA=BRON(BR,B_SI)
   CZAR_TYP=BRON(BR,B_DOSW)
   MOC=100-ARMIA(A,I,TDOSW)
   '------------------------
   If CZAR_TYP=1
      XP#=VEKTOR#(I2,3)
      YP#=VEKTOR#(I2,4)
      VX#=VEKTOR#(I2,1)
      VY#=VEKTOR#(I2,2)
      BB=VEKTOR#(I2,5)
      XP#=XP#+(VX#*2)
      YP#=YP#+(VY#*2)
      VEKTOR#(I2,3)=XP#
      VEKTOR#(I2,4)=YP#
      If BR=42 : Add BB,1,1 To 2 : VEKTOR#(I2,5)=BB : End If 
      If BR=43 : BB=25+Rnd(2) : End If 
      If BR=44 : Add BB,1,10 To 13 : VEKTOR#(I2,5)=BB : End If 
      Bob I2+30,XP#,YP#,PIKIETY+BB
      STREFA=Zone(XP#,YP#)
      If STREFA>0 and STREFA<>I2 and STREFA<21
         If STREFA>10
            Add STREFA,-10
            B=WRG
         Else 
            B=ARM
         End If 
         X1=ARMIA(B,STREFA,TX)
         Y1=ARMIA(B,STREFA,TY)
         ENP=ARMIA(B,STREFA,TE)
         CIOS=SILA-Rnd((SILA*MOC)/100)
         If CIOS<=0 : CIOS=1 : End If 
         Add ENP,-CIOS
         ARMIA(B,STREFA,TE)=ENP
         FX[12]
         If ENP<=0
            MUNDRY=RASY(ARMIA(A,I,TRASA),6)
            Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
            ZABIJ[B,STREFA,0]
         End If 
         If BR<>44
            Bob Off I2+30
            ARMIA(A,I,TTRYB)=0
         End If 
      End If 
      If STREFA>20 and STREFA<31 and KTO_ATAKUJE=A
         Bob Off I2+30
         ARMIA(A,I,TTRYB)=0
         Add MUR(STREFA-21),-SILA
         If MUR(STREFA-21)<=0
            X=(STREFA-21)*64
            Reset Zone STREFA
            Autoback 2 : Paste Bob X,111,BIBY+12+2 : Wait Vbl : Autoback 1
         End If 
      End If 
      
      If XP#>640 or XP#<0 or YP#>512 or YP#<0 or STREFA>40
         Bob Off I2+30
         ARMIA(A,I,TTRYB)=0
      End If 
   End If 
   '----------------- 
   If CZAR_TYP=2
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
         
         Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
         
         TARGET=ARMIA(A,I,TCELX)
         B=ARMIA(A,I,TCELY)
         X2=ARMIA(B,TARGET,TX)
         Y2=ARMIA(B,TARGET,TY)
         ENP=ARMIA(B,TARGET,TE)
         ODP=ARMIA(B,TARGET,TP)
         ENM=ARMIA(B,TARGET,TEM)
         SILA=BRON(BR,B_SI)
         If BR=45
            CENTER[X2,Y2,1]
            FX[9]
            For J=1 To 20
               Bob I2+30,X2,Y2+8,PIKIETY+7+Rnd(2)
               Bob Update : Wait Vbl 
            Next J
         End If 
         If BR=46
            CENTER[X2,Y2,1]
      ' PGJ: commented because formatting of the file fails
         'Fade 5,$0,$25,$48,$16C,$19F,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$FFF,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0,$0
            FX[8]
            For J=1 To 20
               Bob I2+30,X2,Y2+8,PIKIETY+3+Rnd(3)
               Bob Update : Wait Vbl 
               If J=14 : Fade 4 To 2 : End If 
            Next J
            
         End If 
         If SILA=0
            FX[10]
            For J=1 To 15
               Bob I2+30,X2,Y2+1,PIKIETY+14+Rnd(3)
               Bob Update : Wait Vbl 
            Next J
         End If 
         Add ARMIA(B,TARGET,TSZ),BRON(BR,B_SZ)
         If ARMIA(B,TARGET,TSZ)<1 : ARMIA(B,TARGET,TSZ)=1 : End If 
         ENERGIA=BRON(BR,B_EN)
         CIOS=SILA-Rnd((SILA*MOC)/100)
         'CHECK[CIOS] 
         Add ENP,-CIOS
         Add ENP,ENERGIA
         If ENP>ENM
            ENP=ENM
         End If 
         If ENP<=0
            MUNDRY=RASY(ARMIA(A,I,TRASA),6)
            Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
            ZABIJ[B,TARGET,0]
         End If 
         ARMIA(A,I,TTRYB)=0
         ARMIA(B,TARGET,TE)=ENP
         Bob Off I2+30
      End If 
   End If 
   '------------------
   '   CHECK[CZAR_TYP]
   If CZAR_TYP=3
      'intuicja
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
         FX[13]
         Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
         TARGET=ARMIA(A,I,TCELX)
         B=ARMIA(A,I,TCELY)
         X2=ARMIA(B,TARGET,TX)
         Y2=ARMIA(B,TARGET,TY)
         For J=1 To 20
            Bob I2+30,X2,Y2+1,PIKIETY+14+Rnd(3)
            Bob Update : Wait Vbl 
         Next J
         ARMIA(A,I,TTRYB)=0
         If B=WRG
            ARMIA(B,TARGET,TGLOWA)=1
         End If 
         Bob Off I2+30
      End If 
   End If 
   '---------------------   
   If CZAR_TYP=5
      'światłość 
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
      ' PGJ: commented because formatting of the file fails
         'Fade 2,,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF
         Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
         FX[13]
         For J=1 To 10
            If ARMIA(WRG,J,TE)>0
               Bob J+10,ARMIA(WRG,J,TX),ARMIA(WRG,J,TY),ARMIA(WRG,J,TBOB)+2
            End If 
         Next J
         Bob Update : Wait Vbl 
         ARMIA(A,I,TTRYB)=0
         Wait 30
         Fade 3 To 2
      End If 
   End If 
   '-------------   
   If CZAR_TYP=6
      'wszechwiedza
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
      ' PGJ: commented because formatting of the file fails
         'Fade 2,,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF,$FFF
         Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
         B=ARMIA(A,I,TCELY)
         FX[13]
         If B=WRG
            For J=1 To 10
               ARMIA(B,J,TGLOWA)=1
            Next J
         End If 
         ARMIA(A,I,TTRYB)=0
         Wait 30
         Fade 3 To 2
      End If 
   End If 
   '--------------    
   If CZAR_TYP=7
      'Gniew Boży
      If MUZYKA : Music Stop : End If 
      Wait Vbl : FX[8]
      Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
      TARGET=ARMIA(A,I,TCELX)
      B=ARMIA(A,I,TCELY)
      X2=ARMIA(B,TARGET,TX)
      Y2=ARMIA(B,TARGET,TY)
      ' PGJ: commented because formatting of the file fails
         'Fade 2,$0,$25,$48,$16C,$19F,0,0,0,0,0,0,0,0,0,0,0,$FFF,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
      
      CENTER[X2,Y2,0]
      For J=1 To 100
         Bob I2+30,,,PIKIETY+3+Rnd(3)
         Bob I2+50,,,PIKIETY+3+Rnd(3)
         Add B3,1,PIKIETY+18 To PIKIETY+20
         Bob I2+40,,,B3
         Bob Update : Wait Vbl 
         S=Rnd(15)
         If S<2 : FX[9] : End If 
         If S=2 : FX[8] : End If 
         If S=3 : FX[12] : End If 
         If S=4 : FX[14] : End If 
         If J mod 2=0 : Fade 5 To 2 : Bob I2+30,SX+Rnd(320),SY+Rnd(250),PIKIETY+3+Rnd(3) : End If 
         
         If J mod 2=1
            Bob I2+50,SX+Rnd(320),SY+Rnd(250),PIKIETY+3+Rnd(3)
      ' PGJ: commented because formatting of the file fails
         'Fade 5,$0,$25,$48,$16C,$19F,0,0,0,0,0,0,0,0,0,0,0,$FFF,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
         End If 
         If J mod 3=0 : Bob I2+40,SX+Rnd(320),SY+Rnd(250),B3 : End If 
         CENTER[X2+Rnd(10)-5,Y2+Rnd(10)-5,0]
      Next J
      Bob Off I2+30 : Bob Off I2+40 : Bob Off I2+50
      For J=1 To 10
         If ARMIA(B,J,TE)>0
            Add ARMIA(B,J,TE),-Rnd(SILA)
            If ARMIA(B,J,TE)<=0
               MUNDRY=RASY(ARMIA(A,I,TRASA),6)
               Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
               ZABIJ[B,J,0]
            End If 
         End If 
      Next J
      ARMIA(A,I,TTRYB)=0
      Fade 2 To 2
      If MUZYKA : Music 1 : End If 
   End If 
   '----------------------- 
   If CZAR_TYP=8
      'nawrócenie
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
         Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
         B=ARMIA(A,I,TCELX)
         B2=ARMIA(A,I,TCELY)
         X2=ARMIA(B2,B,TX)
         Y2=ARMIA(B2,B,TY)
         RASA=ARMIA(B2,B,TRASA)
         FX[15]
         For J=1 To 20
            Bob I2+30,X2,Y2+1,PIKIETY+14+Rnd(3)
            Bob Update : Wait Vbl 
         Next J
         ARMIA(A,I,TTRYB)=0
         
         If RASA<10 and B2=WRG
            JEST=False
            For L=1 To 10
               If ARMIA(ARM,L,TE)<=0
                  JEST=True
                  L2=L
                  L=10
               End If 
            Next L
            If JEST
               ARMIA(ARM,L2,TRASA)=ARMIA(WRG,B,TRASA)
               ARMIA(ARM,L2,TSI)=ARMIA(WRG,B,TSI)
               ARMIA(ARM,L2,TSZ)=ARMIA(WRG,B,TSZ)
               ARMIA(ARM,L2,TE)=ARMIA(WRG,B,TE)
               ARMIA(ARM,L2,TEM)=ARMIA(WRG,B,TEM)
               ARMIA(ARM,L2,TKLAT)=ARMIA(WRG,B,TKLAT)
               ARMIA(ARM,L2,TMAG)=ARMIA(WRG,B,TMAG)
               ARMIA(ARM,L2,TMAGMA)=ARMIA(WRG,B,TMAGMA)
               ARMIA(ARM,L2,TAMO)=ARMIA(WRG,B,TSZ)
               ARMIA(ARM,L2,TDOSW)=ARMIA(WRG,B,TDOSW)
               ARMIA(ARM,L2,TP)=0
               For I=TGLOWA To TPLECAK+7 : ARMIA(ARM,L2,I)=0 : Next I
               ARMIA$(ARM,L2)=ARMIA$(WRG,B)
               ARMIA(WRG,B,TE)=0 : Bob Off 10+B : Reset Zone 10+B : Bob Update : Wait Vbl 
               ARMIA(WRG,B,TTRYB)=0
               ARMIA(ARM,L2,TX)=ARMIA(WRG,B,TX)
               ARMIA(ARM,L2,TY)=ARMIA(WRG,B,TY)
               BAZA=RASY(ARMIA(ARM,L2,TRASA),7)
               X=ARMIA(ARM,L2,TX)
               Y=ARMIA(ARM,L2,TY)
               ARMIA(ARM,L2,TBOB)=BAZA
               Bob L2,X,Y,BAZA+1 : Bob Off B+10+30
               Set Zone L2,X-16,Y-20 To X+16,Y
            End If 
         End If 
         Bob Off I2+30 : Bob Update : Wait Vbl 
      End If 
   End If 
   
   
   If CZAR_TYP=9
      'wybuch
      '      KLATKA=VEKTOR#(I2,3)
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
         
         X=ARMIA(A,I,TCELX)
         Y=ARMIA(A,I,TCELY)
         CENTER[X,Y,1] : FX[14]
         For J=0 To 2
            Bob I2+30,X,Y,PIKIETY+18+J
            CENTER[X+Rnd(10)-5,Y+Rnd(10)-5,0]
            Bob Update : Wait Vbl 
         Next J
         Bob Off I2+30 : ARMIA(A,I,TTRYB)=0
         
         'zliczanie odległości od epicentrum
         If KLATKA=0
            For J=1 To 10
               If ARMIA(WRG,J,TE)>0
                  X2=ARMIA(WRG,J,TX)
                  Y2=ARMIA(WRG,J,TY)
                  DX=X2-X
                  DY=Y2-Y
                  ODLEG=Abs(Sqr(DX*DX+DY*DY))
                  
                  If ODLEG<60
                     ODLOT=0
                     If I<>J : ODLOT=Rnd(1) : End If 
                     If ODLOT=1
                        ARMIA(WRG,J,TTRYB)=7
                        CELX=X2+DX : If CELX<20 : CELX=20 : End If : If CELX>620 : CELX=620 : End If 
                        CELY=Y2+DY : If CELY<20 : CELY=20 : End If : If CELY>500 : CELY=500 : End If 
                        ARMIA(WRG,J,TCELX)=CELX
                        ARMIA(WRG,J,TCELY)=CELY
                     End If 
                     ENP=ARMIA(WRG,J,TE)
                     CIOS=SILA-(ODLEG/2)
                     Add ENP,-CIOS
                     
                     If ENP<=0
                        MUNDRY=RASY(ARMIA(A,I,TRASA),6)
                        Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
                        If ODLOT=1
                           ARMIA(WRG,J,TTRYB)=8
                           ENP=2
                        Else 
                           ZABIJ[WRG,J,0]
                        End If 
                     End If 
                     ARMIA(WRG,J,TE)=ENP
                  End If 
               End If 
               If ARMIA(ARM,J,TE)>0
                  X2=ARMIA(ARM,J,TX)
                  Y2=ARMIA(ARM,J,TY)
                  DX=X2-X
                  DY=Y2-Y
                  ODLEG=Abs(Sqr(DX*DX+DY*DY))
                  If ODLEG<60
                     ODLOT=0
                     If I<>J : ODLOT=Rnd(1) : End If 
                     If ODLOT=1
                        ARMIA(ARM,J,TTRYB)=7
                        CELX=X2+DX : If CELX<20 : CELX=20 : End If : If CELX>620 : CELX=620 : End If 
                        CELY=Y2+DY : If CELY<20 : CELY=20 : End If : If CELY>500 : CELY=500 : End If 
                        ARMIA(ARM,J,TCELX)=CELX
                        ARMIA(ARM,J,TCELY)=CELY
                     End If 
                     
                     ENP=ARMIA(ARM,J,TE)
                     CIOS=SILA-(ODLEG/2)
                     Add ENP,-CIOS
                     
                     
                     If ENP<=0
                        MUNDRY=RASY(ARMIA(A,I,TRASA),6)
                        Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
                        If ODLOT=1
                           ARMIA(ARM,J,TTRYB)=8
                           ENP=2
                        Else 
                           ZABIJ[ARM,J,0]
                        End If 
                     End If 
                     ARMIA(ARM,J,TE)=ENP
                  End If 
               End If 
            Next J
         End If 
         '      VEKTOR#(I2,3)=VEKTOR#(I2,3)+1 
      End If 
   End If 
   If CZAR_TYP=10
      'uspokojenie 
      SPEED=(100-ARMIA(A,I,TSZ))/10
      If Rnd(SPEED)=0
         FX[15]
         Add ARMIA(A,I,TMAG),-BRON(BR,B_MAG)
         TARGET=ARMIA(A,I,TCELX)
         B=ARMIA(A,I,TCELY)
         X2=ARMIA(B,TARGET,TX)
         Y2=ARMIA(B,TARGET,TY)
         For J=1 To 20
            Bob I2+30,X2,Y2+1,PIKIETY+14+Rnd(3)
            Bob Update : Wait Vbl 
         Next J
         ARMIA(A,I,TTRYB)=0
         If B=WRG
            Add ARMIA(B,TARGET,TKORP),-Rnd(SILA)-10-(ARMIA(A,I,TDOSW)/2),0 To ARMIA(B,TARGET,TKORP)
         End If 
         Bob Off I2+30
      End If 
   End If 
End Proc
Procedure A_LOT[A,I,TRYB]
   Screen 0
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   'CHECK[TRYB] 
   'If TRYB=8 : Bell : End If 
   'wyłączam gościa pikiete 
   Bob Off I2+30
   
   X1=ARMIA(A,I,TX)
   Y1=ARMIA(A,I,TY)
   X2=ARMIA(A,I,TCELX)
   Y2=ARMIA(A,I,TCELY)
   BAZA=ARMIA(A,I,TBOB)
   KLATKA=ARMIA(A,I,TKLAT)
   Add KLATKA,3,2 To 11
   ARMIA(A,I,TKLAT)=KLATKA
   BNR=BAZA+KLATKA
   ROZX=X2-X1
   ROZY=Y2-Y1
   STREFA=Zone(X1,Y1+1)
   STREFA2=Zone(X1,Y1+30)
   RASA=ARMIA(A,I,TRASA)
   SPEED=5
   KLIN=2
   If STREFA2>20 and STREFA2<31
      Limit Bob I2,0,0 To 640,114
   Else 
      Limit Bob I2,0,0 To 640,512
   End If 
   If STREFA>30 and STREFA<41
      PLAPKA[STREFA-30,A,I,X1,Y1]
      If Param=1
         Goto OVER
      End If 
   End If 
   If Abs(ROZX)>4
      ZNX=Sgn(ROZX)
      If ZNX=-1 : T=-17 : End If 
      If ZNX=1 : T=17 : End If 
      ST=Zone(X1+T,Y1)
      If ST=0 or(ST>100 and ST<120 or ST>30 and ST<41) and A=ARM
         Add X1,ZNX*SPEED
         Dec KLIN
      End If 
   End If 
   If Abs(ROZY)>4
      ZNY=Sgn(ROZY)
      If ZNY=-1 : T=-21 : End If 
      If ZNY=1 : T=2 : End If 
      ST=Zone(X1,Y1+T)
      If ST=0 or(ST>30 and ST<41)
         Add Y1,ZNY*SPEED
         Dec KLIN
      End If 
   End If 
   
   If Abs(ROZX)<=4 and Abs(ROZY)<=4
      KLIN=0
      If TRYB=8
         ZABIJ[A,I,0]
         Goto OVER
      End If 
      ARMIA(A,I,TTRYB)=0
   End If 
   SKIP:
   ARMIA(A,I,TX)=X1
   ARMIA(A,I,TY)=Y1
   Set Zone I2,X1-15,Y1-15 To X1+15,Y1
   Bob I2,X1,Y1,BNR
   If KLIN=2
      If TRYB=8 : ZABIJ[A,I,0] : End If 
      ARMIA(A,I,TTRYB)=0
   End If 
   OVER:
End Proc

Procedure PLAPKA[NR,A,I,X,Y]
   PLAPKA=PLAPKI(NR,0)
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   'przepaść
   If PLAPKA=1
      Limit Bob I2,0,0 To 640,Y+2
      For L=Y To Y+60 Step 6
         Bob I2,,L, : Bob Update : Wait Vbl 
      Next 
      SKOK=1
      ZABIJ[A,I,1]
      Wait 20
      FX[2]
   End If 
   'bagno 
   If PLAPKA=2
      Limit Bob I2,0,0 To 640,Y+2
      For L=Y To Y+35
         Bob I2,,L, : Bob Update : Wait Vbl 
      Next 
      ZABIJ[A,I,1]
      SKOK=1
   End If 
   'lodowate jeziorko 
   If PLAPKA=3
      SKOK=0
      Add ARMIA(A,I,TE),-2
      If ARMIA(A,I,TE)<=0
         SKOK=1
         ZABIJ[A,I,1]
      End If 
   End If 
   'zapadnia
   If PLAPKA=4
      Autoback 2
      Paste Bob PLAPKI(NR,1),PLAPKI(NR,2),BIBY+10
      Autoback 1
      Limit Bob I2,0,0 To 640,PLAPKI(NR,4)
      For L=Y To Y+80 Step 6
         Bob I2,,L, : Bob Update : Wait Vbl 
      Next 
      SKOK=1
      ZABIJ[A,I,1]
      Wait 20
      FX[2]
   End If 
   'kolce 
   If PLAPKA=5
      SKOK=0
      CIOS=Rnd(10)+5
      FX[11]
      Add ARMIA(A,I,TE),-CIOS
      If ARMIA(A,I,TE)<=0 : SKOK=1 : ZABIJ[A,I,0] : End If 
      Autoback 2
      Paste Bob PLAPKI(NR,1),PLAPKI(NR,2),BIBY+7
      Autoback 1
   End If 
   'przepaść głęboka
   If PLAPKA=6
      Limit Bob I2,0,0 To 640,Y+PLAPKI(NR,4)
      For L=Y To Y+180 Step 6
         Bob I2,,L, : Bob Update : Wait Vbl 
      Next 
      SKOK=1
      ZABIJ[A,I,1]
      Wait 20
      FX[2]
   End If 
   
End Proc[SKOK]
'--
Procedure A_ROZMOWA[A,I]
   Screen 0
   If A=WRG
      I2=I+10
   Else 
      I2=I
   End If 
   X1=ARMIA(A,I,TX)
   Y1=ARMIA(A,I,TY)
   BAZA=ARMIA(A,I,TBOB)
   BNR=BAZA+7
   TARGET=ARMIA(A,I,TCELX)
   B=ARMIA(A,I,TCELY)
   X2=ARMIA(B,TARGET,TX)
   Y2=ARMIA(B,TARGET,TY)
   
   SPEED=ARMIA(A,I,TSZ)/10
   SPEED2=3-SPEED
   If SPEED2<=0 Then SPEED2=1
   If SPEED<=0 Then SPEED=1
   If SPEED>7 Then SPEED=7
   KLATKA=ARMIA(A,I,TKLAT)
   Add KLATKA,1,0 To(SPEED2*4)-1
   ARMIA(A,I,TKLAT)=KLATKA
   KLATKA=KLATKA/SPEED2
   KLATKA=AN(KLATKA)
   STREFA2=Zone(X1,Y1+30)
   STREFA=Zone(X1,Y1+1)
   If STREFA>30 and STREFA<41
      PLAPKA[STREFA-30,A,I,X1,Y1]
      If Param=1
         Goto OVER
      End If 
   End If 
   If STREFA2>20 and STREFA2<31
      Limit Bob I2,0,0 To 640,114
   Else 
      Limit Bob I2,0,0 To 640,512
   End If 
   
   ROZX=X2-X1
   ROZY=Y2-Y1
   If Abs(ROZX)>53
      ZNX=Sgn(ROZX)
      If ZNX=-1 : BNR=BAZA+4+KLATKA : T=-17 : End If 
      If ZNX=1 : BNR=BAZA+10+KLATKA : T=17 : End If 
      ST=Zone(X1+T,Y1)
      If ST=0 or ST>30 and ST<41 and A=ARM
         Add X1,ZNX*SPEED
      End If 
   End If 
   If Abs(ROZY)>42
      ZNY=Sgn(ROZY)
      If ZNY=-1 : B2=BAZA+1+KLATKA : T=-21 : End If 
      If ZNY=1 : B2=BAZA+7+KLATKA : T=2 : End If 
      ST=Zone(X1,Y1+T)
      If ST=0 or ST>30 and ST<41 and A=ARM
         Add Y1,ZNY*SPEED
         BNR=B2
      End If 
   End If 
   If Abs(ROZX)<=53 and Abs(ROZY)<=42
      ARMIA(A,I,TTRYB)=0
      GADKA[I,TARGET]
   End If 
   ARMIA(A,I,TX)=X1
   ARMIA(A,I,TY)=Y1
   Set Zone I2,X1-15,Y1-15 To X1+15,Y1
   Bob I2,X1,Y1,BNR
   OVER:
End Proc
Procedure GADKA[NR,B]
   OSOBA=B
   AGRESJA=ARMIA(WRG,B,TKORP)
   AG2=AGRESJA/50
   CODP=ARMIA(WRG,B,TPRAWA)
   If CODP<>-1
      If AG2>=3 : CODP=Rnd(2) : End If 
      If AG2=2 : CODP=Rnd(2)+3 : End If 
      If AG2=1 : CODP=Rnd(2)+6 : End If 
      If AG2=0
         If ARMIA(WRG,B,TPRAWA)=0
            If Rnd(2)=1
               CODP=Rnd(24)+9
            Else 
               CODP=9+Rnd(2)
            End If 
            ARMIA(WRG,B,TPRAWA)=CODP
         Else 
            CODP=ARMIA(WRG,B,TPRAWA)
         End If 
      End If 
   End If 
   ARMIA(WRG,B,TGLOWA)=1
   BOMBA1=False
   GODP=4-(AGRESJA/30)
   If GODP<0 Then GODP=0
   If ARMIA(ARM,0,TNOGI)>69 and GODP>=3 and CODP>-1 and Rnd(7)=1
      JP=1
   End If 
   MIASTO=ARMIA(ARM,0,TNOGI)-70
   TAK=False
   Screen 1
   Screen Display 1,130,142,320,150 : View 
   For I=0 To 3
      Paste Bob 0,I*50,1
   Next I
   MSY=MSY+183
   XA=ARMIA(ARM,0,TX) : YA=ARMIA(ARM,0,TY)
   XB=ARMIA(ARM,NR,TX) : YB=ARMIA(ARM,NR,TY)
   
   CELX=ARMIA(WRG,B,TX)
   CELY=ARMIA(WRG,B,TY)
   SRX=(XB+CELX)/2 : SRY=(YB+CELY)/2
   Screen 0
   Bob Off 50 : Bob Off 51 : Bob Update 
   Bob 50,XB,YB,1+BUBY : Bob 51,CELX,CELY,2+BUBY
   Bob Update : Wait Vbl 
   CENTER_V=60
   CENTER[SRX,SRY,1]
   CENTER_V=100
   Screen 1
   For I=0 To 2
      Paste Bob 0,I*50,1
   Next I
   X=10 : Y=20
   GADGET[X,Y-17,120,15,ARMIA$(ARM,NR),6,12,9,30,-1]
   GADGET[X+140,Y-17,150,15,RASY$(ARMIA(WRG,B,TRASA))+" "+ARMIA$(WRG,B),6,12,9,30,-1]
   GADGET[X,Y,130,15,"Co słychać",26,24,25,30,1]
   GADGET[X,Y+18,130,15,"Przyłącz się do nas",26,24,25,30,2]
   GADGET[X,Y+36,130,15,"Oddaj mi swoje pieniądze !",26,24,25,30,3]
   For I=0 To 3
      TYP=PRZYGODY(I,P_TYP)
      If TYP>0
         GTEX$=PRZYGODY$(TYP,2)
         If IM_PRZYGODY$(I)<>""
            DL=Len(GTEX$)
            ZN=Instr(GTEX$,"$")
            GTEX$=GTEX$-"$"
            L$=Left$(GTEX$,ZN-1)
            R$=Right$(GTEX$,DL-ZN-1)
            GTEX$=L$+IM_PRZYGODY$(I)+R$
         End If 
         If PRZYGODY(I,P_LEVEL)>0
            GADGET[X,Y+54+I*18,130,15,GTEX$,26,24,25,30,4+I]
         End If 
      End If 
   Next I
   GADGET[X+140,Y,150,90,"",26,24,25,30,-1]
   GADGET[X+140,Y+100,150,15,"                Exit ",26,24,25,30,8]
   '   ILE=Rnd(100) : Gosub BULI
   
   KONIEC=False
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=1
            BOMBA1#=BOMBA1#-Rnd(2)
            If JP=0
               If BOMBA1#<=2
                  BOMBA1=True
                  GADGET[150,20,150,90,"",26,24,25,30,-1]
                  Gosub LOSOWANIE
                  If STRONA=WIERSZ and WIERSZ=WYRAZ : Edit : End If 
                  
                  For Y=0 To 2
                     For X=0 To 7
                        GADGET[XP+(X*15),YP+(Y*15),13,13,Upper$(ZNAKI$(1+X+Y*8)),24,22,23,30,21+X+Y*8]
                     Next X
                  Next Y
                  GADGET[XP+40,YP+46,36,13,"   OK",24,22,23,30,45]
                  X=0 : Y=0
                  Repeat 
                     If Mouse Click=1
                        If Mouse Zone>20 and Mouse Zone<45
                           OLX=X : OLY=Y
                           GADGET[XP+(OLX*15),YP+(OLY*15),13,13,Upper$(ZNAKI$(1+OLX+OLY*8)),24,22,23,30,-1]
                           I=Mouse Zone-20
                           X=(I mod 8)-1
                           If X=-1 : X=7 : End If 
                           Y=(I-1)/8
                           GADGET[XP+(X*15),YP+(Y*15),13,13,Upper$(ZNAKI$(1+X+Y*8)),21,23,22,13,0]
                        End If 
                        If Mouse Zone=45
                           OLX=X : OLY=Y
                           GADGET[XP+(OLX*15),YP+(OLY*15),13,13,Upper$(ZNAKI$(1+OLX+OLY*8)),24,22,23,30,-1]
                           If I<>L# or OLDL=L#
                              OLDL=L#
                              BOMBA3=True
                              Gosub LOSOWANIE
                           Else 
                              BOMBA1#=80+Rnd(30)
                              BOMBA3=False
                              BOMBA2#=0
                              KONIEC_ZAB=True
                           End If 
                        End If 
                     End If 
                  Until KONIEC_ZAB
                  ERR#=0 : KONIEC_ZAB=False
                  X=10 : Y=20
                  For S=20 To 45 : Reset Zone S : Next 
               End If 
               If CODP=-1
                  A$=PRZYGODY$(PRZYGODY(TRWA_PRZYGODA,P_TYP),8)
               Else 
                  A$=ROZMOWA2$(CODP)
               End If 
               NAPISZ[X+144,Y+15,140,70,A$,TRWA_PRZYGODA,30,25]
            Else 
               JP=0
               If POWER>50
                  LOSUJ1:
                  TYP2=13
               Else 
                  LOSUJ2:
                  TYP2=Rnd(11)+1
               End If 
               If BOMBA1#<=2 : ZAB : End If 
               For I=0 To 3
                  If PRZYGODY(I,P_TYP)=TYP2
                     Goto LOSUJ2
                  End If 
               Next 
               For I=0 To 3
                  TYP=PRZYGODY(I,P_TYP)
                  If TYP=0
                     NOWA_PRZYGODA[ARM,I,TYP2,Rnd(3)+1]
                     A$=PRZYGODY$(TYP2,1)
                     NAPISZ[X+144,Y+15,140,70,A$,I,30,25]
                     GTEX$=PRZYGODY$(TYP2,2)
                     If IM_PRZYGODY$(I)<>""
                        DL=Len(GTEX$)
                        ZN=Instr(GTEX$,"$")
                        GTEX$=GTEX$-"$"
                        L$=Left$(GTEX$,ZN-1)
                        R$=Right$(GTEX$,DL-ZN-1)
                        GTEX$=L$+IM_PRZYGODY$(I)+R$
                     End If 
                     If PRZYGODY(I,P_LEVEL)>0
                        GADGET[X,Y+54+I*18,130,15,GTEX$,26,24,25,30,4+I]
                     End If 
                     I=3
                  End If 
               Next I
            End If 
         End If 
         If STREFA=2
            ODP=GODP
            BOMBA1#=BOMBA1#-Rnd(2)
            A$=ROZMOWA$(1,ODP)
            If BOMBA1#<=2 : ZAB : End If 
            Ink 30 : NAPISZ[X+144,Y+15,140,70,A$,0,30,25]
            If ODP=3 or ODP=4
               JEST=False
               For L=1 To 10
                  If ARMIA(ARM,L,TE)<=0
                     JEST=True
                     L2=L
                     L=10
                  End If 
               Next L
               If JEST
                  TAK=True
                  If ODP=3
                     ILE=(ARMIA(WRG,B,TE)*3)+(ARMIA(WRG,B,TSI)*18)+(ARMIA(WRG,B,TSZ)*9)+(ARMIA(WRG,B,TMAG)*9)
                     Gosub BULI
                  End If 
                  If TAK
                     Screen 0
                     ARMIA(ARM,L2,TRASA)=ARMIA(WRG,B,TRASA)
                     ARMIA(ARM,L2,TSI)=ARMIA(WRG,B,TSI)
                     MXSI=(RASY(ARMIA(ARM,L2,TRASA),1)/2)+30
                     If ARMIA(ARM,L2,TSI)>MXSI : ARMIA(ARM,L2,TSI)=MXSI : End If 
                     ARMIA(ARM,L2,TSZ)=ARMIA(WRG,B,TSZ)
                     ARMIA(ARM,L2,TE)=ARMIA(WRG,B,TE)
                     ARMIA(ARM,L2,TEM)=ARMIA(WRG,B,TEM)
                     ARMIA(ARM,L2,TKLAT)=ARMIA(WRG,B,TKLAT)
                     ARMIA(ARM,L2,TMAG)=ARMIA(WRG,B,TMAG)
                     ARMIA(ARM,L2,TMAGMA)=ARMIA(WRG,B,TMAGMA)
                     ARMIA(ARM,L2,TAMO)=ARMIA(WRG,B,TSZ)
                     ARMIA(ARM,L2,TDOSW)=ARMIA(WRG,B,TDOSW)
                     ARMIA(ARM,L2,TP)=0
                     For I=TGLOWA To TPLECAK+7 : ARMIA(ARM,L2,I)=0 : Next I
                     ARMIA$(ARM,L2)=ARMIA$(WRG,B)
                     ARMIA(WRG,B,TE)=0 : Bob Off 10+B : Reset Zone 10+B : Bob Update : Wait Vbl 
                     ARMIA(WRG,B,TTRYB)=0
                     ARMIA(ARM,L2,TX)=ARMIA(WRG,B,TX)
                     ARMIA(ARM,L2,TY)=ARMIA(WRG,B,TY)
                     BAZA=RASY(ARMIA(ARM,L2,TRASA),7)
                     X=ARMIA(ARM,L2,TX)
                     Y=ARMIA(ARM,L2,TY)
                     ARMIA(ARM,L2,TBOB)=BAZA
                     Bob L2,X,Y,BAZA+1 : Bob Update : Wait Vbl 
                     Set Zone L2,X-16,Y-20 To X+16,Y
                     Screen 1
                     Repeat : Until Mouse Click=1
                     KONIEC=True
                  End If 
               Else 
                  A$="Niestety ale w twoim oddziale nie ma już miejsca."
                  NAPISZ[X+144,Y+15,140,70,A$,0,30,25]
               End If 
               
            End If 
         End If 
         If STREFA=3
            ODP=GODP
            If ARMIA(WRG,B,TRASA)=9
               GUL=30
            Else 
               GUL=30+Rnd(50)
            End If 
            Add AGRESJA,GUL,AGRESJA To 190
            ARMIA(WRG,B,TKORP)=AGRESJA
            GODP=4-(AGRESJA/40)
            BOMBA2#=BOMBA2#+Rnd(1)
            A$=ROZMOWA$(2,ODP)
            If BOMBA2#>125 : ZAB : End If 
            Ink 30 : NAPISZ[X+144,Y+15,140,70,A$,0,30,25]
            If ODP=4
               F=Rnd(100)
               Add GRACZE(1,1),F
               Text X+164,Y+25,Str$(F)
            End If 
         End If 
         If STREFA>3 and STREFA<8
            TAK=False
            NR=STREFA-4
            PX=PRZYGODY(NR,P_X)
            PY=PRZYGODY(NR,P_Y)
            LEVEL=PRZYGODY(NR,P_LEVEL)
            BOMBA2#=BOMBA2#+1.3
            TYP=PRZYGODY(NR,P_TYP)
            If BOMBA2#>131 : ZAB : End If 
            CENA=PRZYGODY(NR,P_CENA)
            If AGRESJA<50
               If PX=MIASTO
                  If OSOBA=PY
                     If CENA>0 and Rnd(2)<>0
                        ILE=CENA : Gosub BULI
                     Else 
                        TAK=True
                     End If 
                     If TAK
                        If LEVEL>2
                           ODP=1
                        End If 
                        If LEVEL=2
                           ODP=2
                        End If 
                        If LEVEL=1
                           ODP=3
                        End If 
                        PRZYGODY[XA,YA,NR]
                        PRZYGODY(NR,P_STAREX)=MIASTO
                        If PRZYGODY(NR,P_LEVEL)=0
                           GADGET[X,Y+54+NR*18,130,15,"",26,24,25,30,-1]
                           Reset Zone 4+NR
                        End If 
                     Else 
                        ODP=0
                     End If 
                     A$=PRZYGODY$(TYP,3+ODP)
                  Else 
                     If Rnd(1)=1
                        If ARMIA(40,PY,TRASA)=4
                           B$=" powinna"
                        Else 
                           B$=" powinien"
                        End If 
                        A$=RASY$(ARMIA(40,PY,TRASA))+" "+ARMIA$(40,PY)+B$+" coś wiedzieć."
                     Else 
                        A$=PRZYGODY$(TYP,3)
                     End If 
                  End If 
               Else 
                  ODP=0
                  If OSOBA>6 and LEVEL>1 and PRZYGODY(NR,P_STAREX)<>MIASTO
                     If CENA>0 and Rnd(2)<>0
                        ILE=CENA : Gosub BULI
                     Else 
                        TAK=True
                     End If 
                     If TAK
                        ODP=2
                     Else 
                        ODP=0
                     End If 
                  End If 
                  A$=PRZYGODY$(TYP,3+ODP)
               End If 
            Else 
               A$="Daj mi spokój."
            End If 
            NAPISZ[X+144,Y+15,140,70,A$,NR,30,25]
         End If 
         If STREFA=8
            KONIEC=True
         End If 
      End If 
   Until KONIEC
   Goto OVER
   '----
   BULI:
   KONIEC2=False
   Ink 25 : Bar X+141,Y+1 To X+140+148,Y+82
   Ink 30
   Text X+144,Y+15,"to będzie cię kosztowało "
   Text X+144,Y+25,Str$(ILE)+" sztuk złota"
   Text X+144,Y+35,"Płacisz ?"
   GADGET[X+144,Y+60,25,15,"Tak",7,9,11,0,10]
   GADGET[X+260,Y+60,25,15,"Nie",7,9,11,0,11]
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=10 and GRACZE(1,1)-ILE>=0
            Add GRACZE(1,1),-ILE
            TAK=True
            KONIEC2=True
         End If 
         If STREFA=11
            TAK=False
            KONIEC2=True
         End If 
      End If 
   Until KONIEC2
   Reset Zone 10 : Reset Zone 11
   Ink 25 : Bar X+141,Y+1 To X+140+148,Y+82
   Return 
   '----- 
   LOSOWANIE:
   A#=Abs(BOARD#(Rnd(125)))
   '   A#=Abs(BOARD#(1))
   OLDL=L#
   _POINTER=(A#*10000+1) mod 100
   STRONA=Int(A#)
   WIERSZ=((A#-STRONA)*10)+1
   BOMBA1=False
   WYRAZ=(Int(((A#*10)-Int(A#*10))*10))+1
   'Print _POINTER
   L#=LITERY#(_POINTER)
   L1=Abs(L#*100)
   L2=Abs((L#*100)/100)
   L2=L2*100
   L#=L1-L2
   XP=163 : YP=46
   Ink 25 : Bar XP,YP-24 To XP+120,YP
   If OLDL=L#
      'Bell  
      ERR#=ERR#+0.01
   Else 
      ERR#=ERR#+0.02
   End If 
   'Print ERR#,OLDL,L#
   Ink 30,25
   BOMBA4=False
   Text XP,YP-15,"Podaj pierwszą literę wyrazu."
   'zamiast edit jakiś poke niszczący system' 
   If ERR#>0.04 : Set Zone 300,0,0 To 100,100 : BOMBA3=True : End If 
   Text XP,YP-5,Str$(STRONA)+" strona,"+Str$(WIERSZ)+" wiersz,"+Str$(WYRAZ)+" wyraz"
   Return 
   '--------------- 
   OVER:
   MSY=278 : Screen 0 : CENTER[XB,YB,0] : Bob Off 51 : Bob Update : Wait Vbl 
   Screen 1 : Reset Zone : Screen Display 1,130,275,320,25 : View 
   EKRAN1
   Screen 0
   If BOMBA1 : BOMBA1=2/ZERO : End If 
End Proc
'----
Procedure SKLEP[MIASTO,SNR,A,NR2]
   NR=NR2
   TYP=MIASTA(MIASTO,SNR,M_LUDZIE)
   PUPIL=MIASTA(MIASTO,SNR,M_PODATEK)
   If TYP=4 : A$="sklep1.hb" : End If 
   If TYP=5 : A$="sklep2.hb" : End If 
   If TYP=6 : A$="sala.hb" : End If 
   If TYP=7 : A$="sklep1.hb" : End If 
   If TYP=8 : A$="yodi.hb" : End If 
   If TYP=9 : Gosub SPICHLERZ : Goto OVER : End If 
   Screen Close 2
   For I=50 To 13 Step -1 : Mvolume I : Wait Vbl : Next 
   _LOAD[KAT$+"dane/grafika/"+A$,"dane:grafika/"+A$,"Dane",5]
   If TYP=5
      Flash 1,"(eee,5)(fff,6)"
      Flash 29,"(ec8,5)(fd9,1)(fea,1)(ffb,2)(fea,1)(fd9,2)"
      Flash 30,"(fd8,5)(fe9,2)(ffa,2)(fe9,1)"
      Flash 28,"(ea8,5)(fb9,3)(fca,4)"
      Flash 24,"(e96,5)(fa7,3)(fb8,3)"
   End If 
   If TYP=4 or TYP=7
      Flash 1,"(eee,9)(fff,6)"
      Flash 29,"(f72,6)(f83,6)(f94,6)"
      Flash 30,"(fc6,9)(fd6,9)"
      Flash 28,"(d85,8)(e96,6)(ea7,4)"
   End If 
   Screen Display 2,130,40,320,244 : Screen To Front 2
   Reserve Zone 10
   Set Font FON1
   Ink 21,0
   Gr Writing 0
   Get Block 1,20,180,112,30
   Get Block 2,240,5,64,25
   Get Block 3,240,180,80,20
   '   Box 220,180 To 220+96,210
   Screen To Front 1 : Screen Display 1,130,255,320,44
   Screen 1 : View 
   Reset Zone 
   Set Font FON1
   Paste Bob 0,0,1
   Colour 0,$310
   GADGET[6,2,200,40,"",19,6,0,1,-1]
   GADGET[234,2,80,40,"",19,6,0,1,-1]
   GADGET[210,2,20,16," «",5,0,8,1,1]
   GADGET[210,24,20,16," »",5,0,8,1,2]
   Gosub KLIENT
   Gosub SZMAL
   Gr Writing 1
   I=0
   For Y=0 To 1
      For X=0 To 9
         If SKLEP(SNR,I)>0
            B1=BRON(SKLEP(SNR,I),B_BOB)
            Paste Bob 8+X*20,4+Y*20,BROBY+B1
         End If 
         Set Zone 10+I,8+X*20,4+Y*20 To 28+X*20,24+Y*20
         Inc I
      Next X
   Next Y
   
   Gosub PLECAK
   
   Repeat 
      If Mouse Click=1
         I=Mouse Zone
         If I=1
            GADGET[210,2,20,16," «",0,5,10,1,0]
            GADGET[210,2,20,16," «",5,0,8,1,-1]
            AG2:
            Add NR,1,1 To 10
            If ARMIA(ARM,NR,TE)<=0 : Goto AG2 : End If 
            Gosub PLECAK
            Gosub KLIENT
         End If 
         If I=2
            GADGET[210,24,20,16," »",0,5,10,1,0]
            GADGET[210,24,20,16," »",5,0,8,1,-1]
            AG1:
            Add NR,-1,1 To 10
            If ARMIA(ARM,NR,TE)<=0 : Goto AG1 : End If 
            Gosub PLECAK
            Gosub KLIENT
         End If 
         
         If I>9 and I<38
            I2=I-10
            BRO=SKLEP(SNR,I2)
            If BRO>0
               B1=BRON(BRO,B_BOB)
               BRO1$=BRON2$(BRON(BRO,B_TYP))
               BRO2$=BRON$(BRO)
               TYPB=BRON(BRO,B_TYP)
               CENA=BRON(BRO,B_CENA)+((BRON(BRO,B_CENA)*MIASTA(MIASTO,TYPB,M_MUR))/100)
               If GRACZE(1,1)-CENA>=0
                  ZNAK=-1
                  A$=BRO1$+" "+BRO2$
                  B$="kosztuje :"+Str$(CENA)
                  Gosub NAPISZ
                  SKLEP(SNR,I2)=0
                  If I2<10
                     Y=4
                     X=8+I2*20
                  Else 
                     Y=24
                     X=8+(I2-10)*20
                  End If 
                  Ink 0 : Bar X,Y To X+16,Y+16
                  Gosub PICK
               Else 
                  A$=BRO1$+" "+BRO2$
                  B$="Nie dla ciebie "+Str$(CENA)
                  Gosub NAPISZ
               End If 
            End If 
         End If 
         If I>39 and I<48
            I2=I-40
            BRO=ARMIA(A,NR,TPLECAK+I2)
            If BRO>0
               B1=BRON(BRO,B_BOB)
               BRO1$=BRON2$(BRON(BRO,B_TYP))
               BRO2$=BRON$(BRO)
               A$=BRO1$+" "+BRO2$
               TYPB=BRON(BRO,B_TYP)
               CENA=BRON(BRO,B_CENA)+((BRON(BRO,B_CENA)*MIASTA(MIASTO,TYPB,M_MUR))/100)
               CENA=CENA-((CENA*10)/100)
               ZNAK=1
               B$="Zapłacę "+Str$(CENA)
               Gosub NAPISZ
               ARMIA(A,NR,TPLECAK+I2)=0
               If I2<4
                  Y=4
                  X=236+I2*20
               Else 
                  Y=24
                  X=236+(I2-4)*20
               End If 
               Ink 0 : Bar X,Y To X+16,Y+16
               Gosub PICK
            End If 
         End If 
      End If 
      If Inkey$="q" or Mouse Key=PRAWY
         KONIEC=True
      End If 
   Until KONIEC
   Goto OVER
   
   NAPISZ:
   Screen 2
   Put Block 1,20,180
   OUTLINE[20,192,A$,31,0]
   OUTLINE[20,205,B$,31,0]
   Screen 1
   Return 
   
   SZMAL:
   Screen 2
   Set Font FON2
   Put Block 2,240,5
   OUTLINE[240,15,Str$(GRACZE(1,1)),31,0]
   '   OUTLINE[40,15,BRON2$(PUPIL),31,0]
   Set Font FON1
   Screen 1
   
   Return 
   
   KLIENT:
   Screen 2
   Put Block 3,240,180
   OUTLINE[240,190,ARMIA$(A,NR)+" "+RASY$(ARMIA(A,NR,TRASA)),31,0]
   Screen 1
   Return 
   
   PLECAK:
   Ink 0 : Bar 235,3 To 235+78,3+38
   For I=0 To 3
      If ARMIA(A,NR,TPLECAK+I)>0
         B1=BRON(ARMIA(A,NR,TPLECAK+I),B_BOB)
         Paste Bob 236+I*20,4,BROBY+B1
      End If 
      Set Zone 40+I,236+I*20,4 To 256+I*20,24
      If ARMIA(A,NR,TPLECAK+I+4)>0
         B2=BRON(ARMIA(A,NR,TPLECAK+I+4),B_BOB)
         Paste Bob 236+I*20,24,BROBY+B2
      End If 
      Set Zone 44+I,236+I*20,24 To 256+I*20,44
   Next I
   Return 
   
   PICK:
   Hide On 
   BB=BRON(BRO,B_BOB)+BROBY
   TYP=BRON(BRO,B_TYP)
   Repeat 
      XM=X Screen(X Mouse)
      YM=Y Screen(Y Mouse)
      Hot Spot BB,$11
      Sprite 53,X Mouse,Y Mouse,BB : Wait Vbl 
      If Mouse Click=1
         Sprite Off 53 : Wait Vbl 
         Hot Spot BB,$0
         J=Zone(XM,YM)
         If J>9 and J<38
            J2=J-10
            BR1=SKLEP(SNR,J2)
            If BR1=0
               If J2<10
                  Y=4
                  X=8+J2*20
               Else 
                  Y=24
                  X=8+(J2-10)*20
               End If 
               Paste Bob X,Y,BB
               SKLEP(SNR,J2)=BRO
               KONIEC=True
               If ZNAK=1
                  Add GRACZE(1,1),CENA*ZNAK
                  Gosub SZMAL
               End If 
            End If 
         End If 
         If J>39 and J<48
            J2=J-40
            BR1=ARMIA(A,NR,TPLECAK+J2)
            If BR1=0
               If J2<4
                  Y=4
                  X=236+J2*20
               Else 
                  Y=24
                  X=236+(J2-4)*20
               End If 
               Paste Bob X,Y,BB
               ARMIA(A,NR,TPLECAK+J2)=BRO
               KONIEC=True
               If ZNAK=-1 and GRACZE(1,1)+(CENA*ZNAK)>=0
                  Add GRACZE(1,1),CENA*ZNAK
                  Gosub SZMAL
               End If 
            End If 
         End If 
         
      End If 
   Until KONIEC
   'WAGA
   'Gosub WYPISZ
   KONIEC=False
   Show On 
   Return 
   
   SPICHLERZ:
   Screen Close 2
   Screen Hide 1
   For I=50 To 13 Step -1 : Mvolume I : Wait Vbl : Next 
   _LOAD[KAT$+"dane/grafika/piekarz.hb","dane:grafika/piekarz.hb","Dane",5]
   Screen Display 2,130,40,320,244 : View 
   Reserve Zone 3
   WOJSKO=ARMIA(ARM,0,TAMO) : SPICH=MIASTA(MIASTO,1,M_LUDZIE) : SZMAL=GRACZE(1,1) : CENA=10+((10*MIASTA(MIASTO,17,M_MUR))/100)
   If WOJSKO<0 : WOJSKO=0 : End If 
   Gr Writing 0
   Set Font FON2
   Get Block 1,245,12,64,20 : OUTLINE[250,25,Str$(SZMAL),30,2]
   OUTLINE[15,25,"Dzisiejsza cena:",30,2]
   OUTLINE[60,40,Str$(CENA),30,2]
   OUTLINE[15,210,"W Spichlerzu:",30,2]
   Get Block 2,60,220,64,25 : OUTLINE[60,230,Str$(SPICH),30,2]
   OUTLINE[190,210,"Legion 1 :",30,2]
   Get Block 3,215,220,64,25 : OUTLINE[215,230,Str$(WOJSKO),30,2]
   Set Font FON1
   GADGET[140,215,12,15,"<",25,7,16,30,1]
   GADGET[160,215,12,15,">",25,7,16,30,3]
   Pen 30
   Repeat 
      MYSZ=Mouse Key
      If MYSZ=LEWY
         STREFA=Mouse Zone
         If STREFA=1 or STREFA=3
            ZNAK=STREFA-2
            Gosub ROZPIS
            Wait 10
            While Mouse Key=LEWY
               Gosub ROZPIS
            Wend 
         End If 
      End If 
   Until MYSZ=PRAWY
   ARMIA(ARM,0,TAMO)=WOJSKO : MIASTA(MIASTO,1,M_LUDZIE)=SPICH : GRACZE(1,1)=SZMAL
   Screen Show 1
   Return 
   
   ROZPIS:
   If SPICH=0 and ZNAK=1 : ZNAK=0 : End If 
   If WOJSKO=0 and ZNAK=-1 : ZNAK=0 : End If 
   If WOJSKO>320 and ZNAK=1 : ZNAK=0 : End If 
   If SZMAL-ZNAK*CENA<0 and ZNAK=1 : ZNAK=0 : End If 
   If ZNAK<>0
      Add WOJSKO,ZNAK
      Add SPICH,-ZNAK
      Add SZMAL,-ZNAK*CENA
      Set Font FON2
      Put Block 1 : OUTLINE[250,25,Str$(SZMAL),30,2] : Wait Vbl 
      Put Block 2 : Put Block 3
      Text 60,230,Str$(SPICH)
      Text 215,230,Str$(WOJSKO)
   End If 
   Return 
   
   OVER:
   Screen Close 2
   Flash Off 
   Screen Open 2,64,50,32,Lowres : Curs Off : Flash Off 
   Screen Hide : Screen To Back 
   Del Block 
   Screen 1 : Colour 0,$0 : Screen Display 1,130,275,320,25 : Reset Zone : EKRAN1
   Add ARMIA(A,NR2,TY),8
   ARMIA(A,NR2,TTRYB)=0
   '   SELECT[A,NUMER]
   Screen 0
   View 
   For I=13 To 50 : Mvolume I : Wait Vbl : Next 
End Proc
'----
Procedure _ATAK[TYP]
   _GET_XY[2,0,0]
If TYP=6 : WROG=False : Else : WROG=True : End If 
   Screen 0
   Bob Off 30+NUMER
   STREFA=Zone(OX,OY)
   If STREFA>10 and STREFA<21
      A=WRG
      Add STREFA,-10
      'żeby nie gadali ze zwierzakami
      If ARMIA(A,STREFA,TRASA)<10
         WROG=True
      End If 
   Else 
      A=ARM
   End If 
   If STREFA>0 and STREFA<11 and WROG
      ARMIA(ARM,NUMER,TCELX)=STREFA
      ARMIA(ARM,NUMER,TCELY)=A
      ARMIA(ARM,NUMER,TTRYB)=TYP
      X=ARMIA(A,STREFA,TX)
      Y=ARMIA(A,STREFA,TY)
      Bob 51,X,Y,2+BUBY : Bob Update : Wait Vbl 
   End If 
   While Mouse Key=LEWY : Wend 
End Proc
Procedure CZARY[BL,BP]
   B1=ARMIA(ARM,NUMER,TLEWA)
   B2=ARMIA(ARM,NUMER,TPRAWA)
   If BP=12
      CZAR_TYP=BRON(B2,B_DOSW)
      BR=B2
   End If 
   If BL=12
      CZAR_TYP=BRON(B1,B_DOSW)
      BR=B1
   End If 
   MAG=BRON(BR,B_MAG)
   MAG2=ARMIA(ARM,NUMER,TMAG)
   If MAG>MAG2
      Screen 1
      GADUP[3]
      Goto OVER
   End If 
   
   If CZAR_TYP=1 or CZAR_TYP=9
      _GET_XY[0,0,0]
      Add MAG2,-MAG
      ARMIA(ARM,NUMER,TMAG)=MAG2
      ARMIA(ARM,NUMER,TCELX)=OX
      ARMIA(ARM,NUMER,TCELY)=OY
      ARMIA(ARM,NUMER,TTRYB)=4
      Screen 0 : Bob 51,OX,OY+12,2+BUBY : Bob Update : Wait Vbl 
      X1=ARMIA(ARM,NUMER,TX)
      Y1=ARMIA(ARM,NUMER,TY)-20
      DX#=OX-X1
      DY#=OY-Y1
      L#=Sqr(DX#*DX#+DY#*DY#)+1
      VX#=DX#/L#
      VY#=DY#/L#
      VEKTOR#(NUMER,1)=VX#*6
      VEKTOR#(NUMER,2)=VY#*6
      If CZAR_TYP=1
         VEKTOR#(NUMER,3)=X1
      Else 
         VEKTOR#(NUMER,3)=0
      End If 
      VEKTOR#(NUMER,4)=Y1
      VEKTOR#(NUMER,0)=BR
   Else 
      _GET_XY[2,0,0]
      STREFA=Zone(OX,OY)
      If STREFA>10
         A=WRG
         Add STREFA,-10
      Else 
         A=ARM
      End If 
      If STREFA>0 and STREFA<11
         VEKTOR#(NUMER,0)=BR
         ARMIA(ARM,NUMER,TCELX)=STREFA
         ARMIA(ARM,NUMER,TCELY)=A
         ARMIA(ARM,NUMER,TTRYB)=5
         X=ARMIA(A,STREFA,TX)
         Y=ARMIA(A,STREFA,TY)
         Bob 51,X,Y,2+BUBY : Bob Update : Wait Vbl 
      Else 
         GADUP[3]
      End If 
      While Mouse Key=LEWY : Wend 
   End If 
   OVER:
End Proc
Procedure STRZAL
   B1=ARMIA(ARM,NUMER,TLEWA)
   B2=ARMIA(ARM,NUMER,TPRAWA)
   BT1=BRON(B1,B_TYP)
   BT2=BRON(B2,B_TYP)
   BT3=RASY(ARMIA(ARM,NUMER,TRASA),4)
   'szybkość lotu pocisku 
   CZAD=4
   If(BT1=4 and BT2=5 and STRZALY(NUMER)>0) or(BT1=5 and BT2=4 and STRZALY(NUMER)>0) or(BT1=15 and BT2=16) or(BT1=16 and BT2=15) or(BT1=9 and BT2<>12) or(BT2=9 and BT1<>12)
      VEKTOR#(NUMER,0)=BRON(B1,B_SI)+BRON(B2,B_SI)
      If BT1=4 or BT2=4
         Dec STRZALY(NUMER)
      End If 
      If BT1=9
         VEKTOR#(NUMER,0)=BRON(B1,B_SI)*3
         PRZELICZ[3,-1]
         ARMIA(ARM,NUMER,TLEWA)=0
         VEKTOR#(NUMER,5)=B1
         Goto SKIP
      End If 
      If BT2=9
         VEKTOR#(NUMER,0)=BRON(B2,B_SI)*3
         PRZELICZ[4,-1]
         ARMIA(ARM,NUMER,TPRAWA)=0
         VEKTOR#(NUMER,5)=B2
         Goto SKIP
      End If 
      If BT1=16
         VEKTOR#(NUMER,0)=-VEKTOR#(NUMER,0)
         ARMIA(ARM,NUMER,TLEWA)=0
      End If 
      If BT2=16
         VEKTOR#(NUMER,0)=-VEKTOR#(NUMER,0)
         ARMIA(ARM,NUMER,TPRAWA)=0
      End If 
      SKIP:
      If BT3=BT1 or BT3=BT2
         'rasa bonus
         VEKTOR#(NUMER,0)=VEKTOR#(NUMER,0)+10
      End If 
      
      _GET_XY[0,0,0]
      ARMIA(ARM,NUMER,TCELX)=OX
      ARMIA(ARM,NUMER,TCELY)=OY
      ARMIA(ARM,NUMER,TTRYB)=3
      Screen 0 : Bob 51,OX,OY+12,2+BUBY : Bob Update : Wait Vbl 
      Bob Off 30+NUMER
      X1=ARMIA(ARM,NUMER,TX)
      Y1=ARMIA(ARM,NUMER,TY)-20
      DX#=OX-X1
      DY#=OY-Y1
      L#=Sqr(DX#*DX#+DY#*DY#)+1
      VX#=DX#/L#
      VY#=DY#/L#
      If BT1=4 or BT1=5 or BT1=9 or BT2=9
         Screen 2
         Cls 0
         X#=15 : Y#=15
         For I=1 To 20
            X#=X#+VX# : Y#=Y#+VY#
            Ink 19 : Plot X#,Y#+15
            Ink 15 : Plot X#,Y#
         Next I
         Get Sprite BSIBY+NUMER,0,0 To 31,31 : Wait Vbl 
         Hot Spot BSIBY+NUMER,$11
      End If 
      VEKTOR#(NUMER,1)=VX#*6
      VEKTOR#(NUMER,2)=VY#*6
      VEKTOR#(NUMER,3)=X1
      VEKTOR#(NUMER,4)=Y1
   Else 
      If BT1<>12 and BT2<>12 : GADUP[3] : End If 
   End If 
   If BT1=12 or BT2=12 : CZARY[BT1,BT2] : End If 
End Proc
Procedure ZABIJ[A,NR,CICHO]
   RASA=ARMIA(A,NR,TRASA)
   If RASA>9
      SAM=3
      Sam Bank 5
   Else 
      SAM=7
   End If 
   FX[SAM]
   Sam Bank 4
   ARMIA(A,NR,TE)=0
   ARMIA(A,NR,TTRYB)=0
   X=ARMIA(A,NR,TX)
   Y=ARMIA(A,NR,TY)
   SEKTOR[X,Y] : SEK=Param
   For I=0 To 3
      If GLEBA(SEK,I)=0
         If A=ARM
            GLEBA(SEK,I)=ARMIA(A,NR,TKORP+I)
         Else 
            If RASA>9
               BR=RASY(RASA,3+Rnd(1))
               GLEBA(SEK,I)=BR
            Else 
               If Rnd(2)=0
                  LOSUJ:
                  BR=Rnd(MX_WEAPON)
                  If BRON(BR,B_CENA)<(ARMIA(A,NR,TDOSW)*30)+ARMIA(A,NR,TSI)
                     GLEBA(SEK,I)=BR
                  Else 
                     Goto LOSUJ
                  End If 
               End If 
            End If 
         End If 
      End If 
   Next I
   BAZA=ARMIA(A,NR,TBOB)
   If A=WRG
      Add NR,10
      For I=1 To 10
         Add ARMIA(A,I,TKORP),-Rnd(20),1 To ARMIA(A,I,TKORP)
      Next I
   End If 
   Bob Off NR
   Bob Off 30+NR
   Bob Update : Wait Vbl 
   KB=BAZA+16
   If Rnd(1)=0 : KB=Hrev(BAZA+16) : End If 
   STREFA2=Zone(X,Y+30)
   If CICHO=0 and(STREFA2<20 or STREFA2>31) and SCENERIA<>7 and PREFS(4)=1
      Autoback 2 : Paste Bob X-24,Y-20,KB : Wait 2 : Autoback 1
   End If 
   Reset Zone NR
End Proc
Procedure WYKRESY[A,NR]
   SILA=ARMIA(A,NR,TSI) : If SILA>80 : SILA=80 : End If 
   SPEED=ARMIA(A,NR,TSZ) : SPEEDM=ARMIA(A,NR,TAMO)
   ENERGIA=ARMIA(A,NR,TE) : If ENERGIA<0 : ENERGIA=0 : End If 
   ENERGIAM=ARMIA(A,NR,TEM)
   MAGIA=ARMIA(A,NR,TMAG)
   MAGIAM=ARMIA(A,NR,TMAGMA)
   Ink 19,19 : Bar 3,3 To 3+138,3+18
   
   If A=WRG and ARMIA(WRG,NR,TGLOWA)=0
      Ink 5,19 : Text 12,14,"brak danych"
   Else 
      Clip 4,4 To 4+73,20
      Ink 2 : Box 4,4 To 4+(ENERGIAM/3),6 : Ink 20 : Draw 4,5 To 4+(ENERGIA/3),5
      
      Ink 3 : Bar 4,8 To 5+SILA,10 : Ink 15 : Draw 4,9 To 5+SILA,9
      Ink 18 : Box 4,16 To 4+MAGIAM,18 : Ink 13 : Draw 4,17 To 4+MAGIA,17
      If A=WRG
         Ink 4 : Bar 4,12 To 4+SPEED,14 : Ink 16 : Draw 4,13 To 4+SPEED,13
         Clip 
         If ARMIA(A,NR,TRASA)>9
            RA$=RASY$(ARMIA(A,NR,TRASA))
         Else 
            RA$=ARMIA$(A,NR)
         End If 
         Ink 5 : Text 90,10,RA$
         MORALE=ARMIA(WRG,NR,TKORP)/50
         If MORALE<0 : MORALE=0 : End If 
         If MORALE>4 : MORALE=4 : End If 
         Text 90,20,GUL$(MORALE+5)
      Else 
         Clip 4,4 To 4+73,20
         Ink 4 : Box 4,12 To 4+SPEEDM,14 : Ink 16 : Draw 4,13 To 4+SPEED,13
      End If 
      Clip 
   End If 
   If A=ARM
      LB=BRON(ARMIA(ARM,NR,TLEWA),B_BOB)
      RB=BRON(ARMIA(ARM,NR,TPRAWA),B_BOB)
      If LB>0 : Paste Bob 108,3,LB+BROBY : Set Zone 20,108,3 To 108+16,3+16 : End If 
      If RB>0 : Paste Bob 124,3,RB+BROBY : Set Zone 21,124,3 To 124+16,3+16 : End If 
      Gr Writing 0
      Ink 13,20 : Text 80,15,ARMIA$(A,NR)
      Gr Writing 1
   End If 
   While Mouse Key=LEWY
   Wend 
End Proc
Procedure BRON_INFO[STREFA]
   If STREFA=20 : BRO=ARMIA(ARM,NUMER,TLEWA) : End If 
   If STREFA=21 : BRO=ARMIA(ARM,NUMER,TPRAWA) : End If 
   Get Block 1,3,3,96,18
   Gr Writing 0
   OUTLINE[12,14,BRON$(BRO),31,19]
   While Mouse Key=LEWY
   Wend 
   Put Block 1
End Proc
'------- 
Procedure USTAW_WOJSKO[A,XW,YW,TYP]
   X1=XW*200
   Y1=YW*160
   For I=1 To 10
      If ARMIA(A,I,TE)>0
         If A=WRG
            I2=I+10
         End If 
         If A=ARM
            I2=I
         End If 
         
         If TYP=1
            AGAIN2:
            XW2=Rnd(2)
            YW2=Rnd(2)
            If XW2=XW and YW2=YW
               Goto AGAIN2
            End If 
            X1=XW2*200
            Y1=YW2*160
         End If 
         If TYP=2
            X1=Rnd(2)*200
         End If 
         If TYP=3
            Y1=Rnd(2)*160
         End If 
         AGAIN:
         X=Rnd(200)+X1+16
         Y=Rnd(160)+Y1+20
         If Zone(X,Y)=0
            ARMIA(A,I,TX)=X
            ARMIA(A,I,TY)=Y
            BAZA=RASY(ARMIA(A,I,TRASA),7)
            ARMIA(A,I,TBOB)=BAZA
            If A=ARM
               If KTO_ATAKUJE=ARM
                  BNR=BAZA+1
               Else 
                  BNR=BAZA+7
               End If 
               Bob I2,X,Y,BNR
               STREFA2=Zone(X,Y+30)
               If STREFA2>20 and STREFA2<31
                  Limit Bob I2,0,0 To 640,114
               Else 
                  Limit Bob I2,0,0 To 640,512
               End If 
            End If 
            Set Zone I2,X-16,Y-20 To X+16,Y
         Else 
            Goto AGAIN
         End If 
      End If 
   Next I
End Proc
Procedure NOWA_ARMIA[A,ILU,RASA]
   If A<20 : A$="Legion "+Str$(A+1)
      ARMIA$(A,0)=A$
   Else 
      'utajnianie
      ARMIA(A,0,TMAGMA)=30
      ARMIA(A,0,TKORP)=150+Rnd(50)+POWER
   End If 
   ARMIA(A,0,TAMO)=Rnd(200)
   ARMIA(A,0,TE)=ILU
   R=RASA
   For I=1 To ILU
      If RASA=-1 : R=Rnd(8) : End If 
      NOWA_POSTAC[A,I,R]
      Add SILA,ARMIA(A,I,TSI)
      Add SILA,ARMIA(A,I,TE)
      Add SPEED,ARMIA(A,I,TSZ)
   Next I
   SPEED=((SPEED/ILU)/5)
   ARMIA(A,0,TSZ)=SPEED
   ARMIA(A,0,TSI)=SILA
   ARMIA(A,0,TTRYB)=0
End Proc
Procedure NOWA_POSTAC[A,NR,RASA]
   For I=0 To 30 : ARMIA(A,NR,I)=0 : Next I
   ARMIA(A,NR,TRASA)=RASA
   ARMIA(A,NR,TSI)=Rnd(10)+(RASY(RASA,1)/2)
   ARMIA(A,NR,TSZ)=Rnd(10)+RASY(RASA,2)
   ARMIA(A,NR,TE)=(Rnd(20)+RASY(RASA,0))*3
   ARMIA(A,NR,TEM)=ARMIA(A,NR,TE)
   ARMIA(A,NR,TKLAT)=Rnd(3)
   '   ARMIA(A,NR,TDOSW)=99 
   If RASA>9
      ARMIA(A,NR,TKORP)=150+Rnd(60)
      ARMIA(A,NR,TMAG)=BRON(RASY(RASA,6),B_MAG)*5
      ARMIA(A,NR,TMAGMA)=ARMIA(A,NR,TMAG)
      'potwory w plecaku przechowują czar  
      ARMIA(A,NR,TPLECAK)=RASY(RASA,6)
      ARMIA(A,NR,TAMO)=Rnd(20)
      ODP=RASY(RASA,5)
      ARMIA(A,NR,TP)=Rnd(ODP/2)+ODP/2
      ARMIA(A,NR,TDOSW)=Rnd(30)
   Else 
      ARMIA(A,NR,TMAG)=Rnd(5)+RASY(RASA,3)
      ARMIA(A,NR,TMAGMA)=ARMIA(A,NR,TMAG)
   End If 
   If PREFS(1)=1
      ROB_IMIE
      ARMIA$(A,NR)=Param$
   Else 
      ARMIA$(A,NR)="wojownik"+Str$(NR)
   End If 
   If A>19
      If RASA<10
         Add ARMIA(A,NR,TSI),Rnd(POWER)
         ARMIA(A,NR,TP)=Rnd(POWER/2)+POWER/2
         ARMIA(A,NR,TDOSW)=Rnd(POWER/2)+POWER/2
      End If 
   Else 
      'zapasowa prędkość w tamo
      ARMIA(A,NR,TAMO)=ARMIA(A,NR,TSZ)
      'to jest tylko do testów nowej broni 
      If TESTING : For J=0 To 7 : ARMIA(A,NR,TPLECAK+J)=Rnd(MX_WEAPON) : Next J : End If 
      '      ARMIA(A,NR,TPLECAK)=Rnd(3)+1
      
      WAGA[A,NR]
   End If 
End Proc
Procedure POTWOR[A,A$,ILU,RASA]
   For I=1 To 16
      Del Bob POTWORY+1
   Next I
   _LOAD[KAT$+"dane/potwory/"+A$,"dane:potwory/"+A$,"Dane",1]
   _LOAD[KAT$+"dane/potwory/"+A$+".snd","dane:potwory/"+A$+".snd","Dane",9]
   ARMIA(A,0,TE)=ILU
   ARMIA(A,0,TKORP)=RASY(RASA,5)
   For I=1 To ILU
      NOWA_POSTAC[A,I,RASA]
   Next I
End Proc
Procedure ZABIJ_ARMIE[A]
   ARMIA(A,0,TE)=0
   ARMIA(A,0,TAMO)=0
   ARMIA(A,0,TSI)=0
   ARMIA(A,0,TSZ)=0
   ARMIA(A,0,TTRYB)=0
   For I=1 To 10
      ARMIA(A,I,TE)=0
   Next 
End Proc
Procedure ZAB2
   Sprite Off 2 : Amal Off : Show On 
   _LOAD[KAT$+"dane/gad","dane:gad","Dane",1]
   Screen Open 1,320,160,32,Lowres
   Screen 1
   Curs Off : Flash Off 
   Reserve Zone 60 : Get Bob Palette : Set Font FON1
   GOBY=44
   'Auto View On  
   Screen 1
   Screen Hide : View 
   Screen Display 1,130,162,320,140
   For I=0 To 3
      Paste Bob 0,I*50,GOBY+1
   Next I
   Screen Show : View 
   GADGET[150,20,150,90,"",26,24,25,30,-1]
   Gosub LOSOWANIE
   For Y=0 To 2
      For X=0 To 7
         GADGET[XP+(X*15),YP+(Y*15),13,13,Upper$(ZNAKI$(1+X+Y*8)),24,22,23,30,21+X+Y*8]
      Next X
   Next Y
   X=0 : Y=0
   GADGET[XP+40,YP+46,36,13,"   OK",24,22,23,30,45]
   If STRONA=WIERSZ and WIERSZ=WYRAZ : STRONA=STRONA/0 : End If 
   Repeat 
      If Mouse Click=1
         If Mouse Zone>20 and Mouse Zone<45
            OLX=X : OLY=Y
            GADGET[XP+(OLX*15),YP+(OLY*15),13,13,Upper$(ZNAKI$(1+OLX+OLY*8)),24,22,23,30,-1]
            I=Mouse Zone-20
            X=(I mod 8)-1
            If X=-1 : X=7 : End If 
            Y=(I-1)/8
            GADGET[XP+(X*15),YP+(Y*15),13,13,Upper$(ZNAKI$(1+X+Y*8)),21,23,22,13,0]
         End If 
         If Mouse Zone=45
            OLX=X : OLY=Y
            GADGET[XP+(OLX*15),YP+(OLY*15),13,13,Upper$(ZNAKI$(1+OLX+OLY*8)),24,22,23,30,-1]
            If I<>L# or OLDL=L#
               OLDL=L#
               BOMBA3=True
               GAME_OVER=True
               OIUEYPOY=3*RTUE
               Gosub LOSOWANIE
            Else 
               BOMBA1#=82+Rnd(30)
               Add WTTITP,10
               GAME_OVER=False
               BOMBA2#=0
               XCBNCB=False
               BOMBA3=False
               KONIEC=True
               WERWRT=True
            End If 
            If I<>L#

               FFSDF=9
            End If 
         End If 
         CZ=ZIETY/1
         Add ZMIO,2
         WXXX=SIEJA
         Inc ZSALAKSO
      End If 
   Until KONIEC
   Goto OVER
   
   LOSOWANIE:
   A#=Abs(BOARD#(Rnd(125)))
   OLDL=L#
   _POINTER=(A#*10000+1) mod 100
   RUUURURRP=235*FFIURE
   STRONA=Int(A#)
   MNSVKJN=WERWR*23424
   WIERSZ=((A#-STRONA)*10)+1
   Inc XCCB
   BOMBA1=False
   WYRAZ=(Int(((A#*10)-Int(A#*10))*10))+1
   'Print _POINTER
   L#=LITERY#(_POINTER)
   L1=Abs(L#*100)
   CXZXC=Abs(RTET*WER)
   L2=Abs((L#*100)/100)
   VBNCVB=Abs(L2*L#)
   L2=L2*100
   L#=L1-L2
   XP=163 : YP=46
   BOMBA4=False
   Ink 25 : Bar XP,YP-24 To XP+120,YP
   If OLDL=L#
      'Bell  
      ERR#=ERR#+0.01
   Else 
      ERR#=ERR#+0.02
   End If 
   'Print ERR#,OLDL,L#
   Ink 30,25
   Text XP,YP-15,"Podaj pierwszą literę wyrazu."
   'zamiast edit jakiś poke niszczący system' 
   If ERR#>0.04 : ERR#=ARMIA(YP,0,1) : End If 
   Text XP,YP-5,Str$(STRONA)+" strona,"+Str$(WIERSZ)+" wiersz,"+Str$(WYRAZ)+" wyraz"
   Return 
   OVER:
   For S=20 To 45 : Reset Zone S : Next 
   Screen Close 1
   For I=1 To 50
      Del Bob GOBY+1
   Next 
   Screen 0
   Sprite 2,SPX,SPY,1
End Proc
'----------
Procedure WYDAJ_ROZKAZ[NR]
   AGRESJA=ARMIA(WRG,NR,TKORP)
   RASA=ARMIA(WRG,NR,TRASA)
   MAGIA=ARMIA(WRG,NR,TMAG)
   If AGRESJA<50 : RODZAJ=0 : End If 
   If AGRESJA>=50 : RODZAJ=1 : End If 
   If AGRESJA>100 : RODZAJ=2 : End If 
   If AGRESJA>150 : RODZAJ=3 : End If 
   X1=ARMIA(WRG,NR,TX)
   Y1=ARMIA(WRG,NR,TY)
   If RODZAJ=1 or RODZAJ=2 or RODZAJ=3
      STARAODL=WIDOCZNOSC
      WIDAC=False
      For I=1 To 10
         If ARMIA(ARM,I,TE)>0
            X2=ARMIA(ARM,I,TX)
            Y2=ARMIA(ARM,I,TY)
            ODL[X1,Y1,X2,Y2]
            'ODLEG=Param 
            If ODLEG<STARAODL
               TARGET=I
               CX=X2 : CY=Y2
               STARAODL=ODLEG
               WIDAC=True
            End If 
         End If 
      Next I
   End If 
   RAN=Rnd(10)
   If RODZAJ=2
      If WIDAC
         If STARAODL<50
            Gosub _ATAKUJ
         Else 
            If STARAODL<WIDOCZNOSC-60 : Bob 10+NR,X1,Y1,ARMIA(WRG,NR,TBOB)+2 : End If 
            If(ARMIA(WRG,NR,TAMO)>0 or MAGIA>10)
               If RAN<5
                  Gosub STRZELAJ
               End If 
            Else 
               If Rnd(1)=0
                  ARMIA(WRG,NR,TKORP)=90
               Else 
                  ARMIA(WRG,NR,TKORP)=155
               End If 
            End If 
         End If 
      End If 
   End If 
   
   If RODZAJ=3
      If WIDAC
         If(ARMIA(WRG,NR,TAMO)>0 or MAGIA>10) and RAN<2
            Gosub STRZELAJ
         Else 
            Gosub _ATAKUJ
         End If 
      End If 
   End If 
   
   If RODZAJ=0
      Gosub RANDOM
   End If 
   
   If RODZAJ=1
      If STARAODL<50
         Gosub _ATAKUJ
      Else 
         Gosub RANDOM
      End If 
   End If 
   Goto OVER
   
   STRZELAJ:
   If RASA>9 and ARMIA(WRG,NR,TPLECAK)>0
      CZAR=ARMIA(WRG,NR,TPLECAK)
   Else 
      CZAR=42+Rnd(4)
   End If 
   MAG=BRON(CZAR,B_MAG)
   If Rnd(5)=1 and ARMIA(WRG,NR,TMAG)-MAG>=0
      Add ARMIA(WRG,NR,TMAG),-MAG
      CZAR_TYP=BRON(CZAR,B_DOSW)
      If CZAR_TYP=1
         ARMIA(WRG,NR,TCELX)=CX
         Add CY,-10
         ARMIA(WRG,NR,TCELY)=CY
         ARMIA(WRG,NR,TTRYB)=4
         Add Y1,-20
         DX#=CX-X1
         DY#=CY-Y1
         L#=Sqr(DX#*DX#+DY#*DY#)+1
         VX#=DX#/L#
         VY#=DY#/L#
         VEKTOR#(NR+10,1)=VX#*6
         VEKTOR#(NR+10,2)=VY#*6
         VEKTOR#(NR+10,3)=X1
         VEKTOR#(NR+10,4)=Y1
         VEKTOR#(NR+10,0)=CZAR
      Else 
         VEKTOR#(NR+10,0)=CZAR
         ARMIA(WRG,NR,TCELX)=TARGET
         ARMIA(WRG,NR,TCELY)=ARM
         ARMIA(WRG,NR,TTRYB)=5
      End If 
   Else 
      If RASA<9
         Add ARMIA(WRG,NR,TAMO),-1
         ARMIA(WRG,NR,TTRYB)=3
         ARMIA(WRG,NR,TCELX)=CX
         Add CY,-10
         ARMIA(WRG,NR,TCELY)=CY
         Y1=Y1-20
         DX#=CX-X1
         DY#=CY-Y1
         L#=Sqr(DX#*DX#+DY#*DY#)+1
         VX#=DX#/L#
         VY#=DY#/L#
         Screen 2
         Cls 0
         X#=15 : Y#=15
         Ink 3
         For I=1 To 20
            X#=X#+VX# : Y#=Y#+VY#
            Ink 19 : Plot X#,Y#+15
            Ink 18 : Plot X#,Y#
         Next I
         Get Sprite BSIBY+10+NR,0,0 To 31,31 : Wait Vbl 
         Hot Spot BSIBY+10+NR,$11
         VEKTOR#(NR+10,1)=VX#*6
         VEKTOR#(NR+10,2)=VY#*6
         VEKTOR#(NR+10,3)=X1
         VEKTOR#(NR+10,4)=Y1
         If KTO_ATAKUJE=WRG : RN=Rnd(2) : End If 
         If RN=2
            SILA=-(Rnd(50)+20)
         Else 
            SILA=Rnd(50)
         End If 
         VEKTOR#(NR+10,0)=SILA
      End If 
   End If 
   Screen 0
   Return 
   
   _ATAKUJ:
   ARMIA(WRG,NR,TCELX)=TARGET
   ARMIA(WRG,NR,TCELY)=ARM
   ARMIA(WRG,NR,TTRYB)=2
   Return 
   
   RANDOM:
   X2=Rnd(600)+20
   Y2=Rnd(450)+50
   If Zone(X2,Y2)=0
      ARMIA(WRG,NR,TCELX)=X2
      ARMIA(WRG,NR,TCELY)=Y2
      ARMIA(WRG,NR,TTRYB)=1
   End If 
   Return 
   
   OVER:
End Proc
'--------
Procedure SETUP[A$,B$,C$]
   'A$="--------" 
   'B$="Bitwa"
   'C$="********" 
   If PREFS(3)=1 : _TRACK_FADE[1] : End If 
   Erase All 
   Hide On 
   Screen Open 2,80,50,32,Lowres : Curs Off : Flash Off : Screen Display 2,252,140,80,50 : Cls 0
   Set Font FON2
   Ink 19,0
   X=40-(Text Length(A$)/2) : Text X,15,A$
   X=40-(Text Length(B$)/2) : Text X,28,B$
   X=40-(Text Length(C$)/2) : Text X,40,C$
   View 
   '--------------- 
   'Auto View Off 
   Screen Open 0,640,512,32,Lowres : Screen Display 0,130,40,320,234 : Screen 0
   Curs Off : Flash Off : Cls 0
   Priority On : Priority Reverse Off 
   Double Buffer : Autoback 1 : Bob Update Off : Screen Hide 
   Reserve Zone 200
   '------------------
   Screen Open 1,320,160,32,Lowres : Screen Display 1,130,275,320,25 : Screen 1
   Screen Hide 1
   Screen To Front 2
   Screen 1 : Curs Off : Flash Off : Cls 10
   Reserve Zone 100
   _LOAD[KAT$+"dane/gad","dane:gad","Dane",0]
   USTAW_FONT["defender2",8]
   Get Bob Palette : Screen Show 
   '------------------
   Screen 0 : Screen Show 
   Sam Bank 4
   _LOAD[KAT$+"dane/sound","dane:sound","Dane",8]
   Mvolume 50
   _LOAD[KAT$+"dane/glowny","dane:glowny","Dane",1]
   USTAW_FONT["defender2",8]
   Get Bob Palette 
   GOBY=0
   PIKIETY=50
   BUBY=PIKIETY+18+10
   POTWORY=BUBY+131+32
   BIBY=POTWORY+16
   BSIBY=BIBY+12
   CELOWNIK=52
   MSX=320 : MSY=278
   Hot Spot 3+BUBY,$0
   Screen To Back 2
Proc
'----
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
   'skały 
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
      'rozrzucanie złota 
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
      'rozrzucanie złota 
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
      'grota władcy
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
      'dodać domy (9)
      BSIBY=BIBY+12+9
   End If 
   If WIES<-1
      RYSUJ_MUR[WIES]
      'dodać mury (2)  
      BSIBY=BIBY+12+2
   End If 
   'wytnij strzały
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
'----
Procedure CHECK[A]
   SK=Screen
   Screen 1 : Print At(1,1);"        " : Print At(1,1);A : Screen SK
   'Wait Key  
End Proc
Procedure CZEKAJ
   For CZ=1 To AMIGA : Next CZ
End Proc
Procedure SPEED_CHECK
   T=Timer
   For I=1 To 100000 : Next I
   T2=Timer
   AMIGA=20000/(T2-T)
   '   Print "your power:";AMIGA,T2-T 
   '   Wait Key 
End Proc

Procedure ROB_IMIE
   IM$=""
   Dim SAMOGL$(10)
   Dim DZW$(30)
   Restore DANE
   For I=0 To 9
      Read A$
      SAMOGL$(I)=A$
   Next I
   
   For I=0 To 30
      Read A$
      DZW$(I)=A$
   Next I
   
   DL=Rnd(2)+1
   For I=0 To DL
      SAM$=SAMOGL$(Rnd(9))
      SPD$=DZW$(Rnd(30))
      A=Rnd(2)
      If A=0
         IM$=IM$+SAM$
         IM$=IM$+SPD$
      End If 
      If A=1
         IM$=IM$+SPD$
         IM$=IM$+SAM$
      End If 
      If A=2
         IM$=IM$+SAM$
      End If 
   Next I
   L$=Left$(IM$,1) : L$=Upper$(L$)
   R$=Right$(IM$,Len(IM$)-1)
   F$=L$+R$
   DANE:
   Data "a","e","i","o","u","i","a","a","e","o"
   SP:
   Data "c","f","h","k","p","s","t","p","j","s","s","k","t","p","t","f"
   Data "b","d","g","l","m","n","r","w","z","r","r","r","d","z","b","g"
   
End Proc[F$]
Procedure OUTLINE[X,Y,A$,K1,K2]
   Gr Writing 0
   Ink K2 : Text X,Y+1,A$ : Text X+1,Y,A$ : Text X-1,Y,A$ : Text X,Y-1,A$
   Ink K1 : Text X,Y,A$
End Proc
Procedure _M_FADE[SPEED]
   SPEED2=SPEED
   I=43
   If BOMBA3 : A=ARMIA(50,1,1) : End If 
   Repeat 
      Dec I
      Mvolume I
      Wait SPEED
   Until I=0
   Music Stop 
   Mvolume 50
End Proc
Procedure _TRACK_FADE[SPEED]
   SPEED2=SPEED
   I=63
   A=Vumeter(0) : Add A,-1
   B=Vumeter(1) : Add B,-1
   C=Vumeter(2) : Add C,-1
   D=Vumeter(3) : Add D,-1
   Repeat 
      Dec SPEED2
      If SPEED2=0
         Add A,-1,0 To A
         Add B,-1,0 To B
         Add C,-1,0 To C
         Add D,-1,0 To D
         Dec I
         SPEED2=SPEED
      End If 
      Wait Vbl 
      Doke $DFF0A8,A
      Doke $DFF0B8,B
      Doke $DFF0C8,C
      Doke $DFF0D8,D
   Until I=5
   Track Stop 
End Proc


Procedure CENTER[X,Y,FLOOD]
   Add X,-160
   Add Y,-CENTER_V
   If X<0 : X=0 : End If 
   If X>MSX : X=MSX : End If 
   If Y<0 : Y=0 : End If 
   If Y>MSY : Y=MSY : End If 
   If FLOOD>0
      ZX=Sgn(X-SX)*8*FLOOD
      ZY=Sgn(Y-SY)*8*FLOOD
      Repeat 
         If Abs(DX)>Abs(ZX) : Add SX,ZX : End If 
         If Abs(DY)>Abs(ZY) : Add SY,ZY : End If 
         DX=(SX-X)
         DY=(SY-Y)
         Wait Vbl 
         Screen Offset 0,SX,SY : View 
      Until Abs(DX)<=Abs(ZX) and Abs(DY)<=Abs(ZY)
   Else 
      SX=X : SY=Y
      Screen Offset 0,SX,SY : View 
   End If 
   
End Proc
Procedure SKROL[A]
   Auto View On 
   X=X Mouse
   Y=Y Mouse
   XO=X : YO=Y
   XF=X Screen(X)
   YF=Y Screen(Y)
   If PREFS(2)=0
      '      Change Mouse 33 
   Else 
      Limit Mouse 0,0 To 600,600
      Hide On 
   End If 
   While Mouse Key=PRAWY
      Wait Vbl 
      If PREFS(2)=0
         X2=X Screen(X Mouse)
         Y2=Y Screen(Y Mouse)
         DX=XF-X2
         DY=YF-Y2
         SX=SX+DX : SY=SY+DY
      Else 
         DX=(X-X Mouse)*2
         DY=(Y-Y Mouse)*2
         SX=SX-DX : SY=SY-DY
         X=X Mouse : Y=Y Mouse
      End If 
      If SX<0
         SX=0
      End If 
      If SY<0
         SY=0
      End If 
      If SX>MSX
         SX=MSX
      End If 
      If SY>MSY
         SY=MSY
      End If 
      Screen Offset 0,SX,SY
   Wend 
   If PREFS(2)=1
      Limit Mouse 128,40 To 447,298
      X Mouse=XO
      Y Mouse=YO
      Show On 
   End If 
   Auto View Off 
   If A=1 : Change Mouse CELOWNIK : End If 
   ': Else : Change Mouse BUBY+6 : End If 
End Proc
Procedure KLAWSKROL[KLAW]
   Auto View On 
   Repeat 
      If KLAW=76 Then Add SY,-4
      If KLAW=77 Then Add SY,4
      If KLAW=78 Then Add SX,4
      If KLAW=79 Then Add SX,-4
      If SX<0 : SX=0 : End If 
      If SY<0 : SY=0 : End If 
      If SX>MSX : SX=MSX : End If 
      If SY>MSY : SY=MSY : End If 
      Screen Offset 0,SX,SY
      Wait Vbl 
   Until Key State(KLAW)=False
   '   Clear Key  
   Auto View Off 
End Proc
Procedure ODL[X1,Y1,X2,Y2]
   DX=X2-X1
   DY=Y2-Y1
   ODLEG=Abs(Sqr(DX*DX+DY*DY))
End Proc
Procedure FX[SAM]
   Add KANAL,1,1 To 3
   If KANAL=1 : KAN=%10 : End If 
   If KANAL=2 : KAN=%100 : End If 
   If KANAL=3 : KAN=%1000 : End If 
   Sam Play KAN,SAM
End Proc

' PGJ: MAIN_LOOP
'** PROCEDURY DO MAPY ************ 
Procedure MAPA_AKCJA
   Inc DZIEN
   BUSY_ANIM
   'wygaszanie konfliktów zbrojnych przez NATO
   For I=0 To 5
      For J=0 To 5
         Add WOJNA(I,J),-1,0 To WOJNA(I,J)
      Next 
   Next 
   'wszczynanie dużych wojen
   SR=0
   For PL=1 To 4 : OBLICZ_POWER[PL] : SR=SR+Param : Next 
   POWER=(GRACZE(1,2)/900)+7 : If POWER>99 : POWER=99 : End If 
   SR=SR/4
   '   Pen 21 : Print At(1,0);"power:",POWER,GRACZE(1,2),SR 
   OLDSI=0
   For I=1 To 4
      SI=GRACZE(I,2)
      If SI>SR+((40*SR)/100) and SI>OLDSI
         OLDSI=SI
         For J=2 To 4 : WOJNA(J,I)=Rnd(15)+10 : Next 
      End If 
   Next I

   'nowe legiony chaosu 
   P=50-POWER
   If P<2 : P=2 : End If 
   If Rnd(P)=1
      For I=20 To 39
         If ARMIA(I,0,TE)=0
            ARMIA$(I,0)="Wojownicy Chaosu"
            MESSAGE2[I,"przbyli z piekieł by szerzyć śmierć",38,0,0]
            NOWA_ARMIA[I,10,11]
            ARMIA(I,0,TMAG)=5
            X=Rnd(600)+20
            Y=Rnd(490)+10
            ARMIA(I,0,TX)=X
            ARMIA(I,0,TY)=Y
            ARMIA(I,0,TBOB)=7
            TEREN[X,Y]
            ARMIA(I,0,TNOGI)=LOK
            B_DRAW[I,X,Y,7]
            I=39
         End If 
      Next I
   End If 
   
   'obsługa moich armii   
   For A=0 To 19
      Exit If GAME_OVER
      If ARMIA(A,0,TE)>0
         'comiesięczne douczanki
         If DZIEN mod 30=0
            For I=1 To 10
               If ARMIA(A,I,TE)>0
                  MUNDRY=RASY(RASA,6)
                  Add ARMIA(A,I,TDOSW),Rnd(MUNDRY),ARMIA(A,I,TDOSW) To 95
               End If 
            Next I
         End If 
         ARMIA(A,0,TWAGA)=0
         TRYB=ARMIA(A,0,TTRYB)
         ZARCIE=ARMIA(A,0,TAMO)
         DNI=ZARCIE/ARMIA(A,0,TE)
         If DNI<5 and DNI>0
            MESSAGE[A,"Kończy nam się żywność.",0,0]
         End If 
         If ZARCIE<=0
            MESSAGE[A,"Oddział rozwiązany",0,0]
            ZABIJ_ARMIE[A]
            B_CLEAR[A]
            Goto OVER_NEXT
         End If 
         If TRYB>0 and TRYB<4
            MA_RUCH[A,TRYB]
         End If 
         If TRYB=0
            MA_OBOZ[A]
         End If 
         If TRYB=4
            MA_POLOWANIE[A]
         End If 
      End If 
      OVER_NEXT:
   Next A
   If GAME_OVER : Goto OVER : End If 
   'obsługa cudzych armii 
   For A=20 To 39
      If ARMIA(A,0,TE)>0
         PL=ARMIA(A,0,TMAG)
         If ARMIA(A,0,TMAGMA)<28 and ARMIA(A,0,TMAGMA)>0
            Dec ARMIA(A,0,TMAGMA)
         End If 
         TRYB=ARMIA(A,0,TTRYB)
         If TRYB>0 and TRYB<4
            If Rnd(6)=1
               MA_WYDAJ_ROZKAZ[PL,A]
            Else 
               MA_RUCH[A,TRYB]
            End If 
         End If 
         If TRYB=0
            MA_OBOZ[A]
            MA_WYDAJ_ROZKAZ[PL,A]
         End If 
         If TRYB=4
            MA_POLOWANIE[A]
         End If 
      End If 
   Next 
   'MIASTA
   If DZIEN mod 96=0 : ZAB2 : End If 
   For M=0 To 49
      LUDZIE=MIASTA(M,0,M_LUDZIE)
      If Rnd(50)=1 and LUDZIE>800 : PLAGA[M,Rnd(2)] : End If 
      CZYJE=MIASTA(M,0,M_CZYJE)
      'szajba & podatek modification 
      If Rnd(5)=1 : Add MIASTA(M,1,M_MORALE),Rnd(2)-1,0 To 25 : End If 
      PODATEK=MIASTA(M,0,M_PODATEK)
      Add GRACZE(CZYJE,1),PODATEK*MIASTA(M,0,M_LUDZIE)/25
      'obsługa spichlerzy
      SPI=0
      For I=2 To 20
         If MIASTA(M,I,M_LUDZIE)=9 : Inc SPI : End If 
      Next I
      If SPI>0 : Add MIASTA(M,1,M_LUDZIE),LUDZIE/15,MIASTA(M,1,M_LUDZIE) To SPI*200 : End If 
      
      If BOMBA2#>175 : C=2/ZERO : End If 
      If CZYJE>1
         Add MIASTA(M,0,M_LUDZIE),Rnd(10)-2
         If GRACZE(CZYJE,1)>10000 and Rnd(3)=1 and MIASTA(M,1,M_PODATEK)=0
            For I=20 To 39
               If ARMIA(I,0,TE)<=0
                  Add GRACZE(CZYJE,1),-10000
                  MIASTA(M,1,M_PODATEK)=20+Rnd(10)
                  NOWA_ARMIA[I,10,-1]
                  ARMIA(I,0,TMAG)=CZYJE
                  X=MIASTA(M,0,M_X)
                  Y=MIASTA(M,0,M_Y)
                  ARMIA(I,0,TX)=X
                  ARMIA(I,0,TY)=Y
                  ARMIA(I,0,TBOB)=2+CZYJE
                  ARMIA(I,0,TNOGI)=MIASTA(M,1,M_X)
                  If Upper$(Right$(IMIONA$(CZYJE),1))="I"
                     KON$="ego"
                  Else 
                     KON$="a"
                  End If 
                  ARMIA$(I,0)=Str$(I)+" Legion "+IMIONA$(CZYJE)+KON$
                  B_DRAW[I,X,Y,2+CZYJE]
                  I=39
               End If 
            Next I
         End If 
      End If 
      If CZYJE=1
         MORALE=MIASTA(M,0,M_MORALE)
         SZAJBA=MIASTA(M,1,M_MORALE)
         LUDZIE=MIASTA(M,0,M_LUDZIE)
         Add LUDZIE,SZAJBA-PODATEK
         Add MORALE,SZAJBA-PODATEK
         If MORALE>150 : MORALE=150 : End If 
         If MORALE<=0
            A$="W mieście wybuchł bunt ! "
            JEST=False
            For I=0 To 19
               If ARMIA(I,0,TE)>0 and ARMIA(I,0,TNOGI)-70=M
                  JEST=True
                  _ATAK=I
                  I=19
               End If 
            Next I
            
            If JEST
               A$=A$+ARMIA$(_ATAK,0)+" będzie walczyć z rebeliantami."
               TEREN=MIASTA(M,1,M_X)
               LWOJ=(LUDZIE/70)+1 : If LWOJ>10 : LWOJ=10 : End If 
               NOWA_ARMIA[40,LWOJ,-1]
               'wieśniacy wśród buntowników 
               For I=1 To 2+Rnd(2) : NOWA_POSTAC[40,I,9] : Next I
               Amal Off 0
               Show On 
               CENTER[MIASTA(M,0,M_X),MIASTA(M,0,M_Y),1]
               MESSAGE[M,A$,0,1]
               BITWA[_ATAK,40,1,1,0,1,1,1,TEREN,M]
               Add LUDZIE,-(LUDZIE/4)
               CENTER[MIASTA(M,0,M_X),MIASTA(M,0,M_Y),0]
               'Hide On 
               'Amal On 0 
               If ARMIA(_ATAK,0,TE)=0
                  JEST=False
                  A$="Rebelianci przejęli miasto."
               Else 
                  MORALE=50
                  Add MIASTA(M,1,M_MORALE),Rnd(3)+5
               End If 
            End If 
            
            If Not JEST
               CENTER[MIASTA(M,0,M_X),MIASTA(M,0,M_Y),1]
               MESSAGE[M,A$,0,1]
               MIASTA(M,0,M_CZYJE)=0
               MB=8
               If LUDZIE>700 : Inc MB : End If 
               Paste Bob MIASTA(M,0,M_X)-8,MIASTA(M,0,M_Y)-8,MB
               MORALE=30
            End If 
         End If 
         If LUDZIE<30 : LUDZIE=30 : End If 
         MIASTA(M,0,M_LUDZIE)=LUDZIE
         MIASTA(M,0,M_MORALE)=MORALE
      End If 
      If MIASTA(M,1,M_Y)<25 and MIASTA(M,1,M_Y)>0 : Dec MIASTA(M,1,M_Y) : End If 
      If MIASTA(M,1,M_PODATEK)>0 : Dec MIASTA(M,1,M_PODATEK) : End If 
   Next 
   OBLICZ_POWER[1]
   OVER:
   Amal Off 
   Show On 
   If DZIEN mod _MODULO=0 : ZAB2 : End If 
End Proc
Procedure MA_RUCH[A,TRYB]
   PL=ARMIA(A,0,TMAG)
   X1=ARMIA(A,0,TX)
   Y1=ARMIA(A,0,TY)
   If ARMIA(A,0,TMAGMA)=100 : CENTER[X1,Y1,1] : End If 
   WOJ=ARMIA(A,0,TE)
   ZARCIE=ARMIA(A,0,TAMO)
   SPEED=ARMIA(A,0,TSZ)
   BB=ARMIA(A,0,TBOB)
'PGJ: ?-> tryb1-ruch, tryb2-szybkiRuch
   If TRYB=1
      X2=ARMIA(A,0,TCELX)
      Y2=ARMIA(A,0,TCELY)
      ILE_ZRE=1
   End If 
   If TRYB=2
      X2=ARMIA(A,0,TCELX)
      Y2=ARMIA(A,0,TCELY)
      ILE_ZRE=3
      SPEED=ARMIA(A,0,TSZ)*2
   End If 
   If TRYB=3
      C=ARMIA(A,0,TCELY)
      B=ARMIA(A,0,TCELX)
      If C=0
         X2=ARMIA(B,0,TX)
         Y2=ARMIA(B,0,TY)
         A$=ARMIA$(B,0)
         PL2=ARMIA(B,0,TMAG)
         If ARMIA(B,0,TE)<=0 : ARMIA(A,0,TTRYB)=0 : Goto OVER : End If 
      Else 
         X2=MIASTA(B,0,M_X)
         Y2=MIASTA(B,0,M_Y)
         A$=MIASTA$(B)
         PL2=MIASTA(B,0,M_CZYJE)
         If PL=PL2 : ARMIA(A,0,TTRYB)=0 : Goto OVER : End If 
      End If 
      ILE_ZRE=1
      
      If PL<>1 and PL2<>1 : SYMULACJA=True : End If 
   End If 
   If A<20
      Add ZARCIE,-WOJ*ILE_ZRE
      If ZARCIE<0 : ZARCIE=0 : End If 
      ARMIA(A,0,TAMO)=ZARCIE
   End If 
   DX=X2-X1 : DY=Y2-Y1
   '   LOX=1 : LOY=1
   '   If DX>4 : LOX=0 : End If 
   '   If DX<-4 : LOX=2 : End If  
   '   If DY>4 : LOY=0 : End If 
   '   If DY<-4 : LOY=2 : End If  
   '   ARMIA(A,0,TLEWA)=LOX 
   '   ARMIA(A,0,TPRAWA)=LOY
   If Abs(DX)>Abs(DY)
      LTRYB=3
      If DX>=0
         LOAX=0 : LOAX2=2
      Else 
         LOAX=2 : LOAX2=0
      End If 
   Else 
      LTRYB=2
      If DY>=0
         LOAY=0 : LOAY2=2
      Else 
         LOAY=2 : LOAY2=0
      End If 
   End If 
   L#=Sqr(DX*DX+DY*DY)+0.2
   VX#=DX/L# : VY#=DY/L#
   X#=X1 : Y#=Y1
   B_CLEAR[A]
   For I=0 To SPEED
      X#=X#+VX#
      Y#=Y#+VY#
      X1=X# : Y1=Y#
      DX=X2-X1 : DY=Y2-Y1
      Bob 1,X1,Y1,BB : Wait Vbl 
      If Abs(DX)<3 and Abs(DY)<3
         Exit 
      End If 
   Next I
   Bob Off 1 : Wait Vbl 
   TEREN[X1,Y1]
   If LOK>69 and LOK<120 and A<20 : MIASTA(LOK-70,1,M_Y)=0 : End If 
   DX=X2-X1 : DY=Y2-Y1
   ARMIA(A,0,TX)=X1
   ARMIA(A,0,TY)=Y1
   B_DRAW[A,X1,Y1,BB]
   If LOK>120 and A<20
      NR=LOK-121
      LOK=PRZYGODY(NR,P_TEREN)
      CENTER[X1,Y1,1]
      MA_PRZYGODA[A,NR]
      'nie chcę już więcej przygód 
      SKIP=1
   End If 
   ARMIA(A,0,TNOGI)=LOK
   If Abs(DX)<3 and Abs(DY)<3
      Amal Off 0
      Show On 
      If TRYB=3 and C=0
         TEREN=ARMIA(B,0,TNOGI)
         ARMIA(A,0,TNOGI)=TEREN
         If TEREN>69 and TEREN<121
            MT=TEREN-70
            TEREN=MIASTA(TEREN-70,1,M_X)
         Else 
            MT=-1
         End If 
         If SYMULACJA
            BITWA_SYMULOWANA[A,B]
            LOSER=Param
            If ARMIA(LOSER,0,TMAGMA)=100
               MESSAGE2[LOSER," został rozbity.",33,0,0]
            End If 
         Else 
            'LOX=ARMIA(B,0,TLEWA)
            'LOY=ARMIA(B,0,TPRAWA) 
            If A>19
               CENTER[X1,Y1,1]
               MESSAGE[A,"zaatakował nasz "+A$+" ",0,0]
               BITWA[B,A,LOAX2,LOAY2,LTRYB,LOAX,LOAY,LTRYB,TEREN,MT]
               ARMIA(A,0,TMAGMA)=0
            Else 
               CENTER[X1,Y1,1]
               MESSAGE[A,"Rozpoczynamy atak na "+A$,0,0]
               ILEDNI=Rnd(30)+10
               WOJNA(PL,PL2)=ILEDNI
               WOJNA(PL2,PL)=ILEDNI
               ARMIA(B,0,TMAGMA)=0
               BITWA[A,B,LOAX,LOAY,LTRYB,LOAX2,LOAY2,LTRYB,TEREN,MT]
            End If 
            CENTER[X1,Y1,0]
            If ARMIA(B,0,TE)=0 : MESSAGE2[B,"został rozbity ",33,0,0] : End If 
            If ARMIA(A,0,TE)=0 : MESSAGE2[A,"został rozbity ",33,0,0] : End If 
         End If 
      End If 
      If TRYB=3 and C=1
         TEREN=MIASTA(B,1,M_X)
         MUR=MIASTA(B,0,M_MUR)
         If MUR=0 or PL=5
            MUR=B
         Else 
            MUR=-MUR-1
         End If 
         MORALE=MIASTA(B,0,M_MORALE)
         LUDZIE=MIASTA(B,0,M_LUDZIE)
         LWOJ=(LUDZIE/70)+1 : If LWOJ>10 : LWOJ=10 : End If 
         MB=8+PL*2
         If LUDZIE>700 : Inc MB : End If 
         KTO_ATAKUJE=A
         If SYMULACJA
            OLDPOWER=POWER
            POWER=(MORALE/3)+10
            NOWA_ARMIA[40,LWOJ,-1]
            'większy ostrzał 
            ARMIA(40,0,TKORP)=150+POWER
            BITWA_SYMULOWANA[A,40]
            Add MIASTA(B,0,M_LUDZIE),-(LUDZIE/4),20 To MIASTA(B,0,M_LUDZIE)
            POWER=OLDPOWER
            If ARMIA(40,0,TE)=0
               If PL=5
                  MIASTA(B,0,M_CZYJE)=0
                  Add MIASTA(B,0,M_LUDZIE),-(LUDZIE/2),20 To MIASTA(B,0,M_LUDZIE)
                  For I=2 To 10 : If Rnd(1)=1 : MIASTA(B,I,M_LUDZIE)=0 : End If : Next I
                  MESSAGE2[B,"Wojownicy Chaosu spalili miasto.",32,1,0]
                  MB=8
               Else 
                  MIASTA(B,0,M_CZYJE)=PL
               End If 
               B_OFF[A] : Paste Bob MIASTA(B,0,M_X)-8,MIASTA(B,0,M_Y)-8,MB : Wait Vbl : B_DRAW[A,X1,Y1,BB]
               If ARMIA(A,0,TMAGMA)=100
                  CENTER[X1,Y1,1]
                  MESSAGE2[A,"Zdobył osadę "+A$,32,0,0]
               End If 
            End If 
            If ARMIA(A,0,TMAGMA)=100
               If ARMIA(A,0,TE)=0
                  CENTER[X1,Y1,1]
                  MESSAGE2[A,"został rozbity w czasie szturmu na miasto "+A$,33,0,0]
               End If 
            End If 
         Else 
            If A>19 and PL2=1
               OBRONA=-1
               For I=0 To 19
                  If ARMIA(I,0,TE)>0 and ARMIA(I,0,TNOGI)=70+B
                     OBRONA=I
                     I=19
                  End If 
               Next 
               If OBRONA>-1
                  CENTER[X1,Y1,1]
                  If PL=5 : KON$="ą"
                  Else 
                     KON$="e"
                  End If 
                  MESSAGE[A,"atakuj"+KON$+" naszą osadę "+A$+" ",0,0]
                  For I=1 To 10 : ARMIA(A,I,TAMO)=30 : Next I
                  BITWA[OBRONA,A,0,0,2,0,2,2,TEREN,MUR]
                  Add MIASTA(B,0,M_LUDZIE),-(LUDZIE/4),20 To MIASTA(B,0,M_LUDZIE)
                  CENTER[X1,Y1,0]
                  If WYNIK_AKCJI<>1
                     If PL=5
                        MIASTA(B,0,M_CZYJE)=0
                        Add MIASTA(B,0,M_LUDZIE),-(LUDZIE/2),20 To MIASTA(B,0,M_LUDZIE)
                        For I=2 To 20 : If Rnd(2)=1 : MIASTA(B,I,M_LUDZIE)=0 : End If : Next I
                        MESSAGE2[B,"Wojownicy Chaosu zdobylii i spalili miasto.",32,1,0]
                        MB=8
                     Else 
                        MIASTA(B,0,M_CZYJE)=PL
                        MESSAGE2[A,"zdobył naszą osadę "+A$+" ",30,0,0]
                     End If 
                     B_OFF[A] : Paste Bob MIASTA(B,0,M_X)-8,MIASTA(B,0,M_Y)-8,MB : Wait Vbl : B_DRAW[A,X1,Y1,BB]
                  End If 
               Else 
                  If PL=5
                     MIASTA(B,0,M_CZYJE)=0
                     Add MIASTA(B,0,M_LUDZIE),-(LUDZIE/2),20 To MIASTA(B,0,M_LUDZIE)
                     For I=2 To 20 : If Rnd(2)=1 : MIASTA(B,I,M_LUDZIE)=0 : End If : Next I
                     MESSAGE2[B,"miasto zostało spalone ",32,1,0]
                     MB=8
                  Else 
                     MIASTA(B,0,M_CZYJE)=PL
                     CENTER[X1,Y1,1]
                     MESSAGE[A,"zajął naszą osadę "+A$+" ",0,0]
                  End If 
                  B_OFF[A] : Paste Bob MIASTA(B,0,M_X)-8,MIASTA(B,0,M_Y)-8,MB : Wait Vbl : B_DRAW[A,X1,Y1,BB]
               End If 
            Else 
               CENTER[X1,Y1,1]
               MESSAGE[A,"Rozpoczynamy atak na osadę "+A$,0,0]
               ILEDNI=Rnd(30)+10
               WOJNA(PL,PL2)=ILEDNI
               WOJNA(PL2,PL)=ILEDNI
               OLDPOWER=POWER
               POWER=(MORALE/3)+10
               NOWA_ARMIA[40,LWOJ,-1]
               For I=1 To 10 : ARMIA(40,I,TAMO)=30 : Next I
               BITWA[A,40,0,2,2,0,0,2,TEREN,MUR]
               Add MIASTA(B,0,M_LUDZIE),-(LUDZIE/4),20 To MIASTA(B,0,M_LUDZIE)
               POWER=OLDPOWER
               CENTER[X1,Y1,0]
               If ARMIA(40,0,TE)=0
                  MIASTA(B,0,M_CZYJE)=PL
                  B_OFF[A] : Paste Bob MIASTA(B,0,M_X)-8,MIASTA(B,0,M_Y)-8,MB : Wait Vbl : B_DRAW[A,X1,Y1,BB]
                  For J=1 To 19 : MIASTA(B,J,M_MUR)=Rnd(20) : Next J
                  MESSAGE2[A,"Zdobyliśmy osadę "+A$+" ",30,0,0]
               End If 
               If ARMIA(A,0,TE)=0
                  MESSAGE2[A,"został rozbity w czasie szturmu na miasto "+A$,33,0,0]
               End If 
            End If 
         End If 
      End If 
      ARMIA(A,0,TTRYB)=0
      BUSY_ANIM
      
   Else 
      '      MA_WYPADEK[A,7] : Goto OVER 
      If A<20 and SKIP=0
         If LOK=7
            If Rnd(3)=1 : MA_WYPADEK[A,3] : End If 
         End If 
         If LOK=5
            If Rnd(6)=1 : MA_WYPADEK[A,1] : End If 
         End If 
         If LOK=1
            P=Rnd(45)
            If P<4 : MA_WYPADEK[A,4+P] : End If 
            If P=5 : MA_WYPADEK[A,2] : End If 
         End If 
         If LOK=2
            P=Rnd(45)
            If P=1 : MA_WYPADEK[A,2] : End If 
            If P=2 : MA_WYPADEK[A,6] : End If 
         End If 
         If LOK=3
            P=Rnd(45)
            If P=1 : MA_WYPADEK[A,2] : End If 
         End If 
         If LOK=4
            P=Rnd(45)
            If P=1 : MA_WYPADEK[A,2] : End If 
            If P=5 : MA_WYPADEK[A,7] : End If 
         End If 
         
      End If 
   End If 
   OVER:
End Proc
Procedure B_CLEAR[NR]
   X=ARMIA(NR,0,TX)
   Y=ARMIA(NR,0,TY)
   Reset Zone NR+20
   Put Block NR+1,X-4,Y-7
   Z1=Zone(X-4,Y-7)
   Z2=Zone(X+4,Y-7)
   Z3=Zone(X-4,Y)
   Z4=Zone(X+4,Y)
   If Z1>=20 and Z1<60 : B_UPDATE[Z1-20] : End If 
   If Z2>=20 and Z2<60 : B_UPDATE[Z2-20] : End If 
   If Z3>=20 and Z3<60 : B_UPDATE[Z3-20] : End If 
   If Z4>=20 and Z4<60 : B_UPDATE[Z4-20] : End If 
End Proc
Procedure B_DRAW[NR,X,Y,O]
   Reset Zone NR+20
   Z1=Zone(X-4,Y-7)
   Z2=Zone(X+4,Y-7)
   Z3=Zone(X-4,Y)
   Z4=Zone(X+4,Y)
   If Z1>=20 and Z1<60 : B_OFF[Z1-20] : End If 
   If Z2>=20 and Z2<60 : B_OFF[Z2-20] : End If 
   If Z3>=20 and Z3<60 : B_OFF[Z3-20] : End If 
   If Z4>=20 and Z4<60 : B_OFF[Z4-20] : End If 
   Get Block NR+1,X-4,Y-7,8,8,1
   If Z1>=20 and Z1<60 : B_UPDATE[Z1-20] : End If 
   If Z2>=20 and Z2<60 : B_UPDATE[Z2-20] : End If 
   If Z3>=20 and Z3<60 : B_UPDATE[Z3-20] : End If 
   If Z4>=20 and Z4<60 : B_UPDATE[Z4-20] : End If 
   Paste Bob X-4,Y-7,O
   Set Zone NR+20,X-4,Y-7 To X+4,Y
End Proc
Procedure B_UPDATE[NR]
   X=ARMIA(NR,0,TX)
   Y=ARMIA(NR,0,TY)
   O=ARMIA(NR,0,TBOB)
   Paste Bob X-4,Y-7,O
End Proc
Procedure B_OFF[NR]
   X=ARMIA(NR,0,TX)
   Y=ARMIA(NR,0,TY)
   Put Block NR+1,X-4,Y-7
End Proc


Procedure MA_POLOWANIE[A]
   TEREN=ARMIA(A,0,TNOGI)
   ARMIA(A,0,TLEWA)=1
   ARMIA(A,0,TPRAWA)=1
   WOJ=ARMIA(A,0,TE)
   If TEREN<70 and A<20
      Add ARMIA(A,0,TAMO),-WOJ
   End If 
   R=Rnd(13)
   ILE=Rnd(9)+1
   If R<5 : PO$="dzik" : RSA=13 : End If 
   If R>4 and R<8 : PO$="wilk" : RSA=12 : End If 
   If R=8 or R=9 : PO$="gargoil" : RSA=10 : ILE=Rnd(3)+1 : End If 
   If R=10 : PO$="skirial" : RSA=16 : ILE=Rnd(5)+1 : End If 
   If R>10 : PO$="warpun" : RSA=15 : End If 
   If TEREN=1 : LOS=1 : End If 
   If TEREN=2 : LOS=2 : End If 
   If TEREN=3 : LOS=6 : End If 
   If TEREN=4 : LOS=5 : End If 
   If TEREN=5 : LOS=4 : End If 
   If TEREN=7 : LOS=3 : PO$="gloom" : RSA=14 : End If 
   If Rnd(LOS)=1
      Amal Off 0
      Show On 
      X=ARMIA(A,0,TX)
      Y=ARMIA(A,0,TY)
      CENTER[X,Y,1]
      MESSAGE[A,"Wytropiliśmy bestię !",0,0]
      ARM=A : WRG=40
      Sprite Off 2
      SETUP["","Polowanie",""]
      For I=1 To 10 : ARMIA(40,I,TE)=0 : Next 
      POTWOR[40,PO$,ILE,RSA]
      RYSUJ_SCENERIE[TEREN,-1]
      X=Rnd(2) : Y=Rnd(2)
      USTAW_WOJSKO[ARM,X,Y,0]
      USTAW_WOJSKO[WRG,X,Y,1]
      MAIN_ACTION
      For I=0 To 10 : ARMIA(40,I,TE)=0 : Next I
      ARMIA(A,0,TTRYB)=0
      SETUP0
      VISUAL_OBJECTS
      Sprite 2,SPX,SPY,1
      CENTER[ARMIA(A,0,TX),ARMIA(A,0,TY),0]
      BUSY_ANIM
      
   End If 
End Proc
Procedure MA_OBOZ[A]
   WOJ=ARMIA(A,0,TE)
   TEREN=ARMIA(A,0,TNOGI)
   ARMIA(A,0,TLEWA)=1
   ARMIA(A,0,TPRAWA)=1
   If TEREN<70 and A<20
      Add ARMIA(A,0,TAMO),-WOJ
   End If 
   For I=1 To 10
      MAGIA=ARMIA(A,I,TMAG)
      M_MAX=ARMIA(A,I,TMAGMA)
      Add MAGIA,Rnd(5)+5,MAGIA To M_MAX
      ARMIA(A,I,TMAG)=MAGIA
      EN=ARMIA(A,I,TE)
      ENM=ARMIA(A,I,TEM)
      If EN>0 and EN<ENM
         Add EN,Rnd(20)+10,EN To ENM
         ARMIA(A,I,TE)=EN
      End If 
   Next 
End Proc

Procedure MA_PRZYGODA[A,NR]
   Amal Off 0
   Show On 
   TEREN=PRZYGODY(NR,P_TEREN)
   TYP=PRZYGODY(NR,P_TYP)
   A$=PRZYGODY$(TYP,7)
   If Not TESTING
      MESSAGE[A,A$,NR,0] : Sprite Off 2
   End If 
   'żadnych komunikatów po akcji 0 armie lub 1 miasta   
   M=-1
   ARM=A : WRG=40
   TRWA_PRZYGODA=NR
   SETUP["Akcja","w","terenie"]
   If TYP=1
      'kopalnia koboldy
      If Rnd(1)=0
         POT=16 : ILE=3 : PO$="skirial"
      Else 
         POT=18 : ILE=5 : PO$="pająk"
      End If 
      POTWOR[40,PO$,ILE,POT]
      For I=ILE+1 To 10 : NOWA_POSTAC[40,I,3] : Next I
      For I=1 To 10 : ARMIA(WRG,I,TPRAWA)=-1 : Next I
      RYSUJ_SCENERIE[TEREN,-1]
      'dosypujemy trochę skarbów 
      For I=1 To Rnd(8)+8
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
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=180 : Next I
      USTAW_WOJSKO[ARM,1,0,0]
      USTAW_WOJSKO[WRG,1,2,2]
      MAIN_ACTION
   End If 
   If TYP=2 or TYP=8
      'grobowiec upiory
      If Rnd(1)=0
         POT=17 : ILE=9 : PO$="humanoid"
      Else 
         POT=18 : ILE=9 : PO$="pająk"
      End If 
      POTWOR[40,PO$,ILE,POT]
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=180 : Next I
      NOWA_POSTAC[WRG,10,9]
      ARMIA(WRG,10,TKORP)=40
      ARMIA(WRG,10,TPRAWA)=-1
      RYSUJ_SCENERIE[TEREN,-1]
      'umieszczenie skarbu 
      
      SEKTOR[460+12,28+22]
      GLEBA(Param,0)=PRZYGODY(NR,P_BRON)
      For I=1 To 3 : GLEBA(Param,I)=80 : Next I
      Paste Bob 460,28,BIBY+11
      
      USTAW_WOJSKO[ARM,0,2,0]
      USTAW_WOJSKO[WRG,0,2,1]
      MAIN_ACTION
   End If 
   If TYP=3
      'bandyci 
      POT=-1 : ILE=Rnd(5)+5
      NOWA_ARMIA[40,ILE,POT]
      For I=1 To ILE : ARMIA(WRG,I,TPRAWA)=-1 : Next I
      RYSUJ_SCENERIE[TEREN,-1]
      'silna i doświadczona załoga show no mercy and kill them all 
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=250 : Next I
      For I=1 To 10 : ARMIA(WRG,I,TDOSW)=Rnd(25) : Next I
      USTAW_WOJSKO[ARM,1,1,1]
      USTAW_WOJSKO[WRG,1,1,0]
      MAIN_ACTION
      If WYNIK_AKCJI=1
         M=0
         CO=ARM
         A$="W nagrodę otrzymujesz "+Str$(PRZYGODY(NR,P_NAGRODA))+" sztuk złota."
         B=41
         Add GRACZE(1,1),PRZYGODY(NR,P_NAGRODA)
      End If 
   End If 
   If TYP=4
      'córka króla 
      POT=-1 : ILE=9
      POS=4
      NOWA_ARMIA[40,ILE,POT]
      RYSUJ_SCENERIE[TEREN,-1]
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=170 : Next I
      NOWA_POSTAC[WRG,10,POS]
      ARMIA(WRG,10,TKORP)=40
      ARMIA(WRG,10,TPRAWA)=-1
      USTAW_WOJSKO[ARM,1,2,0]
      USTAW_WOJSKO[WRG,1,0,0]
      MAIN_ACTION
      If WYNIK_AKCJI=1 and ARMIA(WRG,10,TE)>0
         CO=PRZYGODY(NR,P_NAGRODA) : M=1 : B=30
         A$="Przechodzi w twoje władanie jako nagroda."
         MIASTA(CO,0,M_CZYJE)=1
      End If 
   End If 
   If TYP=5
      'góra szczerbiec 
      POTWOR[WRG,"skirial",5,16]
      RYSUJ_SCENERIE[TEREN,-1]
      GLEBA(5,Rnd(3))=7
      Paste Bob 330,12,BIBY+11
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=170 : Next I
      USTAW_WOJSKO[ARM,1,2,0]
      USTAW_WOJSKO[WRG,1,0,2]
      MAIN_ACTION
   End If 
   If TYP=6
      'super mag i wilki 
      POTWOR[WRG,"wilk",9,12]
      NOWA_POSTAC[WRG,10,8]
      MAGIA=50+Rnd(50) : ENERGIA=30+Rnd(40) : SILA=20+Rnd(10) : SZYBKOSC=10+Rnd(10) : _DOS=50
      RYSUJ_SCENERIE[TEREN,-1]
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=170 : Next I
      ARMIA$(WRG,10)=IM_PRZYGODY$(NR)
      ARMIA(WRG,10,TGLOWA)=1
      ARMIA(WRG,10,TKORP)=40
      Add ARMIA(WRG,10,TEM),ENERGIA
      Add ARMIA(WRG,10,TSI),SILA
      Add ARMIA(WRG,10,TSZ),SZBKOSC
      Add ARMIA(WRG,10,TMAGMA),MAGIA
      Add ARMIA(WRG,10,TDOSW),_DOS
      'będzie gadał
      ARMIA(WRG,10,TPRAWA)=-1
      USTAW_WOJSKO[ARM,0,1,0]
      USTAW_WOJSKO[WRG,2,1,0]
      MAIN_ACTION
   End If 
   If TYP=7
      'super paladyn i szkielety 
      POTWOR[WRG,"szkielet",9,11]
      NOWA_POSTAC[WRG,10,7]
      RYSUJ_SCENERIE[TEREN,-1]
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=240 : Next I
      MAGIA=20+Rnd(20) : ENERGIA=60+Rnd(50) : SILA=20+Rnd(20) : SZYBKOSC=20+Rnd(20) : _DOS=80
      ARMIA(WRG,10,TKORP)=35
      ARMIA$(WRG,10)=IM_PRZYGODY$(NR)
      Add ARMIA(WRG,10,TEM),ENERGIA
      Add ARMIA(WRG,10,TSI),SILA
      Add ARMIA(WRG,10,TSZ),SZBKOSC
      Add ARMIA(WRG,10,TMAGMA),MAGIA
      Add ARMIA(WRG,10,TDOSW),_DOS
      ARMIA(WRG,10,TPRAWA)=-1
      USTAW_WOJSKO[ARM,1,0,0]
      USTAW_WOJSKO[WRG,1,2,2]
      MAIN_ACTION
   End If 
   
   If TYP=9
      'świątynia orków 
      NOWA_ARMIA[40,10,1]
      For I=1 To 10 : ARMIA(WRG,I,TPRAWA)=-1 : Next I
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=180 : Next I
      RYSUJ_SCENERIE[TEREN,-1]
      WIDOCZNOSC=250
      'umieszczenie trupów 
      For Y=0 To 20
         For X=O To 10
            XB=X*60 : YB=Y*25
            If Rnd(8)=1 and Zone(XB+10,YB+10)=0
               BB=Rnd(9)*16+18+63+16
               Paste Bob XB+10,YB+10,BB
            End If 
         Next X
      Next Y
      USTAW_WOJSKO[ARM,1,2,0]
      USTAW_WOJSKO[WRG,1,2,1]
      MAIN_ACTION
   End If 
   
   If TYP=10
      'barbarzyńca na bagnach
      MAGIA=10+Rnd(20) : ENERGIA=40+Rnd(40) : SILA=20+Rnd(20) : SZYBKOSC=10+Rnd(10) : _DOS=60
      POTWOR[40,"gloom",9,14]
      RYSUJ_SCENERIE[TEREN,-1]
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=170 : Next I
      NOWA_POSTAC[WRG,10,0]
      ARMIA$(WRG,10)=IM_PRZYGODY$(NR)
      ARMIA(WRG,10,TGLOWA)=1
      ARMIA(WRG,10,TKORP)=40
      Add ARMIA(WRG,10,TEM),ENERGIA
      Add ARMIA(WRG,10,TSI),SILA
      Add ARMIA(WRG,10,TSZ),SZBKOSC
      Add ARMIA(WRG,10,TMAGMA),MAGIA
      Add ARMIA(WRG,10,TDOSW),_DOS
      'będzie gadał
      ARMIA(WRG,10,TPRAWA)=-1
      USTAW_WOJSKO[ARM,0,1,0]
      USTAW_WOJSKO[WRG,2,1,0]
      MAIN_ACTION
   End If 
   
   If TYP=11
      'wataha z gargoilami 
      POTWOR[WRG,"gargoil",2,10]
      For I=3 To 5+Rnd(4) : NOWA_POSTAC[WRG,I,Rnd(8)] : Next I
      RYSUJ_SCENERIE[TEREN,-1]
      'umieszczenie trupów 
      For Y=0 To 20
         For X=O To 10
            XB=X*60 : YB=Y*25
            If Rnd(8)=1 and Zone(XB+10,YB+10)=0
               BB=Rnd(9)*16+18+63+16
               Paste Bob XB+10,YB+10,BB
            End If 
         Next X
      Next Y
      'silna i doświadczona załoga show no mercy and kill them all 
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=250 : Next I
      For I=1 To 10 : ARMIA(WRG,I,TDOSW)=Rnd(25) : Next I
      'tworzenie bossa 
      MAGIA=10+Rnd(20) : ENERGIA=40+Rnd(40) : SILA=20+Rnd(20) : SZYBKOSC=10+Rnd(10) : _DOS=60
      NOWA_POSTAC[WRG,10,PRZYGODY(NR,P_BRON)]
      ARMIA$(WRG,10)=IM_PRZYGODY$(NR)
      ARMIA(WRG,10,TGLOWA)=1
      ARMIA(WRG,10,TKORP)=170
      Add ARMIA(WRG,10,TEM),ENERGIA
      Add ARMIA(WRG,10,TE),ENERGIA
      Add ARMIA(WRG,10,TSI),SILA
      Add ARMIA(WRG,10,TSZ),SZBKOSC
      Add ARMIA(WRG,10,TMAG),MAGIA
      Add ARMIA(WRG,10,TDOSW),_DOS
      'będzie gadał
      ARMIA(WRG,10,TPRAWA)=-1
      USTAW_WOJSKO[ARM,1,2,0]
      USTAW_WOJSKO[WRG,1,0,0]
      MAIN_ACTION
      If ARMIA(WRG,10,TE)<=0
         M=0 : CO=ARM
         A$="Za głowę zbira otrzymujesz "+Str$(PRZYGODY(NR,P_NAGRODA))+" sztuk złota."
         B=41
         Add GRACZE(1,1),PRZYGODY(NR,P_NAGRODA)
      End If 
   End If 
   
   If TYP=12
      'jaskinia wiedzy 
      NOWA_POSTAC[WRG,10,8]
      RYSUJ_SCENERIE[TEREN,-1]
      ARMIA(WRG,10,TGLOWA)=1
      ARMIA(WRG,10,TKORP)=40
      ARMIA(WRG,10,TDOSW)=60+Rnd(40)
      ARMIA(WRG,10,TPRAWA)=-1
      USTAW_WOJSKO[ARM,1,0,0]
      USTAW_WOJSKO[WRG,1,2,0]
      For I=1 To 10
         Add ARMIA(ARM,I,TDOSW),40+Rnd(40)
         If ARMIA(ARM,I,TDOSW)>95 : ARMIA(ARM,I,TDOSW)=95 : End If 
      Next I
      MAIN_ACTION
   End If 
   If TYP=13
      'Goto SKIP2
      'sparing końcowy 
      'obrona bagien 
      POTWOR[WRG,"szkielet",10,11]
      RYSUJ_SCENERIE[7,-3]
      KTO_ATAKUJE=ARM
      USTAW_WOJSKO[ARM,0,2,2]
      USTAW_WOJSKO[WRG,0,0,2]
      MAIN_ACTION
      If WYNIK_AKCJI=1 or IMIONA$(1)="Marcin ®"
         For I=0 To 10 : ARMIA(40,I,TE)=0 : Next I
         Hide On 
         _LOAD[KAT$+"grob.hb","legion:grob.hb","Legion",3]
         _LOAD[KAT$+"mod.end2","legion:mod.end2","Legion",6]
         Track Loop On : Track Play 3
         USTAW_FONT["defender2",8]
         OUTLINE[10,200,"Władca Chaosu przebywa",1,0]
         OUTLINE[10,210,"w swojej podziemnej",1,0]
         OUTLINE[10,220,"krypcie grobowej,",1,0]
         OUTLINE[10,230,"z której zatruwa całe",1,0]
         OUTLINE[10,240,"królestwo.",1,0]
         View 
         _WAIT[1500]
         Fade 2
         _TRACK_FADE[1]
         Erase 3
         SETUP["Bitwa","z Władcą","Chaosu"]
         'sparing z bossem
         POTWOR[WRG,"boss",1,19]
         RYSUJ_SCENERIE[TEREN,-1]
         For I=1 To 10 : ARMIA(WRG,I,TKORP)=180 : Next I
         USTAW_WOJSKO[ARM,1,1,0]
         USTAW_WOJSKO[WRG,1,1,0]
         MAIN_ACTION
         If WYNIK_AKCJI=1 or IMIONA$(1)="Marcin ®"
            SKIP2:
            PRZYGODY(NR,P_TYP)=0
            GAME_OVER=True
            Hide On 
            _LOAD[KAT$+"pobieda.hb","legion:pobieda.hb","Legion",3]
            _LOAD[KAT$+"mod.2sample+","legion:mod.2sample+","Legion",6]
            Track Loop On : Track Play 3
            USTAW_FONT["defender2",8]
            OUTLINE[10,200,"Oto ten, który niszczył",1,0]
            OUTLINE[10,210,"wszelkie życie ",1,0]
            OUTLINE[10,220,"leży teraz martwy",1,0]
            OUTLINE[10,230,"u twych stóp",1,0]
            OUTLINE[10,240,"",1,0]
            A$="Twoja przygoda dobiegła końca."
            M=0 : CO=ARM : B=34
            View 
            _WAIT[3500]
            Fade 2
            _TRACK_FADE[1]
            Erase 3
         End If 
      End If 
   End If 
   
   OVER:
   If Not TESTING
      TRWA_PRZYGODA=-1
      For I=0 To 10 : ARMIA(40,I,TE)=0 : Next I
      ARMIA(A,0,TTRYB)=0
      If TYP<>13 : PRZYGODY(NR,P_TYP)=0 : End If 
      SETUP0
      VISUAL_OBJECTS
      Sprite 2,SPX,SPY,1
      CENTER[ARMIA(A,0,TX),ARMIA(A,0,TY),0]
      If M>-1
         MESSAGE2[CO,A$,B,M,0]
      End If 
      BUSY_ANIM
   End If 
End Proc
Procedure MA_WYPADEK[A,TYP]
   TEREN=ARMIA(A,0,TNOGI)
   If TYP=1
      A$="Osaczyło nas stado wściekłych wilków ! "
      PO$="wilk"
      XT=1 : YT=1
      POT=12
      ILE=Rnd(5)+5
      BB=34
   End If 
   If TYP=2
      A$="Zaatakowali nas zbóje "
      POT=-1 : ILE=Rnd(5)+5
      XT=Rnd(2) : YT=Rnd(2)
      BB=31
   End If 
   If TYP=3
      A$="Utknęliśmy na bagnach "
      PO$="gloom"
      POT=14 : ILE=Rnd(5)
      XT=1 : YT=1
      BB=34
   End If 
   If TYP=4
      A$="Okrążyły nas leśne trole "
      POT=6 : ILE=Rnd(5)+5
      XT=1 : YT=1
      BB=31
   End If 
   If TYP=5
      A$="Gargoil !!!"
      PO$="gargoil"
      POT=10 : ILE=Rnd(1)+1
      XT=1 : YT=1
      BB=34
   End If 
   If TYP=6
      A$="Spotkaliśmy samotnego wojownika "
      POT=-1 : ILE=1
      XT=Rnd(2) : YT=Rnd(2)
      BB=34
   End If 
   If TYP=7
      A$="Odnaleźliśmy wejście do jaskini "
      POT=18 : ILE=5 : XT=1 : YT=0
      PO$="pająk"
      TEREN=8
      BB=34
   End If 
   Amal Off 
   Show On 
   X=ARMIA(A,0,TX)
   Y=ARMIA(A,0,TY)
   CENTER[X,Y,1]
   MESSAGE2[A,A$,BB,0,1]
   ARM=A : WRG=40
   Sprite Off 2
   SETUP["Akcja","w","terenie"]
   For I=0 To 10 : ARMIA(40,I,TE)=0 : Next I
   If POT>9
      POTWOR[40,PO$,ILE,POT]
      If TYP=7
         For I=6 To 10 : NOWA_POSTAC[40,I,Rnd(8)] : ARMIA(40,I,TKORP)=150+Rnd(50) : Next I
      End If 
   Else 
      NOWA_ARMIA[40,ILE,POT]
      AGRESJA=ARMIA(WRG,0,TKORP)
      If TYP=6 : ARMIA(WRG,1,TDOSW)=Rnd(30)+20 : AGRESJA=40 : End If 
      For I=1 To 10 : ARMIA(WRG,I,TKORP)=AGRESJA : Next I
   End If 
   RYSUJ_SCENERIE[TEREN,-1]
   USTAW_WOJSKO[ARM,XT,YT,0]
   USTAW_WOJSKO[WRG,XT,YT,1]
   MAIN_ACTION
   For I=0 To 10 : ARMIA(40,I,TE)=0 : Next I
   SETUP0
   VISUAL_OBJECTS
   Sprite 2,SPX,SPY,1
   CENTER[ARMIA(A,0,TX),ARMIA(A,0,TY),0]
   BUSY_ANIM
   
End Proc
Procedure PLAGA[MIASTO,PLAGA]
   M$=MIASTA$(MIASTO)
   LUDZIE=MIASTA(MIASTO,0,M_LUDZIE)
   If PLAGA=0
      BB=32
      A$="Płomienie strawiły wielu miaszkańców i ich domostwa."
      Add LUDZIE,-(LUDZIE/4),50 To LUDZIE
      For I=2 To 20 : If Rnd(1)=1 : MIASTA(MIASTO,I,M_LUDZIE)=0 : End If : Next I
   End If 
   If PLAGA=1
      BB=29
      Add LUDZIE,-(LUDZIE/2),50 To LUDZIE
      A$="Epidemia zarazy kosi swe śmiertelne żniwo ! "
   End If 
   If PLAGA=2
      BB=30
      A$="Szczury pożarły cały zapas zboża w spichlerzach."
      MIASTA(MIASTO,1,M_LUDZIE)=0
   End If 
   MIASTA(MIASTO,0,M_LUDZIE)=LUDZIE
   MESSAGE2[MIASTO,A$,BB,1,0]
End Proc

Procedure MA_WYDAJ_ROZKAZ[PL,A]
   XA=ARMIA(A,0,TX)
   YA=ARMIA(A,0,TY)
   '   RODZAJ=ARMIA(A,0,TKORP)
   RODZAJ=3
   If RODZAJ=1 or RODZAJ=2 or RODZAJ=3
      STARAODL=120
      WIDAC=False
      For I=0 To 49
         PL2=MIASTA(I,0,M_CZYJE)
         LUDZIE=MIASTA(I,0,M_LUDZIE)
         'wszczynaie drobnych konfliktów
         If PL2=0 or PL2=1
            SZAJBA=300-POWER
         Else 
            SZAJBA=2200+POWER
         End If 
         If PL=5 : SZAJBA=1 : End If 
         If Rnd(SZAJBA)=1
            WOJNA(PL,PL2)=Rnd(20)+8
            WOJNA(PL2,PL)=Rnd(20)+8
         End If 
         If WOJNA(PL,PL2)>0 and PL2<>PL
            'litości !!! 
            If PL=5 and LUDZIE<200
               Goto SKIP
            End If 
            XB=MIASTA(I,0,M_X)
            YB=MIASTA(I,0,M_Y)
            ODL[XA,YA,XB,YB]
            If ODLEG<STARAODL
               TARGET=I
               CX=XB : CY=1
               STARAODL=ODLEG
               WIDAC=True
            End If 
         End If 
         SKIP:
      Next I
      
      For I=0 To 39
         PL2=ARMIA(I,0,TMAG)
         If ARMIA(I,0,TE)>0 and WOJNA(PL,PL2)>0 and PL2<>PL
            M=ARMIA(I,0,TNOGI)
            If M>=70 and M=<120
               If MIASTA(M-70,0,M_CZYJE)=PL2
                  XB=MIASTA(M-70,0,M_X)
                  YB=MIASTA(M-70,0,M_Y)
                  ODL[XA,YA,XB,YB]
                  If ODLEG<STARAODL
                     TARGET=M-70
                     CX=XB : CY=1
                     STARAODL=ODLEG
                     WIDAC=True
                  End If 
               Else 
                  Goto DALEJ
               End If 
            Else 
               DALEJ:
               XB=ARMIA(I,0,TX)
               YB=ARMIA(I,0,TY)
               ODL[XA,YA,XB,YB]
               If ODLEG<STARAODL
                  TARGET=I
                  CX=XB : CY=0
                  STARAODL=ODLEG
                  WIDAC=True
               End If 
            End If 
         End If 
      Next I
   End If 
   
   If RODZAJ=3 and WIDAC
      Gosub _ATAK
   End If 
   Goto OVER
   
   RUCH:
   Return 
   
   _ATAK:
   ARMIA(A,0,TTRYB)=3
   ARMIA(A,0,TCELX)=TARGET
   ARMIA(A,0,TCELY)=CY
   Return 
   
   OBOZ:
   Return 
   
   OVER:
End Proc

Procedure MIASTO[NR]
   KONIEC=False : KONIEC2=False : KONIEC3=False
   CZYJE=MIASTA(NR,0,M_CZYJE)
   
   If CZYJE=1
      RO$="Rozkazy" : DANE=True
   Else 
      RO$="Wywiad"
      If MIASTA(NR,1,M_Y)>25
         DANE=False : D$="Brak informacji."
      Else 
         DNI=MIASTA(NR,1,M_Y)
         If DNI=1 : DN$=" dzień."
         Else 
            DN$=" dni."
         End If 
         DANE=False : D$="Informacje za "+Str$(DNI)+DN$
      End If 
      If MIASTA(NR,1,M_Y)=0
         RO$=""
         D$=""
         DANE=True
      End If 
   End If 
   If PREFS(5)=1 : WJAZD[MIASTA(NR,0,M_X),MIASTA(NR,0,M_Y),80,80,150,100,4] : End If 
   OKNO[80,80,150,100]
   GDX=OKX+106
   GADGET[OKX+4,OKY+4,142,74,"",31,2,30,1,-1]
   If RO$<>""
      GADGET[OKX+4,OKY+80,40,15,RO$,8,2,6,31,1]
   Else 
      GDX=OKX+55
   End If 
   GADGET[GDX,OKY+80,40,15,"   Ok  ",8,2,6,31,2]
   LUDZIE=MIASTA(NR,0,M_LUDZIE)
   PODATEK=MIASTA(NR,0,M_PODATEK)
   MORALE=MIASTA(NR,0,M_MORALE)
   MORALE2=MORALE/20
   If MORALE2>4 Then MORALE2=4
   MUR=MIASTA(NR,0,M_MUR)
   Paste Bob OKX+8,OKY+8,20+MUR
   If LUDZIE>700
      M$="Miasto : "
   Else 
      M$="Osada  : "
   End If 
   Ink 1,30 : Text OKX+50,OKY+15,M$+MIASTA$(NR)
   Set Zone 3,OKX+85,OKY+5 To OKX+145,OKY+16
   If DANE
      Text OKX+50,OKY+25,Str$(LUDZIE)+" mieszkańców"
      Text OKX+50,OKY+35,"Podatek : "+Str$(PODATEK)
      Text OKX+50,OKY+45,"Morale :"+GUL$(MORALE2)
      For I=2 To 10
         TYP=MIASTA(NR,I,M_LUDZIE)
         If TYP>3 : C$=BUDYNKI$(TYP) : D$=D$-C$ : D$=D$+C$+" " : End If 
      Next 
      NAPISZ[OKX+8,OKY+57,134,20,D$,0,1,30]
   Else 
      Text OKX+25,OKY+60,D$
   End If 
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=2 or STREFA=0
            KONIEC=True
            ZOKNO
         End If 
         If STREFA=3
            WPISZ[OKX+84,OKY+15,1,30,12]
            MIASTA$(NR)=WPI$
         End If 
         If STREFA=1 and CZYJE<>1
            ZOKNO
            KONIEC=True
            SZPIEGUJ[NR,0]
         End If 
         If STREFA=1 and CZYJE=1
            ZOKNO
            KONIEC=True
            Gosub RYSUJ_ROZKAZY
            KONIEC2=False
            Repeat 
               If Mouse Click=1
                  STREFA2=Mouse Zone
                  If STREFA2=2
                     ZOKNO
                     REKRUTACJA[Rnd(20),NR,-1]
                     Gosub RYSUJ_ROZKAZY
                  End If 
                  If STREFA2=4 and MIASTA(NR,0,M_MUR)<3
                     ZOKNO
                     BUDOWA_MURU[NR]
                     Gosub RYSUJ_ROZKAZY
                  End If 
                  If STREFA2=3
                     ZOKNO
                     ROZBUDOWA[NR]
                     KONIEC=True : KONIEC2=True
                     'Gosub RYSUJ_ROZKAZY 
                  End If 
                  If STREFA2=5
                     KONIEC2=True
                     ZOKNO
                  End If 
                  If STREFA2=1
                     ZOKNO
                     OKNO[90,90,135,70]
                     GADGET[OKX+4,OKY+4,100,64,"",31,2,30,1,0]
                     Paste Bob OKX+6,OKY+6,41
                     GADGET[OKX+110,OKY+4,20,15," « ",8,2,6,31,1]
                     GADGET[OKX+110,OKY+24,20,15," » ",8,2,6,31,2]
                     GADGET[OKX+110,OKY+52,20,15,"Ok",8,2,6,31,3]
                     Set Font FON2 : Get Block 120,OKX+6,OKY+6,32,32 : Gr Writing 0
                     Ink 23 : Text OKX+8,OKY+20,Str$(MIASTA(NR,0,M_PODATEK))-" "
                     KONIEC3=False
                     
                     Repeat 
                        If Mouse Key=LEWY
                           STREFA3=Mouse Zone
                           If STREFA3=1
                              Add MIASTA(NR,0,M_PODATEK),1,0 To 25
                              Put Block 120 : Text OKX+8,OKY+20,Str$(MIASTA(NR,0,M_PODATEK))-" "
                              Wait 5
                           End If 
                           
                           If STREFA3=2
                              Add MIASTA(NR,0,M_PODATEK),-1,0 To 25
                              Put Block 120 : Text OKX+8,OKY+20,Str$(MIASTA(NR,0,M_PODATEK))-" "
                              Wait 5
                           End If 
                           
                           If STREFA3=3
                              KONIEC3=True
                              Set Font FON1
                              ZOKNO
                              Gosub RYSUJ_ROZKAZY
                           End If 
                        End If 
                        
                     Until KONIEC3
                     
                  End If 
               End If 
            Until KONIEC2
         End If 
      End If 
   Until KONIEC
   Goto OVER
   RYSUJ_ROZKAZY:
   OKNO[110,90,90,110]
   GADGET[OKX+8,OKY+8,72,15,"Podatki",8,2,6,31,1]
   GADGET[OKX+8,OKY+28,72,15,"Nowy Legion",8,2,6,31,2]
   GADGET[OKX+8,OKY+48,72,15,"Rozbudowa",8,2,6,31,3]
   GADGET[OKX+8,OKY+68,72,15,"Budowa Murów",8,2,6,31,4]
   GADGET[OKX+8,OKY+88,72,15,"Exit",8,2,6,31,5]
   Return 
   OVER:
End Proc
Procedure ZROB_MIASTA
   For I=0 To 49
      AGAIN:
      X=Rnd(590)+20
      Y=Rnd(460)+20
      If Zone(X,Y)=0 and Zone(X+8,Y+8)=0 and Zone(X+4,Y+4)=0
         LUD=Rnd(900)+10
         CZYJE=0
         If I=43 or I=44 : CZYJE=2 : End If 
         If I=45 or I=46 : CZYJE=3 : End If 
         If I=47 or I=48 : CZYJE=4 : End If 
         If IMIONA$(1)="Lechu"
            CZYJE=1
            GRACZE(1,1)=100000
         End If 
         B1=8+CZYJE*2
         
         If LUD>700
            Inc B1
            MUR=Rnd(2)+1
            '            MIASTA(I,2,M_MUR)=6 
         Else 
            MUR=Rnd(1)
            '            TEREN[X+8,Y+8]
            '            MIASTA(I,2,M_MUR)=LOK 
         End If 
         POD=Rnd(25)
         MORALE=Rnd(100)
         TEREN[X+4,Y+4]
         If LOK=7 : LOK=1 : End If 
         MIASTA(I,1,M_X)=LOK
         Paste Bob X,Y,B1
         Set Zone 70+I,X-20,Y-20 To X+30,Y+30
         MIASTA(I,0,M_X)=X+8
         MIASTA(I,0,M_Y)=Y+8
         MIASTA(I,0,M_LUDZIE)=LUD
         MIASTA(I,0,M_PODATEK)=POD
         MIASTA(I,0,M_MORALE)=MORALE
         MIASTA(I,1,M_MORALE)=Rnd(10)+5
         MIASTA(I,0,M_CZYJE)=CZYJE
         MIASTA(I,0,M_MUR)=MUR
         MIASTA(I,1,M_Y)=30
         ROB_IMIE
         MIASTA$(I)=Param$
         X=50 : Y=50
         For J=2 To 9
            BUD=Rnd(9)
            'BUD=8 
            SZER=BUDYNKI(BUD,0) : SZER2=SZER/2
            WYS=BUDYNKI(BUD,1)
            Add X,Rnd(50)
            If X>580 : X=50 : Add Y,130+Rnd(30) : End If 
            MIASTA(I,J,M_X)=X
            MIASTA(I,J,M_Y)=Y
            MIASTA(I,J,M_LUDZIE)=BUD
            Add X,SZER
            'za co nieźle zapłaci
            MIASTA(I,J,M_PODATEK)=Rnd(18)+1
         Next J
         'modyfikatory cenowe w % 
         If CZYJE=1
            WAHANIA=20
         Else 
            WAHANIA=50
         End If 
         For J=1 To 19
            MIASTA(I,J,M_MUR)=Rnd(WAHANIA)
         Next J
      Else 
         Goto AGAIN
      End If 
   Next I
   For I=0 To 49
      X=MIASTA(I,0,M_X)-8
      Y=MIASTA(I,0,M_Y)-8
      Set Zone 70+I,X,Y To X+16,Y+16
   Next I
End Proc

Procedure VISUAL_OBJECTS
   For I=0 To 49
      CZYJE=MIASTA(I,0,M_CZYJE)
      B1=8+CZYJE*2
      LUD=MIASTA(I,0,M_LUDZIE)
      If LUD>700
         Inc B1
         '         MIASTA(I,2,M_MUR)=6
      Else 
         '         TEREN[X+8,Y+8] 
         '         MIASTA(I,2,M_MUR)=LOK
      End If 
      X=MIASTA(I,0,M_X)
      Y=MIASTA(I,0,M_Y)
      'to można potem wywalić
      '  TEREN[X+4,Y+4]
      '  If LOK=7 : LOK=1 : End If 
      '  MIASTA(I,1,M_X)=LOK 
      Paste Bob X-8,Y-8,B1
      Set Zone 70+I,X-8,Y-8 To X+8,Y+8
   Next I
   
   For A=0 To 39
      If ARMIA(A,0,TE)>0
         X=ARMIA(A,0,TX)
         Y=ARMIA(A,0,TY)
         B1=ARMIA(A,0,TBOB)
         B_DRAW[A,X,Y,B1]
      End If 
   Next A
   
   For I=0 To 3
      If PRZYGODY(I,P_TYP)>0 and PRZYGODY(I,P_LEVEL)=0
         X=PRZYGODY(I,P_X) : Y=PRZYGODY(I,P_Y)
         X2=X : Y2=Y
         LOSUJ:
         If Zone(X2,Y2)<>0 or X2<8 or X2>630 or Y2<10 or Y2>500
            X2=X+Rnd(60)-30 : Y2=Y+Rnd(60)-30
            Goto LOSUJ
         End If 
         PRZYGODY(I,P_X)=X2 : PRZYGODY(I,P_Y)=Y2
         If PRZYGODY(I,P_TEREN)=0
            TEREN[X2,Y2]
            PRZYGODY(I,P_TEREN)=LOK
         End If 
         Paste Bob X2,Y2,18
         Set Zone 121+I,X2,Y2 To X2+6,Y2+6
         '         Ink 17 : Box X2,Y2 To X2+6,Y2+6
      End If 
   Next I
   View : Wait Vbl 
End Proc
Procedure ZROB_ARMIE
   IMIONA$(0)="ufo"
   
   
   For L=0 To 2
      XG=Rnd(410)+100
      YG=Rnd(300)+100
      B1=4+L
      '      ROB_IMIE: IMIONA$(L+2)=Param$ 
      For K=0 To 2
         
         AR=(L*5)+20+K
         X=XG+Rnd(200)-100
         Y=YG+Rnd(200)-100
         If Upper$(Right$(IMIONA$(L+2),1))="I"
            KON$="ego"
         Else 
            KON$="a"
         End If 
         ARMIA$(AR,0)=Str$(K+1)+" Legion "+IMIONA$(L+2)+KON$
         ARMIA(AR,0,TX)=X
         ARMIA(AR,0,TY)=Y
         ARMIA(AR,0,TBOB)=B1
         ARMIA(AR,0,TMAG)=L+2
         NOWA_ARMIA[AR,10,-1]
         TEREN[X,Y]
         ARMIA(AR,0,TNOGI)=LOK
         B_DRAW[AR,X,Y,B1]
      Next K
   Next L
   'ustawianie początkowej załogi 
   
   X=Rnd(600)+20
   Y=Rnd(490)+10
   If TESTING
      X=190
      Y=190
   End If 
   NOWA_ARMIA[0,5,-1]
   ARMIA(0,0,TX)=X
   ARMIA(0,0,TY)=Y
   ARMIA(0,0,TBOB)=3
   ARMIA(0,0,TMAG)=1
   TEREN[X,Y]
   ARMIA(0,0,TNOGI)=LOK
   ARMIA(0,0,TAMO)=100
   B_DRAW[0,X,Y,3]
   
End Proc

Procedure ZAB
   '* po upływie 20-u rozmów do 50-u musi odpalić   
   'po każdym kliku w gadce dec bomba1 inc bomba2 
   'sprawdzanie bomby w mapa_akcja,ma_ruch,main_action
   'wychodzenie albo endami albo editami albo pokami albo gameover=true 
   'wywoływana przez co słychać albo przyłącz śie albo szmal albo samoistnie
   '* wywoływana przez ekwipunek ale b.rzadko rnd(100)=1  
   'w procedurze deaktywacja bomby nastawionej na X dni 
   'jeśli złe dane to wyjście od razu lub trochę dalej + bomba znowu + game_over=true     
   'jeśli dobre dane ustawienie bomby na następne rnd(50)+50 dni. 
   'Flash 13,"(a90,2)(ba0,2)(cb0,2)(db0,2)(ec0,2)(ed0,2)(fe0,2)(ff0,0)(ff2,2)(ff3,2)" 
   GADGET[150,20,150,90,"",26,24,25,30,-1]
   Gosub LOSOWANIE
   'Print L#  
   'Print L1,L2,L1-L2 
   'Wait Key  
   If STRONA=WIERSZ and WIERSZ=WYRAZ
      '      Print "kotś grzebał w danych" 
      Edit 
   End If 
   
   For Y=0 To 2
      For X=0 To 7
         GADGET[XP+(X*15),YP+(Y*15),13,13,Upper$(ZNAKI$(1+X+Y*8)),24,22,23,30,21+X+Y*8]
      Next X
   Next Y
   GADGET[XP+40,YP+46,36,13,"   OK",24,22,23,30,45]
   X=0 : Y=0
   Repeat 
      If Mouse Click=1
         If Mouse Zone>20 and Mouse Zone<45
            OLX=X : OLY=Y
            GADGET[XP+(OLX*15),YP+(OLY*15),13,13,Upper$(ZNAKI$(1+OLX+OLY*8)),24,22,23,30,-1]
            I=Mouse Zone-20
            X=(I mod 8)-1
            If X=-1 : X=7 : End If 
            Y=(I-1)/8
            GADGET[XP+(X*15),YP+(Y*15),13,13,Upper$(ZNAKI$(1+X+Y*8)),21,23,22,13,0]
         End If 
         If Mouse Zone=45
            OLX=X : OLY=Y
            GADGET[XP+(OLX*15),YP+(OLY*15),13,13,Upper$(ZNAKI$(1+OLX+OLY*8)),24,22,23,30,-1]
            If I<>L# or OLDL=L#
               OLDL=L#
               GAME_OVER=True
               BOMBA3=True
               Gosub LOSOWANIE
               'mydło 
               CXZ=WER-2
               CNVB=CNVB+SERF
            Else 
               BOMBA1#=83+Rnd(30)
               BOMBA3=False
               GAME_OVER=False
               'mydło 
               CXZ=WER-4
               CNVB=CXZ
               BOMBA2#=0
               KONIEC=True
            End If 
            QERWT=WER
            VNCM=WRRU
            If I<>L#
               CNX=CNB
               FGJK=DJFKD*ETURE
               BOMBA3=True
            End If 
         End If 
      End If 
   Until KONIEC
   Goto OVER
   
   LOSOWANIE:
   A#=Abs(BOARD#(Rnd(125)))
   '   A#=Abs(BOARD#(1))
   OLDL=L#
   
   'Print At(1,1);A#
   _POINTER=(A#*10000+1) mod 100
   STRONA=Int(A#)
   WIERSZ=((A#-STRONA)*10)+1
   BOMBA1=False
   WYRAZ=(Int(((A#*10)-Int(A#*10))*10))+1
   'Print _POINTER
   L#=LITERY#(_POINTER)
   L1=Abs(L#*100)
   L2=Abs((L#*100)/100)
   L2=L2*100
   L#=L1-L2
   XP=163 : YP=46
   BOMBA4=False
   Ink 25 : Bar XP,YP-24 To XP+120,YP
   If OLDL=L#
      'Bell  
      ERR#=ERR#+0.01
   Else 
      ERR#=ERR#+0.02
   End If 
   'Print ERR#,OLDL,L#
   Ink 30,25
   Text XP,YP-15,"Podaj pierwszą literę wyrazu."
   'zamiast edit jakiś poke niszczący system' 
   If ERR#>0.04 : ERR#=ARMIA(YP,0,1) : End If 
   Text XP,YP-5,Str$(STRONA)+" strona,"+Str$(WIERSZ)+" wiersz,"+Str$(WYRAZ)+" wyraz"
   Return 
   
   OVER:
   For S=20 To 45 : Reset Zone S : Next 
End Proc

Procedure OKNO[OKX,OKY,SZER,WYS]
   Add OKX,SX
   Add OKY,SY
   Get Block 100,OKX,OKY,SZER+16,WYS+16,1
   Ink 17 : Box OKX,OKY To OKX+SZER,OKY+WYS
End Proc
Procedure ZOKNO
   Put Block 100,OKX,OKY
   For I=1 To 19
      Reset Zone I
   Next I
End Proc
Procedure WJAZD[XS,YS,X1,Y1,SZER,WYS,_WAIT]
   Gr Writing 3 : Ink 20
   For I=1 To _WAIT
      Box XS-4,YS-4 To XS+4,YS+4
      Wait 2
   Next I
   Add X1,SX
   Add Y1,SY
   SPEED=15
   DX1=((X1-XS)/SPEED)
   DX2=((X1+SZER-XS)/SPEED)
   DY1=((Y1-YS)/SPEED)
   DY2=((Y1+WYS-YS)/SPEED)
   
   XB1=XS : YB1=YS : XB2=XS : YB2=YS
   Repeat 
      Add XB1,DX1
      Add XB2,DX2
      Add YB1,DY1
      Add YB2,DY2
      If Abs(X1-XB1)<SPEED : XB1=X1 : End If 
      If Abs(Y1-YB1)<SPEED : YB1=Y1 : End If 
      If Abs(X1+SZER-XB2)<SPEED : XB2=X1+SZER : End If 
      If Abs(Y1+WYS-YB2)<SPEED : YB2=Y1+WYS : End If 
      Box XB1,YB1 To XB2,YB2
      Wait Vbl 
      Box XB1,YB1 To XB2,YB2
      
      
   Until XB1=X1 and YB1=Y1 and XB2=X1+SZER and YB2=Y1+WYS
   Gr Writing 0
End Proc

Procedure OPCJE
   Gosub RYSUJ
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=1
            
            ZOKNO
            _LOAD_GAME
            JEST=Param
            If JEST
               KONIEC=True
               Reset Zone 
               Del Block 
               Sprite Off 2
               SETUP0
               VISUAL_OBJECTS
               Change Mouse 5
               Sprite 2,SPX,SPY,1
               CENTER[10,10,0]
            Else 
               Gosub RYSUJ
            End If 
         End If 
         If STREFA=2
            ZOKNO
            _SAVE_GAME
            Gosub RYSUJ
         End If 
         If STREFA=3
            ZOKNO
            STATUS
            Gosub RYSUJ
         End If 
         If STREFA=4
            ZOKNO
            PREFERENCJE
            Gosub RYSUJ
         End If 
         If STREFA=5
            REAL_KONIEC=True
            KONIEC=True
            ZOKNO
         End If 
         If STREFA=6
            KONIEC=True
            ZOKNO
         End If 
      End If 
   Until KONIEC
   Goto OVER
   RYSUJ:
   OKNO[100,60,140,160]
   SZMAL$=Str$(GRACZE(1,1))-" "
   DZIEN$=Str$(DZIEN)-" "
   GADGET[OKX+10,OKY+8,120,15,"Dzien "+DZIEN$+"  Skarbiec:"+SZMAL$,7,0,4,31,-1]
   GADGET[OKX+10,OKY+28,120,15,"Odczyt Gry",8,1,6,31,1]
   GADGET[OKX+10,OKY+48,120,15,"Zapis Gry",8,1,6,31,2]
   GADGET[OKX+10,OKY+68,120,15,"Statystyka",8,1,6,31,3]
   GADGET[OKX+10,OKY+88,120,15,"Preferencje",8,1,6,31,4]
   GADGET[OKX+10,OKY+108,120,15,"Koniec Gry",8,1,6,31,5]
   GADGET[OKX+10,OKY+128,120,15,"Exit",8,1,6,31,6]
   Return 
   OVER:
End Proc
Procedure PREFERENCJE
   Gosub RYSUJ
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA>0 and STREFA<6
            If PREFS(STREFA)=1
               PREFS(STREFA)=0
               Text OKX+120,OKY+18+(STREFA*20),"  "
               If STREFA=3
                  _TRACK_FADE[1]
                  Erase 3
               End If 
            Else 
               PREFS(STREFA)=1
               Text OKX+120,OKY+18+(STREFA*20),"@"
               If STREFA=3
                  _LOAD[KAT$+"mod.legion","legion:mod.legion","Legion",6]
                  Track Loop On : Track Play 
               End If 
            End If 
         End If 
         If STREFA=6
            KONIEC=True
            ZOKNO
         End If 
      End If 
   Until KONIEC
   Goto OVER
   RYSUJ:
   OKNO[100,60,140,160]
   GADGET[OKX+10,OKY+8,120,15," Preferencje Gry",7,0,4,31,-1]
   GADGET[OKX+10,OKY+28,120,15,"Imiona Wojowników",8,1,6,31,1]
   GADGET[OKX+10,OKY+48,120,15,"Szybki skrol mapy ",8,1,6,31,2]
   GADGET[OKX+10,OKY+68,120,15,"Muzyka",8,1,6,31,3]
   GADGET[OKX+10,OKY+88,120,15,"Trupy",8,1,6,31,4]
   GADGET[OKX+10,OKY+108,120,15,"Bajery",8,1,6,31,5]
   GADGET[OKX+10,OKY+128,120,15,"Exit",8,1,6,31,6]
   Gr Writing 1
   Ink 31,6
   For STREFA=1 To 5
      If PREFS(STREFA)=0
         Text OKX+120,OKY+18+(STREFA*20),"  "
      Else 
         Text OKX+120,OKY+18+(STREFA*20),"@"
      End If 
   Next 
   Return 
   OVER:
End Proc
Procedure STATUS
   OKNO[80,80,160,120]
   GADGET[OKX+4,OKY+4,152,92,"",31,2,30,1,-1]
   GADGET[OKX+4,OKY+100,40,15,"Wykresy",8,1,6,31,2]
   GADGET[OKX+116,OKY+100,40,15,"   Ok",8,1,6,31,1]
   For A=0 To 19
      If ARMIA(A,0,TE)>0
         Inc AM
         For I=1 To 10
            If ARMIA(A,I,TE)>0
               Inc WOJ
            End If 
         Next I
      End If 
   Next A
   RES=AM mod 10
   KON$="" : KON2$="ów"
   If RES<=1 or RES>4 : KON$="ów" : End If 
   If RES>1 and RES<5 : KON$="y" : End If 
   If AM=1 : KON$="" : End If 
   If WOJ=1 : KON2$="" : End If 
   A$=Str$(AM)+" legion"+KON$+", "+Str$(WOJ)+" wojownik"+KON2$
   For M=0 To 49
      If MIASTA(M,0,M_CZYJE)=1
         Inc MS
         Add LUDZIE,MIASTA(M,0,M_LUDZIE)
         Add POD,MIASTA(M,0,M_PODATEK)*MIASTA(M,0,M_LUDZIE)/25
      End If 
   Next M
   RES=MS mod 10
   KON$=""
   If RES>1 and RES<5 : KON$="a" : End If 
   If MS=1 : KON$="o" : End If 
   B$=Str$(MS)+" miast"+KON$+", "+Str$(LUDZIE)+" mieszkańców"
   C$="Dzienny dochód : "+Str$(POD)
   Gosub NAPISZ
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=1
            KONIEC=True
         End If 
         If STREFA=2
            Ink 30 : Bar OKX+5,OKY+5 To OKX+150,OKY+90
            For I=1 To 4
               WYS=GRACZE(I,2)/250
               KOL=GRACZE(I,3)
               If WYS>100 : WYS=100 : End If 
               If WYS<4 : WYS=4 : End If 
               Ink 1,30 : Text OKX+8,OKY+4+I*20,IMIONA$(I)
               '               Ink KOL+1 : Box OKX+50,OKY-8+I*20 To OKX+50+WYS,OKY-8+I*20+15
               Ink KOL+1 : Box OKX+50,OKY-8+I*20 To OKX+49+WYS,OKY-9+I*20+15
               Ink 25 : Box OKX+51,OKY-7+I*20 To OKX+50+WYS,OKY-8+I*20+15
               
               Ink KOL : Bar OKX+51,OKY-7+I*20 To OKX+49+WYS,OKY-9+I*20+15
            Next I
            Repeat 
            Until Mouse Click=1
            Ink 30 : Bar OKX+5,OKY+5 To OKX+150,OKY+90
            Gosub NAPISZ
         End If 
      End If 
   Until KONIEC
   Goto OVER
   NAPISZ:
   Ink 1,30 : Text OKX+8,OKY+16,"Raport na dzień: "+Str$(DZIEN)
   Text OKX+8,OKY+16+10,"W twoim władaniu :"
   Text OKX+8,OKY+24+20,A$
   Text OKX+8,OKY+24+30,B$
   Text OKX+8,OKY+34+40,C$
   Text OKX+8,OKY+34+50,"W skarbcu: "+Str$(GRACZE(1,1))
   Return 
   OVER:
   ZOKNO
   
End Proc

Procedure SETUP0
   Erase All 
   'Auto View Off 
   _LOAD[KAT$+"mapa2.org","Legion:mapa2.org","Legion",3]
   Screen Display 0,130,40,320,255
   Reserve Zone 130
   Limit Mouse 128,40 To 447,298
   Bob Update On : Sprite Update On 
   Flash Off 
   USTAW_FONT["garnet",16]
   FON2=FONR
   USTAW_FONT["defender2",8]
   FON1=FONR
   _LOAD[KAT$+"mapa","Legion:mapa","Legion",0]
   Change Mouse 5
   CELOWNIK=43
   Show On 
   BUBY=-1
   SPX=425 : SPY=270
   MSX=320 : MSY=256
   Sprite 2,SPX,SPY,1
   '   View 
   If PREFS(3)=1 : _LOAD[KAT$+"mod.legion","legion:mod.legion","Legion",6] : Track Play : Track Loop On : End If 
End Proc
Procedure REKRUTACJA[ILU,MIASTO,A1]
   Dim REKRUCI(10)
   JEST=False
   KONIEC=False
   CENA=0
   ILU=0
   
   If MIASTA(MIASTO,1,M_PODATEK)=0
      If A1=-1
         For A=0 To 19
            If ARMIA(A,0,TE)=0
               Gosub RYSUJ
               Exit 
            End If 
         Next A
      Else 
         A=A1
         Gosub RYSUJ
      End If 
      
      If JEST
         Repeat 
            If Mouse Key=LEWY
               STREFA=Mouse Zone
               If STREFA>0 and STREFA<11
                  I=STREFA
                  If ARMIA(A2,I,TE)>0
                     ARMIA(A2,I,TE)=0
                     Ink 4 : Bar OKX+145,OKY+26+I*15 To OKX+155,OKY+36+I*15
                     Add CENA,-1000 : Dec WOJ
                     Ink 6 : Bar OKX+64,OKY+193 To OKX+96,OKY+205 : Ink 31,6 : Text OKX+66,OKY+202,Str$(CENA)
                  Else 
                     ARMIA(A2,I,TE)=ARMIA(A2,I,TEM)
                     Ink 31,4 : Text OKX+149,OKY+33+I*15,"@"
                     Add CENA,1000 : Inc WOJ
                     Ink 6 : Bar OKX+64,OKY+193 To OKX+96,OKY+205 : Ink 31,6 : Text OKX+66,OKY+202,Str$(CENA)
                  End If 
               End If 
               If STREFA=11
                  WPISZ[OKX+8,OKY+31,31,4,14]
                  ARMIA$(A2,0)=WPI$
               End If 
               If STREFA=13 and WOJ>0 and GRACZE(1,1)-CENA>=0
                  Add GRACZE(1,1),-CENA
                  ARMIA(A2,0,TE)=WOJ
                  MIASTA(MIASTO,1,M_PODATEK)=30
                  ZOKNO
                  If A1=-1
                     ARMIA(A2,0,TAMO)=100
                     ARMIA(A2,0,TMAG)=1
                     XA=MIASTA(MIASTO,0,M_X)
                     YA=MIASTA(MIASTO,0,M_Y)
                     ARMIA(A2,0,TX)=XA
                     ARMIA(A2,0,TY)=YA
                     ARMIA(A2,0,TNOGI)=MIASTO+70
                     ARMIA(A2,0,TBOB)=3
                     B_DRAW[A2,XA,YA,3]
                  End If 
                  KONIEC=True
               End If 
               If STREFA=12
                  For I=1 To 10 : If REKRUCI(I)=1 : ARMIA(A2,I,TE)=0 : End If : Next I
                  ZOKNO
                  KONIEC=True
               End If 
               While Mouse Key=LEWY : Wend 
            End If 
            
         Until KONIEC
         
      Else 
         MESSAGE[MIASTO,"Nie możesz dowodzić większą liczbą wojsk.",0,1]
      End If 
   Else 
      DNI=MIASTA(MIASTO,1,M_PODATEK)
      MESSAGE[MIASTO,"Wystawimy nowych wojowników za "+Str$(DNI)+" Dni.",0,1]
   End If 
   Goto OVER
   RYSUJ:
   A2=A
   JEST=True
   OKNO[70,30,162,210]
   A$=MIASTA$(MIASTO)+" wystawiło rekrutów."
   GADGET[OKX+4,OKY+4,154,15,A$,31,2,30,1,-1]
   If A1=-1
      A$="Legion "+Str$(A+1)
   Else 
      A$=ARMIA$(A,0)
   End If 
   GADGET[OKX+4,OKY+22,70,13,A$,7,0,4,31,11]
   ARMIA$(A2,0)=A$
   GADGET[OKX+77,OKY+22,70,13,"En  Si  Sz  Mag",7,0,4,31,-1]
   GADGET[OKX+4,OKY+192,45,15,"Odwołać",7,0,4,31,12]
   GADGET[OKX+113,OKY+192,45,15,"   Ok",7,0,4,31,13]
   GADGET[OKX+55,OKY+192,50,15,"",8,1,6,31,-1]
   For I=1 To 10
      If A1>-1 and ARMIA(A,I,TE)<=0 or A1=-1
         REKRUCI(I)=1
         NOWA_POSTAC[A,I,Rnd(8)]
         ARMIA(A,I,TE)=0
         A$=ARMIA$(A,I)+" "+RASY$(ARMIA(A,I,TRASA))
         GADGET[OKX+4,OKY+24+I*15,138,13,A$,8,1,6,31,-1]
         GADGET[OKX+144,OKY+24+I*15,15,13,"",7,0,4,31,I]
         Ink 23,6 : Text OKX+77,OKY+34+I*15,Str$(ARMIA(A,I,TEM))
         Text OKX+95,OKY+34+I*15,Str$(ARMIA(A,I,TSI))
         Text OKX+110,OKY+34+I*15,Str$(ARMIA(A,I,TSZ))
         Text OKX+125,OKY+34+I*15,Str$(ARMIA(A,I,TMAG))
      End If 
   Next I
   Return 
   OVER:
End Proc
Procedure BUDOWA_MURU[MIASTO]
   OKNO[110,100,80,84]
   MUR=MIASTA(MIASTO,0,M_MUR)
   GADGET[OKX+4,OKY+44,72,15,"Granitowy",8,1,6,31,3]
   Ink 23,6 : Text OKX+52,OKY+54,"10000"
   If MUR<2
      GADGET[OKX+4,OKY+24,72,15,"Kamienny ",8,1,6,31,2]
      Ink 23,6 : Text OKX+52,OKY+34,"7000"
   End If 
   If MUR<1
      GADGET[OKX+4,OKY+4,72,15,"Palisada ",8,1,6,31,1]
      Ink 23,6 : Text OKX+52,OKY+14,"4000"
   End If 
   GADGET[OKX+4,OKY+64,72,15,"       Exit",8,1,6,31,10]
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=10
            KONIEC=True
         End If 
         If STREFA>0 and STREFA<4 and GRACZE(1,1)-(4000+(STREFA-1)*3000)>=0
            KONIEC=True
            Add GRACZE(1,1),-(4000+(STREFA-1)*3000)
            MIASTA(MIASTO,0,M_MUR)=STREFA
         End If 
      End If 
   Until KONIEC
   ZOKNO
End Proc
Procedure ROZBUDOWA[MIASTO]
   MIA$=MIASTA$(MIASTO)
   TEREN=MIASTA(MIASTO,1,M_X)
   If PREFS(3)=1 : _TRACK_FADE[1] : End If 
   Sprite Off 2
   '----
   Show On 
   Erase All 
   Screen Open 2,80,50,32,Lowres : Curs Off : Flash Off : Screen Display 2,252,140,80,50 : Cls 0 : Screen Hide 2
   Screen Open 0,640,512,32,Lowres : Screen Display 0,130,40,320,234
   Curs Off : Flash Off : Cls 0 : Screen Hide 
   Reserve Zone 200
   '------------------
   Screen Open 1,320,160,32,Lowres : Screen Display 1,130,265,320,35
   Curs Off : Flash Off : Cls 10 : Screen Hide 
   Reserve Zone 30
   _LOAD[KAT$+"dane/gad","dane:gad","Dane",0] : Get Bob Palette 
   _LOAD[KAT$+"dane/gad3","dane:gad3","Dane",1]
   USTAW_FONT["defender2",8]
   Change Mouse 53
   Paste Bob 0,0,1
   Gr Writing 0 : Ink 21 : Text 8,10,"Rozbudowa miasta "+MIA$
   Ink 1 : Text 7,9,"Rozbudowa miasta "+MIA$
   For I=0 To 5
      BB$="bob"+Str$(51+I)-" "
      GADGET[4+I*24,12,20,20,BB$,5,12,9,1,I+1]
   Next I
   GADGET[165,2,110,30,"",0,5,22,1,-1]
   GADGET[280,6,30,20," exit",7,0,11,1,10]
   '------------------
   Screen 0
   USTAW_FONT["defender2",8]
   BIBY=62
   MSX=320 : MSY=278
   '----- 
   RYSUJ_SCENERIE[TEREN,MIASTO]
   Screen Show 0 : Screen Show 1
   View 
   Track Stop 
   Screen 1
   Repeat 
      HY=Y Mouse
      If HY>263
         Screen 1
         If Mouse Click=1
            STREFA=Mouse Zone
            If STREFA>0 and STREFA<8
               I=STREFA+3
               BB$="bob"+Str$(56+STREFA)-" "
               GADGET[4+(STREFA-1)*24,12,20,20,BB$,12,5,11,1,0]
               SZER=BUDYNKI(I,0) : SZER2=SZER/2
               WYS=BUDYNKI(I,1) : WYS2=WYS/2
               CENA=BUDYNKI(I,2)
               CZAS=BUDYNKI(I,3)
               B1=BUDYNKI(I,4)
               A$=BUDYNKI$(I)
               TYP=I
               Gosub WYPISZ
               BB$="bob"+Str$(50+STREFA)-" "
               GADGET[4+(STREFA-1)*24,12,20,20,BB$,5,12,9,1,-1]
            End If 
            If STREFA=10
               GADGET[280,6,30,20," exit",0,7,12,1,0]
               KONIEC=True
               GADGET[280,6,30,20," exit",7,0,11,1,0]
            End If 
         End If 
      Else 
         HY=Y Mouse
         Screen 0
         B$=Inkey$
         KLAW=Scancode
         If Mouse Key=PRAWY : SKROL[0] : End If 
         If KLAW>75 and KLAW<80
            KLAWSKROL[KLAW]
         End If 
         If SZER>0
            Gr Writing 3
            X=X Screen(X Mouse)-SZER2
            Y=Y Screen(Y Mouse)-WYS2
            Box X,Y To X+SZER,Y+WYS : Wait Vbl 
            Box X,Y To X+SZER,Y+WYS
         End If 
         If Mouse Click=1 and SZER>0 and GRACZE(1,1)-CENA>=0
            Gosub CHECK
            For I=2 To 20
               
               If MIASTA(MIASTO,I,M_LUDZIE)=0 and MOZNA
                  Paste Bob X,Y,BIBY+12+B1
                  MIASTA(MIASTO,I,M_X)=X
                  MIASTA(MIASTO,I,M_Y)=Y
                  MIASTA(MIASTO,I,M_LUDZIE)=TYP
                  Add MIASTA(MIASTO,1,M_MORALE),2
                  Add MIASTA(MIASTO,0,M_MORALE),20
                  Set Zone 120+I,X,Y To X+SZER,Y+WYS
                  Add GRACZE(1,1),-CENA
                  Screen 1 : Gosub WYPISZ : Screen 0
                  Exit 
               End If 
            Next I
         End If 
      End If 
   Until KONIEC
   Goto OVER
   '----------- 
   CHECK:
   MOZNA=False
   If X>0 and X+SZER<640 and Y>0 and Y+WYS<512
      If Zone(X,Y)=0 and Zone(X+SZER,Y)=0 and Zone(X,Y+WYS)=0 and Zone(X+SZER,Y+WYS)=0 and Zone(X+SZER2,Y+WYS2)=0
         MOZNA=True
      End If 
   End If 
   Return 
   '----------    
   WYPISZ:
   Ink 22 : Bar 167,3 To 167+105,3+28
   Ink 1,22 : Text 172,15,A$
   Text 172,25,"cena :"+Str$(CENA)
   '   Text 167,30,"budowa:"+Str$(CZAS)+" dni"
   Set Font FON2 : Text 210,12,Str$(GRACZE(1,1)) : Set Font FON1
   
   Return 
   '----------
   OVER:
   Erase All 
   Screen Close 2
   Screen Close 1
   Screen Close 0
   SETUP0
   VISUAL_OBJECTS
   Sprite 2,SPX,SPY,1
   CENTER[MIASTA(MIASTO,0,M_X),MIASTA(MIASTO,0,M_Y),0]
End Proc
Procedure SZPIEGUJ[NR,CO]
   OKNO[80,90,156,100]
   GADGET[OKX+4,OKY+4,104,92,"",31,2,30,1,-1]
   GADGET[OKX+112,OKY+4,18,15," «",8,2,6,31,1]
   GADGET[OKX+133,OKY+4,18,15," »",8,2,6,31,2]
   GADGET[OKX+112,OKY+24,40,15,"",31,2,30,1,-1]
   GADGET[OKX+112,OKY+61,40,15,"Odwołać",8,2,6,31,3]
   GADGET[OKX+112,OKY+81,40,15,"    Ok",8,2,6,31,4]
   Paste Bob OKX+8,OKY+8,35
   CENA=0
   DNI=22
   Gosub WYPISZ
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=1 or STREFA=2
         If STREFA=1 : ZN=1 : Else ZN=-1 : End If 
            Add CENA,ZN*50,0 To 1000
            Add DNI,-ZN,2 To 22
            Ink 30 : Bar OKX+113,OKY+25 To OKX+150,OKY+38
            Ink 1,30 : Text OKX+120,OKY+34,Str$(CENA)
            Gosub WYPISZ
         End If 
         If STREFA=4
            If GRACZE(1,1)-CENA>=0
               If CENA>100
                  If CO=0
                     MIASTA(NR,1,M_Y)=DNI
                  End If 
                  If CO=1
                     ARMIA(NR,0,TMAGMA)=DNI
                  End If 
                  Add GRACZE(1,1),-CENA
               End If 
               KONIEC=True
            End If 
         End If 
         If STREFA=3 : KONIEC=True : End If 
      End If 
   Until KONIEC
   Goto OVER
   WYPISZ:
   If CENA<=100
      A$="ładną mamy dziś "
      B$="pogodę."
      If CENA=0
         A$="Za informacje trzeba"
         B$="zapłacić."
      End If 
   Else 
      A$="Za "+Str$(DNI)+" dni"
      B$="będę coś wiedział."
   End If 
   Ink 30 : Bar OKX+5,OKY+68 To OKX+102,OKY+92
   Ink 1,30 : Text OKX+12,OKY+80,A$
   Text OKX+12,OKY+90,B$
   Return 
   OVER:
   ZOKNO
End Proc
Procedure ARMIA[A]
   AX=ARMIA(A,0,TX)
   AY=ARMIA(A,0,TY)
   PL=ARMIA(A,0,TMAG)
   If PREFS(5)=1 : WJAZD[AX,AY,80,80,150,100,4] : End If 
   OKNO[80,80,150,100]
   GD=40
   If A<20
      RO$="Rozkazy"
      DANE=True
   Else 
      RO$="Wywiad"
      If ARMIA(A,0,TMAGMA)>28 and ARMIA(A,0,TMAGMA)<100
         DANE=False : D$="Brak informacji."
      Else 
         If ARMIA(A,0,TMAGMA)>1
            DNI$=" dni."
         Else 
            DNI$=" dzień."
         End If 
         DANE=False : D$="Informacje za "+Str$(ARMIA(A,0,TMAGMA))+DNI$
      End If 
      If ARMIA(A,0,TMAGMA)=0 or ARMIA(A,0,TMAGMA)=100
         RO$="śledzenie"
         GD=52
         DANE=True
      End If 
   End If 
   GADGET[OKX+4,OKY+4,142,74,"",31,2,30,1,-1]
   GADGET[OKX+4,OKY+80,GD,15,RO$,8,2,6,31,10]
   GADGET[OKX+106,OKY+80,40,15,"   Ok  ",8,2,6,31,1]
   If ARMIA(A,0,TMAGMA)=100 : Ink 31,6 : Text OKX+48,OKY+89,"@" : End If 
   No Mask 23+PL : Paste Bob OKX+8,OKY+8,23+PL
   Set Zone 11,OKX+50,OKY+5 To OKX+120,OKY+15
   Ink 1,30 : Text OKX+50,OKY+15,ARMIA$(A,0)
   If DANE
      For I=1 To 10
         If ARMIA(A,I,TE)>0
            Add WOJ,1
            Add SILA,ARMIA(A,I,TSI)
            Add SILA,ARMIA(A,I,TE)
            Add SPEED,ARMIA(A,I,TSZ)
         End If 
      Next I
      ARMIA(A,0,TE)=WOJ
      SPEED=((SPEED/WOJ)/5)
      ARMIA(A,0,TSZ)=SPEED
      ARMIA(A,0,TSI)=SILA
      AX=ARMIA(A,0,TX)
      AY=ARMIA(A,0,TY)
      TRYB=ARMIA(A,0,TTRYB)
      CELX=ARMIA(A,0,TCELX)
      CELY=ARMIA(A,0,TCELY)
      ROZ=ARMIA(A,0,TTRYB)
      TEREN=ARMIA(A,0,TNOGI)
      WOJ$=" wojowników"
      If WOJ=1 : WOJ$=" wojownik" : End If 
      If ROZ=0
         RO$="Oddział obozuje"
         If TEREN>69
            RO$=RO$+" w "+MIASTA$(TEREN-70)
         End If 
      End If 
      If ROZ=1 or ROZ=2 : RO$="Odział w ruchu" : End If 
      If ROZ=3
         If CELY=0
            R2$=ARMIA$(CELX,0)
         Else 
            R2$=MIASTA$(CELX)
         End If 
         RO$="Atakujemy "+R2$
      End If 
      If ROZ=4 : RO$="Tropimy zwierzyne" : End If 
      ZARCIE=ARMIA(A,0,TAMO)/WOJ
      DNI$="żywność na"+Str$(ZARCIE)+" dni"
      If ZARCIE=1 : DNI$="żywność na 1 dzień" : End If 
      If ZARCIE<=0 : DNI$="Brak żywności !" : End If 
      Ink 1,30
      Text OKX+50,OKY+35,"Siła      :"+Str$(SILA)
      Text OKX+50,OKY+25,Str$(WOJ)+WOJ$
      Text OKX+50,OKY+45,DNI$
      Text OKX+50,OKY+55,"Szybkość  :"+Str$(SPEED)
      Text OKX+12,OKY+65,RO$
   Else 
      Text OKX+25,OKY+60,D$
   End If 
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA=1 or STREFA=0
            KONIEC=True
            ZOKNO
         End If 
         If STREFA=11
            WPISZ[OKX+50,OKY+15,1,30,14]
            ARMIA$(A,0)=WPI$
         End If 
         If STREFA=10 and A<20
            ZOKNO
            KONIEC=True
            Gosub RYSUJ_ROZKAZY
            KONIEC2=False
            Repeat 
               If Mouse Click=1
                  STREFA2=Mouse Zone
                  If STREFA2>0 and STREFA2<4
                     ZOKNO
                     M_RUCH[A,STREFA2]
                     KONIEC2=True : KONIEC=True
                  End If 
                  If STREFA2=4 and TEREN<70
                     ZOKNO
                     ARMIA(A,0,TTRYB)=4
                     KONIEC=True : KONIEC2=True
                  End If 
                  If STREFA2=4 and TEREN>69
                     If MIASTA(TEREN-70,0,M_CZYJE)=1
                        ZOKNO
                        ARMIA(A,0,TTRYB)=0
                        REKRUTACJA[10,TEREN-70,A]
                        Gosub RYSUJ_ROZKAZY
                     End If 
                  End If 
                  
                  If STREFA2=6
                     ZOKNO
                     Sprite Off 2
                     'Auto View Off 
                     _LOAD[KAT$+"dane/gad","dane:gad","Dane",1]
                     Screen Open 1,320,160,32,Lowres
                     Screen 1
                     Curs Off : Flash Off 
                     Reserve Zone 60 : Get Bob Palette : Set Font FON1
                     GOBY=44
                     'Auto View On  
                     ARM=A
                     For I=1 To 10
                        If ARMIA(A,I,TE)>0
                           NUMER=I
                           I=10
                        End If 
                     Next 
                     WYBOR[1]
                     Screen Close 1
                     For I=1 To 50
                        Del Bob GOBY+1
                     Next 
                     Screen 0
                     Sprite 2,SPX,SPY,1
                     Gosub RYSUJ_ROZKAZY
                  End If 
                  
                  If STREFA2=8
                     KONIEC=True : KONIEC2=True
                     ARMIA(A,0,TWAGA)=1
                     ARM=A : WRG=40
                     Sprite Off 2
                     SETUP["Akcja","w","terenie"]
                     If TEREN>69
                        TER2=MIASTA(TEREN-70,1,M_X)
                        RYSUJ_SCENERIE[TER2,TEREN-70]
                        WRG=40
                        'ustaw wieśniaków
                        For I=1 To 7 : NOWA_POSTAC[40,I,9] : Next I
                        For I=8 To 10 : NOWA_POSTAC[40,I,Rnd(8)] : Next I
                        For I=1 To 7 : ARMIA(40,I,TKORP)=20 : Next I
                        For I=8 To 10 : ARMIA(WRG,I,TKORP)=40 : Next I
                        ARMIA(40,0,TE)=10
                        USTAW_WOJSKO[WRG,1,1,1]
                     Else 
                        ARMIA(WRG,0,TE)=0
                        RYSUJ_SCENERIE[TEREN,-1]
                     End If 
                     USTAW_WOJSKO[ARM,1,1,0]
                     MAIN_ACTION
                     'skasuj wieśniaków 
                     For I=0 To 10 : ARMIA(40,I,TE)=0 : Next I
                     SETUP0
                     VISUAL_OBJECTS
                     CENTER[AX,AY,0]
                     Sprite 2,SPX,SPY,1
                  End If 
                  
                  If STREFA2=5
                     ZOKNO
                     ARMIA(A,0,TTRYB)=0
                     KONIEC=True : KONIEC2=True
                  End If 
                  If STREFA2=7
                     ZOKNO
                     KONIEC2=True
                  End If 
               End If 
            Until KONIEC2
         End If 
         If STREFA=10 and A>19
            If ARMIA(A,0,TMAGMA)=0
               Ink 31,6 : Text OKX+48,OKY+89,"@"
               ARMIA(A,0,TMAGMA)=100
               Goto SKIP
            End If 
            If ARMIA(A,0,TMAGMA)=100
               Gr Writing 1 : Ink 6,6
               Text OKX+47,OKY+89,"  "
               ARMIA(A,0,TMAGMA)=0
            End If 
            If ARMIA(A,0,TMAGMA)>0 and ARMIA(A,0,TMAGMA)<100
               ZOKNO
               KONIEC=True
               SZPIEGUJ[A,1]
            End If 
            SKIP:
         End If 
      End If 
   Until KONIEC
   Goto OVER
   RYSUJ_ROZKAZY:
   AWT=ARMIA(A,0,TWAGA)
   If AWT=1
      WYS=135
   Else  
      WYS=150
   End If 
   OKNO[110,70,80,WYS]
   GADGET[OKX+4,OKY+4,72,15,"Ruch",8,2,6,31,1]
   GADGET[OKX+4,OKY+40,72,15,"Atak",8,2,6,31,3]
   GADGET[OKX+4,OKY+2+20,72,15,"Szybki Ruch",8,2,6,31,2]
   If TEREN<70
      GADGET[OKX+4,OKY+58,72,15,"Polowanie",8,2,6,31,4]
   Else 
      GADGET[OKX+4,OKY+58,72,15,"Rekrutacja",8,2,6,31,4]
   End If 
   GADGET[OKX+4,OKY+76,72,15,"Obóz",8,2,6,31,5]
   GADGET[OKX+4,OKY+94,72,15,"Ekwipunek",8,2,6,31,6]
   If AWT=0
      GADGET[OKX+4,OKY+112,72,15,"Akcja w terenie",8,2,6,31,8]
      GADGET[OKX+4,OKY+130,72,15,"Exit",8,2,6,31,7]
   Else 
      GADGET[OKX+4,OKY+112,72,15,"Exit",8,2,6,31,7]
   End If 
   TRYB=ARMIA(A,0,TTRYB)
   Ink 23,6
   If TRYB>0
      Text OKX+65,OKY-4+18*TRYB,"@"
   End If 
   If TRYB=0
      Text OKX+65,OKY-4+18*5,"@"
   End If 
   Return 
   OVER:
End Proc
Procedure M_RUCH[A,TYP]
   AX=ARMIA(A,0,TX) : AY=ARMIA(A,0,TY)
   _GET_XY[1,AX,AY]
   STREFA=Zone(OX,OY)
   ODL[AX,AY,OX,OY]
   SPEED=ARMIA(A,0,TSZ)
   If TYP=2 Then SPEED=SPEED*2
   CZAS=ODLEG/SPEED
   If CZAS=0 or CZAS=1
      DNI$=" dzień" : CZAS=1
   Else 
      DNI$=" dni"
   End If 
   
   If TYP=3
      If STREFA>=20 and STREFA<120
         A$="Osiągniemy cel za "+Str$(CZAS)+DNI$
         ARMIA(A,0,TTRYB)=TYP
         If STREFA<61
            If STREFA-20>19
               ARMIA(A,0,TCELX)=STREFA-20
               ARMIA(A,0,TCELY)=0
            Else 
               ARMIA(A,0,TTRYB)=0
               A$="Nie zaatakujemy naszych !"
            End If 
         Else 
            If MIASTA(STREFA-70,0,M_CZYJE)<>1
               ARMIA(A,0,TCELX)=STREFA-70
               ARMIA(A,0,TCELY)=1
            Else 
               ARMIA(A,0,TTRYB)=0
               A$="Nie zaatakujemy naszej osady !"
            End If 
         End If 
         Gosub INFO
      Else 
         A$="Kogo mamy zaatakować ?"
         Gosub INFO
         ARMIA(A,0,TTRYB)=0
      End If 
   Else 
      If OY<8 : OY=8 : End If 
      If OY>511 : OY=511 : End If 
      If OX<4 : OX=4 : End If 
      If OX>636 : OX=636 : End If 
      
      ARMIA(A,0,TCELX)=OX
      ARMIA(A,0,TCELY)=OY
      ARMIA(A,0,TTRYB)=TYP
      A$="Dotrzemy tam za "+Str$(CZAS)+DNI$
      
      Gosub INFO
   End If 
   Goto OVER
   INFO:
   OKNO[90,100,145,22]
   GADGET[OKX+4,OKY+4,137,15,"",31,2,30,1,0]
   Ink 1,30 : Text OKX+8,OKY+15,A$
   Repeat 
      If Mouse Click=1
         KONIEC=True
      End If 
   Until KONIEC
   ZOKNO
   Return 
   OVER:
End Proc
Procedure TEREN[X1,Y1]
   STREFA=Zone(X1,Y1)
   If STREFA>69 and STREFA<125
      LOK=STREFA
      Goto OVER
   End If 
   If STREFA>19 and STREFA<40
      LOK=ARMIA(STREFA-20,0,TNOGI)
      Goto OVER
   End If 
   
   Dim KOLORY(31)
   For Y=Y1-4 To Y1+4
      For X=X1-4 To X1+4
         KOL=Point(X,Y)
         If KOL>-1 : Add KOLORY(KOL),1 : End If 
      Next X
   Next Y
   KOLOR=0
   For I=0 To 31
      If KOLORY(I)>KOLOR
         KOLOR=KOLORY(I)
         FINAL=I
      End If 
      KOLORY(I)=0
   Next I
   Pen 23
   LOK=0
   If FINAL>8 and FINAL<11
      'bagno 
      LOK=7
   End If 
   If FINAL>12 and FINAL<16
      'łąka
      LOK=2
   End If 
   If FINAL>10 and FINAL<13
      'las 
      LOK=1
   End If 
   If FINAL>6 and FINAL<9
      'pustynia
      LOK=3
   End If 
   If FINAL>0 and FINAL<4
      'las 
      LOK=1
   End If 
   If FINAL>28
      'lodowiec
      LOK=5
   End If 
   If FINAL>3 and FINAL<7
      'skały 
      LOK=4
   End If 
   If FINAL>23 and FINAL<29
      'skały 
      LOK=4
   End If 
   OVER:
   If LOK<=0 : LOK=2 : End If 
End Proc
Procedure MESSAGE[A,A$,P,M]
   If M>0
      NA$=MIASTA$(A)
      MUR=MIASTA(A,0,M_MUR)
      BB=20+MUR
      AX=MIASTA(A,0,M_X)
      AY=MIASTA(A,0,M_Y)
   Else 
      AX=ARMIA(A,0,TX)
      AY=ARMIA(A,0,TY)
      NA$=ARMIA$(A,0)
      PL=ARMIA(A,0,TMAG)
      BB=23+PL
   End If 
   WJAZD[AX,AY,80,80,150,100,10]
   OKNO[80,80,150,100]
   GADGET[OKX+4,OKY+4,142,74,"",31,2,30,1,-1]
   GADGET[OKX+50,OKY+80,50,15,"     Ok  ",8,2,6,31,1]
   No Mask BB : Paste Bob OKX+8,OKY+8,BB
   Ink 1,30 : Text OKX+50,OKY+15,NA$
   NAPISZ[OKX+46,OKY+30,98,40,A$,P,1,30]
   Repeat 
   Until Mouse Click and Mouse Zone=1
   ZOKNO
End Proc
Procedure MESSAGE2[A,A$,B,M,WLOT]
   If M>0
      NA$=MIASTA$(A)
      MUR=MIASTA(A,0,M_MUR)
      
      X=MIASTA(A,0,M_X)
      Y=MIASTA(A,0,M_Y)
   Else 
      NA$=ARMIA$(A,0)
      X=ARMIA(A,0,TX)
      Y=ARMIA(A,0,TY)
   End If 
   If WLOT=1 : WJAZD[X,Y,100,80,112,120,10] : End If 
   OKNO[100,80,112,120]
   GADGET[OKX+4,OKY+4,105,114,"",31,2,30,1,1]
   
   If Rnd(1)=1 : B=Hrev(B) : End If 
   Paste Bob OKX+8,OKY+8,B
   Ink 1,30 : Text OKX+12,OKY+80,NA$
   NAPISZ[OKX+10,OKY+90,88,20,A$,P,1,30]
   Repeat 
   Until Mouse Click and Mouse Zone=1
   ZOKNO
End Proc

Procedure OBLICZ_POWER[PL]
   OPOWER=0
   If Not GAME_OVER
      If PL=1 : GAME_OVER=True : End If 
      For I=0 To 40
         If ARMIA(I,0,TMAG)=PL
            If ARMIA(I,0,TE)>0
               If PL=1 : GAME_OVER=False : End If 
               Add OPOWER,ARMIA(I,0,TSI)
            End If 
         End If 
      Next 
      For I=0 To 49
         If MIASTA(I,0,M_CZYJE)=PL
            If PL=1 : GAME_OVER=False : End If 
            Add OPOWER,MIASTA(I,0,M_LUDZIE)*2
         End If 
      Next 
      Add OPOWER,DZIEN*20
      Add OPOWER,GRACZE(PL,1)/10
      GRACZE(PL,2)=OPOWER
   End If 
End Proc[OPOWER]
Procedure BUSY_ANIM
   Hide On 
   Sprite 0,X Mouse,Y Mouse,36
   A$="Anim 0,(42,4)(43,4)(44,4)(43,4) ; S: Move XM-X,YM-Y,1 ; Jump S"
   Amal 0,A$
   Amal On 0
End Proc
'*** PROCEDURY DO PRZYGÓD *******
Procedure WCZYTAJ_ROZMOWE
   For I=0 To 33
      Read A$ : ROZMOWA2$(I)=A$
   Next I
   For I=1 To 2
      For J=0 To 4
         Read A$
         ROZMOWA$(I,J)=A$
      Next J
   Next I
   DANE:
   'co słychać
   'atak
   Data "Walcz jak wojownik"
   Data "Nie wiem czy najpierw odrąbać ci łeb czy ręce."
   Data "Płacą ci dodatkowy żołd za szczekanie? "
   'obrona
   Data "Ciekawe ile dostanę za twój skalp."
   Data "Nie mam dla ciebie dobrych wiadomości."
   Data "śmierdzisz padliną synu."
   'panika
   Data "Wielu ciekawych już zatłukłem."
   Data "Nie interesuj się"
   Data "Giń poczwaro !"
   'spokój
   Data "Wszysto po staremu. "
   Data "Nic ciekawego."
   Data "Nic."
   Data "Wieśniacy są dobrą przynętą na zwierzyne. "
   Data "Nie radzę ci chodzić po bagnach, żyją tam bestie z piekła rodem. "
   Data "Handlarz zapłaci za kreci korzeń każdą cenę. Znajdziesz go tylko na bagnach."
   Data "W górach znajdziesz głazy do katapult. "
   Data "Warto penetrować jaskinie, złoto wala się pod nogami. "
   Data "Nie wchodź w drogę wojownikom chaosu, widziałem jak wycinali w pień elitarne oddziały. "
   Data "W lesie patrz pod nogi a znajdziesz cenne zioła. "
   Data "Skóra z gargoili kosztuje majątek. "
   Data "Strzesz się gargoili, ta bestyjka jednym kłapnięciem szczeny przegryza człowieka na pół. "
   Data "Buteleczka uzdrawiającej mixtury, w czasie bitwy, może uratować ci życie "
   Data "Nic tak nie goi ran jak liść bobkowy "
   Data "Nie wybieraj się na lodowiec bez butów lub ubrania. "
   Data "Elfy są najlepszymi łucznikami."
   Data "Durne trole uwielbiają maczugi."
   Data "Wielu śmiałków nie wróciło już z bagien. "
   Data "Rycynowe zioła są troche trujące, ale jakiego masz po nich kopa. "
   Data "Polecam kreci korzeń. "
   Data "Pajęcze udka są wyśmienite. "
   Data "Co raz gorzej, podatki rosną, watachy szkieletorów pustoszą okolice, rozwścieczone wilki podchodzą pod domostwa i atakują naszą trzodę."
   Data "Wielgachne pająki mogą jednym ukąszeniem powalić nawet ogra."
   Data "Jeśli nie widziałeś skiriali, to niewiele widziałeś."
   Data "Warto mieć w drużynie ze trzech wieśniaków do odnajdywania drogi przez bagna."
   
   
   'przyłącz się do nas 
   Data "Robie naszyjniki z ludzkich uszu..."
   Data "Nie ma mowy !","Nie gadam z lamerami.(F10)"
   Data "Ok,ale musisz mi zpłacić "
   Data "Zaszczyt to dla mnie wielki, służyć pod twoją komendą Panie."
   
   'oddaj mi swoje piniądze 
   Data "Będziesz umierał powoli.","Chcesz w baniak ?"
   Data "Nie w....aj mnie kozi synu !!!"
   Data "Nie mam pieniędzy"
   Data "To wszysto co mam panie."
   
End Proc
Procedure WCZYTAJ_PRZYGODY
   For I=1 To 13
      For J=0 To 8
         Read A$ : PRZYGODY$(I,J)=A$
      Next J
   Next I
   For I=0 To 3
      PRZYGODY(I,P_TYP)=0
   Next I
   DANE:
   '1-------  
   Data "Stara kopalnia złota"
   Data "Słyszałem od wędrowca o prastarej kopalni złota. Podobno koboldy strzegą tam wielkich skarbów."
   Data "Szukam starej kopalni złota."
   Data "Niestety, nie znam jej położenia.."
   Data "Chyba na @ była jakaś stara kopalnia."
   Data "Zapytaj w mieście §"
   Data "Wskażę ci ją na mapie"
   Data "Dotarliśmy do starej kopalni."
   Data "Odejdź z tąd i pozostaw nas i nasze skarby w spokoju."
   '2------ 
   Data "Kurhan wielkiego wojownika $'a"
   Data "Dawno temu w bitwie pod * poległ wielki wojownik imieniem $ . Wraz z nim pochowana jest również jego cudowną broń: %."
   Data "Szukam grobu $ 'a"
   Data "Nie potrafię ci pomóc."
   Data "Starzy wojownicy mówią że poległ na @."
   Data "świeć Panie nad jego duszą. W § powinni coś wiedzieć."
   Data "Jego grób znajduje się niedaleko stąd."
   Data "Odnaleźliśmy grób $'a."
   Data "Biada temu kto zakłóci sen $'a."
   '3------ 
   Data "Obozowisko bandytów"
   Data "Panie !! 3 dni temu napdadła na nas horda łupieżców. Nasza wieś będzie wdzięczna za ich schwytanie."
   Data "Szukam bandytów."
   Data "Nie wiem gdzie teraz są."
   Data "Podobno zrobili niezłe bydło gdzieś na @."
   Data "Widziano ich w okolicach §. Uważaj, to nie łotrzyki z lasu ale doborowa załoga."
   Data "Wskażę wam ich obozowisko. Tylko nie mówcie nikomu że to ja ich wydałem."
   Data "Okrążyliśmy bandę łotrów."
   Data "He ! Silniejszych typków od ciebie roznosiłem swym ostrzem na strzępy ! "
   '4------ 
   Data "Tu przebywa córka króla $'a"
   Data "Słyszeliśmy że kilka dni temu oddział doborowych wojowników uprowadził córkę króla  $'a. Król obiecał oddać miasto & za jej uwolnienie. Czas nagli !"
   Data "Szukam córki króla $ 'a"
   Data "Nie mogę ci pomóc."
   Data "Widziano ją na @."
   Data "Podobno ludzie w mieście § widzieli bandę która ją porwała"
   Data "Wiem gdzie teraz jest."
   Data "Odnależliśmy córkę króla $'a."
   Data "Jestem córką króla $'a. Dziękuję Ci Dzielny Wojowniku, twoje imie nie zostanie nigdy zapomniane. Pozwól mi wrócić do ojca."
   '5------ 
   Data "Góra $  "
   Data "Legenda mówi że na szczycie góry $ ukryty został najpotężniejszy z potężnych miecz Szczerbiec."
   Data "Szukam góry $ ."
   Data "Nie wiem gdzie może być."
   Data "Wzgórze o które pytasz leży gdzieś na @"
   Data "Górnicy z miasta § muszą o niej coś wiedzieć."
   Data "Wskażę wam ją na mapie."
   Data "Rozpoczynamy poszukiwanie Szczerbca."
   Data ""
   '6------   
   Data "Uwięziony Mag $  "
   Data "Z naszej osady uprowadzono niedawno wielkiego mistrza magii starego $'a. Jeśli uwolnisz go z rąk porywaczy napewno chętnie przyłączy się to twojej drużyny."
   Data "Szukam Maga $'a "
   Data "Nie wiem gdzie teraz jest."
   Data "Zapytaj na @."
   Data "$ jest jednym z kilku najpotężniejszych magów znanego świata. Podobno widziano go w osadzie §."
   Data "Biedny staruszek chyba postradał zmysły, żyje wśród stada wilków niedaleko stąd."
   Data "Odnaleźliśmy Maga $'a."
   Data "Jam jest $, ostatni z potężnych magów. Władca chaosu nasłał na mnie swych sługów przemienionych w wilki."
   '7------ 
   Data "Grota $'a."
   Data "400 lat temu świętej bitwie przeciw siłom chaosu poległo wielu dzielnych rycerzy. Jednym z ocalałych był paladyn $. Legenda mówi że żyje do dziś."
   Data "Szukam $'a"
   Data "Nie wiem gdzie jest."
   Data "Słyszałem o nim. Stare skrole mówią że demony uwięziły go w podziemnej grocie gdzieś na @."
   Data "W § żyją ludzie którzy pamiętają najstarsze legendy."
   Data "Nie wiem czy mogę wam zaufać, ale wskażę wam wejście do groty. Strzeżcie się jednak, nikt żywy z niej nie powrócił."
   Data "Wchodzimy do groty $'a."
   Data "Jestem $, ocalały z wielkiej bitwy. Więziony wiekami szukam zemsty na Chaosie."
   '8------   
   Data "Stary grobowiec"
   Data "Wszyscy magowie twierdzą że skrole z czarami przepisywane są z pokolenia na pokolenie. Istnieje jednak prastare źródło tych czarów: Pierwsza Księga."
   Data "Co wiesz o Pierwszej Księdze ?"
   Data "To tylko stara legenda."
   Data "Wyczytałem w starych zapiskach że spłonęła wiele wieków temu wraz z cała biblioteką i miastem *, które musiało być gdzieś na @."
   Data "Osada § została zbudowana na ruinach o wiele starszego ,spalonego doszczętnie miasta. Podobno uratowano zaledwie kilka kartek z wielkiego księgozbioru."
   Data "Niedaleko z tąd jest stary grobowiec. Jakaś nawiedzona wiedźma majaczyła że Księga jest właśnie tam. Według mnie jest tam tylko stado śmierdzącyh humanoidów."
   Data "Dotarliśmy do starego grobowca."
   Data "Z Księgi ocalała tylko jedna kartka."
   '9------ 
   'usłać pole trupami
   Data "świątynia Orków."
   Data "Podobno niektóre plemiona orków stanęły po ciemnej stronie. Mają ukrytą świątynie gdzie znoszą zrabowane skarby."
   Data "Gdzie jest świątynia Orków."
   Data "Niestey nie wiem."
   Data "Zapytaj na @. Widziano tam oddziały orków. Uważaj na nich, to nie byle jakie zbiry."
   Data "Słyszałem o niej. Podobno orki znoszą tam zrabowane skarby z całego królestwa. Mówili mi o tym przerażeni mieszkańcy z osady §."
   Data "Nie idź tam, to przeklęte miejsce. Orki zabijają każdego kto zbliża się do świątyni. Składają krwawe ofiary złym mocą."
   Data "Wkraczamy do świątyni orków, czas zakończyć ich obłęd."
   Data "Wkroczysz ze mną do pikieł ! "
   '10------    
   Data "Barbarzyńca $."
   Data "W naszej wsi żył wielki wojownik $. Władał mieczem jak nikt inny. Gdy przeszło rok temu wyruszył na wojnę wszelki słuch o nim zaginął."
   Data "Szukam $'a."
   Data "Szukajcie a znajdziecie."
   Data "To był dzielny barbarzyńca. Nie wierzę by ktoś go pokonał w uczciwej walce. Pamiętam że wyruszył z naszej osady na #."
   Data "Kupiec z miata § powiedział mi że złe moce uwięziły go na zaczarownych bagnach, które sprowadzają na ludzi obłęd."
   Data "Podobno błąka się po zaczarowanych bagnach. Wskażę wam ich położenie na mapie."
   Data "Wkraczamy na zaczarowane bagna."
   Data "Z tych przeklętych bagien nie ma wyjścia !"
   '11------    
   'usłać pole trupami przed akcją
   Data "Wataha $'a"
   Data "W okolicy pojawiła się groźna załoga. Dowodzi nimi psychodeliczny ° imieniem $. Za jego głowę wyznaczono nagrodę."
   Data "Szukam bandy $'a"
   Data "Chętnie bym ci pomógł ale nie wiem gdzie jest."
   Data "Podobno ma na swych usługach tresowane gargoile i świetnych wojów. Choć postradał zmysły świetnie walczy. Rozbił na @ oddział pościgowy."
   Data "Niech imię jego będzie przeklęte po wsze czasy. Wymordował wielu mieszkańców z osady §."
   Data "Chaos wypacza umysły swym sługom a $ jest jednym z nich. Pomścij nasze krzywdy."
   Data "Odnaleźliśmy bandę $'a."
   Data "Masz prawo mnie zabić ale nie możesz mnie osądzać."
   '12------
   Data "Jaskinia Wiedzy"
   Data "Słyszałem legendę o magicznej jaskini. Kto do niej wejdzie posiądzie wielką mądrość. Jej położenie zawsze było największą tajemnicą."
   Data "Co wiesz o magicznej jaskini ?"
   Data "Wiem że takowa istnieje i nic poza tym."
   Data "Przed wielką wojną chodzili tam nasi młodzi wojownicy by zdobyć wiedzę i doświadczenie w walce. Pamiętam tylko że zawsze wyruszali na #."
   Data "Mędrzec z miasta § mówił że jaskinia jest najstarszym miejscem w znanym nam świecie."
   Data "Słyszałem o waszych bohaterskich czynach i wieżę że wiedzę, zdobytą w jaskini, wykorzystacie w słusznej sprawie."
   Data "Dotarliśmy do Jaskini Wiedzy."
   Data "Od teraz wasze doświadczenie jest waszą największą siłą. Skierujcie ją przeciw złu."
   '13------
   Data "Tu ukryta jest forteca władcy Chaosu."
   Data "Chaos rośnie w siłe. Z każdym dniem coraz więcej szkieletów wypełza spod ziemi. Atakują wszystkie żywe istoty i roznoszą nieuleczalne choroby."
   Data "Jak pokonać Rycerzy Chaosu ?"
   Data "Nie można ich zabić bo są już martwi. Na miejsce rozbitego oddziału przyjdą dwa nowe."
   Data "Walka z nimi nie ma sensu. Trzeba znisczyć źródło złej mocy, która ciągle ich wskrzesza. Może na @ będą coś więcej wiedzieli."
   Data "Można ich zniszczyć. Cztery wieki temu, po wielkiej bitwie, pokonano ich władcę. W § żyje stary mędrzec który pamięta tamte czasy."
   Data "Ich władca żyje w wielkiej fortecy, ukrytej wśród mgieł. Dysponuje ogromną siłą. Pokonają go tylko najdzielniejsi wojownicy, uzbrojeni w święty oręż."
   Data "Stoimy u bram fortecy. Niech wypełni się przeznaczenie."
   Data ""
   
End Proc
Procedure NOWA_PRZYGODA[A,NR,TYP,LEVEL]
   PRZYGODY(NR,P_TYP)=TYP
   PRZYGODY(NR,P_X)=ARMIA(A,0,TNOGI)-70
   PRZYGODY(NR,P_Y)=Rnd(9)+1
   PRZYGODY(NR,P_KIERUNEK)=-1
   PRZYGODY(NR,P_LEVEL)=LEVEL
   IM_PRZYGODY$(NR)=""
   If TYP=1
      'kopalnia
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=20*LEVEL
      PRZYGODY(NR,P_NAGRODA)=LEVEL*10000
      PRZYGODY(NR,P_TEREN)=8
      PRZYGODY(NR,P_BRON)=0
   End If 
   If TYP=2
      'kurhan
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(20*LEVEL)
      PRZYGODY(NR,P_NAGRODA)=LEVEL*100
      Repeat 
         BRON=Rnd(MX_WEAPON)
         BTYP=BRON(BRON,B_TYP)
      Until BRON(BRON,B_CENA)>=1000 and BRON(BRON,BCENA)<100+LEVEL*1000 and BTYP<>5 and BTYP<>8 and BTYP<>13 and BTYP<>14 and BTYP<16
      PRZYGODY(NR,P_BRON)=BRON
      PRZYGODY(NR,P_TEREN)=9
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   If TYP=3
      'bandyci 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=0
      PRZYGODY(NR,P_NAGRODA)=4000+Rnd(2000)+LEVEL*100
      PRZYGODY(NR,P_TEREN)=0
      PRZYGODY(NR,P_BRON)=0
   End If 
   If TYP=4
      'córa
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=0
      Repeat : MIASTO=Rnd(49) : Until MIASTA(MIASTO,0,M_CZYJE)<>1
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_BRON)=0
      PRZYGODY(NR,P_TEREN)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   If TYP=5
      'góra jakaś tam
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+30
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=4
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   If TYP=6
      'super mag 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+10
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=0
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   If TYP=7
      'grota paladyna ufola
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+10
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=8
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   
   If TYP=8
      'magiczna księga 
      PRZYGODY(NR,P_LEVEL)=3
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=100
      PRZYGODY(NR,P_TEREN)=9
      If Rnd(1)=0
         'GB
         PRZYGODY(NR,P_BRON)=52
      Else 
         'NAW 
         PRZYGODY(NR,P_BRON)=88
      End If 
   End If 
   
   If TYP=9
      'świątynia orków 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(20)
      PRZYGODY(NR,P_TEREN)=9
      PRZYGODY(NR,P_BRON)=0
   End If 
   
   If TYP=10
      'barbrayńca na bagnach 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+30
      PRZYGODY(NR,P_TEREN)=7
      PRZYGODY(NR,P_BRON)=0
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   
   If TYP=11
      'wataha
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=0
      PRZYGODY(NR,P_NAGRODA)=3000*LEVEL
      PRZYGODY(NR,P_TEREN)=0
      AGAIN:
      RSA=Rnd(8)
      If RSA=4
         ' bez amazonek 
         Goto AGAIN
      End If 
      PRZYGODY(NR,P_BRON)=RSA
      ROB_IMIE
      IM_PRZYGODY$(NR)=Param$
   End If 
   
   If TYP=12
      'jaskinia wiedzy 
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=Rnd(100)+20
      PRZYGODY(NR,P_TEREN)=8
   End If 
   
   If TYP=13
      'władca chaosu 
      PRZYGODY(NR,P_LEVEL)=4
      PRZYGODY(NR,P_TERMIN)=100+Rnd(100)
      PRZYGODY(NR,P_CENA)=500+Rnd(100)
      'jedno z miast rnd(m_czyje)
      PRZYGODY(NR,P_NAGRODA)=MIASTO
      PRZYGODY(NR,P_TEREN)=10
      PRZYGODY(NR,P_BRON)=0
   End If 
   
End Proc
Procedure NAPISZ[X,Y,SZER,WYS,A$,P,K1,K2]
   Ink K2 : Bar X-2,Y-10 To X+SZER,Y+WYS
   Ink K1,K2
   '   SZPALTA=SZER/5 
   DL=Len(A$)
   ZDANIE$=""
   For I=1 To DL
      Z$=Mid$(A$,I,1)
      If Z$="@"
         If PRZYGODY(P,P_KIERUNEK)=0 : Z$="północy" : End If 
         If PRZYGODY(P,P_KIERUNEK)=1 : Z$="południu" : End If 
         If PRZYGODY(P,P_KIERUNEK)=2 : Z$="wschodzie" : End If 
         If PRZYGODY(P,P_KIERUNEK)=3 : Z$="zachodzie" : End If 
      End If 
      If Z$="#"
         If PRZYGODY(P,P_KIERUNEK)=0 : Z$="północ" : End If 
         If PRZYGODY(P,P_KIERUNEK)=1 : Z$="południe" : End If 
         If PRZYGODY(P,P_KIERUNEK)=2 : Z$="wschód" : End If 
         If PRZYGODY(P,P_KIERUNEK)=3 : Z$="zachód" : End If 
      End If 
      
      If Z$="*" : ROB_IMIE : Z$=Param$ : End If 
      If Z$="§" : Z$=MIASTA$(PRZYGODY(P,P_X)) : End If 
      If Z$="&" : Z$=MIASTA$(PRZYGODY(P,P_NAGRODA)) : End If 
      If Z$="$" : Z$=IM_PRZYGODY$(P) : End If 
      If Z$="%" : BRO=PRZYGODY(P,P_BRON) : Z$=BRON2$(BRON(BRO,B_TYP))+" "+BRON$(BRO) : End If 
      If Z$="°" : Z$=RASY$(PRZYGODY(P,P_BRON)) : End If 
      WYRA$=WYRA$+Z$
      
      If Z$=" " or Z$="."
         DLUG=Text Length(ZDANIE$+WYRA$)
         If DLUG<SZER
            ZDANIE$=ZDANIE$+WYRA$
            WYRA$=""
         Else 
            Text X,Y,ZDANIE$
            Add Y,10
            ZDANIE$=WYRA$
            WYRA$=""
         End If 
      End If 
      If I=DL : Text X,Y,ZDANIE$+WYRA$ : End If 
   Next I
   
End Proc
Procedure PRZYGODY[XA,YA,NR]
   LEVEL=PRZYGODY(NR,P_LEVEL)
   Dec LEVEL
   PRZYGODY(NR,P_LEVEL)=LEVEL
   
   If LEVEL>0
      'wskaż konkretną osobę 
      'miasto wybrane zgodnie z kierunkiem przygody
      STARAODL=600
      OLD_KIER=PRZYGODY(NR,P_KIERUNEK)
      For I=0 To 49
         X2=MIASTA(I,0,M_X)
         Y2=MIASTA(I,0,M_Y)
         DX=XA-X2
         DY=YA-Y2
         If Abs(DX)>=Abs(DY)
            If DX>=0
               KIER=2
            Else 
               KIER=3
            End If 
         Else 
            If DY>=0
               KIER=1
            Else 
               KIER=0
            End If 
         End If 
         ODL[XA,YA,X2,Y2]
         If ODLEG<STARAODL and KIER<>OLD_KIER and ODLEG>30+Rnd(100)
            STARAODL=ODLEG
            MIASTO=I
         End If 
      Next I
      PRZYGODY(NR,P_X)=MIASTO
      'osoba 
      PRZYGODY(NR,P_Y)=Rnd(9)+1
      DX=XA-MIASTA(MIASTO,0,M_X)
      DY=YA-MIASTA(MIASTO,0,M_Y)
      If Abs(DX)>=Abs(DY)
         If DX>=0
            KIER=3
         Else 
            KIER=2
         End If 
      Else 
         If DY>=0
            KIER=0
         Else 
            KIER=1
         End If 
      End If 
      PRZYGODY(NR,P_KIERUNEK)=KIER
   End If 
   If LEVEL=0
      X=XA+Rnd(100)-50
      Y=YA+Rnd(100)-50
      PRZYGODY(NR,P_X)=X
      PRZYGODY(NR,P_Y)=Y
      'wskaż miejsce na mapie
      'strefa o numerze przygody 
   End If 
End Proc
Procedure PRZYGODA_INFO[NR]
   OKNO[70,100,180,23]
   TYP=PRZYGODY(NR,P_TYP)
   A$=PRZYGODY$(TYP,0)
   If IM_PRZYGODY$(NR)<>""
      DL=Len(A$)
      ZN=Instr(A$,"$")
      If ZN>0
         A$=A$-"$"
         L$=Left$(A$,ZN-1)
         R$=Right$(A$,DL-ZN-1)
         A$=L$+IM_PRZYGODY$(NR)+R$
      End If 
   End If 
   GADGET[OKX+4,OKY+4,172,15,A$,31,2,30,1,-1]
   Repeat 
   Until Mouse Click=1
   ZOKNO
End Proc
'******* DISK ACCESS ************
Procedure _LOAD[A$,B$,NAPI$,TRYB]
   If Exist(A$)
      Goto ODCZYT
   Else 
      A$=B$
      REQUEST[A$,NAPI$]
   End If 
   ODCZYT:
   On Error Proc BLAD
   If TRYB=0 : Load A$ : End If 
   If TRYB=1 : Load A$,1 : End If 
   If TRYB=2 : Load Iff A$ : End If 
   If TRYB=3 : Load Iff A$,0 : End If 
   If TRYB=4 : Load Iff A$,1 : End If 
   If TRYB=5 : Load Iff A$,2 : End If 
   If TRYB=6 : Track Load A$,3 : End If 
   If TRYB=7 : Load A$,3 : End If 
   If TRYB=8 : Load A$,4 : End If 
   If TRYB=9 : Load A$,5 : End If 
   
End Proc
Procedure _SAVE_GAME
   SDIR["Archiwum - Zapis Gry",21,20]
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA>0 and STREFA<6
            NSAVE=STREFA
            WPISZ[OKX+14,OKY+38+((STREFA-1)*20),31,6,20]
            NAME$=WPI$
            If NAME$="" : NAME$="Zapis "+Str$(STREFA) : End If 
            Gosub ZAPIS
         End If 
         If STREFA=6
            KONIEC=True
         End If 
         
      End If 
      
   Until KONIEC
   ZOKNO
   Goto OVER
   
   ZAPIS:
   BUSY_ANIM
   Reserve As Work 10,60000
   Poke$ Start(10),NAME$
   MEM=Start(10)+20
   'armia(40,10,30) 
   For I=0 To 40
      For J=0 To 10
         For K=0 To 30
            DAT=ARMIA(I,J,K)
            Doke MEM,DAT
            Add MEM,2
         Next K
      Next J
   Next I
   'wojna(5,5)
   For I=0 To 5
      For J=0 To 5
         DAT=WOJNA(I,J)
         Poke MEM,DAT
         Inc MEM
      Next 
   Next 
   'gracze(4,3) 
   For I=0 To 4
      For J=0 To 3
         DAT=GRACZE(I,J)
         Loke MEM,DAT
         Add MEM,4
      Next 
   Next 
   'armia$(40,10) 
   For I=0 To 40
      For J=0 To 10
         DAT$=ARMIA$(I,J)
         Gosub WRITE_STRING
      Next 
   Next 
   'imiona$(4)
   For I=0 To 4
      DAT$=IMIONA$(I)
      Gosub WRITE_STRING
   Next 
   'prefs(10) 
   For I=0 To 10
      DAT=PREFS(I)
      Poke MEM,DAT
      Inc MEM
   Next 
   'miasta(50,20,6) 
   For I=0 To 50
      For J=0 To 20
         For K=0 To 6
            DAT=MIASTA(I,J,K)
            Doke MEM,DAT
            Add MEM,2
         Next K
      Next J
   Next I
   'miasta$(50) 
   For I=0 To 50
      DAT$=MIASTA$(I)
      Gosub WRITE_STRING
   Next 
   Doke MEM,DZIEN : Add MEM,2
   Doke MEM,POWER : Add MEM,2
   'przygody(3,10)
   For I=0 To 3
      For J=0 To 10
         DAT=PRZYGODY(I,J)
         Doke MEM,DAT
         Add MEM,2
      Next J
   Next I
   'im_przygody$(3) 
   For I=0 To 3
      DAT$=IM_PRZYGODY$(I)
      Gosub WRITE_STRING
   Next I
   
   Change Mouse 42
   Amal Off 
   Show 
   On Error Proc BLAD2
   Resume Label SKIP
   If Exist(KAT$+"archiwum")
      Bsave KAT$+"archiwum/zapis"+Str$(NSAVE),Start(10) To MEM
   Else 
      REQUEST["archiwum:","Archiwum"]
      Bsave "archiwum:zapis"+Str$(NSAVE),Start(10) To MEM
   End If 
   SKIP:
   Erase 10
   Change Mouse 5
   Return 
   
   WRITE_STRING:
   DLUG=Len(DAT$)
   Poke MEM,DLUG : Inc MEM
   Poke$ MEM,DAT$
   Add MEM,DLUG
   Return 
   
   OVER:
End Proc
Procedure _LOAD_GAME
   SDIR["Archiwum - Odczyt Gry",17,16]
   PAT$=Param$
   Repeat 
      If Mouse Click=1
         STREFA=Mouse Zone
         If STREFA>0 and STREFA<6 and Exist(PAT$+"zapis"+Str$(STREFA))
            NSAVE=STREFA
            KONIEC=True
            ZOKNO
            JEST=True
            Gosub ODCZYT
         End If 
         If STREFA=6
            ZOKNO
            KONIEC=True
         End If 
      End If 
   Until KONIEC
   Goto OVER
   
   ODCZYT:
   Reserve As Work 10,60000
   MEM=Start(10)+20
   Change Mouse 42
   If Exist(KAT$+"archiwum/zapis"+Str$(NSAVE))
      Bload KAT$+"archiwum/zapis"+Str$(NSAVE),Start(10)
   Else 
      REQUEST["archiwum:zapis"+Str$(NSAVE),"Archiwum"]
      Bload "archiwum:zapis"+Str$(NSAVE),Start(10)
   End If 
   BUSY_ANIM
   ODCZYT[MEM]
   Amal Off 
   Show 
   Return 
   OVER:
   
End Proc[JEST]
Procedure ODCZYT[MEM]
   'armia(40,10,30) 
   For I=0 To 40
      For J=0 To 10
         For K=0 To 30
            DAT=Deek(MEM)
            ARMIA(I,J,K)=DAT
            Add MEM,2
         Next K
      Next J
   Next I
   'wojna(5,5)
   For I=0 To 5
      For J=0 To 5
         DAT=Peek(MEM)
         WOJNA(I,J)=DAT
         Inc MEM
      Next 
   Next 
   'gracze(4,3) 
   For I=0 To 4
      For J=0 To 3
         DAT=Leek(MEM)
         GRACZE(I,J)=DAT
         Add MEM,4
      Next 
   Next 
   'armia$(40,10) 
   For I=0 To 40
      For J=0 To 10
         Gosub _READ_STRING
         ARMIA$(I,J)=DAT$
      Next 
   Next 
   'imiona$(4)
   For I=0 To 4
      Gosub _READ_STRING
      IMIONA$(I)=DAT$
   Next 
   'prefs(10) 
   For I=0 To 10
      DAT=Peek(MEM)
      PREFS(I)=DAT
      Inc MEM
   Next 
   'miasta(50,20,6) 
   For I=0 To 50
      For J=0 To 20
         For K=0 To 6
            DAT=Deek(MEM)
            MIASTA(I,J,K)=DAT
            Add MEM,2
         Next K
      Next J
   Next I
   'miasta$(50) 
   For I=0 To 50
      Gosub _READ_STRING
      MIASTA$(I)=DAT$
   Next 
   DZIEN=Deek(MEM) : Add MEM,2
   POWER=Deek(MEM) : Add MEM,2
   'przygody(3,10)
   For I=0 To 3
      For J=0 To 10
         DAT=Deek(MEM)
         PRZYGODY(I,J)=DAT
         Add MEM,2
      Next J
   Next I
   'im_przygody$(3) 
   For I=0 To 3
      Gosub _READ_STRING
      IM_PRZYGODY$(I)=DAT$
   Next I
   Erase 10
   
   Goto OVER
   
   _READ_STRING:
   DLUG=Peek(MEM) : Inc MEM
   DAT$=Peek$(MEM,DLUG)
   Add MEM,DLUG
   Return 
   
   OVER:
End Proc
Procedure CLEAR_TABLES
   'armia(40,10,30) 
   For I=0 To 40
      For J=0 To 10
         For K=0 To 30
            ARMIA(I,J,K)=0
         Next K
      Next J
   Next I
   'wojna(5,5)
   For I=0 To 5
      For J=0 To 5
         WOJNA(I,J)=0
      Next 
   Next 
   'gracze(4,3) 
   For I=0 To 4
      For J=0 To 3
         GRACZE(I,J)=0
      Next 
   Next 
   'armia$(40,10) 
   For I=0 To 40
      For J=0 To 10
         ARMIA$(I,J)=""
      Next 
   Next 
   'imiona$(4)
   For I=0 To 4
      IMIONA$(I)=""
   Next 
   'prefs(10) 
   For I=0 To 10
      PREFS(I)=0
   Next 
   'miasta(50,20,6) 
   For I=0 To 50
      For J=0 To 20
         For K=0 To 6
            MIASTA(I,J,K)=0
         Next K
      Next J
   Next I
   'miasta$(50) 
   For I=0 To 50
      MIASTA$(I)=""
   Next 
   'przygody(3,10)
   For I=0 To 3
      For J=0 To 10
         PRZYGODY(I,J)=0
      Next J
   Next I
   'im_przygody$(3) 
   For I=0 To 3
      IM_PRZYGODY$(I)=""
   Next I
   
   OVER:
End Proc

Procedure SDIR[A$,K1,K2]
   OKNO[100,60,140,160]
   GADGET[OKX+10,OKY+8,120,15,A$,K1,0,K2,31,-1]
   If Exist(KAT$+"archiwum")
      PAT$=KAT$+"archiwum/"
   Else 
      REQUEST["archiwum:","Archiwum"]
      PAT$="archiwum:"
   End If 
   
   For I=0 To 4
      If Exist(PAT$+"zapis"+Str$(I+1))
         Open In 1,PAT$+"zapis"+Str$(I+1)
         NAME$=Input$(1,20)
         Close 1
      Else 
         NAME$="Pusty Slot"
      End If 
      GADGET[OKX+10,OKY+28+(I*20),120,15,NAME$,8,1,6,31,I+1]
   Next 
   GADGET[OKX+10,OKY+128,120,15,"Exit",8,1,6,31,6]
End Proc[PAT$]
Procedure REQUEST[A$,NAPI$]
   If Not Exist(A$)
      SKRIN=Screen
      Hide 
      Screen Open 4,320,17,4,Lowres
      Screen Display 4,140,270,320,
      Screen To Front 4 : Screen 4
      Set Rainbow 0,1,64,"(1,1,1)","",""
      Rainbow 0,0,138,16
      Curs Off 
      Flash Off 
      Set Font FON2
      If SKRIN>-1 and SKRIN<8 : Get Palette SKRIN : End If 
      Palette $0,$A00,$BF0,$840
      Cls 1
      '   Gr Writing 0 : Ink 2 : Text 120,10,NAPI$ 
      X=160-(Text Length(NAPI$)/2)
      OUTLINE[X,10,NAPI$,2,3]
      Y=270
      SPEED=12
      Repeat 
         Add Y,-SPEED
         Add SPEED,-1,1 To SPEED
         Screen Display 4,140,Y,320,
         Rainbow 0,0,Y-1,17
         Wait Vbl : View 
      Until Y<200
      Repeat 
         Wait Vbl 
      Until Exist(A$)
      Repeat 
         Add Y,SPEED
         Add SPEED,1,SPEED To 20
         Screen Display 4,140,Y,320,
         Rainbow 0,0,Y-2,16
         Wait Vbl : View 
      Until Y>250
      Rainbow Del 0
      Screen Close 4
      Show 
      If SKRIN>-1 and SKRIN<8 : Screen SKRIN : End If 
   End If 
End Proc
Procedure _INTRO
   Auto View Off 
   Set Sprite Buffer 300
   Screen Open 2,64,10,32,L : Flash Off : Screen Hide 
   Screen Open 3,64,10,32,L : Flash Off : Screen Hide 
   Screen Open 0,640,512,16,-1 : Flash Off : Cls 0 : Screen Hide : Hide 
   _LOAD[KAT$+"miecz","legion:miecz","Legion",0]
   _LOAD[KAT$+"mod.intro","legion:mod.intro","Legion",6]
   Track Loop On : Led Off 
   USTAW_FONT["bodacious",42]
   Gr Writing 0
   Flash Off : Get Bob Palette 
   For I=0 To 15 : Colour I+16,Colour(I) : Next I
   For I=0 To 15 : Colour I,D : Add D,$222 : Next I
   Screen 2 : Get Palette 0
   Screen Open 1,640,512,16,-1
   Cls 0 : Flash Off 
   Screen 1 : Get Palette 0 : Screen Hide : Hide 
   Screen Display 1,150,,,
   Auto View On 
   _LOAD[KAT$+"title2","legion:title2","Legion",2]
   For I=16 To 31 : Screen 0 : KOL=Colour(I) : Screen 1 : Colour I,KOL : Next I
   Screen 3 : Get Palette 1
   BOMBA4=True
   Screen 0 : _LOAD[KAT$+"gobilog.16","legion:gobilog.16","Legion",2] : Screen Show 0 : View 
   Track Play 3
   Amos To Front : View 
   _WAIT[150]
   Fade 2 : Wait 30 : Cls 0
   For I=0 To 16 : Colour I,0 : Next I
   X1=200 : Y1=235 : A$="przedstawia"
   X2=130 : Y2=270 : B$=""
   Gosub FADING
   
   Sprite 0,365,70,1
   A$="Anim 0,(1,3)(2,3)(3,3)(4,3)(5,3)(6,3)(7,3)(8,3)(9,3)(10,3)(11,3)(12,3)(13,3)(14,3)(15,3)(16,3)(17,3)(18,3)(19,3);"
   Amal 0,A$
   Repeat : Until Timer mod 3=0
   Amal On 0
   Screen 1
   For I=0 To 16 : Colour I,0 : Next I
   
   Repeat 
      Screen 1 : Screen To Front 1 : Screen Show 1 : Fade 2 To 3
      _WAIT[200] : Exit If KONIEC_INTRA>2
      Fade 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
      _WAIT[30] : Exit If KONIEC_INTRA>2
      Screen 0
      Screen Display 0,140,,,
      For I=0 To 16 : Colour I,0 : Next I
      
      Screen To Front 0 : Screen Show 
      X1=130 : Y1=220 : A$="   program   "
      X2=130 : Y2=270 : B$="Marcin Puchta"
      Gosub FADING : Exit If KONIEC_INTRA>2
      X1=135 : Y1=220 : A$="   grafika"
      X2=130 : Y2=270 : B$="Andrzej Puchta"
      Gosub FADING : Exit If KONIEC_INTRA>2
      X1=135 : Y1=220 : A$="muzyka i sfx"
      X2=130 : Y2=270 : B$="Marcin Puchta"
      Gosub FADING : Exit If KONIEC_INTRA>2
      X1=135 : Y1=240 : A$="  pomagali"
      X2=130 : Y2=270 : B$=""
      Gosub FADING : Exit If KONIEC_INTRA>2
      X1=135 : Y1=220 : A$="M.Malachowski"
      X2=130 : Y2=270 : B$=" Marek Lech"
      Gosub FADING : Exit If KONIEC_INTRA>2

      KONIEC_INTRA=2
   Until KONIEC_INTRA>2
   Goto OVER
   FADING:
   Repeat : Until Timer mod 3=1
   Text X1,Y1,A$ : Repeat : Until Timer mod 3=1 : Text X2,Y2,B$
   Fade 2 To 2 : _WAIT[100]
   Fade 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 : Wait 25 : Repeat : Until Timer mod 3=0 : Ink 0 : Bar 130,190 To 415,280
   Return 
   
   OVER:
   Fade 2
   Wait 25
   Amal Off 
   Sprite Off 
   Screen Close 2
   Screen Close 3
   If Screen=0
      Screen Close 1 : Screen Close 0
   Else 
      Screen Close 0 : Screen Close 1
   End If 
   Erase 1
   Auto View Off 
End Proc
Procedure EXTRO
   Hide On 
   _LOAD[KAT$+"czacha.32","legion:czacha.32","Legion",3]
   _LOAD[KAT$+"mod.end2","legion:mod.end2","Legion",6]
   Track Loop On : Track Play 3
   View 
   _WAIT[1500]
   Fade 2
   _TRACK_FADE[1]
End Proc

Procedure _WAIT[ILE]
   Repeat 
      Inc I
      If Mouse Click
         Inc KONIEC_INTRA
         I=ILE
      End If 
      Wait Vbl 
   Until I=ILE
End Proc
Procedure EKRAN_WYBOR
   Hide On 
   _LOAD[KAT$+"kam.pic","LEGION:KAM.PIC","Legion",3]
   _LOAD[KAT$+"mieczyk","legion:mieczyk","Legion",0]
   _LOAD[KAT$+"intro","legion:intro","Legion",1]
   USTAW_FONT["garnet",16]
   FON2=FONR
   USTAW_FONT["defender2",8]
   FON1=FONR
   Reserve Zone 25
   Set Zone 21,0,0 To 640,238
   Set Zone 22,0,238 To 640,285
   Set Zone 23,0,285 To 640,500
   Set Rainbow 2,6,256,"(2,-1,1)","(2,-1,1)","(3,-1,1)"
   Set Rainbow 3,6,256,"","(2,-1,1)","(3,-1,1)"
   Set Rainbow 1,6,256,"(3,-1,1)","(2,-1,1)",""
   Double Buffer 
   Autoback 1
   BOMBA1#=20+Rnd(30)
   Bob Update Off 
   Bob 1,50,190,1 : Bob Update : Wait Vbl 
   A$="E:Move 4,0,4; Move 4,0,3; Move 4,0,2; Move 16,0,6; Move 4,0,2; Move 4,0,3; Move 4,0,4;"
   A$=A$+"Move -4,0,4; Move -4,0,3; Move -4,0,2; Move -16,0,6; Move -4,0,2; Move -4,0,3; Move -4,0,4;Jump E"
   BOMBA2#=0
   Channel 1 To Bob 1
   Amal 1,A$
   Amal On 1
   Limit Mouse 150,140 To 150,205
   View : Wait Vbl 
   BOMBA3=False
End Proc
Procedure BLAD
   Resume 
End Proc
Procedure BLAD2
   Resume Label 
End Proc
