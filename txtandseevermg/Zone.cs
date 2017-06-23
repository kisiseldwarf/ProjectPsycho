using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace txtandseevermg
{
    class Zone
    {
        protected string _descaffiche; //Variable appellé dans game.cs, qui assure le focus

        protected string _desc; //Description principale
        protected string _descLook; //Description des actions...
        protected string _descAct;
        protected string _descMove;
        protected string _descTake;


        protected string _nom; //Nom du niveau

        #region proprietes
        public string Desc { get => _desc; set => _desc = value; }
        public string DescLook { get => _descLook; set => _descLook = value; }
        public string DescAct { get => _descAct; set => _descAct = value; }
        public string DescMove { get => _descMove; set => _descMove = value; }
        public string DescTake { get => _descTake; set => _descTake = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Descaffiche { get => _descaffiche; set => _descaffiche = value; }
        #endregion

        #region constructeurs
        public Zone() //Crée un niveau vide (sans fichier texte)
        {
            Nom = "";
            Desc = "";
            DescLook = "";
            DescAct = "";
            DescMove = "";
            DescTake = "";
        }

        public Zone(string path) //Crée un niveau avec un fichier texte
        {
            StreamReader stread = new StreamReader(path);
            string res = stread.ReadLine();
            try
            {
                while (!res.EndsWith(";"))
                {
                    res += stread.ReadLine();
                }
                Nom = res.Remove(res.LastIndexOf(';'));
                res = stread.ReadLine();
                while (!res.EndsWith(";"))
                {
                    res += stread.ReadLine();
                }
                Desc = res.Remove(res.LastIndexOf(';'));
                res = stread.ReadLine();
                while (!res.EndsWith(";"))
                {
                    res += stread.ReadLine();
                }
                DescAct = res.Remove(res.LastIndexOf(';'));
                res = stread.ReadLine();
                while (!res.EndsWith(";"))
                {
                    res += stread.ReadLine();
                }
                DescLook = res.Remove(res.LastIndexOf(';'));
                res = stread.ReadLine();
                while (!res.EndsWith(";"))
                {
                    res += stread.ReadLine();
                }
                DescMove = res.Remove(res.LastIndexOf(';'));
                res = stread.ReadLine();
                while (!res.EndsWith(";"))
                {
                    res += stread.ReadLine();
                }
                DescTake = res.Remove(res.LastIndexOf(';'));
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur de génération de nievau est survenue. Le programme va s'arrêter.");
            }
            Descaffiche = _desc;

        }

        #endregion

        public virtual void Princ() //Affiche la description principale
        {
            Descaffiche = Desc;
        }
        public virtual void Look() //Accompli l'action Look
        {
            Descaffiche = _descLook; //Passe le focus sur la descrption de l'action
        }

        public virtual void Act() //Accompli l'action Act
        {
            Descaffiche = _descAct; //Passe le focus sur la descrption de l'action
        }
        public virtual void Take() //Accompli l'action Take
        {
            Descaffiche = _descTake; //Passe le focus sur la descrption de l'action
        }
        
        public virtual void Move() //Accompli l'action Move
        {
            Descaffiche = _descMove; //Passe le focus sur la descrption de l'action
        }
    }
}
