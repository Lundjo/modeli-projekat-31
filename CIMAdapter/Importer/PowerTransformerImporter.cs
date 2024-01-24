using System;
using System.Collections.Generic;
using CIM.Model;
using FTN.Common;
using FTN.ESI.SIMES.CIM.CIMAdapter.Manager;

namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	/// <summary>
	/// PowerTransformerImporter
	/// </summary>
	public class PowerTransformerImporter
	{
		/// <summary> Singleton </summary>
		private static PowerTransformerImporter ptImporter = null;
		private static object singletoneLock = new object();

		private ConcreteModel concreteModel;
		private Delta delta;
		private ImportHelper importHelper;
		private TransformAndLoadReport report;


		#region Properties
		public static PowerTransformerImporter Instance
		{
			get
			{
				if (ptImporter == null)
				{
					lock (singletoneLock)
					{
						if (ptImporter == null)
						{
							ptImporter = new PowerTransformerImporter();
							ptImporter.Reset();
						}
					}
				}
				return ptImporter;
			}
		}

		public Delta NMSDelta
		{
			get 
			{
				return delta;
			}
		}
		#endregion Properties


		public void Reset()
		{
			concreteModel = null;
			delta = new Delta();
			importHelper = new ImportHelper();
			report = null;
		}

		public TransformAndLoadReport CreateNMSDelta(ConcreteModel cimConcreteModel)
		{
			LogManager.Log("Importing PowerTransformer Elements...", LogLevel.Info);
			report = new TransformAndLoadReport();
			concreteModel = cimConcreteModel;
			delta.ClearDeltaOperations();

			if ((concreteModel != null) && (concreteModel.ModelMap != null))
			{
				try
				{
					// convert into DMS elements
					ConvertModelAndPopulateDelta();
				}
				catch (Exception ex)
				{
					string message = string.Format("{0} - ERROR in data import - {1}", DateTime.Now, ex.Message);
					LogManager.Log(message);
					report.Report.AppendLine(ex.Message);
					report.Success = false;
				}
			}
			LogManager.Log("Importing PowerTransformer Elements - END.", LogLevel.Info);
			return report;
		}

		/// <summary>
		/// Method performs conversion of network elements from CIM based concrete model into DMS model.
		/// </summary>
		private void ConvertModelAndPopulateDelta()
		{
			LogManager.Log("Loading elements and creating delta...", LogLevel.Info);

			//// import all concrete model types (DMSType enum)
			ImportBaseVoltages();
			ImportSwitches();
            ImportTerminals();
            ImportConnectivityNodeContainers();
            ImportConnectivityNodes();
            ImportTopologicalNodes();

			LogManager.Log("Loading elements and creating delta completed.", LogLevel.Info);
		}

		#region Import
		private void ImportBaseVoltages()
		{
			SortedDictionary<string, object> cimBaseVoltages = concreteModel.GetAllObjectsOfType("FTN.BaseVoltage");
			if (cimBaseVoltages != null)
			{
				foreach (KeyValuePair<string, object> cimBaseVoltagePair in cimBaseVoltages)
				{
					FTN.BaseVoltage cimBaseVoltage = cimBaseVoltagePair.Value as FTN.BaseVoltage;

					ResourceDescription rd = CreateBaseVoltageResourceDescription(cimBaseVoltage);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("BaseVoltage ID = ").Append(cimBaseVoltage.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("BaseVoltage ID = ").Append(cimBaseVoltage.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateBaseVoltageResourceDescription(FTN.BaseVoltage cimBaseVoltage)
		{
			ResourceDescription rd = null;
			if (cimBaseVoltage != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, importHelper.CheckOutIndexForDMSType(DMSType.BASEVOLTAGE));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimBaseVoltage.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateBaseVoltageProperties(cimBaseVoltage, rd);
			}
			return rd;
		}
		
		private void ImportSwitches()
		{
            SortedDictionary<string, object> cimSwitches = concreteModel.GetAllObjectsOfType("FTN.Switch");
            if (cimSwitches != null)
            {
                foreach (KeyValuePair<string, object> cimSwitchPair in cimSwitches)
                {
					Switch cimSwitch = cimSwitchPair.Value as Switch;

                    ResourceDescription rd = CreateSwitchResourceDescription(cimSwitch);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("Switch ID = ").Append(cimSwitch.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("Switch ID = ").Append(cimSwitch.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateSwitchResourceDescription(FTN.Switch cim)
        {
            ResourceDescription rd = null;
            if (cim != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.SWITCH, importHelper.CheckOutIndexForDMSType(DMSType.SWITCH));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cim.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateSwitchProperties(cim, rd, importHelper, report);
            }
            return rd;
        }

        private void ImportTerminals()
        {
            SortedDictionary<string, object> cimTerminals = concreteModel.GetAllObjectsOfType("FTN.Terminal");
            if (cimTerminals != null)
            {
                foreach (KeyValuePair<string, object> cimTerminalPair in cimTerminals)
                {
                    Terminal cimTerminal = cimTerminalPair.Value as Terminal;

                    ResourceDescription rd = CreateTerminalResourceDescription(cimTerminal);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("Terminal ID = ").Append(cimTerminal.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("Terminal ID = ").Append(cimTerminal.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateTerminalResourceDescription(FTN.Terminal cim)
        {
            ResourceDescription rd = null;
            if (cim != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.TERMINAL, importHelper.CheckOutIndexForDMSType(DMSType.TERMINAL));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cim.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateTerminalProperties(cim, rd, importHelper, report);
            }
            return rd;
        }

        private void ImportConnectivityNodeContainers()
        {
            SortedDictionary<string, object> cimCNCs = concreteModel.GetAllObjectsOfType("FTN.ConnectivityNodeContainer");
            if (cimCNCs != null)
            {
                foreach (KeyValuePair<string, object> cimCNCPair in cimCNCs)
                {
                    ConnectivityNodeContainer cimCNC = cimCNCPair.Value as ConnectivityNodeContainer;

                    ResourceDescription rd = CreateConnectivityNodeContainerResourceDescription(cimCNC);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("ConnectivityNodeContainer ID = ").Append(cimCNC.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("ConnectivityNodeContainer ID = ").Append(cimCNC.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateConnectivityNodeContainerResourceDescription(FTN.ConnectivityNodeContainer cim)
        {
            ResourceDescription rd = null;
            if (cim != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.CNODECONTAINER, importHelper.CheckOutIndexForDMSType(DMSType.CNODECONTAINER));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cim.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateConnectivityNodeContainerProperties(cim, rd);
            }
            return rd;
        }

        private void ImportConnectivityNodes()
        {
            SortedDictionary<string, object> cimCNodes = concreteModel.GetAllObjectsOfType("FTN.ConnectivityNode");
            if (cimCNodes != null)
            {
                foreach (KeyValuePair<string, object> cimCNodePair in cimCNodes)
                {
                    ConnectivityNode cimCNode = cimCNodePair.Value as ConnectivityNode;

                    ResourceDescription rd = CreateConnectivityNodeResourceDescription(cimCNode);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("ConnectivityNode ID = ").Append(cimCNode.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("ConnectivityNode ID = ").Append(cimCNode.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateConnectivityNodeResourceDescription(FTN.ConnectivityNode cim)
        {
            ResourceDescription rd = null;
            if (cim != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.CNODE, importHelper.CheckOutIndexForDMSType(DMSType.CNODE));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cim.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateConnectivityNodeProperties(cim, rd, importHelper, report);
            }
            return rd;
        }

        private void ImportTopologicalNodes()
        {
            SortedDictionary<string, object> cimTNodes = concreteModel.GetAllObjectsOfType("FTN.TopologicalNode");
            if (cimTNodes != null)
            {
                foreach (KeyValuePair<string, object> cimTNodePair in cimTNodes)
                {
                    TopologicalNode cimTNode = cimTNodePair.Value as TopologicalNode;

                    ResourceDescription rd = CreateTopologicalNodeResourceDescription(cimTNode);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("TopologicalNode ID = ").Append(cimTNode.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("TopologicalNode ID = ").Append(cimTNode.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateTopologicalNodeResourceDescription(FTN.TopologicalNode cim)
        {
            ResourceDescription rd = null;
            if (cim != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.TNODE, importHelper.CheckOutIndexForDMSType(DMSType.TNODE));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cim.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateTopologicalNodeProperties(cim, rd);
            }
            return rd;
        }

        #endregion Import
    }
}

