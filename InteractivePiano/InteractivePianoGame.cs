using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PianoSimulation;
using System.Text;

namespace InteractivePiano
{
    public class InteractivePianoGame : Game
    {
        private GraphicsDeviceManager _graphics;
       private SpriteBatch _spriteBatch;
       private Piano piano;
       private Audio audio;


        public InteractivePianoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            piano = new Piano();
            audio = new Audio();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
                Exit();
            
            string LetterKeys = "qwertyuiopzxdcfvgbnjmk";
            string KeyString ="";
            Keys[] KeyPressed = state.GetPressedKeys();
            if (KeyPressed.Length > 0) {
               KeyString = KeyPressed[0].ToString().ToLower();
            }
           Inputs(KeyString,LetterKeys, state);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void Inputs(string KeyString, string LetterKeys, KeyboardState state){
            if (LetterKeys.Contains(KeyString)) {
                foreach(char keyValue in KeyString) {
                    piano.StrikeKey(keyValue);
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
                }
            }
            else if (state.IsKeyDown(Keys.D2)) {
                piano.StrikeKey('2');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.D4)) {
                piano.StrikeKey('4');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.D5)) {
                piano.StrikeKey('5');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.D7)) {
                piano.StrikeKey('7');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.D8)) {
                piano.StrikeKey('8');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.D9)) {
                piano.StrikeKey('9');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemMinus)) {
                piano.StrikeKey('-');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemOpenBrackets)) {
                piano.StrikeKey('[');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemPlus)) {
                piano.StrikeKey('=');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemComma)) {
                piano.StrikeKey(',');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemPeriod)) {
                piano.StrikeKey('.');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemSemicolon)) {
                piano.StrikeKey(';');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemQuestion)) {
                piano.StrikeKey('/');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.OemQuotes)) {
                piano.StrikeKey('\'');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
            else if (state.IsKeyDown(Keys.Space)) {
                piano.StrikeKey(' ');
                    for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                    }
                    audio.Reset();
            }
        }
    }
}
