using System;
using System.Linq;
using Gui.Elements;
using Gui.Services;
using Humanizer;
using Legion.Controllers;
using Legion.Model.Types;

namespace Legion.Views.Terrain.Layers
{
    public class CharactersLayer : Layer
    {
        private readonly ITerrainController terrainController;

        public CharactersLayer(IGuiServices guiServices,
            ITerrainController terrainController) : base(guiServices)
        {
            this.terrainController = terrainController;
        }

        // private void DrawCharacters()
        // {
        //     foreach (var userChar in terrainController.UserArmy.Characters)
        //     {
        //         DrawCharacter(userChar);
        //     }

        //     foreach (var enemyChar in terrainController.EnemyArmy.Characters)
        //     {
        //         DrawCharacter(enemyChar);
        //     }
        // }

        // private void DrawCharacter(Character character)
        // {
        //     Enum.GetNames(typeof(ImageType)).FirstOrDefault(n=> n.Contains(character.Type.Name));

        //     var typeStr = "Character " + character.Type.Name;
        //     //ImageType imageType= null;
        //     // try{
        //     // imageType = typeStr.DehumanizeTo<ImageType>();
        //     // }catch
            
        //     //GuiServices.ImagesStore.ImagesProvider.GetImages(ImageType)
        //     var textures = CharactersImagesLoader.Get(character.Type);
        //     var frame = textures[character.CurrentAnimFrame];
        //     spriteBatch.Draw(frame, new Vector2(character.X, character.Y), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
        // }

        // private void DrawMarkers()
        // {
        //     foreach (var userChar in terrainController.UserArmy.Characters)
        //     {
        //         var textures = CharactersImagesLoader.Get(userChar.Type);
        //         var frame = textures[userChar.CurrentAnimFrame];
        //         var x = userChar.X + (frame.Width / 2) - (marker.Width / 2);
        //         var y = userChar.Y - 20;
        //         spriteBatch.Draw(marker, new Vector2(x, y), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
        //     }
        // }

        // private void DrawSelectors(SpriteBatch spriteBatch)
        // {
        //     spriteBatch.Draw(selectorGreen, new Vector2(SelectedCharacter.X, SelectedCharacter.Y + 20), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);

        //     if (SelectedCharacter.CurrentAction != CharacterActionType.None)
        //     {
        //         var x = 0;
        //         var y = 0;
        //         switch (SelectedCharacter.CurrentAction)
        //         {
        //             case CharacterActionType.Move:
        //             case CharacterActionType.Shoot:
        //                 x = SelectedCharacter.TargetX;
        //                 y = SelectedCharacter.TargetY;
        //                 break;
        //             case CharacterActionType.Attack:
        //             case CharacterActionType.Speak:
        //                 var targetChar = EnemyArmy.Characters.Find(c => c.Id == SelectedCharacter.TargetId);
        //                 if (targetChar == null)
        //                 {
        //                     targetChar = UserArmy.Characters.Find(c => c.Id == SelectedCharacter.TargetId);
        //                 }
        //                 x = targetChar.X;
        //                 y = targetChar.Y + 20;
        //                 break;
        //         }
        //         spriteBatch.Draw(selectorOrange, new Vector2(x, y), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
        //     }
        // }

        // public override void Draw()
        // {
        //     DrawCharacters(spriteBatch);

        //     if (IsPaused)
        //     {
        //         DrawMarkers(spriteBatch);
        //         DrawSelectors(spriteBatch);
        //     }
        // }
    }
}