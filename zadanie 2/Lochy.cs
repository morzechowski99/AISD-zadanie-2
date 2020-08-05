using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zadanie_2
{
    public static class Lochy
    {
        private static int n, m;
        private static int[,] depth;
        private static bool[,] check;
        private static int robberCellN, robberCellM;
        private static int robberCellCeiling;
        private static int robberCellFloor;
        private static int counter  = 0;
        private static int resursioncounter = 0;
        public static void ReadData()
        {
            StreamReader reader = new StreamReader("C:/Users/marci/Desktop/in.txt");
            string value = reader.ReadLine();
            String[] s = value.Split(null);
            n = Int32.Parse(s[0]);
            m = Int32.Parse(s[1]);
            depth = new int[n, m];
            int g = 0;
            while ((value = reader.ReadLine()) != null && g < n)
            {
                s = value.Split(null);
                for (int i = 0; i < m; i++)
                {
                    depth[g, i] = Int32.Parse(s[i]);
                }
                g++;
            }

            s = value.Split(null);
            robberCellN = Int32.Parse(s[0]) - 1;
            robberCellM = Int32.Parse(s[1]) - 1;
            robberCellCeiling = depth[robberCellN, robberCellM];
            robberCellFloor = robberCellCeiling + 4;
            check = new bool[n, m];
            reader.Close();
            check[robberCellN, robberCellM] = true;
        }
        public static void WriteData()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write(depth[i, j] + "");
                Console.WriteLine();
            }
            Console.WriteLine($"{robberCellN} {robberCellM}");
        }
        private static int HowMuchWater(int x, int y) //9*N*M
        {
          if (x < 0 || x >= n || y < 0 || y >= m)
          { 
              counter++; 
              return 0;
          }
            int wynik = 0;
            for(int i = x-1; i<=x+1;i++)
            {
                for(int j = y-1;j<=y+1;j++)
                {
                    if (i == x && j == y) ;
                    else if (i < 0 || i >= n || j < 0 || j >= m) ;
                    else if (check[i, j] == true) ;
                    else if (depth[i, j] > depth[x, y] -5 && depth[i, j] < depth[x, y] + 5) 
                    {
                        if (depth[i, j] > robberCellFloor)
                        {
                           check[i, j] = true;
                           resursioncounter++;
                           wynik += 5 + HowMuchWater(i, j);
                        }
                        else if (depth[i,j] + 5 > robberCellFloor)
                        {
                          
                                check[i, j] = true;
                                wynik += 5 - (robberCellFloor - depth[i, j]) + HowMuchWater(i, j);
                                resursioncounter++;
                        }
                        
                    }
                    counter++;
                }
            }
            
            return wynik;

        }
        public static int GetResult()
        {
            resursioncounter++;
            return 1 + HowMuchWater(robberCellN, robberCellM);
        }
        public static int GetCounter()
        {
            return counter;
        }
        public static int GetRecursioncounter()
        {
            return resursioncounter;
        }
        
    }
}
