using System;

namespace Desafio
{
    class Program
    {

        public static string[,] Estoura(string[,] mat,int r, int c, int linha, int coluna)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if((i == linha || j == coluna) && mat[i,j]!="X")
                    {
                        mat[i, j] = ".";
                    }
                }
            }
            return mat;
        }

        static void Main(string[] args)
        {
            int seg = 0, seg2 = 0;
            string resul = "";
            bool implantou = false;
            var arrayCaracteres = new string[] { "X", "O", "." };

            Console.WriteLine("Bomberman!");
            Console.WriteLine("Digite, respectivamente, o número de linhas colunas e o tempo(segundos) de jogo !");
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string[,] mat = new string[r, c];
            bool[,] matAux1 = new bool[r, c];
            bool[,] matAux2 = new bool[r, c];

            Random rnd = new Random();
            Console.WriteLine("\n{0} {1} {2}", r, c, n);
            Console.WriteLine("Estado Inicial:");
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    var elemento = arrayCaracteres[rnd.Next(arrayCaracteres.Length)];

                    mat[i, j] = elemento;
                    if (elemento == "O")
                    {
                        matAux1[i, j] = true;
                    }
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.Write("\n");
            }


            while (n >= 0)
            {
                Console.WriteLine("\nTempo restante: " + n);
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        switch (seg)
                        {
                            case 0:
                                break;
                            case 1:
                                break;
                            case 2:
                                if (mat[i, j] == ".")
                                {
                                    mat[i, j] = "O";
                                    matAux2[i, j] = true;
                                    implantou = true;
                                }
                                break;
                            case 3:
                                if (matAux1[i, j])
                                {
                                    Estoura(mat,r,c,i,j);
                                }
                                break;
                            default:
                                break;
                        }
                        if (seg2 == 3)
                        {
                            Estoura(mat, r, c, i, j);
                        }
                        resul += mat[i, j] + " ";
                    }
                    resul += "\n";
                }
                Console.WriteLine(resul + "\n");
                resul = "";
                n--;
                if (seg == 3)
                {
                    seg = 0;
                }
                else
                {
                    seg++;
                }
                if (implantou)
                {
                    if (seg2 == 3)
                    {
                        seg2 = 0;
                    }
                    else
                    {
                        seg2++;
                    }
                }
            }
        }
    }
}
