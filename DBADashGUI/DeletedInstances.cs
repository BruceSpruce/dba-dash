﻿using DBADash;
using DBADashGUI.CustomReports;
using DBADashGUI.Theme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;

namespace DBADashGUI
{
    public partial class DeletedInstances : UserControl, ISetContext, IRefreshData
    {
        public event EventHandler<int> InstanceRestored;

        private bool IsDeleteInProgesss;

        public DeletedInstances()
        {
            InitializeComponent();
            customReportView1.Grid.ColumnAdded += Grid_ColumnAdded;
        }

        private void Grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (!customReportView1.Grid.Columns.Contains("colRestore"))
            {
                customReportView1.Grid.Columns.Add(new DataGridViewLinkColumn()
                {
                    Name = "colRestore",
                    HeaderText = @"Restore",
                    Text = "Restore",
                    UseColumnTextForLinkValue = true,
                    Width = 80
                });
                customReportView1.Grid.Columns.Add(new DataGridViewLinkColumn()
                {
                    Name = "colDelete",
                    HeaderText = @"Delete",
                    Text = "Delete Now",
                    UseColumnTextForLinkValue = true,
                    Width = 90
                });
                customReportView1.Grid.CellContentClick -= Grid_CellContentClick;
                customReportView1.Grid.CellContentClick += Grid_CellContentClick;
                customReportView1.Grid.ApplyTheme();
            }
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshData));
                return;
            }

            customReportView1.RefreshData();
        }

        public void SetContext(DBADashContext _context)
        {
            if (_context == null) return;
            _context.Report = DeletedInstancesReport;
            customReportView1.SetContext(_context);

            SetStatus(CurrentStatus.Message, CurrentStatus.ToolTip, CurrentStatus.Color);
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var instanceID = (int)customReportView1.Grid.Rows[e.RowIndex].Cells["InstanceID"].Value;
            var instanceName = (string)customReportView1.Grid.Rows[e.RowIndex].Cells["InstanceDisplayName"].Value;
            switch (customReportView1.Grid.Columns[e.ColumnIndex].Name)
            {
                case "colRestore":
                    try
                    {
                        SharedData.RestoreInstance(instanceID, Common.ConnectionString);
                        RefreshData();
                        OnInstanceRestored(instanceID);
                        SetStatus($"Instance {instanceName} restored.  Refresh the tree to see the instance.", string.Empty, DashColors.Success);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "colDelete":
                    {
                        if (IsDeleteInProgesss)
                        {
                            MessageBox.Show(@"Please wait for the current delete operation to complete before starting another.", $@"Delete {instanceName}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var lastCollectionMins = (int)customReportView1.Grid.Rows[e.RowIndex].Cells["LastCollectionMins"].Value;
                        if (lastCollectionMins <= 1440)
                        {
                            MessageBox.Show(@"Please wait at least 1 day before deleting this instance.", $@"Delete {instanceName}",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (MessageBox.Show(
                                @"Warning:This process can't be undone and might take a while to complete.
If you don't need to delete the instance immediately, the data retention settings will eventually remove most of the data associated with the deleted instance by truncating old partitions.

Are you sure you want to delete this instance?",
                                $@"Delete {instanceName}", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;

                        Task.Run(() => HardDeleteInstance(instanceID, instanceName));
                        break;
                    }
            }
        }

        private (string Message, string ToolTip, Color Color) CurrentStatus;

        private void SetStatus(string message, string tooltip, Color color)
        {
            CurrentStatus = new(message, tooltip, color);
            customReportView1.StatusLabel.InvokeSetStatus(message ?? string.Empty, tooltip ?? string.Empty, color);
        }

        private void HardDeleteInstance(int instanceID, string instanceName)
        {
            IsDeleteInProgesss = true;
            try
            {
                SetStatus($"Deleting instance {instanceName}...", string.Empty,
                    DashColors.Information);
                SharedData.HardDeleteInstance(instanceID, Common.ConnectionString);
                SetStatus($"Instance {instanceName} deleted", string.Empty,
                    DashColors.Success);
            }
            catch (Exception ex)
            {
                SetStatus(ex.Message, ex.ToString(), DashColors.Fail);
            }

            RefreshData();
            IsDeleteInProgesss = false;
        }

        protected virtual void OnInstanceRestored(int instanceID)
        {
            InstanceRestored?.Invoke(this, instanceID);
        }

        public static SystemReport DeletedInstancesReport => new()
        {
            ReportName = "DeletedInstances",
            SchemaName = "dbo",
            ProcedureName = "DeletedInstances_Get",
            QualifiedProcedureName = "dbo.DeletedInstances_Get",
            CanEditReport = false,
            CustomReportResults = new Dictionary<int, CustomReportResult>
            {
                {
                    0, new CustomReportResult
                    {
                        ColumnAlias = new Dictionary<string, string>
                        {
                            { "InstanceID", "Instance ID" },
                            { "ConnectionID", "Connection ID" },
                            { "InstanceDisplayName", "Instance" },
                            { "SnapshotDate", "Last Collection Date" },
                            { "LastCollection", "Time Since Last Collection" },
                            { "LastCollectionMins", "Time Since Last Collection (Mins)" },
                            { "ScheduledDeletion", "Scheduled Deletion" },
                            { "ScheduledDeletionDays", "Scheduled Deletion (Days)" },
                            { "HardDeleteThresholdDays", "Hard Delete Threshold (Days)" },
                        },
                         ColumnLayout = new List<KeyValuePair<string, PersistedColumnLayout>>()
                            {
                                new ("InstanceID", new PersistedColumnLayout { Width = 100, Visible = false }),
                                new("ConnectionID", new PersistedColumnLayout { Width = 250, Visible = true }),
                                new("InstanceDisplayName", new PersistedColumnLayout { Width = 250, Visible = true }),
                                new("SnapshotDate", new PersistedColumnLayout { Width = 120, Visible = true }),
                                new("LastCollection", new PersistedColumnLayout { Width = 80, Visible = true }),
                                new("LastCollectionMins", new PersistedColumnLayout { Width = 80, Visible = false }),
                                new("ScheduledDeletion", new PersistedColumnLayout { Width = 120, Visible = true }),
                                new("ScheduledDeletionDays", new PersistedColumnLayout { Width = 80, Visible = true }),
                                new("HardDeleteThresholdDays", new PersistedColumnLayout { Width = 80, Visible = true }),
                                new("colRestore", new PersistedColumnLayout { Width = 80, Visible = true }),
                                new("colDelete", new PersistedColumnLayout { Width = 90, Visible = true }),
                            },
                        CellHighlightingRules =
                        {
                            {
                                "SnapshotDate",
                                new CellHighlightingRuleSet("LastCollectionMins")
                                {
                                    Rules = new List<CellHighlightingRule>
                                    {
                                        new()
                                        {
                                            ConditionType = CellHighlightingRule.ConditionTypes.LessThan,
                                            Value1 = "10",
                                            Status = DBADashStatus.DBADashStatusEnum.Critical
                                        },
                                        new()
                                        {
                                            ConditionType = CellHighlightingRule.ConditionTypes.LessThan,
                                            Value1 = "1440",
                                            Status = DBADashStatus.DBADashStatusEnum.Warning
                                        }
                                    }
                                }
                            },
                            {
                                "LastCollection",
                                new CellHighlightingRuleSet("LastCollectionMins")
                                {
                                    Rules = new List<CellHighlightingRule>
                                    {
                                        new()
                                        {
                                            ConditionType = CellHighlightingRule.ConditionTypes.LessThan,
                                            Value1 = "10",
                                            Status = DBADashStatus.DBADashStatusEnum.Critical
                                        },
                                        new()
                                        {
                                            ConditionType = CellHighlightingRule.ConditionTypes.LessThan,
                                            Value1 = "1440",
                                            Status = DBADashStatus.DBADashStatusEnum.Warning
                                        }
                                    }
                                }
                            },
                        }
                    }
                }
            }
        };
    }
}