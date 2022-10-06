using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;

namespace InteractivePiano
{
    public class BlackTileSprite: DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private Texture2D BlackTileTexture;
        private Game _game;

        private int _moveRight;
        private Color _colorTile = Color.White;
        private char _keyChar;

        public BlackTileSprite(InteractivePianoGame game, int MoveRight, char KeyChar) : base(game) {
            _game = game;
            _moveRight = MoveRight;
            _keyChar = KeyChar;
        }
        public char KeyChar {
            get {
                return _keyChar;
            }
        }
        public Color Color {
            get {
                return _colorTile;
            }
            set {
                _colorTile = value;
            }
        }
        public override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

         protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            BlackTileTexture = _game.Content.Load<Texture2D>("BlackTile");
        }
        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime) {
            _spriteBatch.Begin();
             _spriteBatch.Draw(BlackTileTexture, new Vector2(_moveRight, 129), Color);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}