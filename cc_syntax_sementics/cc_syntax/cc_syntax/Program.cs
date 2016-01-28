using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cc_syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
           syn syntax = new syn();
           
            int counter = 0;
            int count = 0;
            string line;
            System.IO.File.WriteAllText("check.txt", string.Empty);
            System.IO.File.WriteAllText("int.txt", string.Empty);
            System.IO.File.WriteAllText("float.txt", string.Empty);
            System.IO.File.WriteAllText("string.txt", string.Empty);
            System.IO.File.WriteAllText("char.txt", string.Empty);
            System.IO.File.WriteAllText("icg.txt", string.Empty);

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("d:\\VS 2012/Lexical2/Lexical/bin/Debug/classpart.txt");
            while ((line = file.ReadLine()) != null)
            {
                
                counter++;
            }

            file.Close();
            syntax.arr(counter);
            System.IO.StreamReader file1 =
               new System.IO.StreamReader("d:\\VS 2012/Lexical2/Lexical/bin/Debug/classpart.txt");
            while ((line = file1.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                syntax.set(line);
                counter++;
            }

            file1.Close();


            

            syntax.get();



          //  syntax.get();
            
            bool check;
            check = syntax.validate();
            if (check == true)
           {
                Console.WriteLine("valid");
            }
            else
          {
               Console.WriteLine("not valid");
           }
            
           
            Console.ReadLine();
        }
    }
}
class syn
{
    public string codes;
    public int cls = 0;
    public string[] words;
    public string[] ids;
    int i = 0;
    int id_index = 0;
    int scope =0;
    string checker = "";
    int redecflag = 0;
    int[] scopes = new int[100];
    public int top;
    int[] beforesp = { 1, 2 };
    int s = 0;
    string MDM1 = "" , MDM2 = "", op = "", P_M1 = "", P_M2 = "", ROP1 = "", ROP2 = "", AND1 = "", AND2 = "", OR1 = "",OR2 = "";
    string type = "";
    string singleop = "";
    string[] icg = new string[5];
    int icg_count = 0;
    int number = 0;
    string icgid = "";
    string checkcase = "";
    public void arr(int count)
    {
        words = new string[count];
        ids = new string[count];
    }
    
    public void set(string t)
    {
        words[i] = t;
        i++;
        
    }
    
