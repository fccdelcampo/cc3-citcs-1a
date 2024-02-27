// Programmed by: Francis Carlo C. Del Campo (CITCS-1A)
// Lab Activity 7: Role-Playing Game
// CC3 - Object-Oriented Programming

using System;

public class Maze 
{
    // Declaring 2D array for 2D maze
    public int[,] maze = new int[15,21];
    // Non-parameterized constructor
    public Maze()
    {
        /* -1 is for vertical walls
        0 is for open spaces
        1 is for horizontal and inside walls
        2 is for player location
        3 is for enemy location */
        // Creating north wall
        int i = 0;
        int j = 0;
        while (j < 21) 
        {
            maze[i,j] = 1;
            j++;
        }
        
        // Creating south wall
        i = 14;
        j = 0;
        while (j < 21) 
        {
            maze[i,j] = 1;
            j++;
        }

        // Creating west wall
        i = 0;
        j = 0;
        while (i < 15)
        {
            maze[i,j] = -1;
            i++;
        } 

        // Creating east wall
        i = 0;
        j = 20;
        while (i < 15)
        {
            maze[i,j] = -1;
            i++;
        } 

        // Hardcoding wall locations
        maze[1,3] = maze[1,6] = maze[1,12] = maze[1,17] = 1;
        maze[2,3] = maze[2,4] = maze[2,8] = maze[2,11] = maze[2,12] = maze[2,13] = maze[2,15] = maze[2,16] = maze[2,17] = maze[2,18] = 1;
        maze[3,8] = maze[3,11] = maze[3,13] = maze[3,14] = maze[3,15] = maze[3,18] = 1;
        maze[4,2] = maze[4,3] = maze[4,4] = maze[4,7] = maze[4,11] = maze[4,15] = maze[4,16] = 1;
        maze[5,3] = maze[5,6] = maze[5,7] = maze[5,8] = maze[5,9] = maze[5,11] = maze[5,12] = maze[5,15] = 1; 
        maze[6,3] = maze[6,6] = maze[6,9] = maze[6,12] = maze[6,15] = maze[6,18] = maze[6,19] = 1;
        maze[7,2] = maze[7,3] = maze[7,4] = maze[7,6] = maze[7,9] = maze[7,10] = maze[7,11] = maze[7,12] = maze[7,14] = maze[7,15] = maze[7,18] = 1;
        maze[8,4] = maze[8,10] = maze[8,14] = 1;
        maze[9,1] = maze[9,2] = maze[9,7] = maze[9,8] = maze[9,14] = maze[9,15] = maze[9,16] = maze[9,17] = 1;
        maze[10,2] = maze[10,3] = maze[10,4] = maze[10,6] = maze[10,7] = maze[10,10] = maze[10,11] = maze[10,12] = maze[10,17] = maze[10,18] = 1;
        maze[11,3] = maze[11,7] = maze[11,8] = maze[11,9] = maze[11,10] = maze[11,14] = maze[11,16] = maze[11,17] = 1;
        maze[12,2] = maze[12,3] = maze[12,7] = maze[12,10] = 1;
        maze[13,10] = maze[13,19] = 1;
        maze[1,1] = 2;
    }

