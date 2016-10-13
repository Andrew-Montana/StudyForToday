using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCodeWithCSharp
{
    class Test
    {
        // Test class provide us to test our program.
        static void Main(string[] args)
        {
            Console.Title = "Сжатие Хаффмана"; // Setting the Console name.
            List<HuffmanNode> nodeList; // store nodes on List.
            
            ProcessMethods pMethods = new ProcessMethods();


            while (true)
            {
                Console.Clear();
                nodeList = pMethods.getListFromFile();
                Console.Clear();
                if (nodeList == null)
                {
                    setColor();
                    Console.WriteLine("Файл не может быть считан!");
                    Console.WriteLine("Нажмите любую клавишу или напишите \"E\" чтобы выйти.");
                    setColorDefault();
                    string choise = Console.ReadLine();
                    if (choise.ToLower() == "e")
                        break;
                    else
                        continue;
                }
                else
                {
                    Console.Clear();
                    setColor();
                    Console.WriteLine("#Символы   -   #Частота");
                    setColorDefault();
                    pMethods.PrintInformation(nodeList);
                    pMethods.getTreeFromList(nodeList);
                    pMethods.setCodeToTheTree("",nodeList[0]);
                    Console.WriteLine("\n\n");
                    setColor();
                    Console.WriteLine(" #   Дерева Хаффмана   # \n");
                    setColorDefault();
                    pMethods.PrintTree(0, nodeList[0]);
                    setColor();
                    Console.WriteLine("\n\n#Символы    -    #Codes\n");
                    setColorDefault();
                    pMethods.PrintfLeafAndCodes(nodeList[0]);
                    Console.WriteLine("\n\n");
                    ProcessMethods kolbyt = new ProcessMethods();
                  //  Console.WriteLine("Количество бит {0}", Global.kolByte );
                    //
                    string path = Environment.CurrentDirectory.ToString() + "\\text.txt";
                    StreamReader sr = new StreamReader(path);
                    string text = sr.ReadLine();
                    sr.Close();

                    Console.Write("\n \nУпорядоченная последовательность\n Слово ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(text + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    pMethods.OutputCodeResult(nodeList[0]);
               //     foreach (var items in Global.list)
                //   {
                 //      Console.WriteLine("Символ == {0}, Код == {1}", items.symbol, items.code);
                //  }

                        
                                for (int i = 0; i < text.Length; i++)
                                {
                                    foreach (var item in Global.list)
                                    {
                                        if (text[i].ToString() == item.symbol.ToString())
                                        {
                                            Console.WriteLine("Символ = {0} ||| Код = {1}", item.symbol.ToString(), item.code.ToString());
                                        }
                                    }
                                }
                    // только код
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("");
                                for (int i = 0; i < text.Length; i++)
                                {
                                    foreach (var item in Global.list)
                                    {
                                        if (text[i].ToString() == item.symbol.ToString())
                                        {
                                            Console.Write(item.code.ToString());
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n");
                    // ######### Энтропия
                    // N Тропия. Сумма всех log_2(Вероятность) * Вероятность 
                               //double check = -1*(Math.Log(0.42857, 2) * 0.42857 + Math.Log(0.28571, 2) * 0.28571 + Math.Log(0.14285, 2) * 0.14285 + Math.Log(0.14285, 2) * 0.14285);
                              // Console.WriteLine(check);
                                double nTropia = 0;
                                double probability = 0;
                                foreach (var element in Global.list)
                                {
                                    probability = Convert.ToDouble(element.frequency) / text.Length;
                                    Console.WriteLine("Символ = {0:0.00000}, Вероятность = {1:0.00000}", element.symbol, probability);
                                    nTropia += Math.Log(probability, 2) * probability;
                                }
                                nTropia = -1 * nTropia;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Энтропия = {0:0.00000}", nTropia);
                                Console.ForegroundColor = ConsoleColor.White;
                    // коэффициент сжатия
                                Console.WriteLine("");
                                Console.WriteLine("Коэффициент Сжатия:");
                                probability = 0;
                                double koeffizient = 0;
                                foreach (var k in Global.list)
                                {
                                    probability = Convert.ToDouble(k.frequency)/text.Length;
                                    koeffizient += probability * k.code.Length; // Числитель
                                    //Console.WriteLine("Длина {0} = {1}" ,k.symbol,k.code.Length);
                                }
                                koeffizient = koeffizient / Math.Log(text.Length, 2);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("{0:0.00000}",koeffizient);
                                Console.ForegroundColor = ConsoleColor.White;

                    setColor();

                    Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
                    Console.WriteLine("Напишите \"E\" чтобы выйти из программы.");
                    setColorDefault();
                    string choise = Console.ReadLine();
                    if (choise.ToLower() == "e")
                        break;
                    else
                        continue;

                }
            }
        }


        // These are methods that to change the color of the console secren. These are public because they must be accessible from ProcessMethods class. Instant method.
        public static void setColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void setColorDefault()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
