﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buil2
{
    public partial class DeleteForm : Form
    {
        string memberID;
        public DeleteForm(string paraID)
        {
            InitializeComponent();
            memberID = paraID;
        }

        string connStr;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            this.Text = "회원 삭제";
            Bitmap bmp = (Bitmap)Properties.Resources._2;
            this.Icon = Icon.FromHandle(bmp.GetHicon());

            connStr = "Server = localhost\\SQLEXPRESS;Database = CookDB;Trusted_Connection = True;";
            conn = new SqlConnection(connStr);
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM member WHERE id = '" + memberID + "'";
            reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                MessageBox.Show("아이디(" + memberID + ")는 회원이 아닙니다.");
                this.Close();
            }
            else
            {
                string data1, data2, data3, data4;
                data1 = reader.GetString(0).Trim();
                data2 = reader.GetString(1).Trim();
                data3 = reader.GetString(2).Trim();
                data4 = reader.GetInt32(3).ToString();

                tb_id.Text = data1;
                tb_name.Text = data2;
                tb_email.Text = data3;
                tb_birth.Text = data4;
                reader.Close();
            }
        }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string data1, sql;

            data1 = tb_id.Text;

            sql = "DELETE FROM member WHERE id = '" + data1 + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            MessageBox.Show("아이디(" + memberID + ")가 잘 삭제되었습니다. 창이 닫힙니다.");
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
