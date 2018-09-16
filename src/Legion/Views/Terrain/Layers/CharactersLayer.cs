using System;
using System.Linq;
using Gui.Elements;
using Gui.Services;
using Legion.Controllers;
using Legion.Model;
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

        public override void Draw()
        {
            DrawCharacters();

            if (terrainController.IsPaused)
            {
                DrawMarkers();
                DrawSelectors();
            }
        }

        private void DrawCharacters()
        {
            //TODO from where UserArmy/EnemyArmy should be readed? from controller or Parent.Context?
            //terrainController.UserArmy.Characters)
            var context = (TerrainActionContext) Parent.Context;
            foreach (var userChar in context.UserArmy.Characters)
            {
                DrawCharacter(userChar);
            }

            foreach (var enemyChar in context.EnemyArmy.Characters)
            {
                DrawCharacter(enemyChar);
            }
        }

        private void DrawCharacter(Character character)
        {
            var imgName = GuiServices.ImagesStore.GetNames().FirstOrDefault(n =>
                n.EndsWith("." + character.Type.Name)
            );
            var images = GuiServices.ImagesStore.GetImages(imgName);
            var frame = images[character.CurrentAnimFrame];
            GuiServices.BasicDrawer.DrawImage(frame, character.X, character.Y);
        }

        private void DrawMarkers()
        {
            // foreach (var userChar in terrainController.UserArmy.Characters)
            // {
            //     var textures = CharactersImagesLoader.Get(userChar.Type);
            //     var frame = textures[userChar.CurrentAnimFrame];
            //     var x = userChar.X + (frame.Width / 2) - (marker.Width / 2);
            //     var y = userChar.Y - 20;
            //     spriteBatch.Draw(marker, new Vector2(x, y), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
            // }
        }

        private void DrawSelectors()
        {
            // spriteBatch.Draw(selectorGreen, new Vector2(SelectedCharacter.X, SelectedCharacter.Y + 20), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);

            // if (SelectedCharacter.CurrentAction != CharacterActionType.None)
            // {
            //     var x = 0;
            //     var y = 0;
            //     switch (SelectedCharacter.CurrentAction)
            //     {
            //         case CharacterActionType.Move:
            //         case CharacterActionType.Shoot:
            //             x = SelectedCharacter.TargetX;
            //             y = SelectedCharacter.TargetY;
            //             break;
            //         case CharacterActionType.Attack:
            //         case CharacterActionType.Speak:
            //             var targetChar = EnemyArmy.Characters.Find(c => c.Id == SelectedCharacter.TargetId);
            //             if (targetChar == null)
            //             {
            //                 targetChar = UserArmy.Characters.Find(c => c.Id == SelectedCharacter.TargetId);
            //             }
            //             x = targetChar.X;
            //             y = targetChar.Y + 20;
            //             break;
            //     }
            //     spriteBatch.Draw(selectorOrange, new Vector2(x, y), null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
            // }
        }

    }
}