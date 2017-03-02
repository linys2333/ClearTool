using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClearTool.Business.BO;
using ClearTool.Business.DS;
using System.Linq;
using LysControl;
using LysExtend;

namespace ClearTool
{
    public partial class SettingForm : PanelForm
    {
        private string _configPath = $@"{Application.StartupPath}\Config.xml";
        private bool _isAbortTask = true;  // 是否终止当前任务

        public SettingForm()
        {
            InitializeComponent();

            InitForm();
            InitData();
        }

        #region 事件
        
        private void btnCompara_Click(object sender, System.EventArgs e)
        {
            // 校验
            string selectSys = Util.ConvertType<string>(cmbSys.SelectedValue);
            if (selectSys.IsEmpty())
            {
                MsgBox.Warning("请选择系统！");
                return;
            }

            if (!dbTarget.TestDB(false))
            {
                MsgBox.Warning("目标数据库信息不正确！");
                return;
            }
            if (!dbCompara.TestDB(false))
            {
                MsgBox.Warning("对比数据库信息不正确！");
                return;
            }

            // 保存配置信息
            ConfigDS.SysList.SelectSys = selectSys;
            ConfigDS.GetInstance().SaveConfig(_configPath);

            dbTarget.SaveConfig();
            dbCompara.SaveConfig();

            if (dbTarget.DB == dbCompara.DB && !MsgBox.YesNo("数据库相同，是否继续比较？", false))
            {
                return;
            }

            // 对比
            SysTablePrefix sysInfo = ConfigDS.SysList.GetSysTablePrefix(selectSys);
            Compara(new SettingInfo
            {
                InFilter = sysInfo.InFilter,
                NotFilter = sysInfo.NotFilter,
                TargetDB = new ExtDBInfo(dbTarget.DB),
                ComparaDB = new ExtDBInfo(dbCompara.DB)
            });
        }

        private void btnSync_Click(object sender, System.EventArgs e)
        {
            dbCompara.DB = dbTarget.DB;
        }

        private void btnSync_MouseDown(object sender, MouseEventArgs e)
        {
            btnSync.Image = Properties.Resources.refresh3;
        }

        private void btnSync_MouseUp(object sender, MouseEventArgs e)
        {
            btnSync.Image = Properties.Resources.refresh;
        }

        #endregion

        #region 私有方法

        private void InitForm()
        {
        }

        private void InitData()
        {
            // 设置系统列表
            ConfigDS.GetInstance().LoadConfig(_configPath);
            cmbSys.ValueMember = "SysCode";
            cmbSys.DisplayMember = "SysName";
            cmbSys.DataSource = ConfigDS.SysList.SysInfoDic;
            cmbSys.SelectedValue = ConfigDS.SysList.SelectSys;

            // 初始化数据库
            dbTarget.SetDefaultDB();
            dbCompara.SetDefaultDB();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // Esc终止当前操作
                case Keys.Escape:
                    AbortTask();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 异步比较
        /// </summary>
        private async void Compara(SettingInfo set)
        {
            try
            {
                BeforeCompara();

                // 对比
                var result = await Task.Run(() => AnalysisDS.GetInstance().Compara(set));
                CheckTaskComplete();

                result.ForEach(e =>
                {
                    e.SysCode = "Tzsy";
                });

                // 展示结果
                var resultForm = new ResultForm(result);
                //resultForm.Location = new Point(Location.X + Width, Location.Y);
                resultForm.Show("", this);

                // 连接目标数据库
                set.TargetDB.InitConn();
            }
            catch (Exception ex)
            {
                MsgBox.Warning(ex.Message);
            }
            finally
            {
                AfterCompara();
            }
        }

        /// <summary>
        /// 对比之前的操作
        /// </summary>
        private void BeforeCompara()
        {
            _isAbortTask = false;

            btnCompara.Enabled = false;

            prgCompara.Value = 0;
            prgCompara.BringToFront();
            prgCompara.Show();
        }

        /// <summary>
        /// 对比完成后的操作
        /// </summary>
        private void AfterCompara()
        {
            _isAbortTask = true;

            btnCompara.Enabled = true;

            prgCompara.Value = 0;
            prgCompara.Hide();
        }

        private void AbortTask()
        {
            if (!_isAbortTask)
            {
                _isAbortTask = true;
                MsgBox.OK("正在终止任务，请等待...");
            }
        }

        private void CheckTaskComplete()
        {
            if (_isAbortTask)
            {
                throw new Exception("当前任务已终止。");
            }
        }

        #endregion
    }
}
