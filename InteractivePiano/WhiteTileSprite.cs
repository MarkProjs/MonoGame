using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;

namespace InteractivePiano
{
    public class WhiteTileSprite : DrawableGameComponent
    {

        private SpriteBatch _spriteBatch;
        private Texture2D _whiteTileTexture;
        private int _moveRight;
        private Game _game;

        private Color _colorTile = Color.White;
        private char _keyChar;

        public WhiteTileSprite(InteractivePianoGame game, int MoveRight, char KeyChar): base(game) {
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
            _whiteTileTexture = _game.Content.Load<Texture2D>("WhiteTile");
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            _spriteBatch.Begin();
             _spriteBatch.Draw(_whiteTileTexture, new Vector2(_moveRight, 130), Color);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}