    // Instance method to print an instance of the maze
    public void PrintMaze(Character player, Enemies[] enemy)
    {
        // Prints the maze after every move
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 21; j++){
                switch(maze[i,j])
                {
                    // Printing vertical walls
                    case -1:
                        Console.Write(" ║ ");
                        break;
                    // Printing open spaces
                    case 0:
                        Console.Write("   ");
                        break;
                    // Printing horizontal and inside walls
                    case 1:
                        Console.Write("═══");
                        break;
                    // Printing player's avatar
                    case 2:
                        if (player.alive)
                        {
                            switch (player.job) 
                            {
                                case "Archer":
                                    Console.Write("A->");
                                    break;
                                case "Warrior":
                                    Console.Write("<W>");
                                    break;
                                case "Mage":
                                    Console.Write("~M~");
                                    break;
                                case "Assasin":
                                    Console.Write("A[)");
                                    break;
                            }
                        } 
                        else
                        {
                            Console.Write("   ");
                        }
                        break;
                    // Printing enemies
                    case 3:
                        for (int k = 0; k < 5; k++)
                        {
                            if (enemy[k].x == i && enemy[k].y == j)
                            {
                                switch(enemy[k].name)
                                {
                                    case "Tamish":
                                        Console.Write(" T ");
                                        break;
                                    case "Dracul":
                                        Console.Write(" D ");
                                        break;
                                    case "Gamian":
                                        Console.Write(" G ");
                                        break;
                                    case "Kshipa":
                                        Console.Write(" K ");
                                        break;
                                    case "Vlasta":
                                        Console.Write(" V ");
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine();
        }
    }

}

public class Character
{
    // Declaring and initializing attributes for Character class
    public string name;
    public string job;
    public int health = 150;
    public int damage = 50;
    public int speed = 10;
    public int exp = 0;
    public int level = 1;
    public int x;
    public int y;
    public bool alive = true;

    // Parameterized constructor for Character instances
    public Character(string name, string job)
    {
        this.name = name;
        this.job = job;
        this.x = this.y = 1;
    }

    public bool Move(Maze maze, int p_x, int p_y)
    {
        // If cell in maze is open, move the player into that cell
        if (maze.maze[x + p_x,y + p_y] == 0)
        {
            maze.maze[x + p_x,y + p_y] = 2;
            maze.maze[x,y] = 0;
            x += p_x;
            y += p_y;
            return true;
        }
        // Otherwise, ignore the move request
        return false;
    }

    public void RestoreHealth()
    {
        // Restores health of player and adds bonus every time it defeats an enemy
        switch(level)
        {
            case 1:
                health = 150;
                break;
            case 2:
                health = 200;
                break;
            case 3:
                health = 250;
                break;
            case 4:
                health = 300;
                break;
            case 5:
                health = 350;
                break;
        }
    }

    public void LevelUp()
    {
        // If player has defeated all enemies...
        if (level == 5)
        {
            // Print congratulatory message
            Console.WriteLine(@"
█╗   ██╗ ██████╗ ██╗   ██╗    ███████╗ █████╗ ██╗   ██╗███████╗██████╗     
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔════╝██╔══██╗██║   ██║██╔════╝██╔══██╗    
 ╚████╔╝ ██║   ██║██║   ██║    ███████╗███████║██║   ██║█████╗  ██║  ██║    
  ╚██╔╝  ██║   ██║██║   ██║    ╚════██║██╔══██║╚██╗ ██╔╝██╔══╝  ██║  ██║    
   ██║   ╚██████╔╝╚██████╔╝    ███████║██║  ██║ ╚████╔╝ ███████╗██████╔╝    
   ╚═╝    ╚═════╝  ╚═════╝     ╚══════╝╚═╝  ╚═╝  ╚═══╝  ╚══════╝╚═════╝     
                                                                            
 ██████╗ ██████╗  ██████╗ ██████╗ ██╗███████╗ ██████╗  █████╗ ██╗           
██╔═══██╗██╔══██╗██╔═══██╗██╔══██╗██║██╔════╝██╔════╝ ██╔══██╗██║           
██║   ██║██████╔╝██║   ██║██████╔╝██║█████╗  ██║  ███╗███████║██║           
██║   ██║██╔══██╗██║   ██║██╔══██╗██║██╔══╝  ██║   ██║██╔══██║╚═╝           
╚██████╔╝██████╔╝╚██████╔╝██║  ██║██║███████╗╚██████╔╝██║  ██║██╗           
 ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝                                                                                                                               
        ");
            // Ask player if they want to play the game again
            Console.Write("Would you like to play the game again? Y/N");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string option;
            do
            {
                Console.Write(" -> ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                option = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            while (!(string.Equals(option.ToLower(), "y") || string.Equals(option.ToLower(), "n")));

            // User input processing
            if (string.Equals(option.ToLower(), "n"))
            {
                // Exits the game
                Console.WriteLine("Exiting the game...");
                Environment.Exit(0);
                return;
            }
            else
            {
                // Restarts the game
                String[] arr = {""};
                Program.Main(arr);
            }
        }
        else
        {
            // Increase level first then restore health
            level++;
            RestoreHealth();

            // Add +2 to every stat of the player
            health += 2;
            damage += 2;
            speed += 2;
            exp += 2;

            // Print congratulatory message and display new stats
            Console.WriteLine(@"
██╗     ███████╗██╗   ██╗███████╗██╗         ██╗   ██╗██████╗ ██╗
██║     ██╔════╝██║   ██║██╔════╝██║         ██║   ██║██╔══██╗██║
██║     █████╗  ██║   ██║█████╗  ██║         ██║   ██║██████╔╝██║
██║     ██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║         ██║   ██║██╔═══╝ ╚═╝
███████╗███████╗ ╚████╔╝ ███████╗███████╗    ╚██████╔╝██║     ██╗
╚══════╝╚══════╝  ╚═══╝  ╚══════╝╚══════╝     ╚═════╝ ╚═╝     ╚═╝                                                               
            ");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Health (+ bonus +2): {health}");
            Console.WriteLine($"Damage (+2): {damage}");
            Console.WriteLine($"Speed (+2): {speed}");
            Console.WriteLine($"EXP (+2): {exp}");
        }
    }

    public void TakeDamage(Enemies enemy, Maze maze)
    {
        // Decrease player health and display updated stats
        health -= enemy.damage;
        Console.WriteLine($"Your health: {health} | Your damage: {damage} | {enemy.name}'s health: {enemy.health} | {enemy.name}'s damage: {enemy.damage}");
        // If user's health is less than or equal to zero, it is dead...
        if (health <= 0)
        {
            alive = false;
            maze.maze[x,y] = 0;
            x = y = Convert.ToInt32(null);
            Console.WriteLine(@"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗███████╗██████╗ ███████╗    
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██╔════╝██╔══██╗██╔════╝    
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║█████╗  ██████╔╝█████╗      
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██╔══╝  ██╔══██╗██╔══╝      
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝███████╗██║  ██║███████╗    
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝╚══════╝    
                                                                     
██╗  ██╗██╗██╗     ██╗     ███████╗██████╗         ██╗               
██║ ██╔╝██║██║     ██║     ██╔════╝██╔══██╗    ██╗██╔╝               
█████╔╝ ██║██║     ██║     █████╗  ██║  ██║    ╚═╝██║                
██╔═██╗ ██║██║     ██║     ██╔══╝  ██║  ██║    ▄█╗██║                
██║  ██╗██║███████╗███████╗███████╗██████╔╝    ▀═╝╚██╗               
╚═╝  ╚═╝╚═╝╚══════╝╚══════╝╚══════╝╚═════╝         ╚═╝                                                                                                                               
        ");
            string? option;
            // Ask the player if they want to play the game again and process their input
            Console.Write("Would you like to play the game again? Y/N");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            do
            {
                Console.Write(" -> ");
                option = Console.ReadLine();
            }
            while (!(string.Equals(option.ToLower(), "y") || string.Equals(option.ToLower(), "n")));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (string.Equals(option.ToLower(), "n"))
            {
                Console.WriteLine("Exiting the game...");
                Environment.Exit(0);
            }
            else
            {
                String[] arr = {""};
                Program.Main(arr);
            }
        }
    }

    public void DealDamage(Enemies enemy, Maze maze)
    {
        // Decrease enemy health
        enemy.health -= damage;

        // If enemy health is less than or equal to zero, it is dead
        if (enemy.health <= 0)
        {
            enemy.alive = false;
            Console.WriteLine($"You have killed {enemy.name}!");
            // Player levels up every time an enemy is killed
            LevelUp();

            // Clean up defeated enemy's location and position attributes
            maze.maze[enemy.x,enemy.y] = 0;
            enemy.x = enemy.y = -1;
        }
    }
}

public class Enemies
{
    // Declaring attributes of Enemies class
    public string? name;
    public int health;
    public int damage;
    public int speed;

    public int x;
    public int y;
    public bool alive = true;

}

public class Program
{
    // Checks if a player and an enemy are next to each other
    public static bool Adjacent(Character player, Enemies enemy)
    {
        double diff_x = Math.Pow(Convert.ToDouble(player.x - enemy.x), 2.0);
        double diff_y = Math.Pow(Convert.ToDouble(player.y - enemy.y), 2.0);
        double difference = Math.Abs(Math.Sqrt(diff_x + diff_y));
        return difference == 1.0 || difference == Math.Sqrt(2.0);
    }

    // Checks if two enemies are next to each other
    public static bool AdjacentEnemies(Enemies enemy1, Enemies enemy2)
    {
        double diff_x = Math.Pow(Convert.ToDouble(enemy1.x - enemy2.x), 2.0);
        double diff_y = Math.Pow(Convert.ToDouble(enemy1.y - enemy2.y), 2.0);
        double difference = Math.Abs(Math.Sqrt(diff_x + diff_y));
        return difference == 1.0 || difference == Math.Sqrt(2.0);
    }

    public static string AskName()
    {
        // Processes user input and re-prompts them to give their name if they give an empty name
        string? input = "";
        do 
        {
            Console.Write("Enter your name -> ");
            input = Console.ReadLine();
        }
        while (String.IsNullOrEmpty(input));
        return input;
    }

    public static string AskRole()
    {
        // Processes user input and re-prompts them to give their desired role if they give an empty name
        bool validResponse = true;
        Console.Write("SELECT YOUR ROLE AMONG THE FOLLOWING: \n1: Archer A->\n2: Warrior <W>\n3: Mage ~M~\n4: Assassin A[)\n    -> ");
        do
        {
        
            switch(Console.ReadLine())
            {
                case "1":  
                    return "Archer";
                case "2":  
                    return "Warrior";
                case "3":  
                    return "Mage";
                case "4":  
                    return "Assasin";
                default:  
                    validResponse = false;
                    Console.Write("Invalid option. Try again.\n    -> ");
                    break;
            }
        }
        while(!validResponse);
        // Silences warning messages
        return "";
    }

    public static string AskGameOption(Character player)
    {
        string? option = "";
        // Asks player of the option they want to explore
        Console.WriteLine($"Good luck, {player.job} {player.name}. Choose the following options: \n    1: to play the game \n    2: to see your stats \n    3: to exit the game");
        do
        {
            Console.Write("    -> ");
            option = Console.ReadLine();
        }
        while(!(string.Equals(option, "1") || string.Equals(option, "2") || string.Equals(option, "3")));
#pragma warning disable CS8603 // Possible null reference return.
        return option;
#pragma warning restore CS8603 // Possible null reference return.
    }

    public static void AskMove(Maze maze, Character player, Enemies enemy, int mode)
    {
        string? move = "";
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        // If mode is 1, option to attack is available
        if (mode == 1)
        {
            // Continuously prompt user of input until a valid input is given
            do
            {
                Console.Write("    -> ");
                move = Console.ReadLine();
            }
            while (!(string.Equals(move, "1") || string.Equals(move.ToLower(), "w") || string.Equals(move.ToLower(), "a") || string.Equals(move.ToLower(), "s") || string.Equals(move.ToLower(), "d")));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        // If mode is 0 or anything else, option to attac is unavailable
        else
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            // Continuously prompt user of input until a valid input is given
            do
            {
                Console.Write("    -> ");
                move = Console.ReadLine();
            }
            while (!(string.Equals(move.ToLower(), "w") || string.Equals(move.ToLower(), "a") || string.Equals(move.ToLower(), "s") || string.Equals(move.ToLower(), "d")));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        // Process user input and execute the necessary actions
        switch(move.ToLower())
        {
            case "1":
                Console.WriteLine($"You attacked {enemy.name}.");
                player.DealDamage(enemy, maze);
                return;
            case "w":
                player.Move(maze, -1, 0);
                return;
            case "a":
                player.Move(maze, 0, -1);
                return;
            case "s":
                player.Move(maze, 1, 0);
                return;
            case "d":
                player.Move(maze, 0, 1);
                return;
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public static void GenerateEnemies(Maze maze, Enemies[] enemy)
    {
        // Initializes name, health, damage, and speed of enemies
        for (int i = 0; i < 5; i++)
        {
            enemy[i] = new Enemies(); // Initialize each Enemies object

            // Assign values to properties
            switch (i)
            {
                case 0:
                    enemy[i].name = "Tamish";
                    enemy[i].health = 50;
                    enemy[i].damage = 7;
                    enemy[i].speed = 2;
                    break;
                case 1:
                    enemy[i].name = "Dracul";
                    enemy[i].health = 80;
                    enemy[i].damage = 20;
                    enemy[i].speed = 5;
                    break;
                case 2:
                    enemy[i].name = "Gamian";
                    enemy[i].health = 100;
                    enemy[i].damage = 40;
                    enemy[i].speed = 7;
                    break;
                case 3:
                    enemy[i].name = "Kshipa";
                    enemy[i].health = 150;
                    enemy[i].damage = 60;
                    enemy[i].speed = 11;
                    break;
                case 4:
                    enemy[i].name = "Vlasta";
                    enemy[i].health = 200;
                    enemy[i].damage = 70;
                    enemy[i].speed = 20;
                    break;
            }
        }

        Random random = new Random();

        /* Generates random positions for enemies as long as they are not adjacent 
        and will not move into a wall or player position */
        for (int i = 0; i < 5; i++)
        {
            bool enemiesAdjacent = false;
            // Generate random positions
            do
            {
                enemy[i].x = random.Next(1, 14);
                enemy[i].y = random.Next(1, 20);
                
                for (int j = 0; j < i; j++)
                {
                    if (AdjacentEnemies(enemy[i], enemy[j]))
                        enemiesAdjacent = true;
                }
            }
            while (maze.maze[enemy[i].x, enemy[i].y] != 0 && enemiesAdjacent);

            // Update maze with enemy position
            maze.maze[enemy[i].x, enemy[i].y] = 3;
        }
    }
    public static void Main(string[] args) 
    {
        // Print border
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                 The Quest for OBORIEGA                                               ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

        // Print ASCII art
        Console.WriteLine(@"
    ░▒▓██████▓▒░  ░▒▓███████▓▒░   ░▒▓██████▓▒░  ░▒▓███████▓▒░  ░▒▓█▓▒░ ░▒▓████████▓▒░  ░▒▓██████▓▒░   ░▒▓██████▓▒░  
   ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ 
   ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ 
   ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓███████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓███████▓▒░  ░▒▓█▓▒░ ░▒▓██████▓▒░   ░▒▓█▓▒▒▓███▓▒░ ░▒▓████████▓▒░ 
   ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ 
   ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ 
    ░▒▓██████▓▒░  ░▒▓███████▓▒░   ░▒▓██████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓████████▓▒░  ░▒▓██████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ 
════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════                                                                                                                              
        ");

        // Print story
        Console.WriteLine("STORY:");
        Console.WriteLine("In the mystical land of OBORIEGA, where magic and mystery intertwine, an ancient evil threatens to engulf the realm in \ndarkness.");
        Console.WriteLine("As a valiant adventurer, you have been called upon to embark on a perilous journey to defeat the malevolent forces that \nseek to destroy the kingdom.");
        Console.WriteLine("Choose your role wisely among the brave classes of Archer, Warrior, Mage, and Assassin, and prepare to face the \nchallenges that lie ahead.\n");

        // Print instructions
        Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════ ");
        Console.WriteLine("GAME MECHANICS:");
        Console.WriteLine("1. Choose Your Role:");
        Console.WriteLine("   - Upon starting the game, select your role from the available options: Archer, Warrior, Mage, or Assassin.");
        Console.WriteLine("2. Explore the Realm:");
        Console.WriteLine("   - Navigate through the challenging landscape of OBORIEGA, encountering formidable foes along the way.");
        Console.WriteLine("   - Engage in strategic battles with enemies as you explore, using your skills and tactics to emerge victorious.");
        Console.WriteLine("3. Battle Mechanics:");
        Console.WriteLine("   - Each character has attributes including name, job, health, damage, speed, and experience points (EXP).");
        Console.WriteLine("   - Use the command line interface to choose from four attacking options during battles, tailored to your chosen role.");
        Console.WriteLine("   - The order of actions in battles is determined by the speed stat of the characters, with higher speed resulting in \nswifter actions.");
        Console.WriteLine("4. Encounter Enemies:");
        Console.WriteLine("   - Encounter a variety of enemies throughout your journey, including Tamish, Dracul, Gamian, Kshipa, and the \nultimate adversary, Vlasta, the boss of OBORIEGA.");
        Console.WriteLine("   - Defeating enemies grants you experience points, allowing you to level up and improve your character's abilities.");
        Console.WriteLine("5. Leveling Up:");
        Console.WriteLine("   - Accumulate experience points by defeating enemies.");
        Console.WriteLine("   - Upon reaching a certain experience threshold (that is if you defeat an enemy), your character will level up, restore \nyour health (+bonus), and gaining 2 additional points to distribute among their attributes (health, damage, speed).");
        Console.WriteLine("   - Plan your battles strategically to maximize experience gain and level up efficiently.");
        Console.WriteLine("6. Game Over and Restart:");
        Console.WriteLine("   - The game concludes when you either save OBORIEGA or meet your demise in battle.");
        Console.WriteLine("   - After the game ends, you have the option to restart the game or exit the application.");
        Console.WriteLine("   - If you choose to restart, select your role once again and embark on a new adventure with renewed determination.");
        Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════ ");

        // While true loop to ensure game will end only if user wants it to end
        while (true)
        {
            // Generate maze object
            Maze maze = new Maze();

            // Ask user of their name and desired role
            string playerName = AskName();
            string role = AskRole();

            // Instantiate player object
            Character player = new Character(playerName, role);

            // Declare an array of 5 enemies
            Enemies[] enemy = new Enemies[5];

            // Generate enemies attributes and positions
            GenerateEnemies(maze, enemy);

            // Ask player of their game option
            string? option = AskGameOption(player);

            // Process option and execute  necessary actions
            switch(option)
            {
                // Play game
                case "1":
                    // Print maze for first time
                    maze.PrintMaze(player, enemy);

                    while (true)
                    {
                        bool enemyEncounter = false;
                        // Iterate over all enemies and see if the player and one of the enemies are next to each other
                        for (int i = 0; i < 5; i++)
                        {
                            // If the player and an enemy are next to each other..
                            if (Adjacent(player, enemy[i]) && player.alive)
                            {
                                enemyEncounter = true;
                                // ... and player's speed is greater than or equal to enemy speed...
                                if (player.speed >= enemy[i].speed)
                                {
                                    // ... alert the player and display health and damage stats
                                    Console.WriteLine($"You have encountered {enemy[i].name}!");
                                    Console.WriteLine($"Your health: {player.health} | Your damage: {player.damage} | {enemy[i].name}'s health: {enemy[i].health} | {enemy[i].name}'s damage: {enemy[i].damage}");
                                    Console.Write("Press 1 to attack, or w, a, s, d to run!\n");
                                    // Ask player of the move they want to perform
                                    AskMove(maze, player, enemy[i], 1);
                                    // After every move, the player will take damage from the enemy as long as the enemy is alive
                                    if (enemy[i].alive == true)
                                        player.TakeDamage(enemy[i], maze);
                                }
                                else
                                {
                                    // ... and enemy speed is greater than player speed ...
                                    Console.WriteLine($"{enemy[i].name} has attacked you!");
                                    // ... player will automatically take damage
                                    player.TakeDamage(enemy[i], maze);
                                    Console.WriteLine("Press 1 to attack, or w, a, s, d to run!");
                                    // Ask player of the move they want to perform
                                    AskMove(maze, player, enemy[i], 1);
                                }
                                // Display health and damage stats and print maze after every move
                                Console.WriteLine($"Your health: {player.health} | Your damage: {player.damage} | {enemy[i].name}'s health: {enemy[i].health} | {enemy[i].name}'s damage: {enemy[i].damage}");
                                maze.PrintMaze(player, enemy);
                                break;
                                
                            }
                        }

                        if (enemyEncounter == false)
                        {
                            // Else if none of the enemies and the player are not next to each other, ask the player to move and print the maze afterwards
                            Console.Write("Enter w, a, s, or d to move");
                            AskMove(maze, player, enemy[0], 0);
                            maze.PrintMaze(player, enemy);
                        }
                    }
                // See initial stats
                case "2":
                    Console.WriteLine("PLAYER STATS:");
                    Console.WriteLine($"Health: {player.health}");
                    Console.WriteLine($"Speed: {player.speed}");
                    Console.WriteLine($"Level: {player.level}");
                    Console.WriteLine($"EXP: {player.exp}");
                    break;
                // Exit the game
                case "3":
                    Console.WriteLine("Exiting the game...");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
