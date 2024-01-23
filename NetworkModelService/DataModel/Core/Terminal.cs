using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        private long conEqId;
        private long cNodeId;

        public Terminal(long globalId) : base(globalId)
        {
        }

        public long ConEqId
        {
            get { return conEqId; }
            set { conEqId = value; }
        }

        public long CNodeId
        {
            get
            {
                return cNodeId;
            }

            set
            {
                cNodeId = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal x = (Terminal)obj;
                return (x.conEqId == this.conEqId && x.cNodeId == this.cNodeId);
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
                case ModelCode.TERMINAL_CNODE:
                case ModelCode.TERMINAL_CONDEQ:

                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CNODE:
                    property.SetValue(cNodeId);
                    break;

                case ModelCode.TERMINAL_CONDEQ:
                    property.SetValue(conEqId);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    conEqId = property.AsReference();
                    break;

                case ModelCode.TERMINAL_CNODE: 
                    cNodeId = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (conEqId != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONDEQ] = new List<long>();
                references[ModelCode.TERMINAL_CONDEQ].Add(conEqId);
            }
            if (cNodeId != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CNODE] = new List<long> { cNodeId };
            }

            base.GetReferences(references, refType);
        }
    }
}
