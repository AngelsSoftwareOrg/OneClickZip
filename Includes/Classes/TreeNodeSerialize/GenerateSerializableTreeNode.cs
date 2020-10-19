using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GlobExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.Events;
using OneClickZip.Includes.Models.Types;
using OneClickZip.Includes.Utilities;


namespace OneClickZip.Includes.Classes.TreeNodeSerialize
{
    public class GenerateSerializableTreeNode
    {
        public event EventHandler<GeneratingSerializeTreeNodeEventArgs> GenerationInitialization;
        public event EventHandler<GeneratingSerializeTreeNodeEventArgs> RuleEnforcementStatus;
        public event EventHandler<GeneratingSerializeTreeNodeEventArgs> FinishedGeneration;
        public event EventHandler<GeneratingSerializeTreeNodeEventArgs> StopGeneration;

        private GeneratingSerializeTreeNodeEventArgs processingStatusEventArgs;
        private bool stopGenerating;
        private bool stopGeneratingSuccessful;
        private SerializableTreeNode serializableTreeNode;
        private long sequenceNumberCtr = 0;
        private long actualFilesProcessedCount = 0;
        private FolderFilterRule folderFilterRule;

        public GenerateSerializableTreeNode() 
        {
            processingStatusEventArgs = new GeneratingSerializeTreeNodeEventArgs();
        }

        public GenerateSerializableTreeNode(FolderFilterRule folderFilterRule)
        {
            this.folderFilterRule = folderFilterRule;
            processingStatusEventArgs = new GeneratingSerializeTreeNodeEventArgs();
        }

        public void StartGeneration()
        {
            ResetPropertiesForReprocessing();
            ValidateDetailsNeeded();
            StartCrawling();
        }
        private void StartCrawling()
        {
            RaiseEventProcessingStatus(GeneratingSerializeTreeNodeProcessingStage.INITIALIZATION);
            CrawlTreeStructure(SerializableTreeNodeObj, FolderFilterRuleObj.TargetFolderPath);
            if (StopGenerating && StopGeneratingSuccessful)
            {
                RaiseEventStopGeneration();
            }
            else
            {
                RaiseEventFinishedGeneration();
            }
        }
        private void CrawlTreeStructure(SerializableTreeNode serializableTreeNode, String directoryPath)
        {
            if (IsStopGenerating()) return;

            //first step. Check the files
            FileInfo[] filesInfoArr = FileSystemUtilities.GetFiles(directoryPath);
            if (filesInfoArr != null)
            {
                foreach (FileInfo fileInfo in filesInfoArr)
                {
                    if (ApplyFilterRule(fileInfo, false, out String hitFilterRule))
                    {
                        UpdateSequenceInfo("Added File", fileInfo.FullName, hitFilterRule);
                        RaiseEventRuleEnforcementStatus(GeneratingSerializeTreeNodeProcessingStage.ENFORCING_RULE_TO_FILE);
                        serializableTreeNode.AddItem(new CustomFileItem(fileInfo.Name, fileInfo));
                    }
                    Application.DoEvents();
                    if (IsStopGenerating()) return;
                }
            }

            //second step
            DirectoryInfo[] dirInfoArr = FileSystemUtilities.GetDirectories(directoryPath);
            if (dirInfoArr != null)
            {
                foreach (DirectoryInfo dInfo in dirInfoArr)
                {
                    Application.DoEvents();
                    if (ApplyFilterRule(dInfo, true, out String hitFilterRule))
                    {
                        SerializableTreeNode stree = new SerializableTreeNode
                        {
                            Name = dInfo.Name,
                            ToolTipText = String.Empty,
                            ImageIndex = -1,
                            Text = dInfo.Name,
                            SelectedImageIndex = -1,
                            FolderType = FolderType.TreeView
                        };

                        //recursive traversal
                        CrawlTreeStructure(stree, dInfo.FullName);

                        bool includeFoldersWithSubFoldersOrFiles = (!FolderFilterRuleObj.IncludeEmptyFolder && stree.MasterListFilesDir.Count > 0);
                        if (FolderFilterRuleObj.IncludeEmptyFolder || includeFoldersWithSubFoldersOrFiles)
                        {
                            serializableTreeNode.AddItem(new CustomFileItem(dInfo.Name, dInfo));
                            UpdateSequenceInfo("Added Folder", dInfo.FullName, hitFilterRule);
                            RaiseEventRuleEnforcementStatus(GeneratingSerializeTreeNodeProcessingStage.ENFORCING_RULE_TO_FOLDER);
                            serializableTreeNode.Nodes.Add(stree);
                        }
                    }
                    else
                    {
                        CrawlTreeStructure(serializableTreeNode, dInfo.FullName);
                    }
                }
            }
        }
        private bool ApplyFilterRule(FileSystemInfo sysInfo, bool isFolder, out String hitFilterRule)
        {
            if(!IsFilterRuleValidationPassed(sysInfo, out hitFilterRule)) return false;
            if(!isFolder && !IsFileLengthFilterRulePassed(sysInfo)) return false;
            if (!isFolder && !IsFileModifiedDateWithinFilterPassed(sysInfo)) return false;
            return true;
        }