    public void get()
    {
        
        for (int p = 0; p < words.Length; p++)
        {
           
            if (words[p] == "")
            {
                words[p] = words[p + 1];
            }
            //Console.Write(words[p]);
        }
        //Console.Write("at 3"+words[3]);
       /* for (int p = 0; p < ids.Length; p++)
        {

            if (ids[p] == "")
            {
                ids[p] = ids[p + 1];
            }
            //Console.Write(words[p]);
        }*/
    }
    public bool main(ref int index)
    {
        if (words[index] == "StartProg")
        {
            //Console.WriteLine("start matched");
            index++;
            if (cl(ref index) == true)
            {
                if (clas(ref index) == true)
                {
                //Console.WriteLine("3432424asfdf");
               if (dtglobal(ref index) == true)
               {
                if (obj(ref index) == true)
                {
                    //Console.WriteLine("helloasfdf");
                            if (objcall2(ref index) == true)
                            {
                                Console.WriteLine(words[index+1]);
                                if (words[index+1] == "fncall")
                                {
                                    index++;
                                    if (fncal(ref index) == true)
                                    {
                                        if (words[index] == "EndProg")
                                        {
                                            //Console.WriteLine("program is ending");

                                            index++;

                                            return true;
                                        }
                                    }
                                    return false;
                                }

                                if (words[index] == "EndProg")
                                {
                                    //Console.WriteLine("program is ending");

                                    index++;

                                    return true;
                                }
                                return false;
                            }
                            if (words[index] == "fncall")
                            {
                                if (fncal(ref index) == true)
                                {
                                    if (words[index] == "EndProg")
                                    {
                                        //Console.WriteLine("program is ending");

                                        index++;

                                        return true;
                                    }
                                }
                                return false;
                            }
                        
                    
                    if (words[index] == "EndProg")
                    {
                        //Console.WriteLine("program is ending");

                        index++;

                        return true;
                    }

                }
            }
               else if (obj(ref index) == true)
               {
                   //Console.WriteLine("helloasfdf");
                   if (objcall2(ref index) == true)
                   {
                       Console.WriteLine(words[index + 1]);
                       if (words[index + 1] == "fncall")
                       {
                           index++;
                           if (fncal(ref index) == true)
                           {
                               if (words[index] == "EndProg")
                               {
                                   //Console.WriteLine("program is ending");

                                   index++;

                                   return true;
                               }
                           }
                           return false;
                       }

                       if (words[index] == "EndProg")
                       {
                           //Console.WriteLine("program is ending");

                           index++;

                           return true;
                       }
                       return false;
                   }
                   if (words[index] == "fncall")
                   {
                       if (fncal(ref index) == true)
                       {
                           if (words[index] == "EndProg")
                           {
                               //Console.WriteLine("program is ending");

                               index++;

                               return true;
                           }
                       }
                       return false;
                   }


                   if (words[index] == "EndProg")
                   {
                       //Console.WriteLine("program is ending");

                       index++;

                       return true;
                   }

               }
                else if (words[index] == "EndProg")
                {
                    //Console.WriteLine("program is ending");

                    index++;

                    return true;
                }
            }
            }
            else
            {
                if (words[index - 1] == "Hall")
                {
                    return false;
                }
                else if (body(ref index) == true)
                {
                    Console.WriteLine("BODY PARSED SUCCESSFULLY");
                    Console.WriteLine(words[index]);
                    if (words[index] == "EndProg")
                    {
                        Console.WriteLine("NO SYNTAX ERROR");

                        index++;
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
    public bool clas(ref int index)
    {
        if (cl(ref index) == true)
        {
            if (clas(ref index) == true)
            {
                return true;
            }
        }
        return true;
    }
    public bool body(ref int index)
    {
         

        if (words[index] == "{")
        {
            scope++;
            scopes[id_index] = scope;
            Console.WriteLine(scopes[id_index]);
            id_index++;
            top = id_index - 1;
            index++;
            if (MST(ref index) == true)
            {
                if (words[index] == "}")
                {
                    
                    id_index--;
                    top = id_index - 1;
                    index++;
                    return true;
                }
            }
        }

        else
        {
            
            if (MST(ref index) == true)
            {
                scopes[id_index] = 0;
                id_index++;
                top = id_index - 1;
            return true;
            }
            id_index--;
            top = id_index - 1;
            return false;
        }
       
        return false;
        
    }
    public bool MST(ref int index)
    {
        if (SST(ref index) == true)
        {
            if (MST(ref index) == true)
            {
                
                return true;
            }
        }
        
         return true; 
    }
    public bool SST(ref int index)
    {
      //  Console.WriteLine("index value " +index);
       // Console.WriteLine("sst start "+ words[index]);
        if (func(ref index) == true || dt(ref index) == true || assign(ref index) == true || if_otherwise(ref index) == true || till(ref index) == true || arry(ref index) == true || check(ref index) == true || rnd(ref index) == true || fncal(ref index) == true /*|| exp(ref index) == true*/ || ret(ref index))
        {
           // Console.WriteLine("sst true" + words[index ]);
            return true;
        }
        //Console.WriteLine("sst false" + words[index-1]);
        return false;
    }
    public bool func(ref int index)
    {
        if (words[index] == "fn")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
                if (dlookup(words[index] + "_fn", scopes[top]) == true && dlookup(words[index] + "_fn", 1) == true)
                {
                    Console.WriteLine("Redeclared " + words[index]);
                }
                else
                {
                    insert(words[index] + "_fn", scopes[top]);
                }
                index++;

                    if (words[index] == "(")
                    {
                        index++;
                        if (para(ref index) == true)
                        {
                            if (words[index] == ")")
                            {
                                index++;
                                if (body(ref index) == true)
                                {
                                    Console.WriteLine("FUNCTION PARSED SUCCESSFULLY");
                                    return true;
                                }
                            }
                        }
                    }
            }
        }
        
        return false;
    }
    public bool exp(ref int index)
    {
        icg_count = 0;
        if (A(ref index, ref OR1) == true)
        {
            if (exp2(ref index, ref OR1) == true)
            {
                Console.WriteLine("EXPRESSION PARSED SUCCESSFULLY");
                
                return true;
            }
        }
        
        return false;
    }
    public bool exp2(ref int index, ref string cons8)
    {
        if (words[index] == "OR")
        {
            icg[1] = words[index];
            index++;
            if (A(ref index, ref OR2) == true)
            {
                op = compatibility(cons8, OR2);
                if (exp2(ref index, ref op) == true)
                {
                    
                    return true;
                }
            }
        }
        
        return true;
    }
    public bool A(ref int index, ref string cons7)
    {
        if (B(ref index, ref AND1) == true)
        {
            cons7 = AND1;
            if (A2(ref index, ref AND1) == true)
            {
                
                return true;
            }
        }
       
        return false;
    }
    public bool A2(ref int index, ref string cons6)
    {
        if (words[index] == "AND")
        {
            icg[1] = words[index];
            index++;
            if (B(ref index, ref AND2) == true)
            {
                op = compatibility(cons6, AND2);
                if (A2(ref index , ref op) == true)
                {
                    
                    return true;
                }
            }
        }
        
        return true;
    }
    public bool B(ref int index,ref string cons5)
    {
        if (C(ref index, ref ROP1) == true)
        {
            cons5 = ROP1;
            if (B2(ref index, ref ROP1) == true)
            {
                
                return true;
            }
        }
        
        return false;
    }
    public bool B2(ref int index, ref string cons4)
    {
        if (words[index] == ">" || words[index] == "<" || words[index] == "EQUAL" || words[index] == ">=" || words[index] == "<=")
        {
           // Console.WriteLine("icg_count " +icg_count);
            icg[1] = words[index];
            index++;
            if (C(ref index, ref ROP2) == true)
            {
                op = compatibility(cons4, ROP2);
                if (B2(ref index, ref op) == true)
                {
                    
                    return true;
                }
            }
        }
        
        return true;
    }
    public bool C(ref int index,ref string cons3)
    {
        if (D(ref index, ref P_M1) == true)
        {
            cons3 = P_M1;
            if (C2(ref index, ref P_M1) == true)
            {
                
                return true;
            }
        }
       
        return false;
    }
    public bool C2(ref int index, ref string cons2)
    {
        if (words[index] == "ADD" || words[index] == "SUB")
        {
            icg[1] = words[index];
            index++;
            if (D(ref index, ref P_M2) == true)
            {
                op = compatibility(cons2, P_M2);
                //Console.WriteLine("P_M2" + P_M2);
                if (C2(ref index, ref op) == true)
                {
                    
                    return true;
                }
            }
        }
       
        return true;
    }
    public bool D(ref int index, ref string cons1)
    {
        if (E(ref index,ref MDM1) == true)
        {
            cons1 = MDM1;
            
            if (D2(ref index, ref MDM1) == true)
            {
               
                return true;
            }
        }
        
        return false;
    }
    public bool D2(ref int index, ref string cons)
    {
        if (words[index] == "MUL" || words[index] == "DIV")
        {
            icg[1] = words[index];
            
            index++;
            
            if (E(ref index, ref MDM2) == true)
            {
                op = compatibility(cons,MDM2);
                if (D2(ref index, ref op) == true)
                {
                    
                    return true;
                }
            }
        }
       
        return true;
    }
    public bool E(ref int index,ref string abc)
    {
       if (words[index] == "(")
        {
            index++;
            if (exp(ref index) == true)
            {
                if (words[index] == ")")
                {
                    
                    return true;
                }
            }
            
            return false;
        }
       
       else if (cons(ref index) == true)
       {
           abc = words[index];
           icg[icg_count] = words[index];
           if (icg_count == 2)
           {
               insert_icg(icg[0], icg[1], icg[2]);
               icg_count = 0;
               icg[icg_count] = "t" + number;
               icg_count = icg_count + 2;
               number++;
           }
           else
           {
               // Console.WriteLine(icg_count);
               icg_count = icg_count + 2;
           }
           index++;
           if (words[index] == ";")
           {
               index++;
               return true;
           }
           return true;
       }
           
       else
       {
           if (words[index] == "ID")
           {
               index++;
               if (dlookup(words[index],1) == false && dlookup(words[index],2) == false && dlookup(words[index], scopes[top]) == false)
               {
                   Console.WriteLine("Undeclared " + words[index]);
               }
               if (lookup_int(words[index]) == true)
               {
                   abc = "const_int";
                   singleop = "const_int";
               }
               else if (lookup_float(words[index]) == true)
               {
                   abc = "const_float";
                   singleop = "";
               }
               else if (lookup_string(words[index]) == true)
               {
                   abc = "const_string";
                   singleop = "";
               }
               else if (lookup_char(words[index]) == true)
               {
                   abc = "const_char";
                   singleop = "";
               }
               else
               {
                   abc = "";
                   singleop = "";
               }
               Console.WriteLine("1st 2nd " + icg_count);
               icg[icg_count] = words[index];
               if (icg_count == 2)
               {
                   insert_icg(icg[0] , icg[1], icg[2] );
                   icg_count = 0;
                   icg[icg_count] = "t" + number;
                   icg_count = icg_count +2;
                   number++;
               }
               else
               {
                  // Console.WriteLine(icg_count);
                   icg_count = icg_count+2;
               }
               
               index++;
               if (E2(ref index) == true)
               {
                   return true;
               }

           }
           else if (words[index] == ",")
           {
               index++;
               return true;
           }
       }
       return true;
    }
    public bool E2(ref int index)
    {
        if (words[index] == "(")
        {
            index++;
            if (para(ref index) == true)
            {
                if (words[index] == ")")
                {
                    index++;
                    return true;
                }
            }
        }
        else if (words[index] == "INC" || words[index] == "DEC")
        {
            
            if (singleop == "const_int")
            {
                
            }
            else {
                Console.WriteLine("Type Mismatch " + singleop + " and " + words[index]);
            }
            index++;
            return true;

        }
       
        else if (words[index] == "NOT")
        {
            index++;
            if (exp(ref index) == true)
            {
                return true;
            }
            
        }
        else if (words[index] == ";")
        {
            index++;
            if (exp(ref index) == true)
            {
                return true;
            }

        }
        else if (words[index] == "[")
        {
            index++;
            if (cons(ref index) == true)
            {
                index++;
                if (words[index] == "]")
                {
                    index++;
                    return true;
                }
            }

        }
        return true;


    }
    public bool para(ref int index)
    {
        if (words[index] == "dec")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
                if (dlookup(words[index], scopes[top]) == true)
                {
                    Console.WriteLine("Redeclared " + words[index]);
                }
                else
                {
                    insert(words[index], scopes[top]);
                }
                index++;
                if (words[index] == ",")
                {
                    index++;
                    if (para(ref index) == true)
                    {
                        Console.WriteLine("PARAGRAPH PARSED SUCCESSFULLY");
                        return true;
                    }
                }
                
                return true;
            }
        }
        
        return false;
    
    }
    public bool dt(ref int index)
    {
        //Console.WriteLine("dt index " + index);
        //Console.WriteLine("dt index " + words[index]);
        if (words[index] == "dec")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
              //  Console.WriteLine("scope " + scopes[top] + " and " + top);
                if (dlookup(words[index], scopes[top]) == true && dlookup(words[index], 1) == true && dlookup(words[index], 2) == true)
                {
                    Console.WriteLine("Redeclared " + words[index]);
                }
                else
                {
                    insert(words[index], scopes[top]);
                }
                type = words[index];
                index++;
                if (words[index] == "=")
                {
                    index++;
                   // Console.WriteLine("dt const return " + words[index]);
                    if (cons(ref index) == true)
                    {
                        string[] st1;

                        st1 = new string[] { "t" + number+" = "+words[index]  };
                        System.IO.File.AppendAllLines("icg.txt", st1);
                        
                        st1 = new string[] { type + " = " + " t" + number };
                        System.IO.File.AppendAllLines("icg.txt", st1);
                        number++;
                        if (words[index] == "const_int")
                        {
                            insert_int(type);
                        }
                        else if (words[index] == "const_float")
                        {
                            insert_float(type);
                        }
                        else if (words[index] == "const_string")
                        {
                            insert_string(type);
                        }
                        else if (words[index] == "const_char")
                        {
                            insert_char(type);
                        }
                        index++;
                        if (words[index] == ";")
                        {
                            Console.WriteLine("DATATYPE PARSED SUCCESSFULLY");
                            index++;
                            return true;
                        }
                        return true;
                    }
                }
                else if (words[index] == ";")
                {
                    Console.WriteLine("DATATYPE PARSED SUCCESSFULLY");
                    index++;
                    return true;
                }
            }
        }
       // Console.WriteLine("dt index return " + index);
        //Console.WriteLine("dt index return " + words[index]);
        return false;
    }
    public bool assign(ref int index)
    {
       // Console.WriteLine("assign " + index);
       // Console.WriteLine("assign " + words[index]);
        if (words[index] == "ID")
        {
            //Console.WriteLine("assign before " + words[index]);
            index++;
            //Console.WriteLine("assign before 2 " + words[index]);
            icgid = words[index];
            if (dlookup(words[index], 1) == false && dlookup(words[index], 2) == false && dlookup(words[index], scopes[top]) == false && dlookup(words[index], 0) == false)
           {
               
                    Console.WriteLine("Undeclared " + words[index]);
            
            }
            if (lookup_int(words[index]) == true)
            {
                
                singleop = "const_int";
            }
            else if (lookup_float(words[index]) == true)
            {
                
                singleop = "const_float";
            }
            else if (lookup_string(words[index]) == true)
            {
                
                singleop = "const_string";
            }
            else if (lookup_char(words[index]) == true)
            {
                
                singleop = "const_char";
            }
            else
            {
                
                singleop = "";
            }
            index++;
            //Console.WriteLine(" assin after "+ words[index]);
            if (init(ref index) == true)
            {
                insert_icg1(icgid);
                
                    Console.WriteLine("ASSIGNMENT SUCCESSFULLY PARSED");
                    return true;
                
            }
            else if (words[index] == ".")
            {
                index--;
                index--;
                if (objcall(ref index) == true)
                {
                    return true;
                }
            }
            else if (words[index] == "[")
            {
                index--;
                index--;
                if (arraycall(ref index) == true)
                {
                    return true;
                }
            }
            else if (words[index] == "INC" || words[index] == "DEC")
            {
                if (singleop == "const_int")
                {

                }
                else
                {
                    Console.WriteLine("Type Mismatch " + singleop + " and " + words[index]);
                }
                index++;
                if (words[index] == ";")
                {
                    index++;
                    return true;
                }
                return true;
            }
        }
        
       // Console.WriteLine("assign index return " + index);
        //Console.WriteLine("assign index return " + words[index]);
        return false;
    }
    public bool init(ref int index)
    {
        if (words[index] == "=")
        {
            index++;
            if (exp(ref index) == true)
            {
                if (fncal(ref index) == true)
                {
                    return true;
                }
                if (words[index] == ".")
                {
                    index--;
                    index--;
                    if (objcall(ref index) == true)
                    {
                        
                        return true;
                    }
                }
                
                return true;
            }
            if (fncal(ref index) == true)
            { return true; }
            if (objcall(ref index) == true)
            { return true; }
        }
        
        return false;

    }
    public bool init2(ref int index)
    {
        if (words[index] == "ID")
        {
            index++;
            if (dlookup(words[index], scopes[top]) == false)
            {
                Console.WriteLine("Undeclared " + words[index]);
            }
            
            index++;
            if (init(ref index) == true)
            {

                return true;
            }
        }
        return true;
    }
    public bool list(ref int index)
    {
        if (words[index] == ";")
        {
            
            index++;
            return true;
        }
        else
        {
            if (words[index] == ",")
            {
                index++;
                if (words[index] == "ID")
                {
                    index++;
                    if (dlookup(words[index], scopes[top]) == false)
                    {
                        Console.WriteLine("Undeclared " + words[index]);
                    }
                    
                    index++;
                    if (init(ref index) == true)
                    {
                        if (list(ref index) == true)
                        {
                            
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
    }
    public bool if_otherwise(ref int index)
    {
        if (words[index] == "if")
        {
            index++;
            if (words[index] == "(")
            {
                index++;
                
                if (exp(ref index) == true)
                {
                    string[] st;
                    int num1 = number - 1;
                    st = new string[] { "if (t" + num1 +" == false) jump L1" };
                    System.IO.File.AppendAllLines("icg.txt", st);
                    if (words[index] == ".")
                    {
                        index--;
                        if (objcall(ref index) == true)
                        {
                            if (words[index] == ")")
                            {
                                index++;
                                if (body(ref index) == true)
                                {
                                    string[] st1;
                                    string[] st3;
                                    st3 = new string[] { "jump L0 " };
                                    System.IO.File.AppendAllLines("icg.txt", st3);

                                    st1 = new string[] { "L1: " };
                                    System.IO.File.AppendAllLines("icg.txt", st1);
                                    if (o_otherwise(ref index) == true)
                                    {
                                        Console.WriteLine("IF OTHERWISE SCUCESSFULLY PARSED");
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else if (words[index] == "[")
                    {
                        index--;
                        if (arraycall(ref index) == true)
                        {
                            if (words[index] == ")")
                            {
                                index++;
                                if (body(ref index) == true)
                                {
                                    string[] st1;
                                    string[] st3;
                                    st3 = new string[] { "jump L0 " };
                                    System.IO.File.AppendAllLines("icg.txt", st3);
                                    st1 = new string[] { "L1: " };
                                    System.IO.File.AppendAllLines("icg.txt", st1);
                                    if (o_otherwise(ref index) == true)
                                    {
                                        Console.WriteLine("IF OTHERWISE SCUCESSFULLY PARSED");
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    if (words[index] == ")")
                    {
                        index++;
                        if (body(ref index) == true)
                        {
                            string[] st1;
                            string[] st3;
                            st3 = new string[] { "jump L0 " };
                            System.IO.File.AppendAllLines("icg.txt", st3);
                            st1 = new string[] { "L1: " };
                            System.IO.File.AppendAllLines("icg.txt", st1);
                            if (o_otherwise(ref index) == true)
                            {
                                Console.WriteLine("IF OTHERWISE SCUCESSFULLY PARSED");
                                return true;
                            }
                        }
                    }
                }
            }
        }
       
        return false;
    }
    public bool o_otherwise(ref int index)
    {
        if (words[index] == "otherwise")
        {
            index++;
            if (body(ref index) == true)
            {
                
                string[] st3;
                st3 = new string[] { "L0: " };
                System.IO.File.AppendAllLines("icg.txt", st3);
                return true;
            }
        }
        string[] st2;
        st2 = new string[] { "L0: " };
        System.IO.File.AppendAllLines("icg.txt", st2);
        return true;
    }
    public bool till(ref int index)
    {
        if (words[index] == "start")
        {
            index++;
            string[] st1;
            st1 = new string[] { "L2: " };
            System.IO.File.AppendAllLines("icg.txt", st1);
            if (body(ref index) == true)
            {
                if (words[index] == "Till")
                {
                    index++;
                    if (words[index] == "(")
                    {
                        index++;
                        if (tillpara(ref index) == true)
                        {
                            string[] st2;
                            int num1 = number - 1;
                            st2 = new string[] { "if ( t"+ num1 +" == true) jump L2" };
                            System.IO.File.AppendAllLines("icg.txt", st2);
                            return true;
                        }
                        /*if (exp(ref index) == true)
                        {
                            if (words[index] == ".")
                            {
                                index--;
                                if (objcall(ref index) == true)
                                {
                                    if (words[index] == ")")
                                    {
                                        Console.WriteLine("TILL LOOP PARSED SUCCESSFULLY");
                                        index++;
                                        return true;
                                    }
                                }
                            }
                           else if (words[index] == "[")
                            {
                                index--;
                                if (arraycall(ref index) == true)
                                {
                                    if (words[index] == ")")
                                    {
                                        Console.WriteLine("TILL LOOP PARSED SUCCESSFULLY");
                                        index++;
                                        return true;
                                    }
                                }
                            }
                            if (words[index] == ")")
                            {
                                Console.WriteLine("TILL LOOP PARSED SUCCESSFULLY");
                                index++;
                                return true;
                            }
                        }
                    }*/
                    }
                }
            }

            
        }
        return false;
    }
    public bool tillpara(ref int index)
    {
        if (exp(ref index) == true)
        {

            if (words[index] == ".")
            {
                index--;
                if (objcall(ref index) == true || fncal(ref index) == true)
                {
                    if (tillpara(ref index) == true)
                    {
                        if (words[index] == ")")
                        {
                            Console.WriteLine("TILL LOOP PARSED SUCCESSFULLY");
                            index++;
                            return true;
                        }
                    }
                }
            }
            else if (words[index] == "[")
            {
                index--;
                if (arraycall(ref index) == true)
                {
                    if (tillpara(ref index) == true)
                    {
                        if (words[index] == ")")
                        {
                            Console.WriteLine("TILL LOOP PARSED SUCCESSFULLY");
                            index++;
                            return true;
                        }
                    }
                }
            }
            if (words[index] == ")")
            {
                Console.WriteLine("TILL LOOP PARSED SUCCESSFULLY");
                index++;
                return true;
            }

        }
        return true;
    }
    public bool cl(ref int index)
    {
        if (words[index] == "Hall")
        {
            index++;
            if (words[index] == "ID")
            {
                //Console.WriteLine(words[index]);
                index++;
                //Console.WriteLine(words[index]);
                if (dlookup(words[index]+"_Hall", scopes[top]) == true && dlookup(words[index] +"_Hall", 0) == true)
                {
                    Console.WriteLine("Redeclared " + words[index]);
                }
                else
                {
                    insert(words[index]+"_Hall", scopes[top]);
                }
                index++;
                if (words[index] == "{")
                {
                    scope++;
                    scopes[id_index] = scope;
                    Console.WriteLine(scopes[id_index]);
                    id_index++;
                    top = id_index - 1;
                    index++;
                    if (clagain(ref index) == true)
                    {
                        

                            if (words[index] == "}")
                            {
                                Console.WriteLine("CLASS PARSED SUCCESSFULLY");
                                
                                id_index--;
                                top = id_index - 1;
                                index++;
                                return true;
                            }
                        
                        
                    }
                     
                }
            }
        }
       
        return false;
    }
    public bool clagain(ref int index)
    {
        if (dt(ref index) == true || arry(ref index) == true)
        {
            if (func(ref index) == true)
            {
                if (clagain(ref index) == true)
                {
                    return true;
                }
            }
            if (clagain(ref index) == true)
            {
                return true;
            }
        }
        else if (func(ref index) == true)
        {
            if (clagain(ref index) == true)
            {
                return true;
            }
        }
        return true;
    }
    public bool statement(ref int index)
    {
        if (dt(ref index) == true)
        {
            return true;
        }
        else if (MST(ref index) == true)
        {

            return true;
        }
        return false;
    }
    public bool arry(ref int index)
    {
        if (words[index] == "DecSeries")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
                if (dlookup(words[index], scopes[top]) == true && dlookup(words[index], 1) == true && dlookup(words[index], 2) == true)
                {
                    Console.WriteLine("Redeclared " + words[index]);
                }
                else
                {
                    insert(words[index], scopes[top]);
                }
                index++;
                if (words[index] == "=")
                {
                    index++;
                    if (words[index] == "{")
                    {
                        index++;
                        if (cons(ref index) == true)
                        {
                            index++;
                            if (repeat(ref index) == true)
                            {
                                if (words[index] == "}")
                                {
                                    Console.WriteLine("ARRAY PARSED SUCCESSFULLY");
                                    index++;
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        return false;
    }
    public bool repeat(ref int index)
    {
        if (words[index] == ",")
        {
            index++;
            if (cons(ref index) == true)
            {
                
                index++;
                if (repeat(ref index) == true)
                {
                    return true;
                }
                return true;
            }
        }
        
        return true;
    }
    public bool check(ref int index)
    {
        if (words[index] == "CHECK")
        {
            index++;
            if (words[index] == "(")
            {
                index++;
                if (words[index] == "ID")
                {
                    index++;
                    if (dlookup(words[index],1) == false && dlookup(words[index],2) == false && dlookup(words[index], scopes[top]) == false)
                    {
                        Console.WriteLine("Undeclared " + words[index]);
                    }
                    checkcase = words[index];
                    index++;
                    if (words[index] == ")")
                    {
                        index++;
                        if (stmt(ref index) == true)
                        {
                            Console.WriteLine("CHECK PARSED SUCCESSFULLY");
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public bool stmt(ref int index)
    {
        if (words[index] == "THIS")
        {
            index++;
            if (words[index] == "(")
            {
                index++;
                if (cons(ref index) == true)
                {
                    string[] st2;
                    int num1 = number - 1;
                    st2 = new string[] { "t" + num1 + " = " + words[index]  };
                    System.IO.File.AppendAllLines("icg.txt", st2);
                    
                     num1 = number ;
                     int num2 = number - 1;
                    st2 = new string[] { "t" + num1 + " = " + checkcase + " == " + "t" +num2  };
                    System.IO.File.AppendAllLines("icg.txt", st2);

                    st2 = new string[] { "if (t"+num1+" == true) jump L"};
                    System.IO.File.AppendAllLines("icg.txt", st2);
                    index++;
                    if (words[index] == ")")
                    {
                        index++;
                        st2 = new string[] { "if (t" + num1 + " == true) jump L" };
                        System.IO.File.AppendAllLines("icg.txt", st2);
                        if (body(ref index) == true)
                        {
                            if (words[index] == "STOP")
                            {
                                index++;
                                if (ch(ref index) == true)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
    public bool ch(ref int index)
    {
        if (words[index] == "THIS")
        {
            index++;
            if (words[index] == "(")
            {
                index++;
                if (cons(ref index) == true)
                {
                    
                    string[] st2;
                    int num1 = number - 1;
                    st2 = new string[] { "t" + num1 + " = " + words[index]  };
                    System.IO.File.AppendAllLines("icg.txt", st2);
                    
                     num1 = number ;
                     int num2 = number - 1;
                    st2 = new string[] { "t" + num1 + " = " + checkcase + " == " + "t" +num2  };
                    System.IO.File.AppendAllLines("icg.txt", st2);

                    st2 = new string[] { "if (t" + num1 + " == true) jump L" };
                    System.IO.File.AppendAllLines("icg.txt", st2);
                    index++;
                    if (words[index] == ")")
                    {
                        index++;
                        if (body(ref index) == true)
                        {
                            st2 = new string[] { "L " };
                            System.IO.File.AppendAllLines("icg.txt", st2);
                            if (words[index] == "STOP")
                            {
                                index++;
                                if (ch(ref index) == true)
                                {
                                    return true;
                                }
                                return true;
                            }

                            return true;
                        }
                    }
                }
            }
        }
        else if (words[index] == "Default")
        {
            index++;
            if (body(ref index) == true)
            {
                return true;
            }
        }
        return false;
    }
    public bool rnd(ref int index)
    {
        if (words[index] == "Round")
        {
            index++;
            if (words[index] == "(")
            {
                index++;
                if (cons(ref index) == true)
                {
                    index++;
                    if (words[index] == "TO")
                    {
                        index++;
                        if (cons(ref index) == true)
                        {
                            index++;
                            if (words[index] == ")")
                            {
                                index++;
                                if (body(ref index) == true)
                                {
                                    Console.WriteLine("ROUND LOOP SUCCESSFULLY PARSED");
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;

    }
    public bool fncal(ref int index)
    {
        if (words[index] == "fncall")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
                if (dlookup(words[index]+ "_fn",1) == false)
                {
                    Console.WriteLine("Undeclared " + words[index]);
                }
                
                index++;
                if (words[index] == "(")
                {
                    index++;
                    //Console.WriteLine(" ( parsed");
                    if (fnpara(ref index) == true)
                    {
                        
                       // Console.WriteLine(" exp parsed");
                        if (words[index] == ")")
                        {
                            Console.WriteLine("FUNCTION CALL PARSED SUCCESSFULLY");
                            index++;
                            if (words[index] == ";")
                            {
                                index++;
                                return true;
                            }
                            return true;
                        }
                    }
                }
            }
        }
        return false;

    }

    public bool fnpara(ref int index)
    {
        if (exp(ref index) == true)
        {
            if (words[index] == ",")
            {
                index++;
                if (fnpara(ref index) == true)
                {
                    return true;
                }
                
            }
            if (words[index] == ".")
            {
                index--;
                if (objcall(ref index) == true)
                {
                    if (words[index] == ",")
                    {
                        index++;
                        if (fnpara(ref index) == true)
                        {
                            return true;
                        }
                    }
                    return true;
                }
 
            }
            if (words[index] == "[")
            {
                index--;
                if (arraycall(ref index) == true)
                {
                    if (words[index] == ",")
                    {
                        index++;
                        if (fnpara(ref index) == true)
                        {
                            return true;
                        }
                    }
                    return true;
                }

            }
            return true;
        }
        else if (fncal(ref index) == true)
        {
            if (words[index] == ",")
            {
                index++;
                if (fnpara(ref index) == true)
                {
                    return true;
                }
            }
            return true;
        }
       /* else
        {
            index--;
            if (objcall(ref index) == true)
            {
                if (words[index] == ",")
                {
                    index++;
                    if (fnpara(ref index) == true)
                    {
                        return true;
                    }
                }
                return true;
            }
        }*/
        return false;
    }
    public bool para2(ref int index)
    {
        if (cons(ref index) == true)
        {
            index++;
            if (words[index] == ",")
            {
                index++;
                if (para2(ref index) == true)
                {
                    return true;
                }
            }
            return true;


        }
        return false;
    }
    public bool ret(ref int index)
    {
        if (words[index] == "return")
        {
            index++;
            if (cons(ref index) == true || words[index] == "true" || words[index] == "false")
            {
                index++;
                if (words[index] == ";")
                {
                    index++;
                    return true;
                }
            }
            if (words[index] == ";")
            {
                index++;
                return true;
            }
         
        }

        return false;
    }
    public bool obj(ref int index)
    {
        if (words[index] == "obj")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
                if (dlookup(words[index]+ "_obj", 0) == true)
                {
                    Console.WriteLine("Redeclared "+ words[index]);
                }
                else
                {
                    insert(words[index] + "_obj", 0);
                }


                
                
                index++;
                if (words[index] == "ID")
                {
                    index++;
                    if (dlookup(words[index] + "_Hall", 0) == false)
                    {
                        Console.WriteLine("Undeclared " + words[index]);
                    }
                    index++;
                    if (words[index] == ";")
                    {
                        index++;
                        return true;
                    }
                    return true;
                }
            }
        }
        return false;
    }
    public bool objcall(ref int index)
    {
        if (words[index] == "ID")
        {
            index++;
            if (dlookup(words[index] + "_obj", 0) == false)
            {
                Console.WriteLine("Undeclared " + words[index]);
            }
            
            index++;
            if (words[index] == ".")
            {
                index++;
                if (words[index] == "ID" || words[index] == "fncall")
                {
                    if (words[index] == "fncall")
                    {
                        if (fncal(ref index) == true)
                        {
                            return true;
                        }
                        return false;
                    }
                    index++;
                    if (dlookup(words[index], 1) == false )
                    {
                        Console.WriteLine("Undeclared " + words[index]);
                    }
                    
                    index++;
                    if (words[index] == ";")
                    {
                        index++;
                        return true;
                    }
                    return true;
                }
                return false;
            }
        }
        return false;
    }
    public bool objcall1(ref int index)
    {
        if (objcall(ref index) == true)
        {
            if (objcall1(ref index) == true)
            {
                return true;
            }
        }
        return true;
    }
    public bool objcall2(ref int index)
    {
        if (words[index] == "ID")
        {
            index++;
            if (dlookup(words[index], 0) == false && dlookup(words[index]+"_obj",0) == false)
            {
                Console.WriteLine("Undeclared " + words[index]);
            }
            
            index++;
            if (words[index] == "=")
            {
                index++;
                if (objcall(ref index) == true)
                {
                    if (objcall2(ref index) == true)
                    {
                        return true;
                    }
                }
            }
           
        }
        return true;
    }
    public bool arraycall(ref int index)
    {
        if (words[index] == "ID")
        {
            index++;
            if (dlookup(words[index], scopes[top]) == false && dlookup(words[index], 1) == false && dlookup(words[index], 2) == false)
            {
                Console.WriteLine("Undeclared " + words[index]);
            }
            
            index++;
            if (words[index] == "[")
            {
                index++;
                if (cons(ref index) == true)
                {
                    index++;
                    if (words[index] == "]")
                    {
                        index++;
                        return true;
                    }
                }

            }
        }
        return false;
    }
    public bool dtglobal(ref int index)
    { 
        if (dtglobal2(ref index) == true)
        {
            if (dtglobal(ref index) == true)
            return true;
        }
        return true;
    }
    public bool dtglobal2(ref int index)
    {
        if (words[index] == "dec")
        {
            index++;
            if (words[index] == "ID")
            {
                index++;
                
                if (dlookup(words[index], 0) == true)
                {
                    Console.WriteLine("Redeclared " + words[index]);
                }
                else
                {
                    insert(words[index], 0);
                }
                index++;
                if (words[index] == "=")
                {
                    index++;
                    // Console.WriteLine("dt const return " + words[index]);
                    if (cons(ref index) == true)
                    {
                        index++;
                        if (words[index] == ";")
                        {
                            Console.WriteLine("DATATYPE PARSED SUCCESSFULLY");
                            index++;
                            return true;
                        }
                        return true;
                    }
                }
                else if (words[index] == ";")
                {
                    Console.WriteLine("DATATYPE PARSED SUCCESSFULLY");
                    index++;
                    return true;
                }
            }
        }
        return false;
    }
    public bool cons(ref int index)
    {
        if (words[index] == "const_int" || words[index] == "const_string" || words[index] == "const_char" || words[index] == "const_float" || words[index] == "const")
        {
            
            return true;
        }
        return false;
    }
    public void insert(string t, int s)
    {
        string[] lines;
        
        lines = new string[] { t + "," + s };
        System.IO.File.AppendAllLines("check.txt", lines);
        
    }
    public bool dlookup(string temp, int s)
    {
        string temp1 = temp + "," + s;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader("check.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (temp1 == line)
            {
                //Console.WriteLine("redeclared");
                file.Close();
                return true;
            }

        }


        file.Close();
        return false;
    }
    public bool dlookup2(string temp)
    {
        s = s + 1;
        string temp1 = temp + "," + s;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader("check.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (temp1 == line)
            {
                //Console.WriteLine("redeclared");
                file.Close();
                return true;
            }

        }


        file.Close();
        return false;
    }
    public string compatibility(string checking1, string checking2)
    {
        if (checking1 == checking2)
        {
            return checking1;
        }
        else
        {
            Console.WriteLine("Type Mismatch " + checking1 + " and "  + checking2 );
            return "Null";
        }
    }
    public void insert_int(string t)
    {
        string[] lines;

        lines = new string[] { t };
        System.IO.File.AppendAllLines("int.txt", lines);

    }
    public void insert_float(string t)
    {
        string[] lines;

        lines = new string[] { t };
        System.IO.File.AppendAllLines("float.txt", lines);

    }
    public void insert_string(string t)
    {
        string[] lines;

        lines = new string[] { t };
        System.IO.File.AppendAllLines("string.txt", lines);

    }
    public void insert_char(string t)
    {
        string[] lines;

        lines = new string[] { t };
        System.IO.File.AppendAllLines("char.txt", lines);

    }
    public bool lookup_int(string temp)
    {

        string temp1 = temp;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader("int.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (temp1 == line)
            {
                //Console.WriteLine("redeclared");
                file.Close();
                return true;
            }

        }


        file.Close();
        return false;
    }
    public bool lookup_float(string temp)
    {

        string temp1 = temp;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader("float.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (temp1 == line)
            {
                //Console.WriteLine("redeclared");
                file.Close();
                return true;
            }

        }


        file.Close();
        return false;
    }
    public bool lookup_string(string temp)
    {

        string temp1 = temp;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader("string.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (temp1 == line)
            {
                //Console.WriteLine("redeclared");
                file.Close();
                return true;
            }

        }


        file.Close();
        return false;
    }
    public bool lookup_char(string temp)
    {

        string temp1 = temp;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader("char.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (temp1 == line)
            {
                //Console.WriteLine("redeclared");
                file.Close();
                return true;
            }

        }


        file.Close();
        return false;
    }
    public void insert_icg(string t, string t1, string t2)
    {
        string[] lines;

        lines = new string[] { "t" +number+ " = "+ t +" " + t1 + " " +t2};
        System.IO.File.AppendAllLines("icg.txt", lines);

    }
    public void insert_icg1(string t)
    {
        string[] lines;
        int num = number - 1;
        lines = new string[] {t + " = t" +num };
        System.IO.File.AppendAllLines("icg.txt", lines);

    }
    public bool validate()
    {
        
        int index = 0;
        if (main(ref index) == true)
        {
           Console.WriteLine("main func done");
            
             return true; 
        }
        else
            return false;
        
    }
}
