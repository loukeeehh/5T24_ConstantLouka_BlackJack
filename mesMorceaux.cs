using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public struct mesMorceaux
    {
       /* public void sommeTableau(ref int[] T, out int sum)
        {
            sum = T.Sum();

        }
       */
        public void tireCarte(ref int[,] T, int numPioche, int numJoueur /* lignes */) // procédure qui permet de tirer une carte
        {

            int carte = new Random().Next(1, 12);
            T[numJoueur, numPioche + 1] = carte;
             
        }

        public void totalScoreJoueurs(int[,] T, int numJoueur /*lignes*/, out int total) //calculer le total des points des joueurs
        {
            int i;
            total = 0;
            for (i = 0; i <= T.GetLength(1) - 1; i++)
            {
                total = total + T[numJoueur, i];
            }
            
        }


        public void genereMatrice(out int[,] Matrice) // procédure pour générer une matrice
        {
            int lignes = 5;
            int colonnes = 6;
            Matrice = new int[lignes, colonnes];
            int i;
            int j;
            Random alea = new Random();

            for (i = 0; i < lignes; i++)
            {

                for (j = 0; j < colonnes; j++)
                {
                    if (j == 0 || j == 1)
                    {
                        Matrice[i, j] = alea.Next(1, 11);
                    }

                    else
                    {
                        Matrice[i, j] = 0;
                    }
                    
                }
            }

        }


        public void concateneMatrice(int[,] Matrice, out string concatene) // procédure pour concaténer la matrice
        {
            concatene = "";

            for (int i = 0; i <= Matrice.GetLength(0) - 1; i++)
            {
                string lignes = "";

                for (int j = 0; j <= Matrice.GetLength(1) - 1; j++)
                {
                    lignes = lignes + Matrice[i, j];

                    if (j != Matrice.GetLength(1) - 1)
                    {
                        lignes = lignes + ",";
                    }
                }
                concatene = concatene + "\n" + lignes;
            }
        }


        public void afficherTableauJoueurs(int[,] T, out string message)
        {
            message = " ";
            foreach (int i in T)
            {
                switch (i)
                {
                    case 1:

                        message += "As ";
                        break;
                    case 2:

                        message += "Deux ";
                        break;

                    case 3:

                        message += "Trois ";
                        break;

                    case 4:

                        message += "Quatre ";
                        break;

                    case 5:

                        message += "Cinq ";
                        break;

                    case 6:

                        message += "Six ";
                        break;

                    case 7:

                        message += "Sept ";
                        break;

                    case 8:

                        message += "Huit ";
                        break;

                    case 9:

                        message += "Neuf ";
                        break;

                    case 10:
                        message += "Dix ";
                        break;

                    case 11:
                        message += "As ";
                        break;
                    default:

                        message += " ";
                        break;


                }

            }
        }

        




        /*
        public void annonceVainqueur(int scoreCroupier, int scoreUser, out string message)
        {
            message = "";
            if (scoreUser <= 21 && scoreUser > scoreCroupier || scoreUser == 21)
            {
                message = $"Félicitation, vous avez gagné ! Votre score est de {scoreUser}";
            }

            else if (scoreUser < scoreCroupier)
            {
                message = $"Désolé, vous avez perdu ! Votre score est de {scoreUser}";
            }

            else if (scoreUser == scoreCroupier)
            {
                message = "Vous êtes à égalité avec le croupier !";
            }

        }
        */

      




        /*
        public void CarteCachee( ref int[] T)
        {
            int i;

            for (i = 0; i < T.Length ; i++)
            {
                Console.WriteLine("Cartes cachées");
            }
        }
        */
        /*
        public void annonceVainqueur(int scoreCroupier, int scoreUser, out string message)
        {
            message = "";
            if (scoreUser <= 21 && scoreUser > scoreCroupier || scoreUser == 21)
            {
                message = $"Félicitation, vous avez gagné ! Votre score est de {scoreUser}";
            }

            else if (scoreUser < scoreCroupier)
            {
                message = $"Désolé, vous avez perdu ! Votre score est de {scoreUser}";
            }

            else if (scoreUser == scoreCroupier)
            {
                message = "Vous êtes à égalité avec le croupier !";
            }

        }
        */
    }
}