        private bool IsFilterRuleValidationPassed(FileSystemInfo sysInfo, out String hitFilterRule)
        {
            String relativePath = sysInfo.FullName.Replace(FolderFilterRuleObj.TargetFolderPath, "").Trim();

            //exclude unwanted files
            foreach (String filter in FolderFilterRuleObj.ExcludeFilterRules)
            {
                bool match = Glob.IsMatch(relativePath, filter);
                if (match)
                {
                    hitFilterRule = filter;
                    return false;
                }
            }

            //include wanted files
            foreach (String filter in FolderFilterRuleObj.IncludeFilterRules)
            {
                bool match = Glob.IsMatch(relativePath, filter);
                if (match)
                {
                    hitFilterRule = filter;
                    return true;
                }
            }
            hitFilterRule = String.Empty;
            return false;
        }
        private bool IsFileLengthFilterRulePassed(FileSystemInfo sysInfo)
        {
            if (!FolderFilterRuleObj.HasMinimumFileSize && !FolderFilterRuleObj.HasMaximumFileSize) return true;
            bool result = false;
            FileInfo filObj = (FileInfo)sysInfo;

            if (FolderFilterRuleObj.HasMinimumFileSize)
            {
                result = (filObj.Length >= FolderFilterRuleObj.MinimumFileSize);
            }
            if (FolderFilterRuleObj.HasMaximumFileSize)
            {
                result = result && (filObj.Length <= FolderFilterRuleObj.MaximumFileSize);
            }
            return result;
        }
        private bool IsFileModifiedDateWithinFilterPassed(FileSystemInfo sysInfo)
        {
            if (FolderFilterRuleObj.TimeSpanOptionValue == FolderFilterRule.TimeSpanOption.NONE) return true;

            bool result = false;
            FileInfo fInfo = (FileInfo)sysInfo;

            switch (FolderFilterRuleObj.TimeSpanOptionValue)
            {
                case FolderFilterRule.TimeSpanOption.TODAY:
                    result = (DateAndTime.Now.Date == fInfo.LastWriteTime.Date);
                    break;
                case FolderFilterRule.TimeSpanOption.THIS_MONTH:
                    result = DateAndTime.Now.Month == fInfo.LastWriteTime.Month;
                    break;
                case FolderFilterRule.TimeSpanOption.THIS_YEAR:
                    result = (DateAndTime.Now.Year == fInfo.LastWriteTime.Year);
                    break;
                case FolderFilterRule.TimeSpanOption.LAST_XX_DAYS:
                    result = ((DateAndTime.Now - fInfo.LastWriteTime).TotalDays <= FolderFilterRuleObj.LastNumberOfDaysValue);
                    break;
                default:
                    break;
            }
            return result;
        }

        #region Event Functions
        private void UpdateSequenceInfo(String actionTaken, String evaluatedPath, String hitFilterRule)
        {
            sequenceNumberCtr++;
            processingStatusEventArgs.FolderFilterRuleObj = FolderFilterRuleObj;
            processingStatusEventArgs.ActionTaken = actionTaken;
            processingStatusEventArgs.SequenceNumber = sequenceNumberCtr;
            processingStatusEventArgs.EvaluatedPath = evaluatedPath;
            processingStatusEventArgs.RelativeEvaluatedPath = evaluatedPath.Replace(FolderFilterRuleObj.TargetFolderPath, "");
            processingStatusEventArgs.HitFilterRule = hitFilterRule;
            processingStatusEventArgs.ActualFilesProcessedCount = actualFilesProcessedCount;
        }
        private void RaiseEventProcessingStatus(GeneratingSerializeTreeNodeProcessingStage processingStage)
        {
            processingStatusEventArgs.ProcessingStage = processingStage;
            UpdateSequenceInfo("Initialization", "Initializing path filter rule generation", "");
            GenerationInitialization?.Invoke(this, processingStatusEventArgs);
        }
        private void RaiseEventRuleEnforcementStatus(GeneratingSerializeTreeNodeProcessingStage processingStage)
        {
            actualFilesProcessedCount++;
            processingStatusEventArgs.ProcessingStage = processingStage;
            RuleEnforcementStatus?.Invoke(this, processingStatusEventArgs);
        }
        private void RaiseEventFinishedGeneration()
        {
            processingStatusEventArgs.ProcessingStage = GeneratingSerializeTreeNodeProcessingStage.GENERATION_SUCCESSFUL;
            UpdateSequenceInfo("Finished", "Path file base on filter rules is successful", "");
            FinishedGeneration?.Invoke(this, processingStatusEventArgs);
        }
        private void RaiseEventStopGeneration()
        {
            processingStatusEventArgs.ProcessingStage = GeneratingSerializeTreeNodeProcessingStage.STOP_GENERATION;
            UpdateSequenceInfo("Stopped", "Path file base on filter rules has been halted.", "");
            StopGeneration?.Invoke(this, processingStatusEventArgs);
        }
        #endregion
        
        private void ValidateDetailsNeeded()
        {
            if (folderFilterRule == null) throw new ArgumentNullException("FolderFilterRule is null. This is mandatory to get details at.");
        }
        public FolderFilterRule FolderFilterRuleObj { get => folderFilterRule; set => folderFilterRule = value; }
        private bool StopGenerating { get => stopGenerating; set => stopGenerating = value; }
        public bool StopGeneratingSuccessful { get => stopGeneratingSuccessful; set => stopGeneratingSuccessful = value; }
        public SerializableTreeNode SerializableTreeNodeObj 
        {
            get
            {
                if(serializableTreeNode == null) serializableTreeNode = new SerializableTreeNode();
                return serializableTreeNode;
            }
            set {
                serializableTreeNode = value; 
            }
        }
        private bool IsStopGenerating()
        {
            if (StopGenerating)
            {
                StopGeneratingSuccessful = true;
                return true;
            }
            return false;
        }
        public void StopGenerationProcess()
        {
            StopGenerating = true;
            Application.DoEvents();
        }
        private void ResetPropertiesForReprocessing()
        {
            sequenceNumberCtr = 0;
            actualFilesProcessedCount = 0;
            processingStatusEventArgs = new GeneratingSerializeTreeNodeEventArgs();
            StopGenerating = false;
            StopGeneratingSuccessful = false;
        }
    
    }
}
