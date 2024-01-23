using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConnectivityNode : IdentifiedObject
    {
        private long tNodeId;
        private long cncId;
        private List<long> terminals = new List<long>();

        public ConnectivityNode(long globalId) : base(globalId)
        {
        }

        public List<long> Terminals
        {
            get { return terminals; }
            set { terminals = value; }
        }

        public long TNodeId
        {
            get { return tNodeId; }
            set { tNodeId = value; }
        }

        public long CncId
        {
            get { return cncId; }
            set { cncId = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConnectivityNode x = (ConnectivityNode)obj;
                return (x.tNodeId == this.tNodeId && x.cncId == this.cncId && CompareHelper.CompareLists(x.terminals, this.terminals));
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

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.CNODE_CNODECONTAINER:
                case ModelCode.CNODE_TERMINAL:
                case ModelCode.CNODE_TNODE:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.CNODE_CNODECONTAINER:
                    prop.SetValue(cncId);
                    break;
                case ModelCode.CNODE_TNODE:
                    prop.SetValue(tNodeId); 
                    break;
                case ModelCode.CNODE_TERMINAL:
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
                case ModelCode.CNODE_CNODECONTAINER:
                    cncId = property.AsReference();
                    break;
                case ModelCode.CNODE_TNODE:
                    tNodeId = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        public override bool IsReferenced
        {
            get
            {
                return terminals.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (cncId != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.CNODE_CNODECONTAINER] = new List<long>();
                references[ModelCode.CNODE_CNODECONTAINER].Add(cncId);
            }
            if (tNodeId != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.CNODE_TNODE] = new List<long>();
                references[ModelCode.CNODE_TNODE].Add(tNodeId);
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
                case ModelCode.TERMINAL_CNODE:
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
                case ModelCode.TERMINAL_CNODE:

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
