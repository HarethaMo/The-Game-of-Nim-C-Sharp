using System;

namespace NimGame00
{
    class Program
    {
        static void Main()
        {
            int turn = 2;
            Console.WriteLine("Welcom TO The Nim Game\n\nEnter 1 For Player vs Computer Mode | Enter 2 For Player vs Player Mode | Enter 3 For Computer vs Computer Mode");
            int mode = int.Parse(Console.ReadLine());
            int[] heaps = CreateHeaps();
            Console.WriteLine();
            if (mode == 1)
            {
                while (!isGameOver(heaps, turn))
                {
                    turn = (turn == 1 ? 2 : 1);
                    ShowHeaps(heaps);
                    int nimSum = NimSum(heaps, turn);
                    if (turn == 1)
                        MakeMove(ref heaps, ref turn);
                    else
                        ComputerMove(heaps, nimSum);

                    Console.WriteLine("\n******************************************************\n");
                }
            }
            else if(mode == 2)
            {
                while (!isGameOver(heaps, turn))
                {
                    turn = (turn == 1 ? 2 : 1);
                    ShowHeaps(heaps);
                    NimSum(heaps, turn);
                    MakeMove(ref heaps, ref turn);
                    Console.WriteLine("\n******************************************************\n");
                }
            }
            else
            {
                while (!isGameOver(heaps, turn))
                {
                    turn = (turn == 1 ? 2 : 1);
                    ShowHeaps(heaps);
                    int nimsum =NimSum(heaps, turn);
                    ComputerMove(heaps, nimsum);
                    Console.WriteLine("\n******************************************************\n");
                }
            }
           
            
           
        }
        // A method that take user input to create the heaps for the game to start, it's called once early in the program.
        static int[] CreateHeaps()
        {
            Console.WriteLine("Number of heaps:");
            int heapsNum = int.Parse(Console.ReadLine());
            int[] heaps = new int[heapsNum];
            Console.WriteLine("Number of items in each heap:");
            string line = Console.ReadLine();
            var input = line.Split(" ");
            for(int i = 0; i < heaps.Length; i++)
                heaps[i] = int.Parse(input[i]);
            return heaps;
        }
        // A method to show the state of the game to the players after each turn.
        static void ShowHeaps(int[] heaps)
        {
            for (int i = 0; i <heaps.Length; i++)
            {
                Console.Write("Heap {0} has {1} items", i + 1,heaps[i]);   
                Console.Write("\n");
            }
        }
        /* A method for human player to make a move, it takes a string as input and turns it into an array of 2 integers,
         the firs is the number of the heap to make the move in, and the second the number of items to remove form that heap. */
        static void MakeMove(ref int[] heaps, ref int turn)
        {
            Console.WriteLine("\nIt's player {0} turn \nEnter Your Move:", turn);
            string line = Console.ReadLine();
            var input = line.Split(" ");
            int heapNo = int.Parse(input[0]) - 1;
            int heapRe = int.Parse(input[1]);
            heaps[heapNo] -= heapRe;

        } // A method to check when the game is over and declare the winner, the game is over when all heaps have 0 items.
         static bool isGameOver(int[] heaps, int turn)
        {
            for(int i=0; i< heaps.Length; i++)
            {
                if (heaps[i] != 0)
                    return false;
                
            }
            ShowHeaps(heaps);
            Console.WriteLine("\nGame over, player {0} wins, Congratulations!!", turn);
            return true;
        }
        /* Nimsum is the sum of applying the xOr logical operation to the binray equivalent of the number of items in each heap.
         The nimsum is used to determine the player with the winnig position and the optimal computer move if the the computer is winning. */
        static int NimSum(int[] heaps, int turn)
        {
            int nimSum = 0;
            for(int i=0; i<heaps.Length; i++)
            {
                nimSum ^= heaps[i];
            }
            if (nimSum == 0 && turn == 1)
                Console.WriteLine("\nNimSum = 0 || Player 2 is Winning!");
            else if (nimSum == 0 && turn == 2)
                Console.WriteLine("\nNimSum = 0 || Player 1 is Winning!");
            else
                Console.WriteLine("\nNimSum = {0} || Player {1} is winning!", nimSum, turn);
            return nimSum;
        }
        /* when it's the computer's trun there is 2 possibilties for it's move, either it's winning and then it will find the optimal move using the nimsum method,
        else it will make a random move in a nonempty heap. */
        static void ComputerMove(int[] heaps, int NimSum)
        {
            if(NimSum == 0)
            {
                Random r = new Random();
                int x = (r.Next(100) % heaps.Length);
                // This loop ensures that the random heap the computer chooses isn't empty, by changing to a new heap as long as the pervios one is empty
                while (heaps[x] == 0)
                {
                    x = (r.Next(100) % heaps.Length);
                }
                int y = (r.Next(100) % heaps[x]) + 1;
                heaps[x] -= y;
                Console.WriteLine("\nComputer's move is to remove {0} items from heap {1}", y, x + 1);
            }
            else
            {
                int cHeap = 0;
                int cRemove = 0;
                for (int i=0; i<heaps.Length; i++)
                {
                    if((NimSum ^ heaps[i]) < heaps[i])
                    {
                        cHeap = i;
                        cRemove = heaps[i] - (NimSum ^ heaps[i]);
                        break;
                    }
                }
                heaps[cHeap] -= cRemove;
                Console.WriteLine("\nComputer's move is to remove {0} items from heap {1}", cRemove, cHeap + 1);
            }
        }
    }
}
