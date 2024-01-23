using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Topology
{
    public class TopologicalNode : IdentifiedObject
    {
        private List<long> cNodes = new List<long>();

        public TopologicalNode(long globalId) : base(globalId)
        {
        }

        public List<long> CNodes
        {
            get { return cNodes; }
            set { cNodes = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TopologicalNode x = (TopologicalNode)obj;
                return CompareHelper.CompareLists(x.cNodes, this.cNodes);
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

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.TNODE_CNODE:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TNODE_CNODE:
                    prop.SetValue(cNodes);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            base.SetProperty(property);

        }

        public override bool IsReferenced
        {
            get
            {
                return cNodes.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (cNodes != null && cNodes.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TNODE_CNODE] = cNodes.GetRange(0, cNodes.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.CNODE_TNODE:
                    cNodes.Add(globalId);
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
                case ModelCode.CNODE_TNODE:

                    if (cNodes.Contains(globalId))
                    {
                        cNodes.Remove(globalId);
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
