using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;

namespace InteractivePiano
{
    public class WhiteTileSprite : KeySprite
    {
        private char _keyChar;
        public WhiteTileSprite(InteractivePianoGame game, int MoveRight, char KeyChar): base(game, MoveRight){
            _keyChar = KeyChar;
            _colorTile = Color.White;
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
        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tileTexture = _game.Content.Load<Texture2D>("WhiteTile");
        }
    }
}