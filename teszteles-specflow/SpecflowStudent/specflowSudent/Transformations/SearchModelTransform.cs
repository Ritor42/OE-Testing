using specflowSudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace specflowSudent.Transformations
{
    [Binding]
    public class SearchModelTransform
    {
        [StepArgumentTransformation]
        public SearchModel TransformTableToSearchModel(Table table)
        {
            return table.CreateInstance<SearchModel>();
        }
    }
}
