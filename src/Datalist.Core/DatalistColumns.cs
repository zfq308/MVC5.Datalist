﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Datalist
{
    public class DatalistColumns : IEnumerable<DatalistColumn>
    {
        private List<DatalistColumn> Columns
        {
            get;
        }
        public IEnumerable<String> Keys
        {
            get
            {
                return Columns.Select(column => column.Key);
            }
        }

        public DatalistColumns()
        {
            Columns = new List<DatalistColumn>();
        }

        public void Add(DatalistColumn column)
        {
            if (column == null)
                throw new ArgumentNullException(nameof(column));

            if (Columns.Any(col => col.Key == column.Key))
                throw new DatalistException($"Can not add datalist column with the same key '{column.Key}'.");

            Columns.Add(column);
        }
        public void Add(String key, String header, String cssClass = "")
        {
            Add(new DatalistColumn(key, header, cssClass));
        }
        public Boolean Remove(DatalistColumn column)
        {
            return Columns.Remove(column);
        }
        public Boolean Remove(String key)
        {
            return Columns.Remove(Columns.FirstOrDefault(column => column.Key == key));
        }
        public void Clear()
        {
            Columns.Clear();
        }

        public IEnumerator<DatalistColumn> GetEnumerator()
        {
            return Columns.ToList().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
