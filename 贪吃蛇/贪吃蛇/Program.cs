using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int consoleWidth = 80;
    static int consoleHeight = 25;
    static Random random = new Random();

    static int snakeHeadX;
    static int snakeHeadY;
    static List<int> snakeBodyX = new List<int>();
    static List<int> snakeBodyY = new List<int>();
    static int foodX;
    static int foodY;
    static bool isGameover = false;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(consoleWidth, consoleHeight);
        Console.SetBufferSize(consoleWidth, consoleHeight);

        snakeHeadX = consoleWidth / 2;
        snakeHeadY = consoleHeight / 2;

        GenerateFood();

        Thread inputThread = new Thread(Input);
        inputThread.Start();

        while (!isGameover)
        {
            Draw();
            Move();
            Thread.Sleep(100);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Press Enter to play again or any other key to exit...");
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            ResetGame();
        }
    }

    static void Input()
    {
        while (!isGameover)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveSnake(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSnake(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveSnake(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveSnake(1, 0);
                        break;
                }
            }
        }
    }

    static void Draw()
    {
        Console.Clear();
        Console.SetCursorPosition(snakeHeadX, snakeHeadY);
        Console.Write("@");
        for (int i = 0; i < snakeBodyX.Count; i++)
        {
            Console.SetCursorPosition(snakeBodyX[i], snakeBodyY[i]);
            Console.Write("*");
        }
        Console.SetCursorPosition(foodX, foodY);
        Console.Write("#");
    }

    static void Move()
    {
        if (isGameover)
        {
            return;
        }

        for (int i = snakeBodyX.Count - 1; i >= 1; i--)
        {
            snakeBodyX[i] = snakeBodyX[i - 1];
            snakeBodyY[i] = snakeBodyY[i - 1];
        }

        snakeBodyX[0] = snakeHeadX;
        snakeBodyY[0] = snakeHeadY;

        MoveSnake(0, 0);

        if (snakeHeadX == foodX && snakeHeadY == foodY)
        {
            GenerateFood();
            snakeBodyX.Add(snakeHeadX);
            snakeBodyY.Add(snakeHeadY);
        }

        for (int i = 1; i < snakeBodyX.Count; i++)
        {
            if (snakeHeadX == snakeBodyX[i] && snakeHeadY == snakeBodyY[i])
            {
                isGameover = true;
                break;
            }
        }

        if (snakeHeadX >= consoleWidth || snakeHeadX < 0 || snakeHeadY >= consoleHeight || snakeHeadY < 0)
        {
            isGameover = true;
        }
    }

    static void MoveSnake(int deltaX, int deltaY)
    {
        snakeHeadX += deltaX;
        snakeHeadY += deltaY;
    }

    static void GenerateFood()
    {
        foodX = random.Next(consoleWidth);
        foodY = random.Next(consoleHeight);
    }

    static void ResetGame()
    {
        isGameover = false;
        snakeHeadX = consoleWidth / 2;
        snakeHeadY = consoleHeight / 2;
        snakeBodyX.Clear();
        snakeBodyY.Clear();
        GenerateFood();
    }
}
