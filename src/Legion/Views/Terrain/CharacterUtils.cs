using System;
using Legion.Model.Types;
using Legion.Utils;
using Microsoft.Xna.Framework;

namespace Legion.Views.Terrain
{
    public class CharactersUtils
    {
        public static Character FindCharacterAtPosition(Army army, Point p)
        {
            foreach (var character in army.Characters)
            {
                var bounds = GetCharacterBounds(character);
                if (bounds.Contains(p))
                {
                    return character;
                }
            }
            return null;
        }

        public static Rectangle GetCharacterBounds(Character character)
        {
            // TODO: provide correct bounds
            //var textures = CharactersImagesLoader.Get(character.Type);
            //var frame = textures[character.CurrentAnimFrame];
            //var charBounds = new Rectangle(character.X, character.Y, frame.Width, frame.Height);
            //32x45
            var charBounds = new Rectangle(character.X, character.Y, 32, 45);

            return charBounds;
        }

        //TODO: need to be refactored. It must probably also check collision with buildings and other terrain things
        public static bool CheckCollision(Character character, Point newPosition, Army userArmy, Army enemyArmy)
        {
            var b = GetCharacterBounds(character);
            var pos = new Point(newPosition.X, newPosition.Y + b.Height);

            var isCollision = new Func<Character, bool>(c =>
                {
                    if (c.Id != character.Id)
                    {
                        var bounds = GetCharacterBounds(c);
                        if (bounds.Contains(pos))
                        {
                            return true;
                        }
                    }
                    return false;
                });

            foreach (var c in userArmy.Characters)
            {
                if (isCollision(c))
                {
                    return true;
                }
            }
            foreach (var c in enemyArmy.Characters)
            {
                if (isCollision(c))
                {
                    return true;
                }
            }

            return false;
        }

        public static void InitArmyPostion(Army army, int xw, int yw, int type)
        {
            //TODO: replace this magic numbers (200/160) by screen width/height or something 
            var x1 = xw * 200;
            var y1 = yw * 160;
            foreach (var character in army.Characters)
            {
                if (type == 1)
                {
                    var xw2 = 0;
                    var yw2 = 0;
                    do
                    {
                        xw2 = GlobalUtils.Rand(3);
                        yw2 = GlobalUtils.Rand(3);
                    } while (xw2 != xw && yw2 != yw);
                    x1 = xw2 * 200;
                    y1 = yw2 * 160;
                }
                else if (type == 2)
                {
                    x1 = GlobalUtils.Rand(3) * 200;
                }
                else if (type == 3)
                {
                    y1 = GlobalUtils.Rand(3) * 160;
                }
                do
                {
                    character.X = GlobalUtils.Rand(200) + x1 + 16;
                    character.Y = GlobalUtils.Rand(160) + y1 + 20;
                } while (false); //TODO: while there is no other things in that position
            }
        }
    }

}