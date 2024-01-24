namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
				if (cimIdentifiedObject.NameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
				}
				if (cimIdentifiedObject.AliasNameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_ALIASNAME, cimIdentifiedObject.AliasName));
				}
			}
		}

		public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
			}
		}

		public static void PopulateBaseVoltageProperties(FTN.BaseVoltage cimBaseVoltage, ResourceDescription rd)
		{
			if ((cimBaseVoltage != null) && (rd != null))
			{
				PopulateIdentifiedObjectProperties(cimBaseVoltage, rd);
			}
		}

		public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PopulatePowerSystemResourceProperties(cimEquipment, rd);

                if (cimEquipment.AggregateHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_AGGREGATE, cimEquipment.Aggregate));
                }
                if (cimEquipment.NormallyInServiceHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_NORMALLYINSERVICE, cimEquipment.NormallyInService));
                }
            }
		}

		public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConductingEquipment != null) && (rd != null))
			{
				PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);

				if (cimConductingEquipment.BaseVoltageHasValue)
				{
					long gid = importHelper.GetMappedGID(cimConductingEquipment.BaseVoltage.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimConductingEquipment.GetType().ToString()).Append(" rdfID = \"").Append(cimConductingEquipment.ID);
						report.Report.Append("\" - Failed to set reference to BaseVoltage: rdfID \"").Append(cimConductingEquipment.BaseVoltage.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.CONDEQ_BASEVOLTAGE, gid));
				}
			}
		}

		public static void PopulateSwitchProperties(FTN.Switch cim, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if((cim != null) && (rd != null))
			{
				PopulateConductingEquipmentProperties(cim, rd, importHelper, report);

				if (cim.NormalOpenHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_NORMALOPEN, cim.NormalOpen));
				}
				if(cim.RatedCurrentHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_RATEDCURRENT, cim.RatedCurrent));
				}
				if(cim.RetainedHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_RETAINED, cim.Retained));
				}
				if(cim.SwitchOnCountHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_ONCOUNT, cim.SwitchOnCount));
				}
				if(cim.SwitchOnDateHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_ONDATE, cim.SwitchOnDate));
				}
			}
		}

		public static void PopulateTerminalProperties(Terminal cim, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if((cim != null) && (rd != null)) 
			{ 
				PopulateIdentifiedObjectProperties(cim, rd);

				if(cim.ConductingEquipmentHasValue)
				{
                    long gid = importHelper.GetMappedGID(cim.ConductingEquipment.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cim.GetType().ToString()).Append(" rdfID = \"").Append(cim.ID);
                        report.Report.Append("\" - Failed to set reference to ConductingEquipment: rdfID \"").Append(cim.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONDEQ, gid));
                }
                if (cim.ConnectivityNodeHasValue)
                {
                    long gid = importHelper.GetMappedGID(cim.ConnectivityNode.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cim.GetType().ToString()).Append(" rdfID = \"").Append(cim.ID);
                        report.Report.Append("\" - Failed to set reference to ConnectivityNode: rdfID \"").Append(cim.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CNODE, gid));
                }
            }
		}

		public static void PopulateConnectivityNodeContainerProperties(ConnectivityNodeContainer cim, ResourceDescription rd)
		{
			if((cim != null) && (rd != null))
			{
				PopulatePowerSystemResourceProperties(cim, rd);
			}
		}

		public static void PopulateConnectivityNodeProperties(ConnectivityNode cim, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
            if ((cim != null) && (rd != null))
			{
				PopulateIdentifiedObjectProperties(cim, rd);

                if (cim.ConnectivityNodeContainerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cim.ConnectivityNodeContainer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cim.GetType().ToString()).Append(" rdfID = \"").Append(cim.ID);
                        report.Report.Append("\" - Failed to set reference to ConnectivityNodeContainer: rdfID \"").Append(cim.ConnectivityNodeContainer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.CNODE_CNODECONTAINER, gid));
                }
                if (cim.TopologicalNodeHasValue)
                {
                    long gid = importHelper.GetMappedGID(cim.TopologicalNode.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cim.GetType().ToString()).Append(" rdfID = \"").Append(cim.ID);
                        report.Report.Append("\" - Failed to set reference to TopologicalNode: rdfID \"").Append(cim.TopologicalNode.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.CNODE_TNODE, gid));
                }
            }
        }

		public static void PopulateTopologicalNodeProperties(TopologicalNode cim, ResourceDescription rd)
		{
			if((cim != null) && (rd != null))
			{
                PopulateIdentifiedObjectProperties(cim, rd);
            }
		}

        #endregion Populate ResourceDescription
	}
}
