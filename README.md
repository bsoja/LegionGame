# LegionGame [![Build Status](https://travis-ci.com/bsoja/LegionGame.svg?branch=master)](https://travis-ci.com/bsoja/LegionGame)
Remake of the classic Amiga game Legion, based on the official AMOS source code provided by authors.

## Original source code
Original source code location: /data/amos/leg31.Asc

## Idea
Completely rewrite game using modern, widely used and popular object oriented language (C#), for better maintainability and easier future extension. Code is written from scratch, but directly based on original AMOS source code and original logic.

First step is to create mostly the same functionality as in original game. If some small improvements can be made at this step they will be also included. Bigger improvements and new ideas can be made in next steps.

## Techonology stack
MonoGame on .Net Core. I'm currently using VS Code on Linux to write code.

NOTE: currently only 64 bit versions of Linux and Windows are supported, 32 bit versions can be added by modyfing Legion.csproj file to recognize bitness and choose 32bit versions of SDL.dll (they are already available in theirs folders under lib directory). OSX should be also supported but it was not tested.

## Current status
Architecture and basic UI is done, most progress is made for map view.

## Localization
Game should be easily to localize, currently only Polish and (mostly) English version is available.

## Contribution
If you would like to help/comment/donate or have some ideas, please let me know.

## Links
* Original source code: https://www.ppa.pl/rodzynki/legion.html
* Interview with author 1: https://www.ppa.pl/gry/rozmowa-z-marcinem-puchta-wspolautorem-gry-legion.html
* Interview with author 2: https://www.ppa.pl/gry/rozmowa-z-andrzejem-puchta-autorem-gry-legion.html

## Screenshots
<p align="center">
  <img src="data/screenshots/legion-debug.png?raw=true" width="98%" />
  <img src="data/screenshots/legion-info-pl.png?raw=true" width="49%" />
  <img src="data/screenshots/legion-info-en.png?raw=true" width="49%" />
  <img src="data/screenshots/legion-terrain.png?raw=true" width="49%" />
</p>
