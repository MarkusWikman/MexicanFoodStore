using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanFoodStore.UI.Models.Link
{
    public class LinkGroup
    {
        public string Name { get; set; } = string.Empty;
        public List<LinkOption> LinkOptions { get; set; } = [];
    }
}
