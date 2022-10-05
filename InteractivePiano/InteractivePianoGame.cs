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
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.ApplyChanges();
            //whitetile: qwertyuiop[zxcvbnm,./*space*
            //blacktile: 245789-=dfgjk;'
            // TODO: Add your initialization logic here
            //white, black, white, white, black, white, black, white, white, black, white
            //black, white, black, white, white, black, white, black
            
            
            for (int i = 0; i< 22;i++) {
                WhiteTileSprite b = new WhiteTileSprite(this, (i*54));
                WhiteTileList.Add(b);
                Components.Add(b);
            }

            BlackTileList.Add(new BlackTileSprite(this, 38));
            BlackTileList.Add(new BlackTileSprite(this, 146));
            BlackTileList.Add(new BlackTileSprite(this, 200));
            BlackTileList.Add(new BlackTileSprite(this, 308));
            BlackTileList.Add(new BlackTileSprite(this, 362));
            BlackTileList.Add(new BlackTileSprite(this, 416));
            BlackTileList.Add(new BlackTileSprite(this, 524));
            BlackTileList.Add(new BlackTileSprite(this, 578));
            BlackTileList.Add(new BlackTileSprite(this, 686));
            BlackTileList.Add(new BlackTileSprite(this, 740));
            BlackTileList.Add(new BlackTileSprite(this, 794));
            BlackTileList.Add(new BlackTileSprite(this, 902));
            BlackTileList.Add(new BlackTileSprite(this, 956));
            BlackTileList.Add(new BlackTileSprite(this, 1064));
            BlackTileList.Add(new BlackTileSprite(this, 1118));

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
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape)) {
                Exit();
            }
            KeyPressed(state);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void KeyPressed(KeyboardState state) {
            var strikes = new List<char>();
            var keyDict = new Dictionary<Keys, char> {
                {Keys.Q, 'q'},
                {Keys.D2, '2'},
                {Keys.W, 'w'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'},
                {Keys.Q, 'q'}  
            };
            if (state.IsKeyDown(Keys.Q)) {
                RestartColors();
                WhiteTileList[0].Color = Color.Gray;
                strikes.Add('q');
            }
            else if (state.IsKeyDown(Keys.D2)) {
                RestartColors();
                BlackTileList[0].Color = Color.Gray;
                strikes.Add('2');
            }
            else if (state.IsKeyDown(Keys.W)) {
                RestartColors();
                WhiteTileList[1].Color = Color.Gray;
                strikes.Add('w');
            }
            else if (state.IsKeyDown(Keys.E)) {
                RestartColors();
                WhiteTileList[2].Color = Color.Gray;
                strikes.Add('e');
            }
            else if (state.IsKeyDown(Keys.D4)) {
                RestartColors();
                BlackTileList[1].Color = Color.Gray;
                strikes.Add('4');
            }
            else if (state.IsKeyDown(Keys.R)) {
                RestartColors();
                WhiteTileList[3].Color = Color.Gray;
                strikes.Add('r');
            }
            else if (state.IsKeyDown(Keys.D5)) {
                RestartColors();
                BlackTileList[2].Color = Color.Gray;
                strikes.Add('5');
            }
            else if (state.IsKeyDown(Keys.T)) {
                RestartColors();
                WhiteTileList[4].Color = Color.Gray;
                strikes.Add('t');
            }
            else if (state.IsKeyDown(Keys.Y)) {
                RestartColors();
                WhiteTileList[5].Color = Color.Gray;
                strikes.Add('y');
            }
            else if (state.IsKeyDown(Keys.D7)) {
                RestartColors();
                BlackTileList[3].Color = Color.Gray;
                strikes.Add('7');
            }
            else if (state.IsKeyDown(Keys.U)) {
                RestartColors();
                WhiteTileList[6].Color = Color.Gray;
                strikes.Add('u');
            }
            else if (state.IsKeyDown(Keys.D8)) {
                RestartColors();
                BlackTileList[4].Color = Color.Gray;
                strikes.Add('8');
            }
            else if (state.IsKeyDown(Keys.I)) {
                RestartColors();
                WhiteTileList[7].Color = Color.Gray;
                strikes.Add('i');
            }
            else if (state.IsKeyDown(Keys.D9)) {
                RestartColors();
                BlackTileList[5].Color = Color.Gray;
                strikes.Add('9');
            }
            else if (state.IsKeyDown(Keys.O)) {
                RestartColors();
                WhiteTileList[8].Color = Color.Gray;
                strikes.Add('o');
            }
            else if (state.IsKeyDown(Keys.P)) {
                RestartColors();
                WhiteTileList[9].Color = Color.Gray;
                strikes.Add('p');
            }
            else if (state.IsKeyDown(Keys.OemMinus)) {
                RestartColors();
                BlackTileList[6].Color = Color.Gray;
                strikes.Add('-');
            }
            else if (state.IsKeyDown(Keys.OemOpenBrackets)) {
                RestartColors();
                WhiteTileList[10].Color = Color.Gray;
                strikes.Add('[');
            }
            else if (state.IsKeyDown(Keys.OemPlus)) {
                RestartColors();
                BlackTileList[7].Color = Color.Gray;
                strikes.Add('=');
            }
            foreach (char strikeKey in strikes) {
                piano.StrikeKey(strikeKey);
                audio.Reset();
                for (int i = 0; i < 44100 * 3; i++) {
                    audio.Play(piano.Play());
                }
                
            }
        }

        private void RestartColors() {
            for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
        }
    }
}
