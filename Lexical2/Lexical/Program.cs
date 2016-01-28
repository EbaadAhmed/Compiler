
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace compiler
{
    class start_with_alphabet
    {


        //DFA implementation of identifier R.E
        public int[,] arr = { { 1, 3, 2, 3 }, { 1, 1, 1, 3 }, { 1, 1, 2, 3 }, { 3, 3, 3, 3 } };
        string[] lines;
        string[] classpart;
        public int state = 0;
        public int final = 1;
       //  public int scope;
        /* public void insert()
         {
             //int[,]arr={{1,3,2},{1,1,1},{1,1,2},{3,3,3}};
             arr[0, 0] = 1;
             arr[0, 1] = 3;
             arr[0, 2] = 2;
             arr[1, 0] = 1;
             arr[1, 1] = 1;
             arr[1, 2] = 1;
             arr[2, 0] = 1;
             arr[2, 1] = 1;
             arr[2, 2] = 2;
             arr[3, 0] = 3;
             arr[3, 1] = 3;
             arr[3, 2] = 3;

         }*/

        public bool dfa_id(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                transition(state, ch);

            }

            if (state == final)
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        public void display(string input,int  scope)
        {
            lines = new string[] { "(" + "ID" + "," + input + "," + "line number" + ")" };
            System.IO.File.AppendAllLines("output.txt", lines);
            classpart = new string[] { "ID"};
            System.IO.File.AppendAllLines("classpart.txt", classpart);
            classpart = new string[] { input };
            System.IO.File.AppendAllLines("classpart.txt", classpart);
            lines = new string[] {input + "," + scope};
            System.IO.File.AppendAllLines("ids.txt", lines);
        }
        public void transition(int st, char ch)
        {

            if (ch >= 'A' && ch <= 'Z')
            {

                state = arr[st, 0];



            }
            else
            {
                if (ch >= 'a' && ch <= 'z')
                {


                    state = arr[st, 0];


                }
                if (ch >= '0' && ch <= '9')
                {

                    state = arr[st, 1];

                }
                if (ch == '_')
                {

                    state = arr[st, 2];

                }
                //extra
                if (ch == '.')
                {

                    state = arr[st, 3];

                }

            }

        }
        //keyword checking
        string[,] classification = new string[,]{
            
            {"EndProg","EndProg"},
            {"StartProg","StartProg"},
            {"return","return"},
            {"break","break"},
            {"Print","Print"},
            {"dec","dec"},
            {"=","="},
            {"EQUAL","EQUAL"},
            {"~","Relational"},
            {"GREATER",">"},
            {">=",">="},
            {"LESS","<"},
            {"<=","<="},
            {"!=","Relational"},
            {"fn","fn"},
            {"AND","AND"},
            {"OR","OR"},
            {"TO","TO"},
            {"Hall","Hall"},
            {"CHECK","CHECK"},
            {"FROM","Control End"},
            {"if","if"},
            {"otherwise","otherwise"},
            {"Till","Till"},
            {"start","start"},           
            {"ADD","ADD"},
            {"SUB","SUB"},
            {"MUL","MUL"},
            {"DIV","DIV"},
            {"mod","MDM"},
            {"INC","INC"},
            {"DEC","DEC"},
            {".","."},
            {"call", "call"},
            {"}","}"},
            {"(","("},
            {")",")"},
            {"}","Close Bracket"},
            {":",":"},
            {",",","},
            {";",";"},
            {"Public","Access Modifier"},
            {"obj","obj"},
            {"Check","Check"},
            {"Condition","Condition"},
            {"Default","Default"},
            {"DecSeries","DecSeries"},
            {"[","["},
            {"]","]"},
            {"void","void"},
            {"int","int"},
            {"true","true"},
            {"false","false"},
             {"STOP","STOP"},
            {"Round","Round"},
            {"THIS","THIS"},
            {"fncall","fncall"},
            {"NT","NOT"}
    };
        public void display1(string input)
        {
            for (int i = 0; i < 58; i++)
            {
                if (input == classification[i, 0])
                {
                    lines = new string[] { "(" + classification[i, 1] + "," + input + "," + "line number" + ")" };
                    System.IO.File.AppendAllLines("output.txt", lines);
                    classpart = new string[] { classification[i, 1] };
                    System.IO.File.AppendAllLines("classpart.txt", classpart);

                }
            }
        }
        public bool kw(string input)
        {
            for (int i = 0; i < 58; i++)
            {
                if (input == classification[i, 0])
                {

                    return true;
                }
            }
            return false;
        }
    }

    class start_with_number
    {
        string[] lines;
        string[] classpart;
        //float
        string floating = @"^[-]*[0-9]*\.[0-9]+[e]*$";

        public bool FLOAT_CHK(string check)
        {
            if (Regex.IsMatch(check, floating))
            {
                // Console.WriteLine(checkfloat + " is a correct floating point");


                return true;
            }


            return false;
        }

        //integar

        string integer = @"^[+|-]*[0-9]+$";

        public bool INT_CHK(string input)
        {
            if (Regex.IsMatch(input, integer))
            {

                //   Console.WriteLine(check + " is Valid");
                return true;
            }
            else
            {
                lines = new string[] { "(" + "Lexical Error" + "," + input + "," + "line number" + ")" };
                System.IO.File.AppendAllLines("output.txt", lines);
                classpart = new string[] { "Lexical Error" };
                System.IO.File.AppendAllLines("classpart.txt", classpart);
                return false;

            }
        }


    }

    class character
    {
        string[] lines;
        string[] classpart;
        //char
        string ch = @"\'[\w]\'";
        string ch1 = @"\'[\\][[a-z]\'";
        string ch2 = @"\'[\W]\'";
        public bool ch_check(string check)
        {
            if (Regex.IsMatch(check, ch))
            {



                return true;
            }
            else if (Regex.IsMatch(check, ch1))
            {



                return true;
            }
            else if (Regex.IsMatch(check, ch2))
            {



                return true;
            }
            else
            {
                lines = new string[] { "(" + "Lexical Error" + "," + check + "," + "line number" + ")" };
                System.IO.File.AppendAllLines("output.txt", lines);
                classpart = new string[] { "Lexical Error" };
                System.IO.File.AppendAllLines("classpart.txt", classpart);
                return false;

            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int looplimit = 58;
            int scope = 0;
            //string str = "";
            // create a writer and open the file
            //StreamReader myStream = new StreamReader("input.txt");

            //string str = myStream.ReadLine();

            //myStream.Close();
            //string[] strr = System.IO.File.ReadAllLines("input.txt");
            //foreach (string line in strr)
            //{
            //    Console.WriteLine("\t" + line);
            //}
            string str = System.IO.File.ReadAllText("input.txt");
            start_with_alphabet abc = new start_with_alphabet();
            //char str = Convert.ToChar(str);
            //int counter = 0;
            //string str;

            // Read the file and display it line by line.
            //System.IO.StreamReader file =
            //   new System.IO.StreamReader("input.txt");
            //while ((str = file.ReadLine()) != null)
            //{
            //    Console.WriteLine(str);
            //    counter++;
            //}

            //file.Close();


            string[,] classification1 = new string[,]{
            
            {"EndProg","EndProg"},
            {"StartProg","StartProg"},
            {"StartProg\r","StartProg"},
            {"return","return"},
            {"break","break"},            
            {"dec","dec"},
            {"=","="},
            {"EQUAL","EQUAL"},
            {"GREATER",">"},
            {">=",">="},
            {"LESS","<"},
            {"<=","<="},
            {"NT","NOT"},
            {"fn","fn"},
            {"AND","AND"},
            {"OR","OR"},
            {"to","Range in loop"},
            {"section","section"},
            {"CHECK","CHECK"},
            {"FROM","Control End"},
            {"if","if"},
            {"otherwise","otherwise"},
            {"Till","Till"},
            {"start","start"},           
            {"ADD","PM"},
            {"SUB","PM"},
            {"MUL","MDM"},
            {"DIV","MDM"},
            {"mod","MDM"},
            {"INC","INC"},
            {"DEC","DEC"},
            {".","."},
            {"{", "{"},
            {"}","}"},
            {"(","("},
            {")",")"},
            {":",":"},
            {",",","},
            {";",";"},
            {"Public","Access Modifier"},
            {"obj","obj"},
            {"Hall","Hall"},
            {"Condition","Condition"},
            {"Default","Default"},
            {"DecSeries","DecSeries"},
            {"[","["},
            {"]","]"},
            {"*","star"},
            {"/","Slash"},
            {"?","Lexical Error"},
            {"%","Lexical Error"},
            {"|","Lexical Error"},
            {"@","Lexical Error"},
            {"&","Lexical Error"},
            {"!","Lexical Error"},
            {"call","call"},
            {"STOP","STOP"},
            {"Round","Round"},
            {"THIS","THIS"},
            {"fncall","fncall"}
    };

            System.IO.File.WriteAllText("output.txt", string.Empty);
            System.IO.File.WriteAllText("classpart.txt", string.Empty);
            System.IO.File.WriteAllText("ids.txt", string.Empty);
            start_with_alphabet c1 = new start_with_alphabet();
            start_with_number c2 = new start_with_number();
            character c3 = new character();
            bool strline = str != null;
            int i = 0;
            
            
            Console.WriteLine(str);
            Console.WriteLine(str.Length);
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            int m = 0;
            string temp = "";
            string[] lines;
            string[] classpart;
            for (i = 0; i < str.Length; i++)
            {
                try
                {
                    if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z' || str[i] == '_')
                    {

                        do
                        {

                            temp += str[i];

                            i++;


                        } while (str[i] != ' ' && str[i] != ';' && str[i] != '+' && str[i] != '~' && str[i] != '.' && str[i] != '=' && str[i] != '/' && str[i] != ',' && str[i] != ':' && str[i] != '<' && str[i] != '>' && str[i] != '{' && str[i] != '}' && str[i] != '[' && str[i] != ']' && str[i] != '(' && str[i] != ')' && str[i] != ':' && str[i] != '!' && str[i] != '-' && str[i] != '*' && str[i] != '\\' && str[i] != '"' && str[i] != '\n');
                        Console.WriteLine(temp);
                        if (c1.dfa_id(temp) == true)
                        {

                            if (c1.kw(temp) == true)
                            {

                                c1.display1(temp);
                            }
                            else if (c1.dfa_id(temp) == true)
                            {
                                if (c1.kw(temp) == false)
                                {

                                    c1.display(temp,scope);
                                }
                            }

                        }

                    }
                }
                catch (Exception e)
                {

                }


                //for number
                try
                {
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        Console.WriteLine(i);
                        do
                        {

                            temp += str[i];
                            i++;


                        } while (str[i] != ' ' && str[i] != ';' && str[i] != '+' && str[i] != '~' && str[i] != '=' && str[i] != '/' && str[i] != ',' && str[i] != ':' && str[i] != '<' && str[i] != '>' && str[i] != '{' && str[i] != '}' && str[i] != '[' && str[i] != ']' && str[i] != '(' && str[i] != ')' && str[i] != ':' && str[i] != '!' && str[i] != '-' && str[i] != '*' && str[i] != '\\' && str[i] != '\n');
                        Console.WriteLine(temp);

                        if (c2.FLOAT_CHK(temp) == true)
                        {
                            lines = new string[] { "(" + "Float_const" + "," + temp + "," + "line number" + ")" };
                            System.IO.File.AppendAllLines("output.txt", lines);
                            classpart = new string[] { "const" };
                            System.IO.File.AppendAllLines("classpart.txt", classpart);
                        }


                        else if (c2.INT_CHK(temp) == true)
                        {
                            lines = new string[] { "(" + "integar_const" + "," + temp + "," + "line number" + ")" };
                            System.IO.File.AppendAllLines("output.txt", lines);
                            classpart = new string[] { "const" };
                            System.IO.File.AppendAllLines("classpart.txt", classpart);
                        }

                    }
                }
                catch (Exception e)
                {

                }





                //char

                try
                {
                    if (str[i] == '\'')
                    {
                        i++;
                        if (str[i] == '\'')
                        {
                            i++;
                            if (str[i] == '\'')
                            {
                                lines = new string[] { "(" + "Character Constant" + "," + "'" + "," + "line number" + ")" };

                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { "const" };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }

                        else if (str[i] != '\'')
                        {
                            i--;
                            do
                            {

                                temp += str[i];
                                i++;


                            } while (str[i] != '\'');
                            temp = temp + "'";
                            Console.WriteLine(temp);

                            if (c3.ch_check(temp) == true)
                            {
                                lines = new string[] { "(" + "Character_const" + "," + temp + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { "const" };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }



                    }
                }
                catch (Exception e)
                {

                }



                //string
                try
                {
                    if (str[i] == '"')
                    {
                        i++;
                        do
                        {

                            temp += str[i];
                            i++;

                        } while (str[i] != '"' && str[i] != '\n');
                        lines = new string[] { "(" + "String Constant" + "," + temp + "," + "line number" + ")" };
                        System.IO.File.AppendAllLines("output.txt", lines);
                        classpart = new string[] { "const" };
                        System.IO.File.AppendAllLines("classpart.txt", classpart);
                    }
                }
                catch (Exception e)
                {

                }



                //comment
                try
                {
                    if (str[i] == '#')
                    {
                        do
                        {
                            temp += str[i];
                            i++;

                        } while (str[i] != '#');
                    }
                }
                catch (Exception e)
                {
                    lines = new string[] { "(" + "Lexical Error" + "," + temp + "," + "line number" + ")" };
                    System.IO.File.AppendAllLines("output.txt", lines);
                    classpart = new string[] { "Lexical Error" };
                    System.IO.File.AppendAllLines("classpart.txt", classpart);
                }


                //operators
                try
                {
                    if (str[i] == '<' && str[i + 1] == '=')
                    {
                        string s1 = str[i].ToString();
                        // string s2 = str[i + 1].ToString();

                        string a = "<=";
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (a == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + a + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }

                        i = i + 1;
                        Console.WriteLine(i);



                    }
                    else if (str[i] == '=')
                    {
                        Console.WriteLine(i);
                        lines = new string[] { "(" + "Assignment Operator" + "," + str[i] + "," + "line number" + ")" };
                        System.IO.File.AppendAllLines("output.txt", lines);
                        classpart = new string[] { "=" };
                        System.IO.File.AppendAllLines("classpart.txt", classpart);
                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '>' && str[i + 1] == '=')
                    {
                        string s1 = str[i].ToString();
                        // string s2 = str[i + 1].ToString();

                        string a = ">=";
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (a == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + a + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }

                        i = i + 1;
                        Console.WriteLine(i);
                    }
                }
                catch (Exception e)
                {


                }

                try
                {
                    if (str[i] == '!' && str[i + 1] == '=')
                    {
                        string s1 = str[i].ToString();
                        // string s2 = str[i + 1].ToString();

                        string a = "!=";
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (a == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + a + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }

                        i = i + 1;
                        Console.WriteLine(i);

                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '~')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '.')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '$')
                    {
                        lines = new string[] { "(" + "Lexical Error" + "," + str[i] + "," + "line number" + ")" };
                        System.IO.File.AppendAllLines("output.txt", lines);
                        classpart = new string[] { "Lexical Error" };
                        System.IO.File.AppendAllLines("classpart.txt", classpart);
                    }
                }
                catch (Exception e)
                {

                }





                try
                {
                    if (str[i] == '!')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (str[i] == '%')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (str[i] == '@')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '}')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (str[i] == ';')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (str[i] == ':')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }






                try
                {
                    if (str[i] == ',')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (str[i] == '{')
                    {
                     scope ++;
                     //abc.scope = scope;
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1]  };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '(')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }

                try
                {
                    if (str[i] == ')')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }





                try
                {
                    if (str[i] == '[')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == ']')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }



                try
                {
                    if (str[i] == '/')
                    {
                        string s1 = str[i].ToString();
                        for (int j = 0; j < looplimit; j++)
                        {
                            if (s1 == classification1[j, 0])
                            {
                                lines = new string[] { "(" + classification1[j, 1] + "," + s1 + "," + "line number" + ")" };
                                System.IO.File.AppendAllLines("output.txt", lines);
                                classpart = new string[] { classification1[j, 1] };
                                System.IO.File.AppendAllLines("classpart.txt", classpart);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }



                //single line comment

                try
                {
                    if (str[i] == '*')
                    {

                        do
                        {

                            temp += str[i];
                            i++;


                        } while (str[i] != 10);






                    }
                }
                catch (Exception e)
                {

                }



                try
                {
                    if (str[i] == '+')
                    {
                        lines = new string[] { "(" + "Concatenate" + "," + "+" + "," + "line number" + ")" };
                        System.IO.File.AppendAllLines("output.txt", lines);
                        classpart = new string[] { "Concatenate" };
                        System.IO.File.AppendAllLines("classpart.txt", classpart);

                    }
                }
                catch (Exception e)
                {

                }


                try
                {
                    if (str[i] == '-')
                    {
                        lines = new string[] { "(" + "Lexical Error" + "," + "-" + "," + "line number" + ")" };
                        System.IO.File.AppendAllLines("output.txt", lines);
                        classpart = new string[] { "Lexical Error" };
                        System.IO.File.AppendAllLines("classpart.txt", classpart);
                    }
                }
                catch (Exception e)
                {

                }

                temp = "";

            }
            classpart = new string[] { "$" };
            System.IO.File.AppendAllLines("classpart.txt", classpart);
            Console.ReadLine();


        }


    }

}