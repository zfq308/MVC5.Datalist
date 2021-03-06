﻿using Datalist.Tests.Objects.Data;
using System.Linq;
using System.Web.Mvc;

namespace Datalist.Tests.Objects
{
    public class TestDatalistProxy : GenericDatalistProxy<TestModel>
    {
        private IQueryable<TestModel> models;

        public TestDatalistProxy()
        {
            models = new Context().TestModels.OrderByDescending(model => model.Id);
        }
        public TestDatalistProxy(UrlHelper url) : base(url)
        {
            models = new Context().TestModels.OrderByDescending(model => model.Id);
        }

        protected override IQueryable<TestModel> GetModels()
        {
            return models;
        }
    }
}
