using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading;

namespace Battleships
{
    static class GlobalContext
    {
        // Reference to the main menu form instance.
        public static MainMenuForm MainMenuForm { get; set; }
        
        // Method for generating random numbers.
        public static int RandomNumber(int max) 
        {
            Random random = new Random();
            return random.Next(max);
        }
    }

    // Player information structure.
    public class Player
    {
        // Player's name.
        public string Name { get; set; }
        // Player's password.
        public string Password { get; set; }
        // Locations of the players' ships.
        public int[,] ShipSet { get; set; }
        // [true] revieled / [false] unrevieled.
        public bool[,] RevealedCells { get; set; }
        // Last revieled cells.
        public int[] LastRevieledCells { get; set; }
        // Ships cells left.
        public int[] ShipLeftCells { get; set; }

        // Hits count.
        public int Hits { get; set; }
        // Misses count.
        public int Misses { get; set; }
        // Hit ratio.
        public double HitRatio { get; set; }
        // Unrevealed cells count.
        public int UnrevealedCells { get; set; }
        // Ships cells count.
        public int ShipCells { get; set; }
        // Ships left count.
        public int ShipsLeft { get; set; }

        // Battle log content.
        public string BattleLog { get; set; }

        public Player()
        {
            ShipLeftCells = new int[] { 2, 3, 3, 4, 5 };
            Hits = 0;
            Misses = 0;
            HitRatio = 0;
            UnrevealedCells = 100;
            ShipCells = 17;
            ShipsLeft = 5;
            BattleLog = "";
            ShipSet = new int[10, 10];
            RevealedCells = new bool[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ShipSet[i, j] = -1;
                    RevealedCells[i, j] = false;
                }
            }

