using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    class Morse
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList(); //Creating Arraylist to store data from file
                                              
            string fpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            fpath = fpath.Replace("\\ConsoleApp1\\bin\\Debug\\net6.0\\ConsoleApp1.dll", ""); //getting the file path

            string[] data = File.ReadAllLines(fpath + "\\Morse.txt");  //Reading data from file
            
            foreach (string line in data) 
            {
            Code morseCode = new Code();
                morseCode.Character = line.Split(' ')[0];   //Getting data from file and adding to ArrayList
                morseCode.mCode = line.Split(" ")[1];
                

            list.Add(morseCode); // adding the morse code data to the array
            }

            while(true)
            {
                string userInput;
                string resultOutput = "";  //setting user input and also the resulting output

                Console.WriteLine("Enter phrase you would like to translate to morse code: ");
                userInput = Console.ReadLine();    //asking the user for input 

                if (userInput.Equals("0")) { break; }

                else
                {
                    char[] userChar = userInput.ToCharArray();

                    foreach(char c in userChar)
                    {
                        foreach(Code x in list)
                        {
                            if(x.Character.Equals(c.ToString()))
                            {
                                resultOutput += x.mCode;
                                break;
                            }
                            else if(c == ' ')
                            {
                                resultOutput += ' ';
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(resultOutput); //outputting results
            }
        }
       
    }

}
