using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SinusCosinus
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        Texture2D raket;
        Vector2 position;
        float rotation;

        Vector2 mousePosition;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
      

            base.Initialize();
        }

        protected override void LoadContent()
        {

            raket = Content.Load<Texture2D>("raketen");

            position = new Vector2(200, 200);
            rotation = 0;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

      
        protected override void UnloadContent()
        {
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Möjliggör hämtning av musposition
            MouseState mouse = Mouse.GetState();

            //lagrar nuvarande muspos för varje renderad frame (60ggr i sek uppdateras den)
            mousePosition = new Vector2(mouse.X, mouse.Y);

            //möjliggör synlig muspekare i spelruta
            IsMouseVisible = true;


            Vector2 direction = mousePosition - position;
            direction.Normalize();


            //Trigonometri Arctan2
            rotation = (float)Math.Atan2((double)direction.Y,(double)direction.X);


            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(raket, position, null, Color.White, rotation,new Vector2(raket.Width / 2, raket.Height / 2), 1.0f, SpriteEffects.None, 1.0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
