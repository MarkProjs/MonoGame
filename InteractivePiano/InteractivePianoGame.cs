using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InteractivePiano
{
    public class InteractivePianoGame : Game
    {
        private GraphicsDeviceManager _graphics;
       private SpriteBatch _spriteBatch;
       private Piano piano;
       private Audio audio;

        private List<KeySprite> _tileList = new List<KeySprite>();
        private string _whiteKeys = "qwertyuiop[zxcvbnm,./ ";
        private string _blackKeys = "245789-=dfgjk;\'";

        public InteractivePianoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            piano = new Piano();
            audio = Audio.Instance;
        }

        protected override void Initialize()
        {   
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.ApplyChanges();
            //full keys: q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' 
            //whitetile: qwertyuiop[zxcvbnm,./*space*
            //blacktile: 245789-=dfgjk;'
            // TODO: Add your initialization logic here
            //white, black, white, white, black, white, black, white, white, black, white
            //black, white, black, white, white, black, white, black
            
            for (int i = 0; i< 22;i++) {
                KeySprite w = new WhiteTileSprite(this, (i*54), _whiteKeys[i]);
                _tileList.Add(w); 
            }
            
            int initialVal = 38;
            int[] _doubleInitVal = {0, 2, 5, 7, 10, 12};
            for (int i =0 ; i < 15 ; i++) {
                KeySprite b = new BlackTileSprite(this, ((i*54) + initialVal), _blackKeys[i]);
                _tileList.Add(b);
                //insert the black keys
                if (_doubleInitVal.Contains(i)) {
                    initialVal = initialVal + 54;
                }
                
            }

            for (int i = 0; i < _tileList.Count;i++) {
                Components.Add(_tileList[i]);
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
            Dictionary<Keys, char> keyDict = new Dictionary<Keys, char>() {
                {Keys.Q, 'q'},{Keys.D2, '2'},{Keys.W, 'w'},{Keys.E, 'e'}, {Keys.D4, '4'},{Keys.R, 'r'},{Keys.D5, '5'},{Keys.T, 't'},{Keys.Y, 'y'},
                {Keys.D7, '7'},{Keys.U, 'u'},{Keys.D8, '8'},{Keys.I, 'i'},{Keys.D9, '9'},{Keys.O, 'o'},{Keys.P, 'p'},{Keys.OemMinus, '-'},
                {Keys.OemOpenBrackets, '['},{Keys.OemPlus, '='},{Keys.Z, 'z'},{Keys.X, 'x'},{Keys.D, 'd'},{Keys.C, 'c'},{Keys.F, 'f'},{Keys.V, 'v'},
                {Keys.G, 'g'},{Keys.B, 'b'},{Keys.N, 'n'},{Keys.J, 'j'},{Keys.M, 'm'},{Keys.K, 'k'},{Keys.OemComma, ','},
                {Keys.OemPeriod, '.'},{Keys.OemSemicolon, ';'},{Keys.OemQuestion, '/'},{Keys.OemQuotes, '\''},{Keys.Space, ' '}
            };

            foreach (var tile in keyDict)
            {
                if (state.IsKeyDown(tile.Key)) {
                    RestartColors();
                    if (_whiteKeys.Contains(tile.Value)) {
                        for (int i = 0;i < _tileList.Count;i++) {
                            if (_tileList[i] is WhiteTileSprite) {
                                if (((WhiteTileSprite)_tileList[i]).KeyChar == tile.Value) {
                                    ((WhiteTileSprite)_tileList[i]).Color = Color.Red;
                                }
                            }
                        }
                    }
                    else if (_blackKeys.Contains(tile.Value)) {
                        for (int i = 0 ; i < _tileList.Count;i++) {
                            if (_tileList[i] is BlackTileSprite) {
                                if (((BlackTileSprite)_tileList[i]).KeyChar == tile.Value) {
                                    ((BlackTileSprite)_tileList[i]).Color = Color.Red;
                                }
                            }
                        }
                    } 
                    Task.Run(() =>{
                        piano.StrikeKey(tile.Value);
                        audio.Reset();
                        for (int i = 0; i < 44100 * 3; i++) {
                            audio.Play(piano.Play());
                        }
                    });  
                }
            }
        }

        private void RestartColors() {
            for (int i = 0 ; i < _tileList.Count; i++) {
                    if (_tileList[i] is WhiteTileSprite) {
                        ((WhiteTileSprite)_tileList[i]).Color = Color.White;
                    }
                    
            }
            for (int i = 0 ; i < _tileList.Count; i++) {
                if (_tileList[i] is BlackTileSprite) {
                     ((BlackTileSprite)_tileList[i]).Color = Color.Black;
                }
                
            }
        }
    }
}
