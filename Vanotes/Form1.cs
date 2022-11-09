using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vanotes
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");
            previousNotes.DataSource = notes;

        }
        //This will add the note and title section
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            titlebox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notesBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
        //This puts the notes that user takes and saves them from the load button- holds them in an array of strings
        private void new_Click(object sender, EventArgs e)
        {
            titlebox.Text = "";
            notesBox.Text = "";

        }
        // This adds new text so that user can type in it
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) { Console.WriteLine("Not a valid note"); } 
        }
        //This function will catch invalid deleted notes and throw exceptions

        private void save_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titlebox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = notesBox.Text;
            }
            else
            {
                notes.Rows.Add(titlebox.Text, notesBox.Text);
            }
            titlebox.Text = "";
            notesBox.Text = "";
            editing = false;
        }
        //This will take the input from the user and save it so that they can add more underneath it if needed
        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titlebox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notesBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
        //This will help to save and retrieve the old notes so they aren't deleted
    }
}
