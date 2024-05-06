namespace blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Bienvenue au BlakJack !");
            int[,] TScoreUsers; // Matrice des scores de joueurs
            int numPioche = 1; // rajouter une carte
            int totalPoints = 0;
            string nUser; //réponse de l'utilisateur
            string message;
            string repeatProg; // répétition du programme
            mesMorceaux morceauxProg = new mesMorceaux(); // morceaux de programme

            do
            {
                Console.WriteLine("Avant de vouloir commencer cette partie, voulez-vous les règles ?");
                Console.WriteLine(" - Taper 1 pour les voir.\n - Taper 2 pour les passer.");
                nUser = Console.ReadLine();


                if (nUser == "1")
                {
                    Console.WriteLine("Voici les règles :");
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

                    

                    while (totalPoints < 21)
                    {
                        numPioche = 1;

                        for (int i = 0; i <= TScoreUsers.GetLength(0) - 1; i++)
                        {

                            Console.WriteLine("Voulez-vous tirer une carte ? 't' pour tirer une carte, 'r' pour rester ");
                            nUser = Console.ReadLine();

                            if (nUser == "t")
                            {
                                morceauxProg.tireCarte(ref TScoreUsers, numPioche, i);
                                
                            }
                            
                        }
                        

                        Console.WriteLine("Vos cartes :");
                        morceauxProg.concateneMatrice(TScoreUsers, out message);
                        Console.WriteLine($"{message}\n");
                        Console.Write("Les résultats :\n");
                        morceauxProg.totalScoreJoueurs(TScoreUsers, numPioche, out totalPoints);
                        Console.WriteLine($"Votre score est de {totalPoints}");

                        
                    }
                    

                    if (totalPoints > 21)
                    {
                        Console.WriteLine("Vous avez perdu !");
                    }

                    if (totalPoints == 21)
                    {
                        Console.WriteLine("Bravo, vous avez gagné !");
                    }

                    numPioche += 1;


                }

                // Demande de répetition 
                Console.WriteLine("Voulez-Vous recommencer une partie ? 'o' = oui, 'n' = non.");
                repeatProg = Console.ReadLine();

            } while (repeatProg == "o");
        }
    }
}
    

