using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDT.WinApp.Controls
{
    public partial class UcIndex : UcBase
    {
        private String currentIsolationLevel = String.Empty;
        private Dictionary<String, String> containers = new Dictionary<String, String>()
        {
            { "ReadUncommitted","读未提交，顾名思义，就是一个事务可以读取另一个未提交事务的数据。"},
            { "ReadCommitted","读提交，顾名思义，就是一个事务要等另一个事务提交后才能读取数据。"},
            { "RepeatableRead","重复读，就是在开始读取数据（事务开启）时，不再允许修改操作"},
            { "Serializable","Serializable 是最高的事务隔离级别，在该级别下，事务串行化顺序执行，可以避免脏读、不可重复读与幻读。"},
        };
        #region 构造函数

        public UcIndex()
        {
            InitializeComponent();

            this.Load += OnUcIndexLoad;
        }

        private void OnUcIndexLoad(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = containers;
            this.comboBox1.DataSource = bs;
            this.comboBox1.DisplayMember = "Key";
            this.comboBox1.ValueMember = "Key";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<String, String> selectitem = (KeyValuePair<String, String>)this.comboBox1.SelectedItem;
            this.DisplayDescription(selectitem.Value);
            this.currentIsolationLevel = selectitem.Key;
            base.Rollback1();
            base.Rollback2();
            this.button1.Enabled = true;
            this.button2.Enabled = true;
        }

        #endregion





        #region 事务1
        private void 开启事务一回调事件(object sender, EventArgs e)
        {
            base.StartTran1(this.currentIsolationLevel);
            this.button1.Enabled = false;
        }
        private void 修改事务一数据回调事件(object sender, EventArgs e)
        {
            try
            {
                String money = new Random().Next(10000, 40000).ToString();
                String sqlStr = "UPDATE  Salary SET money = '" + money + "' ";
                base.ExecuteNonQuery(base.command1, sqlStr);
                this.label2.Text = "修改数据成功 --> " + money;
            }
            catch (SqlException ex)
            {
                this.richTextBox2.Text = ex.Message + "\r\n";
            }
            catch (Exception ex)
            {

                this.richTextBox2.Text = ex.Message + "\r\n";
            }
        }
        private void 提交事务一回调事件(object sender, EventArgs e)
        {
            base.CommitTran1();
        }
        private void 检索事务一数据回调事件(object sender, EventArgs e)
        {
            try
            {
                var dt = base.ExecuteAdapter(this.command1);
                this.dataGridView1.DataSource = dt;
            }
            catch (SqlException ex)
            {
                this.richTextBox2.Text = ex.Message + "\r\n";
            }
            catch (Exception ex)
            {
                this.richTextBox2.Text = ex.Message + "\r\n";
            }
        }
        #endregion

        #region 事务2


        private void 检索事务二数据回调事件(object sender, EventArgs e)
        {
            try
            {
                //
                var dt = base.ExecuteAdapter(this.command2);
                this.dataGridView2.DataSource = dt;
            }
            catch (SqlException ex)
            {
                this.richTextBox2.Text = ex.Message + "\r\n";
            }
            catch (Exception ex)
            {

                this.richTextBox2.Text = ex.Message + "\r\n";
            }

        }

        #endregion

        private void 提交事务二回调事件(object sender, EventArgs e)
        {
            this.CommitTran2();
        }

        private void 开启事务二回调事件(object sender, EventArgs e)
        {
            base.StartTran2(this.currentIsolationLevel);
            this.button2.Enabled = false;
        }

        #region 私有方法
        private void DisplayDescription(String description)
        {
            this.richTextBox1.Text = description;
        }
        #endregion


    }
}
