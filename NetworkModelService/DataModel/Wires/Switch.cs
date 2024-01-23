using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Switch : ConductingEquipment
    {
        private bool normalOpen;
        private float ratedCurrent;
        private bool retained;
        private int switchOnCount;
        private DateTime switchOnDate;

        public Switch(long globalId) : base(globalId)
        {
        }

        public bool NormalOpen { get => normalOpen; set => normalOpen = value; }
        public float RatedCurrent { get => ratedCurrent; set => ratedCurrent = value; }
        public bool Retained { get => retained; set => retained = value; }
        public int SwitchOnCount { get => switchOnCount; set => switchOnCount = value; }
        public DateTime SwitchOnDate { get => switchOnDate; set => switchOnDate = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Switch x = (Switch)obj;
                return (x.normalOpen == this.normalOpen && x.ratedCurrent == this.ratedCurrent && x.retained == this.retained && x.switchOnCount == this.switchOnCount && x.switchOnDate == this.switchOnDate);
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
                case ModelCode.SWITCH_NORMALOPEN:
                case ModelCode.SWITCH_RATEDCURRENT:
                case ModelCode.SWITCH_RETAINED:
                case ModelCode.SWITCH_ONCOUNT:
                case ModelCode.SWITCH_ONDATE:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.SWITCH_NORMALOPEN:
                    prop.SetValue(normalOpen);
                    break;

                case ModelCode.SWITCH_RATEDCURRENT:
                    prop.SetValue(ratedCurrent);
                    break;

                case ModelCode.SWITCH_RETAINED:
                    prop.SetValue(retained);
                    break;

                case ModelCode.SWITCH_ONCOUNT:
                    prop.SetValue(switchOnCount);
                    break;

                case ModelCode.SWITCH_ONDATE:
                    prop.SetValue(switchOnDate);
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
                case ModelCode.SWITCH_NORMALOPEN:
                    normalOpen = property.AsBool();
                    break;

                case ModelCode.SWITCH_RATEDCURRENT:
                    ratedCurrent = property.AsFloat();
                    break;

                case ModelCode.SWITCH_RETAINED:
                    retained = property.AsBool();
                    break;

                case ModelCode.SWITCH_ONCOUNT:
                    switchOnCount = property.AsInt();
                    break;

                case ModelCode.SWITCH_ONDATE:
                    switchOnDate = property.AsDateTime();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
    }
}
