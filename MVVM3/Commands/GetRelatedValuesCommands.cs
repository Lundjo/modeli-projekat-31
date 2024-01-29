using FTN.Common;
using FTN.ServiceContracts;
using MVVM3.Model;
using MVVMLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM3.Commands
{
    public class GetRelatedValuesCommands
    {
        private ModelResourcesDesc modelResourcesDesc = new ModelResourcesDesc();

        public GetRelatedValuesCommands() { }

        protected INetworkModelGDAContract Proxy
        {
            get { return ProxyConnector.Instance.GetProxy(); }
        }

        // Method to get gids per dms model code
        public ObservableCollection<long> GetGIDs(DMSType modelCode)
        {
            int iteratorId = 0;
            List<long> ids = new List<long>();

            try
            {
                int numberOfResources = 2;
                int resourcesLeft = 0;

                List<ModelCode> properties = modelResourcesDesc.GetAllPropertyIds(modelCode);

                iteratorId = Proxy.GetExtentValues(modelResourcesDesc.GetModelCodeFromType(modelCode), properties);
                resourcesLeft = Proxy.IteratorResourcesLeft(iteratorId);

                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = Proxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        ids.Add(rds[i].Id);
                    }

                    resourcesLeft = Proxy.IteratorResourcesLeft(iteratorId);
                }

                Proxy.IteratorClose(iteratorId);
            }
            catch (Exception e)
            {
                
            }

            ObservableCollection<long> gids = new ObservableCollection<long>(ids);

            return gids;
        }

        // Method to get by values
        public ObservableCollection<PropertiesView> GetRelatedValues(long globalId, List<ModelCode> props, Association association, ModelCode requestedEntityType)
        {
            int iteratorId = 0;
            List<long> ids = new List<long>();
            ObservableCollection<PropertiesView> data = new ObservableCollection<PropertiesView>();

            try
            {
                int numberOfResources = 2;
                int resourcesLeft = 0;

                iteratorId = Proxy.GetRelatedValues(globalId, props, association);
                resourcesLeft = Proxy.IteratorResourcesLeft(iteratorId);

                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = Proxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        ids.Add(rds[i].Id);
                    }

                    resourcesLeft = Proxy.IteratorResourcesLeft(iteratorId);
                }

                Proxy.IteratorClose(iteratorId);

                foreach (long gid in ids)
                {
                    List<PropertyView> entity = new GetValuesCommands().GetValues(gid, props).ToList();
                    data.Add(new PropertiesView() { ParentElementName = requestedEntityType, Properties = entity });
                }
            }
            catch (Exception)
            {
            }

            return data;
        }
    }
}