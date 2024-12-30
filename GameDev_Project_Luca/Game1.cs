using GameDev_Project_Luca.GameObjects;
using GameDev_Project_Luca.Input;
using GameDev_Project_Luca.Interfaces;
using GameDev_Project_Luca.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameDev_Project_Luca
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _textureHero;
        private Texture2D _textureFly;
        Hero hero;
        Level level;
        FlyingEnemy fly;

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
            //_graphics.IsFullScreen = true;
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
            // background + HUD
            background = Content.Load<Texture2D>("background-lake");
            deathScreen = Content.Load<Texture2D>("DeathScreen");
            // hero + enemies
            _textureHero = Content.Load<Texture2D>("Hedgehog Sprite Sheet");
            _textureFly = Content.Load<Texture2D>("Giant Fly Sprite Sheet");
            // blocks
            grassBlock = Content.Load<Texture2D>("GrassBlock");
            dirtBlock = Content.Load<Texture2D>("DirtTexture");
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(_textureHero, new KeyboardReader());
            fly = new FlyingEnemy(_textureFly, hero);
            level = new Level();
            level1 = new Level1();
            level2 = new Level2();
            level3 = new Level3();

            level.level1 = level1;
            level.level2 = level2;
            level.level3 = level3;

            level.gameboard = level1.gameboard;

            level.hero = hero;
            hero.level = level;
            level.CreateBlocks(grassBlock, dirtBlock);
            level.hero.blocks = level.blocks;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            level.CheckLevelStatus();
            level.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(background, new Rectangle(0, 0, 1920, 1080), Color.White);
            level.Draw(_spriteBatch);
            level.hero.Draw(_spriteBatch);
            fly.Draw(_spriteBatch);
            if (level.hero.IsDead)
            {
                _spriteBatch.Draw(deathScreen, new Rectangle(0,0,1920,1080), Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
