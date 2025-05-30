﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
	public class ConductingEquipment : Equipment
	{
        private long baseVoltage = 0;
        private List<long> terminals = new List<long>();

		public ConductingEquipment(long globalId) : base(globalId) 
		{
		}

        public long BaseVoltage
        {
            get { return baseVoltage; }
            set { baseVoltage = value; }
        }

        public List<long> Terminals
        {
            get { return terminals; }
            set { terminals = value; }
        }

        public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				ConductingEquipment x = (ConductingEquipment)obj;
				return (x.baseVoltage == this.baseVoltage && CompareHelper.CompareLists(x.terminals, this.terminals));
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region IAccess implementation

		public override bool HasProperty(ModelCode property)
		{
            switch (property)
            {
                case ModelCode.CONDEQ_BASEVOLTAGE:
                case ModelCode.CONDEQ_TERMINAL:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

		public override void GetProperty(Property prop)
		{
            switch (prop.Id)
            {
                case ModelCode.CONDEQ_BASEVOLTAGE:
                    prop.SetValue(baseVoltage);
                    break;
                case ModelCode.CONDEQ_TERMINAL:
                    prop.SetValue(terminals);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

		public override void SetProperty(Property property)
		{
            switch (property.Id)
            {
                case ModelCode.CONDEQ_BASEVOLTAGE:
                    baseVoltage = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        public override bool IsReferenced
        {
            get
            {
                return terminals.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (baseVoltage != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONDEQ_BASEVOLTAGE] = new List<long>();
                references[ModelCode.CONDEQ_BASEVOLTAGE].Add(baseVoltage);
            }
            if (terminals != null && terminals.Count != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONDEQ_TERMINAL] = terminals.GetRange(0, terminals.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    terminals.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDEQ:

                    if (terminals.Contains(globalId))
                    {
                        terminals.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }
    }
}
