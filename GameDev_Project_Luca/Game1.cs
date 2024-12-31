using GameDev_Project_Luca.GameComponents;
using GameDev_Project_Luca.GameObjects;
using GameDev_Project_Luca.Input;
using GameDev_Project_Luca.Levels;
using GameDev_Project_Luca.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameDev_Project_Luca
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _textureHero;
        private Texture2D _textureFly;
        private Texture2D _textureGuard;
        private Texture2D _textureShy;
        private Texture2D _textureHealthFull;
        private Texture2D _textureHealthTwo;
        private Texture2D _textureHealthOne;
        private Texture2D _textureHealthEmpty;
        private Texture2D _textureCoin;

        private SpriteFont textFont;
        private Vector2 fontPos;

        private Gamestate gameState = new Gamestate();
        private Menu menu = new Menu();
        private VictoryScreen victory = new VictoryScreen();

        Hero hero;
        Level level;

        Texture2D background;
        Texture2D deathScreen;

        Texture2D grassBlock;
        Texture2D dirtBlock;

        Level1 level1;
        Level2 level2;
        Level3 level3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true; //fps lock
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
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
            // CoinCounter font
            textFont = Content.Load<SpriteFont>("Font");
            Viewport viewport = _graphics.GraphicsDevice.Viewport;

            fontPos = new Vector2(viewport.Width / 2, viewport.Height / 2);
            // background + HUD
            background = Content.Load<Texture2D>("background-lake");
            deathScreen = Content.Load<Texture2D>("DeathScreen");
            _textureHealthFull = Content.Load<Texture2D>("FullHealth");
            _textureHealthTwo = Content.Load<Texture2D>("2Health");
            _textureHealthOne = Content.Load<Texture2D>("1Health");
            _textureHealthEmpty = Content.Load<Texture2D>("Dead");
            // Screens
            menu.titleScreen = Content.Load<Texture2D>("TitleScreen");
            menu.startSelected = Content.Load<Texture2D>("StartSelected");
            menu.ExitSelected = Content.Load<Texture2D>("ExitSelected");
            victory.Victory = Content.Load<Texture2D>("Victory");
            // Hero + enemies
            _textureHero = Content.Load<Texture2D>("Hedgehog Sprite Sheet");
            _textureFly = Content.Load<Texture2D>("Giant Fly Sprite Sheet");
            _textureGuard = Content.Load<Texture2D>("Fox Sprite Sheet");
            _textureShy = Content.Load<Texture2D>("Pidgeon Sprite Sheet");

            // Level building
            grassBlock = Content.Load<Texture2D>("GrassBlock");
            dirtBlock = Content.Load<Texture2D>("DirtTexture");
            _textureCoin = Content.Load<Texture2D>("RotatingCoin_spritSheet");
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(_textureHero, new KeyboardReader());
            level = new Level();
            level1 = new Level1();
            level2 = new Level2();
            level3 = new Level3();

            level.gameboard = level1.gameboard;

            level.FlyingEnemy = _textureFly;
            level.GuardingEnemy = _textureGuard;
            level.ShyEnemy = _textureShy;
            level.hero = hero;
            level.CoinTexture = _textureCoin;

            level.hero.FullHealth = _textureHealthFull;
            level.hero.TwoHealth = _textureHealthTwo;
            level.hero.OneHealth = _textureHealthOne;
            level.hero.NoHealth = _textureHealthEmpty;

            hero.level = level;
            level.CreateBlocks(grassBlock, dirtBlock);
            level.hero.blocks = level.blocks;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            if (gameState.CheckState() == 0)
            {
                bool enter = menu.Update();
                if (enter == true)
                {
                    int state = menu.PressedEnter();
                    //1 = start, 9 = stop
                    if (state == 1)
                        gameState.changeState(1);
                    else if (state == 9)
                    {
                        Exit();
                    }
                }
            }

            if (gameState.CheckState() == 1)
            {
                bool finished = level.CheckLevelStatus();
                if (finished)
                {
                    int levelNr = level.SwitchLevel();
                    switch (levelNr)
                    {
                        case 1:
                            level.gameboard = level1.gameboard;
                            level.CreateBlocks(grassBlock, dirtBlock);
                            break;
                        case 2:
                            level.gameboard = level2.gameboard;
                            level.CreateBlocks(grassBlock, dirtBlock);
                            break;
                        case 3:
                            level.gameboard = level3.gameboard;
                            level.CreateBlocks(grassBlock, dirtBlock);
                            break;
                        case 4:
                            gameState.changeState(2);
                            break;
                    }
                }
                level.Update(gameTime);
            }
            if (gameState.CheckState() == 2)
            {
                bool retry = victory.Update();
                if (retry == true)
                {
                    gameState.changeState(0);
                    level.gameboard = level1.gameboard;
                    level.CreateBlocks(grassBlock, dirtBlock);
                    level.levelNr = 1;
                    level.hero.FullRestore();
                    level.hero.CoinsCollected = 0;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(background, new Rectangle(0, 0, 1920, 1080), Color.White);

            if (gameState.CheckState() == 0)
                menu.Draw(_spriteBatch);

            if (gameState.CheckState() == 1)
            {
                level.Draw(_spriteBatch);
                level.hero.Draw(_spriteBatch);
                if (level.hero.IsDead)
                {
                    _spriteBatch.Draw(deathScreen, new Rectangle(0, 0, 1920, 1080), Color.White);
                }
            }

            if (gameState.CheckState() == 2)
            {
                victory.Draw(_spriteBatch);
                string output = $"Coins Collected: {level.hero.CoinsCollected}";
                Vector2 FontOrigin = textFont.MeasureString(output) / 2;
                _spriteBatch.DrawString(textFont, output, fontPos, Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
