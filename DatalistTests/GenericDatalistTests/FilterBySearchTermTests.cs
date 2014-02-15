﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DatalistTests.GenericDatalistTests
{
    [TestClass]
    public class FilterBySearchTermTests : GenericDatalistTests
    {
        #region Tests

        [TestMethod]
        public void NullTermTest()
        {
            Datalist.CurrentFilter.SearchTerm = null;
            var actual = Datalist.BaseFilterBySearchTerm(Datalist.Models).ToList();
            var expected = Datalist.Models;

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void WhiteSpaceTermTest()
        {
            Datalist.CurrentFilter.SearchTerm = "   ";
            var actual = Datalist.BaseFilterBySearchTerm(Datalist.Models).ToList();
            var expected = Datalist.Models;

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void ContainsSearchTest()
        {
            var term = "1";
            Datalist.CurrentFilter.SearchTerm = term;
            var actual = Datalist.BaseFilterBySearchTerm(Datalist.Models).ToList();
            var expected = Datalist.Models.Where(model =>
                (model.Id != null && model.Id.ToLower().Contains(term)) ||
                (model.FirstRelationModel != null && model.FirstRelationModel.Value != null && model.FirstRelationModel.Value.ToLower().Contains(term)) ||
                (model.SecondRelationModel != null && model.SecondRelationModel.Value != null && model.SecondRelationModel.Value.ToLower().Contains(term))).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        #endregion
    }
}