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
        private string[] _whiteNote = {"A","B","C","D","E","F","G","A","B","C","D","E","F","G","A","B","C","D","E","F","G","A"};
        private string[] _blackNote = {"A#", "C#", "D#", "F#", "G#", "A#", "C#", "D#", "F#", "G#", "A#", "C#", "D#", "F#", "G#"};
        private List<NoteSprite> _keyNotes = new List<NoteSprite>();

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
           //insert the tiles in the initialization
           InsertTilesAndNotes();
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
                                    ((WhiteNoteSprite)_keyNotes[i]).Color = Color.Red;
                                }
                            }
                        }
                    }
                    else if (_blackKeys.Contains(tile.Value)) {
                        for (int i = 0 ; i < _tileList.Count;i++) {
                            if (_tileList[i] is BlackTileSprite) {
                                if (((BlackTileSprite)_tileList[i]).KeyChar == tile.Value) {
                                    ((BlackTileSprite)_tileList[i]).Color = Color.Red;
                                    ((BlackNoteSprite)_keyNotes[i]).Color = Color.Red;
                                }
                            }
                        }
                    } 

                    audio.Reset();
                    piano.StrikeKey(tile.Value);
                    Task.Run(() => {
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
                else if (_tileList[i] is BlackTileSprite) {
                    ((BlackTileSprite)_tileList[i]).Color = Color.Black;
                }
                _keyNotes[i].Color = Color.Transparent;
            }
        }

        private void InsertTilesAndNotes() {
            //inserting the white tiles and white notes
            for (int i = 0; i< 22;i++) {
                NoteSprite nw = new WhiteNoteSprite(this, ((i*54) + 20), _whiteNote[i], _whiteKeys[i]);
                _keyNotes.Add(nw);
                KeySprite w = new WhiteTileSprite(this, (i*54), _whiteKeys[i]);
                _tileList.Add(w); 
            }
            
             //insert the black keys and their notes
            int initialValKey = 38;
            int initialValNote = 41;
            int[] _doubleInitVal = {0, 2, 5, 7, 10, 12};
            for (int i =0 ; i < 15 ; i++) {
                NoteSprite nb = new BlackNoteSprite(this, ((i*54)+initialValNote), _blackNote[i], _blackKeys[i]);
                _keyNotes.Add(nb);
                KeySprite b = new BlackTileSprite(this, ((i*54) + initialValKey), _blackKeys[i]);
                _tileList.Add(b);
                if (_doubleInitVal.Contains(i)) {
                    initialValNote = initialValNote + 54;
                    initialValKey = initialValKey + 54;
                } 
            }

            for (int i = 0; i < _tileList.Count;i++) {
                Components.Add(_keyNotes[i]);
                Components.Add(_tileList[i]);
            }
        }
    }
}
