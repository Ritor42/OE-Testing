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
    public class FeedbackModelTransform
    {
        [StepArgumentTransformation]
        public FeedbackModel TransformTableToSearchModel(Table table)
        {
            var model = table.CreateInstance<FeedbackModel>();
            model.SecondAnswer--;
            model.ThirdAnswer = string
                .Join(", ", model.ThirdAnswer.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x) - 1));
            model.FourthAnswer--;
            return model;
        }
    }
}
