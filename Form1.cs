using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0; //Stores result information
        String operationPerformed = ""; //Stores textbox information
        bool isOperationPerformed = false;

        /* Attention!
         * Programm remembers last operator called , if user presses a number after calcutions wihtout cleaning result,
            programm will automaticly calculate result with number user pressed with last operator called  
            (Result / Operetor last used / new number = new result) */

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Button_click(object sender, EventArgs e)
        {

            //If statement for clearing the default set 0 from textBox as u start pressing numbers
            if (textBox_Result.Text == "0")
                textBox_Result.Clear(); //Clear() function for clearing the textbox area

            //create new Button object -- for reading what number is pressed in calculator
            Button button = (Button)sender; //cast sender to button

            textBox_Result.Text += button.Text; //will get whatever button(who has event Click set as button_click) is pressed on calculator 
        }

        private void Button_Operetor(object sender, EventArgs e)
        {
            //Creating new Button object -- for reading what operator is pressed in calculator
            Button button = (Button)sender;

            if(resultValue != 0) //if result is not equal to 0
            {
                buttonEqual.PerformClick(); //Generates a Click event for a button
                operationPerformed = button.Text; //Gets wich operetor was pressed
                labelResults.Text = resultValue + " " + operationPerformed; //Set LabelResult
                textBox_Result.Text = "0";//set textBox_result bact to 0 (starting point)
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                labelResults.Text = resultValue + " " + operationPerformed;
                textBox_Result.Text = "0";
            }

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0"; //Pressing C clears only textbox
        }

        private void ButtonClearE_Click(object sender, EventArgs e)
        {
            //Pressing CE clears all 
            textBox_Result.Text = "0";
            resultValue = 0;
            labelResults.Text = " ";
        }

        private void TextBox_Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerformed) //Setting what pressed operator does
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text); //Prase string do doulbe
            labelResults.Text = resultValue.ToString("0.######"); //Prase double to string to show result in resulttable
            textBox_Result.Text = "0"; //set textBox_Result back to 0 (Starting point)

    }
    }
}
