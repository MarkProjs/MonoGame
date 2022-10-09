using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;


namespace InteractivePiano
{
    public class WhiteNoteSprite : NoteSprite
    {
        private char _keyChar;
        public WhiteNoteSprite(InteractivePianoGame game, int MoveWidth, string KeyNote, char KeyChar): base(game, MoveWidth, KeyNote){
            _keyChar = KeyChar;
            _moveHeight = 310;
        }

        public char KeyChar {
            get {
                return _keyChar;
            }   
        }
        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = _game.Content.Load<SpriteFont>("NoteFont");
        }
    }
}