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
        Double result = 0; //Stores result information
        String operationPerformed = ""; //Stores textbox information
        bool dotCheck = false;

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
            if (textBox_Result.Text == "0"){
                textBox_Result.Clear(); //Clear() function for clearing the textbox area
                dotCheck = false;
                }
            //create new Button object -- for reading what number is pressed in calculator
            Button b = (Button)sender; //cast sender to button
                        
            //Goes through textBox string 
            for(int i = 0 ; i < textBox_Result.Text.Length; i++){
                if(textBox_Result.Text[i] != '.'){

                    //dotCheck = false;
                } 
                else{
                    dotCheck = true;
                }
            }

            if(dotCheck == true && b.Text != ".")
            {
                 textBox_Result.Text += b.Text; //will get whatever button(who has event Click set as button_click) is pressed on calculator 
            }
            else if(dotCheck == false)
            {
                textBox_Result.Text += b.Text; //will get whatever button(who has event Click set as button_click) is pressed on calculator 
            }
           
           
                
        }

        private void Button_Operetor(object sender, EventArgs e)
        {
            //Creating new Button object -- for reading what operator is pressed in calculator
            Button b = (Button)sender;

            if(result != 0) //if result is not equal to 0
            {
                buttonEqual.PerformClick(); //Generates a Click event for a button
                operationPerformed = b.Text; //Gets wich operetor was pressed
                labelResults.Text = result + " " + operationPerformed; //Set LabelResult
                textBox_Result.Text = "0";//set textBox_result bact to 0 (starting point)
            }
            else
            {
                operationPerformed = b.Text;
                result = Double.Parse(textBox_Result.Text);
                labelResults.Text = result + " " + operationPerformed;
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
            result = 0;
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
                    textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (result / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textBox_Result.Text); //Prase string do doulbe
            labelResults.Text = result.ToString("0.######"); //Prase double to string to show result in resulttable
            textBox_Result.Text = "0"; //set textBox_Result back to 0 (Starting point)

    }
    }
}
