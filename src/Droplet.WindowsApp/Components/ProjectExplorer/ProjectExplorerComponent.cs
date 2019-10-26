using Droplet.Core.Inp.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Droplet.WindowsApp.Components.ProjectExplorer
{
    public class ProjectExplorerComponent : ComponentBase
    {
        public ProjectExplorerComponent()
        {

        }

        public List<EntityClass> Entities = new List<EntityClass>()
        {
            new EntityClass("Subcatchments")
            {
                Members = new ObservableCollection<InpEntity>()
                {
                    new Subcatchment() { Name = "1"},
                    new Subcatchment() { Name = "2"}
                }
            }
        };
    }

    public class EntityClass
    {

        public EntityClass(string name)
        {
            Members = new ObservableCollection<InpEntity>();
            Name = name;
        }

        public string Name { get; set; }

        public ObservableCollection<InpEntity> Members { get; set; }
    }
}
