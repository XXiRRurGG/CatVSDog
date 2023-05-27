using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatVsDog
{
    class UI
    {
        public static void PrintStats()
        {
            double[] valuesCat = Players.cat.GetAllValues();
            double[] valuesDog = Players.dog.GetAllValues();
            Console.WriteLine("\tStamina:{0}\t\t\t\t\t\t\t\t\t\t\tStamina:{1}",valuesCat[0],valuesDog[0]);
            Console.WriteLine("\tHP:{0}\t\t\t\t\t\t\t\t\t\t\t\tHP:{1}", valuesCat[1],valuesDog[1]);
            Console.WriteLine("\tDodge:{0}\t\t\t\t\t\t\t\t\t\t\t\tDodge:{1}", valuesCat[2],valuesDog[2]);
            Console.WriteLine("\tCards to skip:{0}\t\t\t\t\t\t\t\t\t\t\tCards to skip:{1}", valuesCat[3],valuesDog[3]);
            Console.WriteLine("\tDMG Multiplier:{0}\t\t\t\t\t\t\t\t\t\tDMG Multiplier:{1}", valuesCat[4],valuesDog[4]);
            Console.WriteLine("\tHeal Multiplier:{0}\t\t\t\t\t\t\t\t\t\tHeal Multiplier:{1}", valuesCat[5],valuesDog[5]);
        }
        public static void PrintPlayers()
        {
            Console.WriteLine("\t  ,_         _,           \t                                                                  ____");
            Console.WriteLine("\t  |\\\\.-\"\"\"-.//|      \t                                                                        ,-'-,  `---._");
            Console.WriteLine("\t  \\`         `/          \t                                                        _______(0} `, , ` , )");
            Console.WriteLine("\t  /    _   _   \\         \t                                                        V           ; ` , ` (                            ,'~~~~~~`,");
            Console.WriteLine("\t  |    o _ o   |          \t                                                        `.____,- '  (,  `  , )                          :`,-'\"\"`. \"; ");
            Console.WriteLine("\t  '.==   Y  ==.'          \t                                                          `-------._);  ,  ` `,                         \\;:      )``:");
            Console.WriteLine("\t    >._  ^  _.<           \t                                                                 )  ) ; ` ,,  :                          ``      : ';");
            Console.WriteLine("\t  /    `````   \\         \t                                                                 (  (`;:  ; ` ;:\\                                 ;;;,");
            Console.WriteLine("\t  )            (          \t                                                                 (:  )``;:;;)`'`'`--.    _____     ____       _,-';;`");
            Console.WriteLine("\t ,(            ),         \t                                                                 :`  )`;)`)`'   :    \"~~~~~~~~~~~`--',.;;;'");
            Console.WriteLine("\t / )   /   \\   ( \\      \t                                                                  `--;~~~~~      `  ,  \", \"\"\",  \"  \"   \"` \",, \\ ;``");
            Console.WriteLine("\t ) (   )   (   ) (        \t                                                                  ( ;         ,   `                ;      `; ;");
            Console.WriteLine("\t ( )   (   )   ( )        \t                                                                  (; ; ;      `                   ,`       ` :");
            Console.WriteLine("\t ( )   (   )   ( )        \t                                                                   (; /            ;   ;          ` ;     ; :");
            Console.WriteLine("\t )_(   )   (   )_(-.._    \t                                                                   ;(_; ;  :   ; ; `; ;` ; ; ,,,\"\"\";}     `;");
             Console.WriteLine("\t(  )_  (._.)  _(  )_, `\\\t                                                                     : `; `; `  :  `  `,,;,''''   );;`);     ;");
            Console.WriteLine("\t ``(   )   (   )`` .' .'  \t                                                                   ;' :;   ; : ``'`'           (;` :( ; ,  ;");
            Console.WriteLine("\t    ```     ```   ( (`    \t                                                                   |, `;; ,``                  `)`; `(; `  `;");
            Console.WriteLine("\t                  '-'     \t                                                                   ;  ;;  ``:                   `).:` \\;,   `.");
            Console.WriteLine("\t                          \t                                                                ,-'   ;`;;:;`                   ;;'`;;  `)   )");
            Console.WriteLine("\t                          \t                                                                 ~~~,-`;`;,\"                    ~~~~~  , -'   ;");
            Console.WriteLine("\t                          \t                                                                    \"\"\"\"\"\"                             `\"\"\"\"\"");
        }
        public static void PrintHand()
        {
            string[] hand = new string[20];
            for(int i=0;i<Players.cat.GetNumberOfCards();i++)
            {
                Players.cat.hand[i].SetCard();
            }
            for(int i=0;i<Players.dog.GetNumberOfCards();i++)
            {
                Players.dog.hand[i].SetDogsCard();
            }
            for(int i=0;i<10;i++)
            {
                for (int j = 0; j < Players.cat.GetNumberOfCards(); j++)
                {
                    hand[i] += Players.cat.hand[j].card[i];
                    hand[i] += "\t";
                }
            }
            for(int i=0;i<10;i++)
            {
                //hand[i + 10] += "\t\t\t\t\t\t\t\t\t";
                for (int j = 0; j < Players.dog.GetNumberOfCards(); j++)
                {
                    hand[i+10] += Players.dog.hand[j].card[i];
                    hand[i+10] += "\t";
                }
            }
            for (int i=0;i<20; i++)
            {
                Console.WriteLine(hand[i]);
            }
        }
        public static void PrintMenu()
        {
            Console.WriteLine("\t1 - Use a card");
            Console.WriteLine("\t2 - Finish a move");
            Console.WriteLine("\t3 - Surrender");
        }
        public static void PrintWinner(string name)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("                                                                   ⡾⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠛⡆            ");
            Console.WriteLine("                                                                   ⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇            ");
            Console.WriteLine("                                                                   ⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇            ");
            Console.WriteLine("                                                                   ⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀    {0} has won⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⡇      ",name);
            Console.WriteLine("                                                                   ⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇  ");
            Console.WriteLine("                                                                   ⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇         ");
            Console.WriteLine("                                                                 ⠀ ⠑⠒⡲⠀⠀⣀⣀⡤⠖⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠒⠁        ");
            Console.WriteLine("                                                                    ⣠⣾⠵⠖⠛⠉⠀⠀            ");
            Console.WriteLine("                                                     ⣠⣴⣾⣿⣷⣶⣦⣄⣀⣀⣀⣀⣀⡀⠚⠉⠀          ");
            Console.WriteLine("                                                   ⢠⣾⣿⣿⣿⣇⣀⣿⣿⣿⣿⣿⡿⠿⠛⠋          ");
            Console.WriteLine("                                                  ⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋               ");
            Console.WriteLine("                                                 ⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⠀                ");
            Console.WriteLine("                                                ⣼⣿⣿⣿⣿⠿⠿⠿⢿⣿⣿⡀⠀⠀               ");
            Console.WriteLine("                                               ⣴⣿⠟⠉⠉⠉⠀⣦⣄⡈⢉⣭⢳⠀                ");
            Console.WriteLine("                                              ⣼⣿⡇⠀⠀⠀⠀⠀⢿⠿⠏⠻⢿⡀⢧⡀⠀              ");
            Console.WriteLine("                                             ⣼⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣦⠀⠀⠀              ");
            Console.WriteLine("                                            ⣼⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣷⡀⠀⠀              ");
            Console.WriteLine("                                          ⢠⣾⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣷⡀⠀⠀              ");
            Console.WriteLine("                                         ⢰⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣧⠀⠀⠀              ");
            Console.WriteLine("                                        ⢠⣿⣿⣿⣿⣿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⣿⣿⣿⣇            ");
            Console.WriteLine("                                       ⢀⣿⣿⡿⠃⣾⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⢹⣿⣿⣿          ");
            Console.WriteLine("                                       ⣾⣿⠿⠁⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠇⠀⠹⣿⠏        ");
            Console.WriteLine("                                      ⣼⣿⠃⠀⠀⠀⢻⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸        ");
            Console.WriteLine("                                     ⢠⣿⠏⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡞⠀      ");
            Console.WriteLine("                                     ⡾⠏⠀⠀⠀⠀⠀⢠⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⠀      ");
            Console.WriteLine("                                          ⣀⣴⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠞⠀⠀      ");
            Console.WriteLine("                                       ⠀⣴⣾⣿⣿⣿⠟⠑⠒⣶⣦⣤⣤⣤⣤⠔⢲⣶⣿⣷⣄⣀⠀⠀      ");
            Console.WriteLine("                                               ⠈⠻⣿⣿⣿⣿⡿⠟⠙⠛⠛⠛⠛⠛⠃      ");
        }
        public static void DogWins()
        {
            Console.WriteLine("\t  ,_         _,           \t                                                                  ____");
            Console.WriteLine("\t  |\\\\.-\"\"\"-.//|      \t                                                                        ,-'-,  `---._");
            Console.WriteLine("\t  \\`         `/          \t                                                        _______(0} `, , ` , )");
            Console.WriteLine("\t  /    _   _   \\         \t                                                        V           ; ` , ` (                            ,'~~~~~~`,");
            Console.WriteLine("\t  |    x _ x   |          \t                                                        `.____,- '  (,  `  , )                          :`,-'\"\"`. \"; ");
            Console.WriteLine("\t  '.==   Y  ==.'          \t                                                          `-------._);  ,  ` `,                         \\;:      )``:");
            Console.WriteLine("\t    >._  ^  _.<           \t                                                                 )  ) ; ` ,,  :                          ``      : ';");
            Console.WriteLine("\t  /    `````   \\         \t                                                                 (  (`;:  ; ` ;:\\                                 ;;;,");
            Console.WriteLine("\t  )            (          \t                                                                 (:  )``;:;;)`'`'`--.    _____     ____       _,-';;`");
            Console.WriteLine("\t ,(            ),         \t                                                                 :`  )`;)`)`'   :    \"~~~~~~~~~~~`--',.;;;'");
            Console.WriteLine("\t / )   /   \\   ( \\      \t                                                                  `--;~~~~~      `  ,  \", \"\"\",  \"  \"   \"` \",, \\ ;``");
            Console.WriteLine("\t ) (   )   (   ) (        \t                                                                  ( ;         ,   `                ;      `; ;");
            Console.WriteLine("\t ( )   (   )   ( )        \t                                                                  (; ; ;      `                   ,`       ` :");
            Console.WriteLine("\t ( )   (   )   ( )        \t                                                                   (; /            ;   ;          ` ;     ; :");
            Console.WriteLine("\t )_(   )   (   )_(-.._    \t                                                                   ;(_; ;  :   ; ; `; ;` ; ; ,,,\"\"\";}     `;");
            Console.WriteLine("\t(  )_  (._.)  _(  )_, `\\\t                                                                     : `; `; `  :  `  `,,;,''''   );;`);     ;");
            Console.WriteLine("\t ``(   )   (   )`` .' .'  \t                                                                   ;' :;   ; : ``'`'           (;` :( ; ,  ;");
            Console.WriteLine("\t    ```     ```   ( (`    \t                                                                   |, `;; ,``                  `)`; `(; `  `;");
            Console.WriteLine("\t                  '-'     \t                                                                   ;  ;;  ``:                   `).:` \\;,   `.");
            Console.WriteLine("\t                          \t                                                                ,-'   ;`;;:;`                   ;;'`;;  `)   )");
            Console.WriteLine("\t                          \t                                                                 ~~~,-`;`;,\"                    ~~~~~  , -'   ;");
            Console.WriteLine("\t                          \t                                                                    \"\"\"\"\"\"                             `\"\"\"\"\"");
        }
        public static void CatWins()
        {
            Console.WriteLine("\t  ,_         _,           \t                                                                  ____");
            Console.WriteLine("\t  |\\\\.-\"\"\"-.//|      \t                                                                        ,-'-,  `---._");
            Console.WriteLine("\t  \\`         `/          \t                                                        _______(x} `, , ` , )");
            Console.WriteLine("\t  /    _   _   \\         \t                                                        V           ; ` , ` (                            ,'~~~~~~`,");
            Console.WriteLine("\t  |    o _ o   |          \t                                                        `.          (,  `  , )                          :`,-'\"\"`. \"; ");
            Console.WriteLine("\t  '.==   Y  ==.'          \t                                                          `-------._);  ,  ` `,                         \\;:      )``:");
            Console.WriteLine("\t    >._  ^  _.<           \t                                                                 )  ) ; ` ,,  :                          ``      : ';");
            Console.WriteLine("\t  /    `````   \\         \t                                                                 (  (`;:  ; ` ;:\\                                 ;;;,");
            Console.WriteLine("\t  )            (          \t                                                                 (:  )``;:;;)`'`'`--.    _____     ____       _,-';;`");
            Console.WriteLine("\t ,(            ),         \t                                                                 :`  )`;)`)`'   :    \"~~~~~~~~~~~`--',.;;;'");
            Console.WriteLine("\t / )   /   \\   ( \\      \t                                                                  `--;~~~~~      `  ,  \", \"\"\",  \"  \"   \"` \",, \\ ;``");
            Console.WriteLine("\t ) (   )   (   ) (        \t                                                                  ( ;         ,   `                ;      `; ;");
            Console.WriteLine("\t ( )   (   )   ( )        \t                                                                  (; ; ;      `                   ,`       ` :");
            Console.WriteLine("\t ( )   (   )   ( )        \t                                                                   (; /            ;   ;          ` ;     ; :");
            Console.WriteLine("\t )_(   )   (   )_(-.._    \t                                                                   ;(_; ;  :   ; ; `; ;` ; ; ,,,\"\"\";}     `;");
            Console.WriteLine("\t(  )_  (._.)  _(  )_, `\\\t                                                                     : `; `; `  :  `  `,,;,''''   );;`);     ;");
            Console.WriteLine("\t ``(   )   (   )`` .' .'  \t                                                                   ;' :;   ; : ``'`'           (;` :( ; ,  ;");
            Console.WriteLine("\t    ```     ```   ( (`    \t                                                                   |, `;; ,``                  `)`; `(; `  `;");
            Console.WriteLine("\t                  '-'     \t                                                                   ;  ;;  ``:                   `).:` \\;,   `.");
            Console.WriteLine("\t                          \t                                                                ,-'   ;`;;:;`                   ;;'`;;  `)   )");
            Console.WriteLine("\t                          \t                                                                 ~~~,-`;`;,\"                    ~~~~~  , -'   ;");
            Console.WriteLine("\t                          \t                                                                    \"\"\"\"\"\"                             `\"\"\"\"\"");
        }
    }
}
