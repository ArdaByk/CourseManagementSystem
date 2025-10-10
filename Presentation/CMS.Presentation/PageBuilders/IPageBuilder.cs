using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Presentation.PageBuilders;

public interface IPageBuilder
{
    void Build(TabPage tabPage);
}
