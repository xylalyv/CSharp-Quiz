using System;
class Program
{
    
    static string[][] questions = new string[][] {
        new string[]{"Azerbaycanin paytaxti haradir?", "Baki", "Gence", "Naxcivan", "Baki" },
        new string[]{"Azerbaycanin en böyük şeheri hansidir?", "Gence", "Naxcivan", "Baki", "Baki" },
        new string[]{"Azerbaycanin pul vahidi nedir?", "Manat", "Dollar", "Avro", "Manat" },
        new string[]{"Azərbaycanin en yuksek dag zirvesi hansidir?", "Bazarduzu", "Sahdag", "Goyezen", "Bazarduzu"},
        new string[]{"Azerbaycanda esas din hansidir?", "İslam", "Xristianliq", "İudaizm", "İslam" },
        new string[]{"Azerbaycanin resmi dili nedir?", "Azerbaycan dili", "Rus dili", "İngilis dili", "Azerbaycan dili" },
        new string[]{"Azerbaycanin qedim od mebedi ne adlanir?", "Atesgah", "Heyder Eliyev Merkezi", "Alov Qulleleri", "Atesgah" },
        new string[]{"Azerbaycanin en boyuk golu hansidir?", "Goygol golu", "Sevan golu", "Van golu", "Goygol golu" },
        new string[]{"Abseron rayonunda yerlesen milli parkimizin adi nedir?", "Goygol Milli Parki", "Seki Milli Parki", "Abseron Milli Parki", "Abseron Milli Parki" },
        new string[]{"Xemse hansi şairin eseridir?", "Nizami Gencevi", "Fuzuli", "Xursidbanu Natevan", "Nizami Gencevi" }
    };

    static void Main()
    {
        Random rand = new Random();
        int score = 0;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"
            /------\     |       |      -----        ------
            |      |     |       |        |               /
            |      |     |       |        |              /
            \------/     |       |        |             /
                \        |       |        |            /
                 \       |-------|      -----        ------
        ");
        Console.ResetColor();
        for (int i = 0; i < questions.Length; i++)
        {
            string correctAnswer = questions[i][4];
            string[] shuffledAnswers = Shuffle(questions[i].Skip(1).Take(3).ToArray(), rand) ;
            Console.WriteLine(questions[i][0]);
            Console.WriteLine($"a) {shuffledAnswers[0]}");
            Console.WriteLine($"b) {shuffledAnswers[1]}");
            Console.WriteLine($"c) {shuffledAnswers[2]}");
            Console.Write("Cavablar (a, b, c): ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "a" || answer == "b" || answer == "c")
            {

                if ((answer == "a" && correctAnswer == shuffledAnswers[0]) || (answer == "b" && correctAnswer == shuffledAnswers[1]) || (answer == "c" && correctAnswer == shuffledAnswers[2]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Duzdur!");
                    score += 10;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sehvdir! Duzgun cavab: " + correctAnswer);
                    score -= 10;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yanlis simvol daxil etmisiniz! a, b ve ya c -den birini secmeli idiniz");
                score -= 10;
               
            }

            if (i < questions.Length - 1)
            {
                Console.WriteLine("Davam etmek ucun Enter-e basin");
                Console.ReadLine();
                Console.Clear();
            }

            Console.ResetColor();
        }

        Console.WriteLine("Quiz bitdi. Umumu xaliniz: " + Math.Max(score, 0) + " xal");
    }

    static string[] Shuffle(string[] array, Random rand)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            int j = rand.Next(i + 1);
            string temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
        return array;
    }
}