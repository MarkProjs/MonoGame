using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;

namespace InteractivePiano
{
    public class InteractivePianoGame : Game
    {
        private GraphicsDeviceManager _graphics;
       private SpriteBatch _spriteBatch;
       private Piano piano;
       private Audio audio;

        private List<WhiteTileSprite> WhiteTileList = new List<WhiteTileSprite>();
        private List<BlackTileSprite> BlackTileList = new List<BlackTileSprite>();

        private int _whiteTileMoveRight = 0;
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
            //white, black, white, white, black, white, black, white, white, black, white
            //black, white, black, white, white, black, white, black
            
            
            for (int i = 0; i< 11;i++) {
                WhiteTileSprite b = new WhiteTileSprite(this, _whiteTileMoveRight);
                WhiteTileList.Add(b);
                Components.Add(b);
                _whiteTileMoveRight += 54;
            }

            BlackTileList.Add(new BlackTileSprite(this, 38));
            BlackTileList.Add(new BlackTileSprite(this, 146));
            BlackTileList.Add(new BlackTileSprite(this, 200));
            BlackTileList.Add(new BlackTileSprite(this, 308));
            BlackTileList.Add(new BlackTileSprite(this, 362));
            BlackTileList.Add(new BlackTileSprite(this, 416));
            BlackTileList.Add(new BlackTileSprite(this, 524));
            BlackTileList.Add(new BlackTileSprite(this, 578));

            for (int i = 0 ; i < BlackTileList.Count;i++) {
                Components.Add(BlackTileList[i]);
            }
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //q2we4r5ty7u8i9op-[=
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
            var strikes = new List<char>();
            if (LetterKeys.Contains(KeyString)) {
                strikes.AddRange(KeyString);
            }
            else if (state.IsKeyDown(Keys.D2)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                WhiteTileList[0].Color = Color.Gray;
                strikes.Add('2');
            }
            else if (state.IsKeyDown(Keys.D4)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                WhiteTileList[1].Color = Color.Gray;
                strikes.Add('4');
            }
            else if (state.IsKeyDown(Keys.D5)) {
                strikes.Add('5');
            }
            else if (state.IsKeyDown(Keys.D7)) {
                strikes.Add('7');
            }
            else if (state.IsKeyDown(Keys.D8)) {
                strikes.Add('8');
            }
            else if (state.IsKeyDown(Keys.D9)) {
                strikes.Add('9');
            }
            else if (state.IsKeyDown(Keys.OemMinus)) {
                strikes.Add('-');
            }
            else if (state.IsKeyDown(Keys.OemOpenBrackets)) {
                strikes.Add('[');
            }
            else if (state.IsKeyDown(Keys.OemPlus)) {
                strikes.Add('=');
            }
            else if (state.IsKeyDown(Keys.OemComma)) {
                strikes.Add(',');
            }
            else if (state.IsKeyDown(Keys.OemPeriod)) {
                strikes.Add('.');
            }
            else if (state.IsKeyDown(Keys.OemSemicolon)) {
                strikes.Add(';');
            }
            else if (state.IsKeyDown(Keys.OemQuestion)) {
                strikes.Add('/');
            }
            else if (state.IsKeyDown(Keys.OemQuotes)) {
                strikes.Add('\'');
            }
            else if (state.IsKeyDown(Keys.Space)) {
                strikes.Add(' ');
            }

            foreach (char strikeKey in strikes) {
                piano.StrikeKey(strikeKey);
                audio.Reset();
                for (int i = 0; i < 44100 * 3; i++) {
                    audio.Play(piano.Play());
                }
                
            }
        }
    }
}
