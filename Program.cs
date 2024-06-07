namespace blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+----------------------------------+");
            Console.Write("\n|");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Bienvenue au BlackJack  royale    ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("|");
            Console.Write("\n+----------------------------------+\n");
            Console.ResetColor();

            Console.WriteLine("Bienvenue au BlakJack !");
            int[,] TScoreUsers; // Matrice des scores de joueurs
            int numPioche; // rajouter une carte
            int totalPoints; // total point d'un joueur
            int[] totauxPointsJoueur = new int[5];
            int maxPoints = 0; // points maximum atteint sur le jeu
            int numJoueurGagnant; // numéro du joueur gagnant
            bool[] jeuFini  = new bool [5];
            string nUser; //réponse de l'utilisateur
            string message;
            string repeatProg; // répétition du programme
            mesMorceaux morceauxProg = new mesMorceaux(); // morceaux de programme

            do
            {
                for (int i = 0; i <= jeuFini.Length - 1; i++)
                {
                    jeuFini[i] = false;
                }
                
                Console.WriteLine("Avant de vouloir commencer cette partie, voulez-vous les règles ?");
                Console.WriteLine(" - Taper 1 pour les voir.\n - Taper 2 pour les passer.");
                nUser = Console.ReadLine();


                if (nUser == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Voici les règles :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Le Blackjack consiste à battre la banque, qui est représenté par le croupier, sans dépasser la valeur de 21 sinon vous perdez la partie.\nSi vous atteignez le Blackjack (une carte valant 10 + un as) vous gagnez directement la partie ! Si vous gagnez contre le croupier (si la valeur de vos cartes est supérieur à celle du croupier et après en avoir tiré 1 ou 2), vous remportez également la partie .\r\nIl existe des valeurs sur toutes les cartes (sauf le joker car il n'est présent dans le jeu). \n Les voici :\n\n Le BlackJack = 21 (Vous gagnez automatiquement)\n L'As = 1 ou 11 (Selon votre score, à votre avantage)\n Le roi = 10\n La reine = 10\n Le valet = 10\n La carte dix = 10\n La carte neuf = 9\n La carte huit = 8\n La carte sept = 7\n La carte six = 6\n La carte cinq = 5\n La carte quatre = 4\n La carte trois = 3\n La carte deux = 2\n");
                }

                else if (nUser == "2")
                {
                    Console.WriteLine("Très bien, je vous souhaite une bonne partie !\n");
                }

                Console.WriteLine("Voulez - vous commencer la partie ? 'o' = oui, 'n' = non");
                nUser = Console.ReadLine();

                if (nUser == "o")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    morceauxProg.genereMatrice(out TScoreUsers);
                    morceauxProg.concateneMatrice(TScoreUsers, out message);
                    Console.WriteLine($"{message}\n");
                    morceauxProg.afficherTableauJoueurs(TScoreUsers, out message);
                    Console.WriteLine(message);
                    numPioche = 1;
                    

                    while (numPioche <= 3)
                    {
                
                        for (int i = 0; i <= TScoreUsers.GetLength(0) - 1; i++)
                        {
                            if (!jeuFini[i])
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"Joueur {i} Voulez-vous tirer une carte ? 't' pour tirer une carte, 'r' pour rester ");
                                Console.ResetColor();
                                nUser = Console.ReadLine();

                                if (nUser == "t")
                                {
                                    morceauxProg.tireCarte(ref TScoreUsers, numPioche, i);
                                }
                            }
                            

                            morceauxProg.totalScoreJoueurs(TScoreUsers, i, out totalPoints);
                            totauxPointsJoueur[i] = totalPoints;

                            if (totalPoints > 21)
                            {
                                //Console.WriteLine($"\nJoueur {i}, vous avez perdu !\n");
                                jeuFini[i] = true;
                            }

                        }
                        numPioche++;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Vos cartes :");
                        Console.ResetColor();
                        morceauxProg.concateneMatrice(TScoreUsers, out message);
                        Console.WriteLine($"{message}\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Les résultats à l'issue de ce tour :\n");

                        for (int i = 0; i < totauxPointsJoueur.Length; i++)
                        {
                            Console.WriteLine($"Joueur {i}, votre score est de {totauxPointsJoueur[i]}");
                        }
   

                    } 

                    maxPoints = 0;
                    numJoueurGagnant = -1;

                    for (int i = 0; i < totauxPointsJoueur.Length; i++)
                    {
                        if (totauxPointsJoueur[i] > maxPoints && totauxPointsJoueur[i] <= 21 && jeuFini[i] == false)
                        {
                            maxPoints = totauxPointsJoueur[i];
                            numJoueurGagnant = i;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;

                    if (maxPoints == 21)
                    {
                        Console.WriteLine($"Bravo, Joueur {numJoueurGagnant}, vous avez atteint {maxPoints} et gagné !");
                    }

                    else if (maxPoints <= 21)
                    {
                        Console.WriteLine($"Félicitations, Joueur {numJoueurGagnant}, vous avez gagné avec un score de {maxPoints} !");
                    }

                    else if (maxPoints > 21)
                    {
                        Console.WriteLine($"{numJoueurGagnant}, vous avez dépassé 21 ! Vous avez Perdu avec {maxPoints} !");
                    }

                }

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;

                // Demande de répetition 
                Console.WriteLine("Voulez-Vous recommencer une partie ? 'o' = oui, 'n' = non.");
                repeatProg = Console.ReadLine();

            } while (repeatProg == "o");
        }
    }
}
    

