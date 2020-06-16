// Date created: 6/15/2020
// Time: 2 hrs
// Description: Written in C# and MySQL to help the user manage customer 's information 
// Note: Add-in MYSQL for Visual Studio is needed

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInformation {
	public partial class frmCustInfo : Form {
		public frmCustInfo () {
			InitializeComponent ();
		}

		private void frmCustInfo_Load (object sender, EventArgs e) {
			// TODO: This line of code loads data into the 'dbcustomerid.customers' table. You can move, or remove it, as needed.
			this.customersTableAdapter.Fill (this.dbcustomerid.customers);
			customersBindingSource.DataSource = this.dbcustomerid.customers;
		}

		private void txtSearch_KeyPress (object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char) 13) // Delete key pressed?
			{
				if (string.IsNullOrEmpty (txtSearch.Text)) {
					// TODO: This line of code loads data into the 'dbcustomerid.customers' table. You can move, or remove it, as needed.
					this.customersTableAdapter.Fill (this.dbcustomerid.customers);
					customersBindingSource.DataSource = this.dbcustomerid.customers;
				} else {
					var query = from o in this.dbcustomerid.customers
					where o.fullname.Contains (txtSearch.Text) || o.email == txtSearch.Text || o.address.Contains (txtSearch.Text)
					select o;
					customersBindingSource.DataSource = query.ToList ();
				}
			}
		}

		private void btnNew_Click (object sender, EventArgs e) {
			try {
				panel1.Enabled = true;
				txtFullname.Focus ();
				this.dbcustomerid.customers.AddcustomersRow (this.dbcustomerid.customers.NewcustomersRow ());
				customersBindingSource.MoveLast ();
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEdit_Click (object sender, EventArgs e) {
			panel1.Enabled = true;
			txtFullname.Focus ();
		}

		private void btnCancel_Click (object sender, EventArgs e) {
			panel1.Enabled = false;
			customersBindingSource.ResetBindings (false);
		}

		private void btnSave_Click (object sender, EventArgs e) {
			try {
				customersBindingSource.EndEdit ();
				customersTableAdapter.Update (this.dbcustomerid.customers);
				panel1.Enabled = false;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataGridView_KeyDown (object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				if (MessageBox.Show ("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					customersBindingSource.RemoveCurrent ();

				}
			}
		}

		private void txtSearch_TextChanged (object sender, EventArgs e) {

		}
	}
}