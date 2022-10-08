using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PianoSimulation;
using System.Threading.Tasks;

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
        private string whiteKeys = "qwertyuiop[zxcvbnm,./ ";
        private string blackKeys = "245789-=dfgjk;\'";

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
            //whitetile: qwertyuiop[zxcvbnm,./*space*
            //blacktile: 245789-=dfgjk;'
            // TODO: Add your initialization logic here
            //white, black, white, white, black, white, black, white, white, black, white
            //black, white, black, white, white, black, white, black
            
            
            for (int i = 0; i< 22;i++) {
                WhiteTileSprite b = new WhiteTileSprite(this, (i*54), whiteKeys[i]);
                WhiteTileList.Add(b);
                Components.Add(b);
            }

            BlackTileList.Add(new BlackTileSprite(this, 38, (char)blackKeys[0]));
            BlackTileList.Add(new BlackTileSprite(this, 146, (char)blackKeys[1]));
            BlackTileList.Add(new BlackTileSprite(this, 200, (char)blackKeys[2]));
            BlackTileList.Add(new BlackTileSprite(this, 308, (char)blackKeys[3]));
            BlackTileList.Add(new BlackTileSprite(this, 362, (char)blackKeys[4]));
            BlackTileList.Add(new BlackTileSprite(this, 416, (char)blackKeys[5]));
            BlackTileList.Add(new BlackTileSprite(this, 524, (char)blackKeys[6]));
            BlackTileList.Add(new BlackTileSprite(this, 578, (char)blackKeys[7]));
            BlackTileList.Add(new BlackTileSprite(this, 686, (char)blackKeys[8]));
            BlackTileList.Add(new BlackTileSprite(this, 740, (char)blackKeys[9]));
            BlackTileList.Add(new BlackTileSprite(this, 794, (char)blackKeys[10]));
            BlackTileList.Add(new BlackTileSprite(this, 902, (char)blackKeys[11]));
            BlackTileList.Add(new BlackTileSprite(this, 956, (char)blackKeys[12]));
            BlackTileList.Add(new BlackTileSprite(this, 1064, (char)blackKeys[13]));
            BlackTileList.Add(new BlackTileSprite(this, 1118, (char)blackKeys[14]));

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
            Dictionary<Keys, char> keyDict = new Dictionary<Keys, char>() {
                {Keys.Q, 'q'},{Keys.D2, '2'},{Keys.W, 'w'},{Keys.E, 'e'},
                {Keys.D4, '4'},{Keys.R, 'r'},{Keys.D5, '5'},
                {Keys.T, 't'},{Keys.Y, 'y'},{Keys.D7, '7'},{Keys.U, 'u'},
                {Keys.D8, '8'},{Keys.I, 'i'},{Keys.D9, '9'},{Keys.O, 'o'},
                {Keys.P, 'p'},{Keys.OemMinus, '-'},{Keys.OemOpenBrackets, '['},
                {Keys.OemPlus, '='},{Keys.Z, 'z'},{Keys.X, 'x'},{Keys.D, 'd'},
                {Keys.C, 'c'},{Keys.F, 'f'},{Keys.V, 'v'},{Keys.G, 'g'},
                {Keys.B, 'b'},{Keys.N, 'n'},{Keys.J, 'j'},{Keys.M, 'm'},{Keys.K, 'k'},
                {Keys.OemComma, ','},{Keys.OemPeriod, '.'},{Keys.OemSemicolon, ';'},
                {Keys.OemQuestion, '/'},{Keys.OemQuotes, '\''},{Keys.Space, ' '}
            };

            foreach (var tile in keyDict)
            {
                if (state.IsKeyDown(tile.Key)) {
                    RestartColors();
                    if (whiteKeys.Contains(tile.Value)) {
                        for (int i = 0;i < WhiteTileList.Count;i++) {
                            if (WhiteTileList[i].KeyChar == tile.Value) {
                                WhiteTileList[i].Color = Color.Red;
                            }
                        }
                    }
                    else if (blackKeys.Contains(tile.Value)) {
                        for (int i = 0 ; i < BlackTileList.Count;i++) {
                            if (BlackTileList[i].KeyChar == tile.Value) {
                                BlackTileList[i].Color = Color.Red;
                            }
                        }
                    } 
                    piano.StrikeKey(tile.Value);
                    audio.Reset();
                    Task.Run(() =>{
                        for (int i = 0; i < 44100 * 3; i++) {
                        audio.Play(piano.Play());
                        }
                    });    
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
