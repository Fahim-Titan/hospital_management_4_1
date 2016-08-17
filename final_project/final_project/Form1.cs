using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace final_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet6.PAYMENT' table. You can move, or remove it, as needed.
            this.pAYMENTTableAdapter.Fill(this.dataSet6.PAYMENT);
            // TODO: This line of code loads data into the 'dataSet5.ROOM' table. You can move, or remove it, as needed.
            this.rOOMTableAdapter.Fill(this.dataSet5.ROOM);
            // TODO: This line of code loads data into the 'dataSet4.SERIAL' table. You can move, or remove it, as needed.
            this.sERIALTableAdapter.Fill(this.dataSet4.SERIAL);
            
            // TODO: This line of code loads data into the 'dataSet2.DOCTOR' table. You can move, or remove it, as needed.
            this.dOCTORTableAdapter.Fill(this.dataSet2.DOCTOR);
            // TODO: This line of code loads data into the 'dataSet1.PATIENT' table. You can move, or remove it, as needed.
            this.pATIENTTableAdapter.Fill(this.dataSet1.PATIENT);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into Patient (Patient_ID, Gender, DOB, P_name, Weight, Phone) values (" + Int32.Parse(Patient_ID.Text) + ",'"+Patient_Gender.Text +"','" + Patient_DOB.Text + "','" + Patient_name.Text + "',"+ Int32.Parse(Patient_Weight.Text)+","+ Int32.Parse(Patient_phone_number.Text)+ ")";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.pATIENTTableAdapter.Fill(this.dataSet1.PATIENT);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into Doctor (Doctor_Id, Doctor_name , Doctor_dept) values (" + Int32.Parse(Doctor_Id.Text) + ",'" + Doctor_name.Text + "','" +Dept_name.Text + "')";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.dOCTORTableAdapter.Fill(this.dataSet2.DOCTOR);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Entry_serial_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into Serial (Serial_Id, Doctor_Id, Patient_Id) values (" + Int32.Parse(Serial_number.Text) + "," + Int32.Parse(serial_doctor_id.Text) + "," + Int32.Parse(serial_patient_Id.Text) + ")";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.sERIALTableAdapter.Fill(this.dataSet4.SERIAL);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Room_Entry_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into Room (Room_Id, Patient_Id) values (" + Int32.Parse(Room_Number.Text) + "," + Int32.Parse(Room_Patient_Id.Text) +")";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.rOOMTableAdapter.Fill(this.dataSet5.ROOM);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Payment_Entry_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into Payment (Patient_Bill_Id, Patient_Id,Date_Bill_Paid, Total_amount ) values (" + Int32.Parse(Payment_Bill_ID.Text) + "," + Int32.Parse(Payment_Patient_ID.Text) +"," +Payment_Date.Text+"," +Int32.Parse(Payment_Total_amount.Text)+")";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.pAYMENTTableAdapter.Fill(this.dataSet6.PAYMENT);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_payment_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "delete from PAYMENT where (PATIENT_BILL_ID = " + Int32.Parse(Delete_payment_Id.Text) + ")";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.pAYMENTTableAdapter.Fill(this.dataSet6.PAYMENT);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_room_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "delete from room where (ROOM_ID = " + Int32.Parse(Room_Delete.Text) + ")";
                    cmd.ExecuteNonQuery();
                    //dataGridView1.Update();
                    //dataGridView1.Refresh();
                    this.rOOMTableAdapter.Fill(this.dataSet5.ROOM);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = "DATA SOURCE=localhost:1521/XE;PERSIST SECURITY INFO=True;USER ID=TAN_NOM_FAH; Password=123456";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = conString;
                {
                    //conn.Open();
                    //OracleCommand cmd = conn.CreateCommand();
                    //cmd.CommandText = "SELECT GET_patient_name(" + Int32.Parse(get_name.Text) + ") from dual";
                    //cmd.ExecuteNonQuery();
                    ////dataGridView1.Update();
                    ////dataGridView1.Refresh();
                    //this.rOOMTableAdapter.Fill(this.dataSet5.ROOM);
                    //conn.Close();
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    //cmd.CommandText = "SELECT GET_patient_name(" + Int32.Parse(get_name.Text) + ") from dual";
                    cmd.CommandText = "GET_patient_name";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //var paitent_id_param = Int32.Parse(get_name.Text);
                    cmd.Parameters.Add("paitent_id_param", OracleDbType.Int16).Value = Int32.Parse(get_name.Text); ;
                    cmd.Parameters.Add("names", OracleDbType.Varchar2).Direction = ParameterDirection.ReturnValue;
                    //cmd.Parameters["names"].Direction = ParameterDirection.ReturnValue;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //if(cmd.Parameters["names"].Value != null)
                    //{
                    //    names_got.Text = cmd.Parameters["names"].Value.ToString() ;
                    //}
                    var nam = Convert.ToString(cmd.Parameters["names"].Value);

                    MessageBox.Show(nam);
                    conn.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
        
}

