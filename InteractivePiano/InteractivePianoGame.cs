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
            var strikes = new List<char>();
            if (state.IsKeyDown(Keys.Q)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[0].Color = Color.Gray;
                strikes.Add('q');
            }
            else if (state.IsKeyDown(Keys.D2)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[0].Color = Color.Gray;
                strikes.Add('2');
            }
            else if (state.IsKeyDown(Keys.W)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[1].Color = Color.Gray;
                strikes.Add('w');
            }
            else if (state.IsKeyDown(Keys.E)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[2].Color = Color.Gray;
                strikes.Add('e');
            }
            else if (state.IsKeyDown(Keys.D4)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[1].Color = Color.Gray;
                strikes.Add('4');
            }
            else if (state.IsKeyDown(Keys.R)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[3].Color = Color.Gray;
                strikes.Add('r');
            }
            else if (state.IsKeyDown(Keys.D5)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[2].Color = Color.Gray;
                strikes.Add('5');
            }
            else if (state.IsKeyDown(Keys.T)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[4].Color = Color.Gray;
                strikes.Add('t');
            }
            else if (state.IsKeyDown(Keys.Y)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[5].Color = Color.Gray;
                strikes.Add('y');
            }
            else if (state.IsKeyDown(Keys.D7)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[3].Color = Color.Gray;
                strikes.Add('7');
            }
            else if (state.IsKeyDown(Keys.U)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[6].Color = Color.Gray;
                strikes.Add('u');
            }
            else if (state.IsKeyDown(Keys.D8)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[4].Color = Color.Gray;
                strikes.Add('8');
            }
            else if (state.IsKeyDown(Keys.I)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[7].Color = Color.Gray;
                strikes.Add('i');
            }
            else if (state.IsKeyDown(Keys.D9)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[5].Color = Color.Gray;
                strikes.Add('9');
            }
            else if (state.IsKeyDown(Keys.O)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[8].Color = Color.Gray;
                strikes.Add('o');
            }
            else if (state.IsKeyDown(Keys.P)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[9].Color = Color.Gray;
                strikes.Add('p');
            }
            else if (state.IsKeyDown(Keys.OemMinus)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                BlackTileList[6].Color = Color.Gray;
                strikes.Add('-');
            }
            else if (state.IsKeyDown(Keys.OemOpenBrackets)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
                WhiteTileList[10].Color = Color.Gray;
                strikes.Add('[');
            }
            else if (state.IsKeyDown(Keys.OemPlus)) {
                for (int i = 0 ; i < WhiteTileList.Count; i++) {
                    WhiteTileList[i].Color = Color.White;
                }
                for (int i = 0 ; i < BlackTileList.Count; i++) {
                    BlackTileList[i].Color = Color.Black;
                }
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
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
