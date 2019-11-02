using Droplet.WindowsApp.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.WindowsApp.Services
{
    public class ComponentManager
    {
        public ComponentManager()
        {
            _components = new Dictionary<Guid, ComponentBase>();
        }

        private readonly Dictionary<Guid, ComponentBase> _components;

        public void Add(ComponentBase component) 
            => _components.Add(component.Id, component);

        public ComponentBase Get(Guid id) 
            => _components[id];
    }
}
