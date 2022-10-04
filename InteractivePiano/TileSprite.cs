using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;

namespace InteractivePiano
{
    public class TileSprite : DrawableGameComponent
    {

        private SpriteBatch _spriteBatch;
        private Texture2D _balckTileTexture;
        private Texture2D _whiteTileTexture;
        Game _game;

        public TileSprite(InteractivePianoGame game): base(game) {
            _game = game;
        }
        public override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _balckTileTexture = _game.Content.Load<Texture2D>("BlackTile");
            _whiteTileTexture = _game.Content.Load<Texture2D>("WhiteTile");
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            _spriteBatch.Begin(SpriteSortMode.BackToFront);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}