using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;


namespace InteractivePiano
{
    public abstract class KeySprite: DrawableGameComponent
    {
        protected SpriteBatch _spriteBatch;
        protected Texture2D _tileTexture;
        protected int _moveRight;
        protected Color _colorTile;

        protected InteractivePianoGame _game;
        public KeySprite(InteractivePianoGame game, int MoveRight): base(game) {
            _moveRight = MoveRight;
            _game = game;
        }

        public override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        protected override abstract void LoadContent();

        public override void Draw(GameTime gameTime) {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_tileTexture, new Vector2(_moveRight, 130), _colorTile);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
      
    }
}