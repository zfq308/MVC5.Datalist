﻿using System;
using System.Collections.Generic;
using System.Web;

namespace Datalist
{
    public abstract class AbstractDatalist
    {
        public const String Prefix = "Datalist";
        public const String IdKey = "DatalistIdKey";
        public const String AcKey = "DatalistAcKey";

        public String DialogTitle
        {
            get;
            protected set;
        }
        public String DatalistUrl
        {
            get;
            protected set;
        }
        public String DefaultSortColumn
        {
            get;
            protected set;
        }
        public UInt32 DefaultRecordsPerPage
        {
            get;
            protected set;
        }
        public List<String> AdditionalFilters
        {
            get;
            protected set;
        }
        public DatalistSortOrder DefaultSortOrder
        {
            get;
            protected set;
        }
        public Dictionary<String, String> Columns
        {
            get;
            protected set;
        }

        public DatalistFilter CurrentFilter
        {
            get;
            set;
        }

        protected AbstractDatalist()
        {
            String sanitizedName = GetType().Name.Replace(AbstractDatalist.Prefix, String.Empty);
            Columns = new Dictionary<String, String>();
            AdditionalFilters = new List<String>();
            CurrentFilter = new DatalistFilter();
            DialogTitle = sanitizedName;
            DefaultRecordsPerPage = 20;

            DatalistUrl = String.Format("{0}://{1}{2}{3}/{4}",
                HttpContext.Current.Request.Url.Scheme,
                HttpContext.Current.Request.Url.Authority,
                HttpContext.Current.Request.ApplicationPath ?? "/",
                AbstractDatalist.Prefix,
                sanitizedName);
        }

        public abstract DatalistData GetData();
    }
}
