﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Datalist.Tests.Objects
{
    public class TestModel
    {
        [DatalistColumn(0)]
        public String Id { get; set; }

        [DatalistColumn]
        [Display(Name = "TestDisplay")]
        public Int32 Number { get; set; }

        [Datalist(typeof(TestDatalistProxy))]
        public String ParentId { get; set; }

        [DatalistColumn(-5, Format = "{0:d}")]
        public DateTime CreationDate { get; set; }

        public Decimal Sum { get; set; }
        public String NullableString { get; set; }

        public String FirstRelationModelId { get; set; }
        public String SecondRelationModelId { get; set; }

        [DatalistColumn(1, Relation = "Value")]
        public virtual TestRelationModel FirstRelationModel { get; set; }

        [DatalistColumn(1, Relation = "NoValue")]
        public virtual TestRelationModel SecondRelationModel { get; set; }
    }
}
