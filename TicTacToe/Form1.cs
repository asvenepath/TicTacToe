using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    //Name: Asvene Pathmanathan
    //Date: December 19, 2022
    //Title: TicTacToe
    //Purpose: Create an AI-smart ("Impossible") TicTacToe game

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Global variables
        bool blnClickedOne = false;
        bool blnClickedTwo = false;
        bool blnClickedThree = false;
        bool blnClickedFour = false;
        bool blnClickedFive = false;
        bool blnClickedSix = false;
        bool blnClickedSeven = false;
        bool blnClickedEight = false;
        bool blnClickedNine = false;

        bool blnPlayerTurn = true;
        bool blnWinner = false;

        int intCounterPlayer = -1;
        int intCounterComp = -1;
        int intCompScore = 0;
        int intPlayerScore = 0;
        int intDrawScore = 0;
        int intMovesPlayer = 0;

        int[] intPlayerMoves = { -99, -99, -99, -99, -99 };
        int[] intCompMoves = { -99, -99, -99, -99, -99 };

        Random rnd = new Random();

        //Resetting the game by resetting the values of variables
        public void ResetGame()
        {
            for (int i = 0; i < intPlayerMoves.Length; i++)
            {
                intPlayerMoves[i] = -99;
                intCompMoves[i] = -99;
            }
            blnClickedOne = false;
            blnClickedTwo = false;
            blnClickedThree = false;
            blnClickedFour = false;
            blnClickedFive = false;
            blnClickedSix = false;
            blnClickedSeven = false;
            blnClickedEight = false;
            blnClickedNine = false;

            blnPlayerTurn = true;

            intCounterPlayer = -1;
            intCounterComp = -1;
            blnWinner = false;

            //Resetting the button text and colour
            this.btnONE.Text = "?";
            btnONE.BackColor = Color.White;
            this.btnTWO.Text = "?";
            btnTWO.BackColor = Color.White;
            this.btnTHREE.Text = "?";
            btnTHREE.BackColor = Color.White;
            this.btnFOUR.Text = "?";
            btnFOUR.BackColor = Color.White;
            this.btnFIVE.Text = "?";
            btnFIVE.BackColor = Color.White;
            this.btnSIX.Text = "?";
            btnSIX.BackColor = Color.White;
            this.btnSEVEN.Text = "?";
            btnSEVEN.BackColor = Color.White;
            this.btnEIGHT.Text = "?";
            btnEIGHT.BackColor = Color.White;
            this.btnNINE.Text = "?";
            btnNINE.BackColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {
            

        }
        //Exits the application when quit button is pressed
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Game resets when the restart button is chosen
        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetGame();
            MessageBox.Show("Please choose your first move");
        }

        public void checkDraw()
        {
            //Determines if a draw has occured. Outputs "DRAW" and resets game
            if (blnClickedOne == true && blnClickedTwo == true && blnClickedThree == true && blnClickedFour == true
                && blnClickedFive == true && blnClickedSix == true && blnClickedSeven == true && blnClickedEight == true
                && blnClickedNine == true && checkAnyWinner(intCompMoves) == false && checkAnyWinner(intPlayerMoves) == false)
            {
                MessageBox.Show("DRAW");
                //Adds one to the draw score
                intDrawScore++;
                this.lblDrawScore.Text = intDrawScore.ToString();
                ResetGame();
            }

        }

        //Outputs message if computer or player won
        public void checkWinner()
        {
            //Checks if computer won
            if (checkAnyWinner(intCompMoves))
            {
                MessageBox.Show("Computer Won.");
                intCompScore++;
                this.lblCPUNum.Text = intCompScore.ToString();
                ResetGame();
            }
            //Checks if player won
            else if (checkAnyWinner(intPlayerMoves))
            {
                MessageBox.Show("You Won!");
                intPlayerScore++;
                this.lblPlScore.Text = intPlayerScore.ToString();
                ResetGame();
            }
        }
        public bool checkAnyWinner(int[] intMoves)
        {
            //Calculates if either player has three moves in a row
            //if 3 squares in a row equal to 15 (magic square), there is a winner
            if (intMoves[0] + intMoves[1] + intMoves[2] == 15)
            {
                return true;
            }
            else if (intMoves[0] + intMoves[1] + intMoves[3] == 15)
            {
                return true;
            }
            else if (intMoves[0] + intMoves[1] + intMoves[4] == 15)
            {
                return true;
            }
            else if (intMoves[1] + intMoves[2] + intMoves[3] == 15)
            {
                return true;
            }
            else if (intMoves[1] + intMoves[3] + intMoves[4] == 15)
            {
                return true;
            }
            else if (intMoves[2] + intMoves[3] + intMoves[4] == 15)
            {
                return true;
            }
            else if (intMoves[1] + intMoves[2] + intMoves[4] == 15)
            {
                return true;
            }
            else if (intMoves[0] + intMoves[2] + intMoves[3] == 15)
            {
                return true;
            }
            else if (intMoves[0] + intMoves[2] + intMoves[4] == 15)
            {
                return true;
            }
            else if (intMoves[0] + intMoves[3] + intMoves[4] == 15)
            {
                return true;
            }
            //No three squares rows equal to 15 yet
            else
            {
                return false;
            }

        }

        public void ComputerMove()
        {
            intCounterComp++;
            int rndMove;

            while (true)
            {
                //Pt.1 Computer prioritizes checking off the third box in a row to win
                //Pt.1a: Computer gets a diagonal win
                if (btnONE.Text == "O" && btnFIVE.Text == "O" && btnNINE.Text == "?")
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "?" && btnFIVE.Text == "O" && btnNINE.Text == "O")
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "O" && btnFIVE.Text == "?" && btnNINE.Text == "O")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "O" && btnFIVE.Text == "O" && btnSEVEN.Text == "?")
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "?" && btnFIVE.Text == "O" && btnSEVEN.Text == "O")
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "O" && btnFIVE.Text == "?" && btnSEVEN.Text == "O")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                // pt. 1b) CPU gets a left to right win
                else if (btnTWO.Text == "O" && btnTHREE.Text == "O" && btnONE.Text == "?")
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "O" && btnTHREE.Text == "O" && btnTWO.Text == "?")
                {
                    this.btnTWO.Text = "O";
                    intCompMoves[intCounterComp] = 9;
                    blnClickedTwo = true;
                    btnTWO.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "O" && btnTWO.Text == "O" && btnTHREE.Text == "?")
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnFOUR.Text == "O" && btnFIVE.Text == "O" && btnSIX.Text == "?")
                {
                    this.btnSIX.Text = "O";
                    intCompMoves[intCounterComp] = 3;
                    blnClickedSix = true;
                    btnSIX.BackColor = Color.Crimson;
                    break;
                }
                else if (btnFOUR.Text == "O" && btnSIX.Text == "O" && btnFIVE.Text == "?")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnFOUR.Text == "?" && btnSIX.Text == "O" && btnFIVE.Text == "O")
                {
                    this.btnFOUR.Text = "O";
                    intCompMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnFOUR.BackColor = Color.Crimson;
                    break;
                }
                else if (btnSEVEN.Text == "O" && btnEIGHT.Text == "O" && btnNINE.Text == "?")
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnSEVEN.Text == "O" && btnNINE.Text == "O" && btnEIGHT.Text == "?")
                {
                    this.btnEIGHT.Text = "O";
                    intCompMoves[intCounterComp] = 1;
                    blnClickedEight = true;
                    btnEIGHT.BackColor = Color.Crimson;
                    break;
                }
                else if (btnSEVEN.Text == "?" && btnEIGHT.Text == "O" && btnNINE.Text == "O")
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                //Pt.1c: CPU gets an up to down win
                else if (btnONE.Text == "O" && btnFOUR.Text == "O" && btnSEVEN.Text == "?")
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "?" && btnFOUR.Text == "O" && btnSEVEN.Text == "O")
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "O" && btnFOUR.Text == "?" && btnSEVEN.Text == "O")
                {
                    this.btnFOUR.Text = "O";
                    intCompMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnFOUR.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTWO.Text == "?" && btnFIVE.Text == "O" && btnEIGHT.Text == "O")
                {
                    this.btnTWO.Text = "O";
                    intCompMoves[intCounterComp] = 9;
                    blnClickedTwo = true;
                    btnTWO.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTWO.Text == "O" && btnFIVE.Text == "O" && btnEIGHT.Text == "?")
                {
                    this.btnEIGHT.Text = "O";
                    intCompMoves[intCounterComp] = 1;
                    blnClickedEight = true;
                    btnEIGHT.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTWO.Text == "O" && btnFIVE.Text == "?" && btnEIGHT.Text == "O")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "O" && btnSIX.Text == "O" && btnNINE.Text == "?")
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "?" && btnSIX.Text == "O" && btnNINE.Text == "O")
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "O" && btnSIX.Text == "?" && btnNINE.Text == "O")
                {
                    this.btnSIX.Text = "O";
                    intCompMoves[intCounterComp] = 3;
                    blnClickedSix = true;
                    btnSIX.BackColor = Color.Crimson;
                    break;
                }
                
                
                /////////////////////////////////////////////////////////////////////
                // Pt. 2: Preventing the user from winning 
                //Pt.2a) Preventing diagonal win for user
                if (btnTHREE.Text == "X" && btnFIVE.Text == "X" && btnSEVEN.Text == "?")
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "?" && btnFIVE.Text == "X" && btnSEVEN.Text == "X")
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "X" && btnFIVE.Text == "?" && btnSEVEN.Text == "X")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "X" && btnFIVE.Text == "X" && btnNINE.Text == "?")
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "?" && btnFIVE.Text == "X" && btnNINE.Text == "X")
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "X" && btnFIVE.Text == "?" && btnNINE.Text == "X")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }

                //Pt. 2b) Preventing sideways winning
                if (btnTWO.Text == "X" && btnTHREE.Text == "X" && btnONE.Text == "?")
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "X" && btnTHREE.Text == "X" && btnTWO.Text == "?")
                {
                    this.btnTWO.Text = "O";
                    intCompMoves[intCounterComp] = 9;
                    blnClickedTwo = true;
                    btnTWO.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "X" && btnTWO.Text == "X" && btnTHREE.Text == "?")
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnFOUR.Text == "X" && btnFIVE.Text == "X" && btnSIX.Text == "?")
                {
                    this.btnSIX.Text = "O";
                    intCompMoves[intCounterComp] = 3;
                    blnClickedSix = true;
                    btnSIX.BackColor = Color.Crimson;
                    break;
                }
                else if (btnFOUR.Text == "X" && btnSIX.Text == "X" && btnFIVE.Text == "?")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnFOUR.Text == "?" && btnSIX.Text == "X" && btnFIVE.Text == "X")
                {
                    this.btnFOUR.Text = "O";
                    intCompMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnFOUR.BackColor = Color.Crimson;
                    break;
                }
                else if (btnSEVEN.Text == "X" && btnEIGHT.Text == "X" && btnNINE.Text == "?")
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnSEVEN.Text == "X" && btnNINE.Text == "X" && btnEIGHT.Text == "?")
                {
                    this.btnEIGHT.Text = "O";
                    intCompMoves[intCounterComp] = 1;
                    blnClickedEight = true;
                    btnEIGHT.BackColor = Color.Crimson;
                    break;
                }
                else if (btnSEVEN.Text == "?" && btnEIGHT.Text == "X" && btnNINE.Text == "X")
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                //Pt.2c: Preventing an up or down player cross
                else if (btnONE.Text == "X" && btnFOUR.Text == "X" && btnSEVEN.Text == "?")
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "?" && btnFOUR.Text == "X" && btnSEVEN.Text == "X")
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnONE.Text == "X" && btnFOUR.Text == "?" && btnSEVEN.Text == "X")
                {
                    this.btnFOUR.Text = "O";
                    intCompMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnFOUR.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTWO.Text == "?" && btnFIVE.Text == "X" && btnEIGHT.Text == "X")
                {
                    this.btnTWO.Text = "O";
                    intCompMoves[intCounterComp] = 9;
                    blnClickedTwo = true;
                    btnTWO.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTWO.Text == "X" && btnFIVE.Text == "X" && btnEIGHT.Text == "?")
                {
                    this.btnEIGHT.Text = "O";
                    intCompMoves[intCounterComp] = 1;
                    blnClickedEight = true;
                    btnEIGHT.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTWO.Text == "X" && btnFIVE.Text == "?" && btnEIGHT.Text == "X")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "X" && btnSIX.Text == "X" && btnNINE.Text == "?")
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "?" && btnSIX.Text == "X" && btnNINE.Text == "X")
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (btnTHREE.Text == "X" && btnSIX.Text == "?" && btnNINE.Text == "X")
                {
                    this.btnSIX.Text = "O";
                    intCompMoves[intCounterComp] = 3;
                    blnClickedSix = true;
                    btnSIX.BackColor = Color.Crimson;
                    break;
                }
                //////////////////////////////////////////////////////////////////////////
                //PT. 3: CPU selects the middle box first if it is not chosen by player first
                if (btnFIVE.Text == "?")
                {
                    this.btnFIVE.Text = "O";
                    intCompMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnFIVE.BackColor = Color.Crimson;
                    break;
                }
                //Pt.4: CPU picks a corner space if rndMove equals to an open space
                rndMove = rnd.Next(1, 5);
                if (rndMove == 1 && blnClickedOne == false)
                {
                    this.btnONE.Text = "O";
                    intCompMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnONE.BackColor = Color.Crimson;
                    break;
                }
                else if (rndMove == 2 && blnClickedThree == false)
                {
                    this.btnTHREE.Text = "O";
                    intCompMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnTHREE.BackColor = Color.Crimson;
                    break;
                }
                else if (rndMove == 3 && blnClickedSeven == false)
                {
                    this.btnSEVEN.Text = "O";
                    intCompMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSEVEN.BackColor = Color.Crimson;
                    break;
                }
                else if (rndMove == 4 && blnClickedNine == false)
                {
                    this.btnNINE.Text = "O";
                    intCompMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnNINE.BackColor = Color.Crimson;
                    break;
                }

                //Pt.5: Computer choses the squares adjacent to the corners if rndMove 
                // is equal to an open space
                rndMove = rnd.Next(6, 10);
                if (rndMove == 6 && blnClickedTwo == false)
                {
                    this.btnTWO.Text = "O";
                    intCompMoves[intCounterComp] = 9;
                    blnClickedTwo = true;
                    btnTWO.BackColor = Color.Crimson;
                    break;
                }
                else if (rndMove == 7 && blnClickedFour == false)
                {
                    this.btnFOUR.Text = "O";
                    intCompMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnFOUR.BackColor = Color.Crimson;
                    break;
                }
                else if (rndMove == 8 && blnClickedSix == false)
                {
                    this.btnSIX.Text = "O";
                    intCompMoves[intCounterComp] = 3;
                    blnClickedSix = true;
                    btnSIX.BackColor = Color.Crimson;
                    break;
                }
                else if (rndMove == 9 && blnClickedEight == false)
                {
                    this.btnEIGHT.Text = "O";
                    intCompMoves[intCounterComp] = 1;
                    blnClickedEight = true;
                    btnEIGHT.BackColor = Color.Crimson;
                    break;
                }

            }
            //After CPU goes, a draw is checked, then winner is checked
            checkDraw();
            checkWinner();
        }

        //The user selects a square, each square corresponding to a method
        private void btnONE_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 2;

            //Process
            if (blnClickedOne == false)
            {
                intCounterPlayer++;
                this.btnONE.Text = "X"; //Button is marked X
                intPlayerMoves[intCounterPlayer] = intBtnVal; //Value of  this square is added to 
                // the intPlayerMoves array
                blnPlayerTurn = false; 
                blnClickedOne = true;
                btnONE.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            //Checks draw, winner, then the computer goes
            checkDraw();
            checkWinner();
            ComputerMove();
        }
        private void btnTWO_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 9;

            //Process
            if (blnClickedTwo == false)
            {
                intCounterPlayer++;
                this.btnTWO.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedTwo = true;
                btnTWO.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }
        private void btnTHREE_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 4;

            //Process
            if (blnClickedThree == false)
            {
                intCounterPlayer++;
                this.btnTHREE.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedThree = true;
                btnTHREE.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void btnFOUR_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 7;

            //Process
            if (blnClickedFour == false)
            {
                intCounterPlayer++;
                this.btnFOUR.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedFour = true;
                btnFOUR.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void btnFIVE_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 5;

            //Process
            if (blnClickedFive == false)
            {
                intCounterPlayer++;
                this.btnFIVE.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedFive = true;
                btnFIVE.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void btnSIX_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 3;

            //Process
            if (blnClickedSix == false)
            {
                intCounterPlayer++;
                this.btnSIX.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedSix = true;
                btnSIX.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void btnSEVEN_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 6;

            //Process
            if (blnClickedSeven == false)
            {
                intCounterPlayer++;
                this.btnSEVEN.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedSeven = true;
                btnSEVEN.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void btnEIGHT_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 1;

            //Process
            if (blnClickedEight == false)
            {
                intCounterPlayer++;
                this.btnEIGHT.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedEight = true;
                btnEIGHT.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void btnNINE_Click(object sender, EventArgs e)
        {
            //Variable declaration
            int intBtnVal = 8;

            //Process
            if (blnClickedNine == false)
            {
                intCounterPlayer++;
                this.btnNINE.Text = "X";
                intPlayerMoves[intCounterPlayer] = intBtnVal;
                blnPlayerTurn = false;
                blnClickedNine = true;
                btnNINE.BackColor = Color.LimeGreen;
            }
            intMovesPlayer++;
            checkDraw();
            checkWinner();
            ComputerMove();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblPlScore_Click(object sender, EventArgs e)
        {

        }
    }
}
