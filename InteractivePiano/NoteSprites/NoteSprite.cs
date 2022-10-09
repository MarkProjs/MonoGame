using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;


namespace InteractivePiano
{
    public abstract class NoteSprite : DrawableGameComponent
    {
        protected SpriteBatch _spriteBatch;
        protected SpriteFont _font;
        protected int _moveWidth;
        protected int _moveHeight;
        protected InteractivePianoGame _game;
        protected string _keyNote;
        protected Color _fontColor;

        public NoteSprite(InteractivePianoGame game, int MoveWidth, string KeyNote): base(game) {
            _moveWidth = MoveWidth;
            _game = game;
            _keyNote = KeyNote;
            _fontColor = Color.Transparent;
        }

        public string KeyNote {
            get {
                return _keyNote;
            }   
        }
        public Color Color {
            set {
                _fontColor = value;
            }
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
            _spriteBatch.DrawString(_font, _keyNote, new Vector2(_moveWidth, _moveHeight), _fontColor);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}