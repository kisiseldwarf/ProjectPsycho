using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace txtandseevermg
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Zone> zones;
        SpriteFont princFont;
        Interface[] interfaces; //Un nombre N d'interfaces

        int focusInterface; //focus de l'interface
        Zone zoneact; //représente la zone actuelle
        const string pathzonedir = "Zones"; //Repertoire des zones
        const int nbInterfaces = 5; //Nombre d'interface du jeu
        KeyboardState keyboardInput;
        KeyboardState oldKeyboardInput; 

        double millis; //Sert a ecrire lettre par lettre ; gere le temps
        int j; //Sert à écrire lettre par lettre ; gere les index
        string descfocus; //Sert a ecrire lettre par lettre ; gère le string qui s'affiche

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            zones = new List<Zone>();
            interfaces = new Interface[nbInterfaces];
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            focusInterface = 0;
            interfaces[0] = new Interface(5); //Création de l'interface principale
            interfaces[0].Nom = "Menu";
            interfaces[0].Boutons[0] = "Act";
            interfaces[0].Boutons[1] = "Look";
            interfaces[0].Boutons[2] = "Take";
            interfaces[0].Boutons[3] = "Move";
            interfaces[0].Boutons[4] = "Journal des quetes";
            interfaces[1] = new Interface(2); //Création de l'inventaire
            interfaces[1].Boutons[0] = "Journal";
            interfaces[1].Boutons[1] = "Revenir";
            interfaces[2] = new Interface();

            millis = 0;
            j = 0;
            descfocus = "";

            foreach (string pathzone in Directory.EnumerateFiles(pathzonedir)) //Chargement des zones 
            {
                pathzone.Replace("/", "//");
                zones.Add(new Zone(pathzone));
            }
            zoneact = zones[0];
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            princFont = Content.Load<SpriteFont>("arial");       
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keyboardInput = Keyboard.GetState();

            if (keyboardInput.IsKeyDown(Keys.Escape))
                Exit(); //Pour quitter le jeu

            if (keyboardInput.IsKeyDown(Keys.Enter) && oldKeyboardInput.IsKeyUp(Keys.Enter)) //En cas d'appui sur Entrée
            {
                for (int i = 0; i < interfaces[focusInterface].Nbboutons; i++)
                {

                }
                if (focusInterface == 0)//Interface 0 Menu
                {
                    if (interfaces[focusInterface].FocusBoutons == 0) // 0 = ACT
                    {
                        descfocus = "";//On clean le focus (vu qu'on change de focus)
                        j = 0;
                        zoneact.Act(); //TODO faire une liste de niveaux avec un index générique pr le niveau actuel
                    }
                    if (interfaces[focusInterface].FocusBoutons == 1) // 1 = LOOK
                    {

                        descfocus = "";//On clean le focus (vu qu'on change de focus)
                        j = 0;
                        zoneact.Look(); //TODO faire une liste de niveaux avec un index générique pr le niveau actuel

                    }

                    if (interfaces[focusInterface].FocusBoutons == 2)// 2 = TAKE
                    {
                        descfocus = "";//On clean le focus (vu qu'on change de focus)
                        j = 0;
                        zoneact.Take(); //TODO faire une liste de niveaux avec un index générique pr le niveau actuel

                    }
                    if (interfaces[focusInterface].FocusBoutons == 3)// 3 = MOVE
                    {

                        descfocus = "";//On clean le focus (vu qu'on change de focus)
                        j = 0;
                        zoneact.Move(); //TODO faire une liste de niveaux avec un index générique pr le niveau actuel

                    }
                    if (interfaces[focusInterface].FocusBoutons == 4)// 4 = Inventaire
                    {

                        focusInterface = 1;
                        interfaces[focusInterface].FocusBoutons = 0; //Evite un bug
                        //TODO : Ici code qui se déclenche à l'arrivée de la nouvelle interface une et une fois

                    }
                } // Interface 0 (Menu)

                if (focusInterface == 1) //Inventaire
                {
                    if (interfaces[focusInterface].FocusBoutons == 1)
                    {
                        focusInterface = 0;
                        interfaces[focusInterface].FocusBoutons = 0; //Evite un bug
                    }
                }

            }//Appui sur entrée


            #region Interface : selection d'un bouton

            if (keyboardInput.IsKeyDown(Keys.Left) && oldKeyboardInput.IsKeyUp(Keys.Left)) //Choix de l'action ds menu des actions
            {
                interfaces[focusInterface].FocusBoutons--;
                if (interfaces[focusInterface].FocusBoutons <= -1)
                {
                    interfaces[focusInterface].FocusBoutons = interfaces[focusInterface].Nbboutons - 1;
                }
            }

            if (keyboardInput.IsKeyDown(Keys.Right) && oldKeyboardInput.IsKeyUp(Keys.Right)) //Idem
            {
                interfaces[focusInterface].FocusBoutons++;
                if (interfaces[focusInterface].FocusBoutons >= interfaces[focusInterface].Nbboutons)
                {
                    interfaces[focusInterface].FocusBoutons = 0;
                }
            }
            #endregion


            // TODO: Add your update logic here

            oldKeyboardInput = keyboardInput;
            base.Update(gameTime);
        } // Interface 1 (Menu)

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            spriteBatch.Begin();

            interfaces[focusInterface].Draw(spriteBatch, princFont);

            if (gameTime.TotalGameTime.TotalMilliseconds - millis > 20 && j < zoneact.Descaffiche.Length) //Dessin du texte
            {                
                descfocus += zoneact.Descaffiche[j];
                j++;
                millis = gameTime.TotalGameTime.TotalMilliseconds;
            } 
            spriteBatch.DrawString(princFont, descfocus, new Vector2(0, 50), Color.White); //Fin dessin du texte

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
