using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClearTool.Business.BO;
using ClearTool.Business.DS;
using LysControl;
using LysExtend;

namespace ClearTool
{
    public partial class ResultForm : PanelForm
    {
        private List<ComparaResult> _backupResult;  // 备份结果数据
        private List<ComparaResult> _comparaResult; // 对比结果数据

        public string ExportFolder {
            get
            {
                return Application.StartupPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            }
        }

        public ResultForm(List<ComparaResult> compara)
        {
            InitializeComponent();

            _comparaResult = compara;
            _backupResult = _comparaResult.Copy<List<ComparaResult>>();

            InitForm();
            InitData();
        }

        #region 事件

        private void dgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            string indexCol = "Index";
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                // 第1个可见列为序号列
                if (col.Visible)
                {
                    indexCol = col.Name;
                    break;
                }
            }
            dgv.CreateIndex(indexCol);
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tableName = dgvResult.CurrentRow?.Cells["TargetTableName"].Value.ToString();

            dgvField.DataSource = tableName.IsEmpty() 
                ? new List<ComparaField>()
                : _comparaResult.SingleOrNew(c => c.TableName == tableName).FieldList;
        }

        private void btnRebind_Click(object sender, EventArgs e)
        {
            if (MsgBox.YesNo("确认还原为初始数据？", false))
            {
                _comparaResult = _backupResult.Copy<List<ComparaResult>>();
                Bind();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ReverseBind();

                if (_comparaResult.Count > 0)
                {
                    _comparaResult.ForEach(c => c.Remark = "");
                    ResultDS.GetInstance().Create(ref _comparaResult, ExportFolder);
                    Bind();
                    MsgBox.OK("导出完毕！");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Warning(ex.Message);
            }
        }
        
        #endregion

        #region 私有方法

        private void InitForm()
        {
            dgvResult.AutoGenerateColumns = false;

            // 设置表数量信息
            lblSumCount.Text += _comparaResult.Count;
            lblAddCount.Text += _comparaResult.Count(e => e.Flag == StatusFlag.Add);
            lblEditCount.Text += _comparaResult.Count(e => e.Flag == StatusFlag.Edit);
            lblDeleteCount.Text += _comparaResult.Count(e => e.Flag == StatusFlag.Delete);
        }

        private void InitData()
        {
            Bind();
        }

        private void Bind()
        {
            dgvResult.DataSource = _comparaResult.Select(e => (ComparaInfo)e).ToList();

            _comparaResult.ForEach((e, i) =>
            {
                var row = dgvResult.Rows[i];

                var cellRemark = row.Cells["Remark"];

                cellRemark.Style.BackColor = e.IsAssert ? Color.Yellow : Color.White;
            });
        }
        
        private void ReverseBind()
        {
            for (int i = 0; i < dgvResult.Rows.Count; i++)
            {
                var row = dgvResult.Rows[i];

                var tableName = Util.ConvertType<string>(row.Cells["TableName"].Value);
                var isClear = Util.ConvertType<string>(row.Cells["IsClear"].Value);

                _comparaResult.SingleOrNew(e => e.TableName == tableName).IsClear = isClear == "是";
            }
        }

        #endregion
    }
}