            LastRevieledCells = new int[2];
            LastRevieledCells[0] = -1;
            LastRevieledCells[1] = -1;
        }
    }

    static class Game
    {
        // AI cleverness, 1 for dumb, 10 for mastermind.
        static int AICleverness = 8;

        // Ship lengths.
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };

        // Label arrays for battle log conversation.
        public static char[] letterLabels = new char[10] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public static string[] numberLables = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public static string[] shipLabels = new string[5] { "Patrol Boat (2, Yellow)", "Submarine (3, Red)", "Destroyer (3, Green)", "Battleship (4, Blue)", "Aircraft Carrier (5, Violet)" };

        // [true] singleplayer / [false] multiplayer.
        public static bool gameMode;
        // [true] player1's move / [false] player2's move.
        public static bool playerSwitch;
        // Round count.
        public static int roundCount;

        // Player information.
        public static Player player1;
        public static Player player2;

        // Inicalize the game.
        static public void Initialize()
        {
            playerSwitch = true;
            roundCount = 1;
        }
        // Method returns whether a cell can contain a ship.
        // First implementation is dedicated for the ship deployment.
        static public bool CanThereBeShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            // Is the index of the most upper-left cell within the bounds.
            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            if (isHorizontal)
            {
                if (cellX + Game.shipLengths[currentShip] - 1 <= 9)
                {
                    // Searching for an invalid layout on the grid.
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(9, cellX + Game.shipLengths[currentShip]); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(9, cellY + 1); j++)
                        {
                            if (shipSet[i, j] != -1)
                            {
                                // Invalid layout found.
                                return false;
                            }
                        }
                    }

                    // Invalid layout not found.
                    return true;
                }
                else
                {
                    // Out of the bounds of the grid.
                    return false;
                }
            }
            else
            {
                // Vertical validation.
                if (cellY + Game.shipLengths[currentShip] - 1 <= 9)
                {
                    // Searching for an invalid layout on the grid.
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(9, cellX + 1); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(9, cellY + Game.shipLengths[currentShip]); j++)
                        {
                            if (shipSet[i, j] != -1)
                            {
                                // Invalid layout found.
                                return false;
                            }
                        }
                    }

                    // Invalid layout not found.
                    return true;
                }
                else
                {
                    // Out of the bounds of the grid.
                    return false;
                }
            }
        }

        // Method returns whether a cell can contain a ship.
        // Second implementation is dedicated for AI logic.
        static public bool CanThereBeShip(int currentShip, int cellX, int cellY, bool isHorizontal, Player player)
        {
            // Is the index of the most upper-left cell within the bounds.
            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            if (isHorizontal)
            {
                if (cellX + Game.shipLengths[currentShip] - 1 <= 9)
                {
                    // Searching for an invalid layout on the grid.
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(9, cellX + Game.shipLengths[currentShip]); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(9, cellY + 1); j++)
                        {
                            // Ship position cells.
                            if (i >= cellX && i < cellX + shipLengths[currentShip] && j == cellY)
                            {
                                // If the cell is revealed and there is water or a sunken ship.
                                if ((player.RevealedCells[i, j] && player.ShipSet[i, j] == -1) || (player.ShipSet[i, j] != -1 && player.ShipLeftCells[player.ShipSet[i, j]] == 0))
                                {
                                    // Invalid layout found.
                                    return false;
                                }

                            }
                            // Neighbouring cells.
                            else
                            {
                                // If there is a neighbouring revealed ship cell.
                                if (player.RevealedCells[i, j] && player.ShipSet[i, j] != -1)
                                {
                                    // Invalid layout found.
                                    return false;
                                }
                            }
                        }
                    }

                    // Invalid layout not found.
                    return true;
                }
                else
                {
                    // Out of the bounds of the grid.
                    return false;
                }
            }
            else
            {
                // Vertical validation.
                if (cellY + Game.shipLengths[currentShip] - 1 <= 9)
                {
                    // Searching for an invalid layout on the grid.
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(9, cellX + 1); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(9, cellY + Game.shipLengths[currentShip]); j++)
                        {
                            // Ship position cells.
                            if (j >= cellY && j < cellY + shipLengths[currentShip] && i == cellX)
                            {
                                // If the cell is revealed and there is water or a sunken ship.
                                if (player.RevealedCells[i, j] && (player.ShipSet[i, j] == -1) || (player.ShipSet[i, j] != -1 && player.ShipLeftCells[player.ShipSet[i, j]] == 0))
                                {
                                    // Invalid layout found.
                                    return false;
                                }

                            }
                            // Neighbouring cells.
                            else
                            {
                                // If there is a neighbouring revealed ship cell.
                                if (player.RevealedCells[i, j] && player.ShipSet[i, j] != -1)
                                {
                                    // Invalid layout found.
                                    return false;
                                }
                            }
                        }
                    }

                    // Invalid layout not found.
                    return true;
                }
                else
                {
                    // Out of the bounds of the grid.
                    return false;
                }
            }
        }

        // Deploy a ship into a ship set.
        static public void DeployShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            if (isHorizontal)
            {
                for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                {
                    // Deploy into a ship set.
                    shipSet[cellX + i, cellY] = currentShip;
                }
            }
            else
            {
                for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                {
                    // Deploy into a ship set.
                    shipSet[cellX, cellY + i] = currentShip;
                }
            }

        }

        // Delete a ship from a ship set, dedicated for the deployment for delete ship functionality.
        static public void DeleteShip(int currentShip, int[,] shipSet)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (shipSet[x, y] == currentShip)
                    {
                        shipSet[x, y] = -1;
                    }
                }
            }
        }

        // Random ship deployment.
        static public void AIDeployShips()
        {
            // Stepwise through all ships.
            for (int currentShip = 0; currentShip < 5; currentShip++)
            {
                // Inicializating the list of possibilities.
                List<int[]> possibilities = new List<int[]>();
                List<bool> rotationAspects = new List<bool>();

                // For all cells in grid 10 x 10.
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        // Is there a valid horizontal layout at [x,y] in the current grid?
                        if (CanThereBeShip(currentShip, x, y, true, player2.ShipSet))
                        {
                            // Add into possibilities, [x, y].
                            possibilities.Add(new int[2] { x, y });
                            // At this index, add the horizontal rotation aspect.
                            rotationAspects.Add(true);
                        }

                        // Is there a valid vertical layout at [x,y] in the current grid?
                        if (CanThereBeShip(currentShip, x, y, false, player2.ShipSet))
                        {
                            // Add into possibilities, [x, y].
                            possibilities.Add(new int[2] { x, y });
                            // At this index, add the vertical rotation aspect.
                            rotationAspects.Add(false);
                        }
                    }
                }

                // Choosing possibility.
                int numberOfChosen = GlobalContext.RandomNumber(possibilities.Count);

                // Deploy the ship into the ship set.
                DeployShip(currentShip, possibilities[numberOfChosen][0], possibilities[numberOfChosen][1], rotationAspects[numberOfChosen], Game.player2.ShipSet);
            }
        }

        // Adds probability to all the spots the ship can be deployed.
        static private void probabilitySetAddShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] probabilitySet)
        {
            for (int i = 0; i < shipLengths[currentShip]; i++)
            {
                if (isHorizontal)
                {
                    probabilitySet[cellX + i, cellY]++;
                }
                else
                {
                    probabilitySet[cellX, cellY + i]++;
                }
            }
        }

        // AI method for choosing a cell to hit.
        static public int[] AIChooseCellToHit(Player player)
        {
            // Prepared array of ship cell probabilities and its inicialization
            int[,] probabilitySet = new int[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    probabilitySet[x, y] = 0;
                }
            }
           
            // Revieled cells of partially revieled ships.
            List<int[]> partialRevealedCells = new List<int[]>();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (player.RevealedCells[x, y] && player.ShipSet[x, y] != -1 && player.ShipLeftCells[player.ShipSet[x, y]] != 0)
                    {
                        // Partially revealed ship found at [x, y].
                        partialRevealedCells.Add(new int[2]{x,y});
                    }
                }
            }

            // Are there any partially revealed ships?
            if (partialRevealedCells.Count != 0)
            {
                // For every revealed cell of a partially revealed ship.
                foreach (int[] partialReveleadCell in partialRevealedCells)
                {
                    // Calculate the cross probability.
                    for (int currentShip = 0; currentShip < 5; currentShip++)
                    {
                        // For all the available ships left.
                        if (player.ShipLeftCells[currentShip] != 0)
                        {
                            // Apply cross search for each parial revealation cell.
                            for (int coorOffset = 0; coorOffset < shipLengths[currentShip]; coorOffset++)
                            {
                                if (CanThereBeShip(currentShip, partialReveleadCell[0] - coorOffset, partialReveleadCell[1], true, player))
                                {
                                    probabilitySetAddShip(currentShip, partialReveleadCell[0] - coorOffset, partialReveleadCell[1], true, probabilitySet);
                                }
                                if (CanThereBeShip(currentShip, partialReveleadCell[0], partialReveleadCell[1] - coorOffset, false, player))
                                {
                                    probabilitySetAddShip(currentShip, partialReveleadCell[0], partialReveleadCell[1] - coorOffset, false, probabilitySet);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // No partially revealed ship found.
                for (int currentShip = 0; currentShip < 5; currentShip++)
                {
                    // For all the available ships left.
                    if (player.ShipLeftCells[currentShip] != 0)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            for (int y = 0; y < 10; y++)
                           {
                                // Validate the possible deployment and if valid add it to the probabilities.
                                if (CanThereBeShip(currentShip, x, y, true, player))
                                {
                                    probabilitySetAddShip(currentShip, x, y, true, probabilitySet);
                                }
                                if (CanThereBeShip(currentShip, x, y, false, player))
                                {
                                    probabilitySetAddShip(currentShip, x, y, false, probabilitySet);
                                }
                            }
                        }
                    }
                }
            }

            /*
             * Basic idea of the algorith is simple--choose a random cell among all the cells
             * with the top percentile. The percentile threshold is defined by the AICleverness.
            */

            // Find the maximum possibility of a cell to contain a ship.
            int maxPossibility = -1;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (probabilitySet[x, y] > maxPossibility && !player.RevealedCells[x, y])
                    {
                        maxPossibility = probabilitySet[x, y];
                    }
                }
            }

            // Collect all the cells with a favourable probability to contain a ship.
            List<int[]> favourableCells = new List<int[]>();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    // Is there any partially revealed cell?
                    if (partialRevealedCells.Count != 0)
                    {
                        // Collect the cell that have the best possibility of being a ship cell.
                        if (probabilitySet[x, y] == maxPossibility && !player.RevealedCells[x, y])
                        {
                            favourableCells.Add(new int[] { x, y });
                        }
                    }
                    else
                    {
                        // Collect the cells that have favourable possibility of being a ship cell.
                        if (probabilitySet[x, y] >= Math.Max((maxPossibility / 10 * AICleverness), 1) && !player.RevealedCells[x, y])
                        {
                            favourableCells.Add(new int[] { x, y });
                        }
                    }
                }
            }

            // Return a random cell out of all fabourable cells.
            return favourableCells[GlobalContext.RandomNumber(favourableCells.Count)];
        }

        // Perform an attack of a player on a player at a given cell.
        // [true] if game is over and the attacker won / [false] if not.
        static public bool PerformAttack(int cellX, int cellY, Player attacker, Player attacked)
        {
            string attackerLogNote = "--> " + String.Format("{0:000}", roundCount) + ".round:  You: " + attacker.Name + ", attack your enemy: "
                + attacked.Name + " at cell [ " + letterLabels[cellX] + "," + numberLables[cellY] + " ]. ";
            string attackedLogNote = "<-- " + String.Format("{0:000}", roundCount) + ".round:  You: " + attacked.Name 
                + ", have been attacked by your enemy: " + attacker.Name + " at cell [ " + letterLabels[cellX] + "," + numberLables[cellY] + " ]. ";

            // Play a shot sound and wait few seconds.
            AudioContext.PlayShot();
            Thread.Sleep(3000);

            // Mark the cell as revealed.
            attacked.RevealedCells[cellX, cellY] = true;

            // Decrease the count of unrevealed cells.
            attacked.UnrevealedCells--;
            
            // Mark the lastly revealed cell.
            attacked.LastRevieledCells[0] = cellX;
            attacked.LastRevieledCells[1] = cellY;
            
            // Is the attack a hit?
            if (attacked.ShipSet[cellX, cellY] != -1)
            {
                AudioContext.PlayHit();
                // Decrease the amount of ship cells left.
                attacked.ShipCells--;
                // Increase the count of attacker's hits.
                attacker.Hits++;
                // Recalculate the attacker's hit ration.
                attacker.HitRatio = Convert.ToDouble(attacker.Hits) / Convert.ToDouble(Game.roundCount); 

                // Decrease the amount of cells left for the ship that has been hit.
                attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]]--;

                attackedLogNote = attackedLogNote + "Your " + shipLabels[attacked.ShipSet[cellX, cellY]] + " have been hit, "
                    + attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]].ToString() + " ship cells left out of it. ";
                attackerLogNote = attackerLogNote + "You've hit " + attacked.Name + "'s ship. ";

                if (attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]] == 0)
                {
                    // The ship was completely shot down.
                    attacked.ShipsLeft--;

                    attackedLogNote = attackedLogNote + "It is sunken, now. You have " + attacked.ShipsLeft.ToString() + " more ships left. ";
                    attackerLogNote = attackerLogNote + "You have sunken it. You have found out it was: " + 
                        shipLabels[attacked.ShipSet[cellX, cellY]] + ". You have " + attacked.ShipsLeft.ToString() + " more ships to sink. ";

                    // How many neighbouring cells has been revealed with the sunken ship.
                    int extraRevealedCells = 0;

                    // Reveal neighbouring cells of the sunken ship.
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (attacked.ShipSet[x, y] == attacked.ShipSet[cellX, cellY])
                            {
                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y - 1])
                                    {
                                        attacked.RevealedCells[x - 1, y - 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y])
                                    {
                                        attacked.RevealedCells[x - 1, y] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y + 1])
                                    {
                                        attacked.RevealedCells[x - 1, y + 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try 
                                {
                                    if (!attacked.RevealedCells[x, y - 1])
                                    {
                                        attacked.RevealedCells[x, y - 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try 
                                {
                                    if (!attacked.RevealedCells[x, y + 1])
                                    {
                                        attacked.RevealedCells[x, y + 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try 
                                {
                                    if (!attacked.RevealedCells[x + 1, y - 1])
                                    {
                                        attacked.RevealedCells[x + 1, y - 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try 
                                {
                                    if (!attacked.RevealedCells[x + 1, y])
                                    {
                                        attacked.RevealedCells[x + 1, y] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y + 1])
                                    {
                                        attacked.RevealedCells[x + 1, y + 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };
                            }
                        }
                    }

                    // Decrease the number of unrevealed cells.
                    attacked.UnrevealedCells -= extraRevealedCells;

                    attackedLogNote = attackedLogNote + "With your last ship sunken, " + attacker.Name + " revealed himself another " + extraRevealedCells.ToString() + " cells of water. ";
                    attackerLogNote = attackerLogNote + "With your last attack, you have also revealed another " + extraRevealedCells.ToString() + " cells of water. "; 

                    // Is the game over?
                    if (attacked.ShipsLeft == 0)
                    {
                        attackerLogNote = attackerLogNote + attacker.Name.ToString() + " has won the battle!";
                        attacked.BattleLog = attacked.BattleLog + attackedLogNote + "\n";
                        attacker.BattleLog = attacker.BattleLog + attackerLogNote + "\n";
                        return true;
                    }
                    else
                    {
                        // Else return a false, some ships are left
                        attacked.BattleLog = attacked.BattleLog + attackedLogNote + "\n";
                        attacker.BattleLog = attacker.BattleLog + attackerLogNote + "\n";
                        return false;
                    }
                }
                else
                {
                    //There are some ship cells left in this ship, so that Game dont end
                    attacked.BattleLog = attacked.BattleLog + attackedLogNote + "\n";
                    attacker.BattleLog = attacker.BattleLog + attackerLogNote + "\n";
                    return false;
                }
            }
            else
            {
                // The attack is not a hit.
                attackedLogNote = attackedLogNote + " Luckily nothing happened, it hit the water.";
                attackerLogNote = attackerLogNote + " Unfortunately, it is just hit the water.";
                attacker.Misses++;
                attacker.HitRatio = Convert.ToDouble(attacker.Hits) / Convert.ToDouble(Game.roundCount); 

                AudioContext.PlaySplash();
                attacked.BattleLog = attacked.BattleLog + attackedLogNote + "\n";
                attacker.BattleLog = attacker.BattleLog + attackerLogNote + "\n";
                return false;
            }

        } 
    }

    static class GraphicContext
    {
        static private readonly Bitmap hitImage = new Bitmap(Properties.Resources.hitImage);
        static private readonly Bitmap splashImage = new Bitmap(Properties.Resources.splashImage);
        static public readonly Bitmap[] deckImages = new Bitmap[4];

        static GraphicContext()
        {
            deckImages[0] = new Bitmap(Properties.Resources.deck0Image);
            deckImages[1] = new Bitmap(Properties.Resources.deck1Image);
            deckImages[2] = new Bitmap(Properties.Resources.deck2Image);
            deckImages[3] = new Bitmap(Properties.Resources.deck3Image);
        }

        // Opacity settings.
        private static int generalOpacity = 150;
        private static int spacialOpacity = 200;
        public static readonly Brush[] colors = new SolidBrush[8] 
        {
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 255, 0)),   // [0] Yellow
            new SolidBrush(Color.FromArgb(generalOpacity, 255, 0, 0)),     // [1] Red
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 255, 0)),     // [2] Green
            new SolidBrush(Color.FromArgb(generalOpacity, 0, 0, 255)),     // [3] Blue
            new SolidBrush(Color.FromArgb(generalOpacity, 150, 0, 200)),   // [4] Violet
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 255, 255)), // [5] White
            new SolidBrush(Color.FromArgb(spacialOpacity, 0, 255, 255)),   // [6] Azure
            new SolidBrush(Color.FromArgb(spacialOpacity, 255, 0, 140))    // [7] Magenta
        };

        static public int GetCoorX(Form form, PictureBox deckPictureBox)
        {
            int borderWidth = (form.Width - form.ClientSize.Width) / 2;
            int coorX = Control.MousePosition.X - form.Location.X - deckPictureBox.Location.X - borderWidth;
            return (coorX < 33 || coorX > 342) ? -1 : coorX;
        }

        static public int GetCoorY(Form form, PictureBox deckPictureBox)
        {
            int borderWidth = (form.Width - form.ClientSize.Width) / 2;
            int titleBarHeight = form.Height - form.ClientSize.Height - 2 * borderWidth;
            int coorY = Control.MousePosition.Y - form.Location.Y - deckPictureBox.Location.Y - titleBarHeight - borderWidth;
            return (coorY < 33 || coorY > 342) ? -1 : coorY;
        }

        static public int GetCell(int coor)
        {
            return (coor - 33) / 31;
        }

        // PictureBox paint event handler for drawing a colored cell.
        static public void DrawColoredCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(GraphicContext.colors[color], (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1, 30, 30);
        }

        static public void DrawHitCell(int cellX, int cellY, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            g.DrawImage(hitImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        // PictureBox paint event handler for drawing a hit cell.
        static public void DrawHitCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(hitImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        // PictureBox paint event handler for drawing a splash cell.
        static public void DrawSplashCell(int cellX, int cellY, PaintEventArgs e)
        {
            e.Graphics.DrawImage(splashImage, (cellX + 1) * 31 + 1, (cellY + 1) * 31 + 1);
        }

        static public void DrawInnerFrameCell(int cellX, int cellY, int color, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            Pen framePen = new Pen(colors[color], 3);
            g.DrawRectangle(framePen, (cellX + 1) * 31 + 3, (cellY + 1) * 31 + 3, 25, 25);
        }

        static public void DrawOuterFrameCell(int cellX, int cellY, int color, Form form, PictureBox deckPictureBox)
        {
            Graphics g = deckPictureBox.CreateGraphics();
            Pen framePen = new Pen(colors[color], 3);
            g.DrawRectangle(framePen, (cellX + 1) * 31 + -3, (cellY + 1) * 31 + -3, 37, 37);
        }

        // PictureBox paint event handler for drawing an outer frame around a cell.
        static public void DrawOuterFrameCell(int cellX, int cellY, int color, PaintEventArgs e)
        {
            Pen framePen = new Pen(colors[color], 3);
            e.Graphics.DrawRectangle(framePen, (cellX + 1) * 31 + -3, (cellY + 1) * 31 + -3, 37, 37);
        }

        // PictureBox paint event handler for drawing a ship set on a deck.
        static public void DrawShipSet(int[,] shipSet, PaintEventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (shipSet[x, y] != -1)
                    {
                        DrawColoredCell(x, y, shipSet[x, y], e);
                    }
                }
            }
        }

        // PictureBox paint event handler for drawing a deck status of all the cells.
        static public void DrawDeckStatus(bool[,] deckStatus, int[,] shipSet, PaintEventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (deckStatus[x, y])
                    {
                        if (shipSet[x, y] != -1)
                        {
                            DrawHitCell(x, y, e);
                        }
                        else
                        {
                            DrawSplashCell(x, y, e);
                        }
                    }
                }
            }
        }

        // PictureBox paint event handler for drawing sunken ships.
        static public void DrawSunkenShips(int[,] shipSet, int[] ShipLeftCells, PaintEventArgs e) 
        {
            for (int currentShip = 0; currentShip < 5; currentShip++)
            {
                if (ShipLeftCells[currentShip] == 0)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (shipSet[x, y] == currentShip)
                            {
                                DrawColoredCell(x, y, currentShip, e);
                            }
                        }
                    }
                }
            }
        }
    }

    static class AudioContext
    {
        static public readonly SoundPlayer menuSoundPlayer = new SoundPlayer(Properties.Resources.menuSound);
        static public readonly SoundPlayer drumSoundPlayer = new SoundPlayer(Properties.Resources.drumSound);
        static public readonly SoundPlayer vicotrySoundPlayer = new SoundPlayer(Properties.Resources.victorySound);

        static public readonly SoundPlayer[] shotSoundPlayers = new SoundPlayer[3];
        static public readonly SoundPlayer[] splashSoundPlayers = new SoundPlayer[3];
        static public readonly SoundPlayer[] hitSoundPlayers = new SoundPlayer[3];

        static AudioContext()
        {
            shotSoundPlayers[0] = new SoundPlayer(Properties.Resources.shot0Sound);
            shotSoundPlayers[1] = new SoundPlayer(Properties.Resources.shot1Sound);
            shotSoundPlayers[2] = new SoundPlayer(Properties.Resources.shot2Sound);

            splashSoundPlayers[0] = new SoundPlayer(Properties.Resources.splash0Sound);
            splashSoundPlayers[1] = new SoundPlayer(Properties.Resources.splash1Sound);
            splashSoundPlayers[2] = new SoundPlayer(Properties.Resources.splash2Sound);

            hitSoundPlayers[0] = new SoundPlayer(Properties.Resources.hit0Sound);
            hitSoundPlayers[1] = new SoundPlayer(Properties.Resources.hit1Sound);
            hitSoundPlayers[2] = new SoundPlayer(Properties.Resources.hit2Sound);
        }

        static public void PlayShot()
        {
            AudioContext.shotSoundPlayers[GlobalContext.RandomNumber(shotSoundPlayers.Length)].Play();
        }

        static public void PlaySplash()
        {
            AudioContext.splashSoundPlayers[GlobalContext.RandomNumber(splashSoundPlayers.Length)].Play();
        }

        static public void PlayHit()
        {
            AudioContext.hitSoundPlayers[GlobalContext.RandomNumber(hitSoundPlayers.Length)].Play();
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Start to play the main menu sound in loop.
            AudioContext.menuSoundPlayer.PlayLooping();

            // Initialize the main menu and run the application.
            MainMenuForm mainMenuForm = new MainMenuForm();
            GlobalContext.MainMenuForm = mainMenuForm;
            Application.Run(mainMenuForm);
        }
    }
}
