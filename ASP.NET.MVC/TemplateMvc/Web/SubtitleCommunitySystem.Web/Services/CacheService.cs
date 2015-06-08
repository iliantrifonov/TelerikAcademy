namespace Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Web.Caching;
    using System.Web;

    using AutoMapper.QueryableExtensions;
    using Gma.DataStructures.StringSearch;

    using Data;

    public class CacheService : ICacheService
    {
        private const string SubtitleSearchCacheKey = "subtitleSearch";
        private const string UserCacheDropDownFormat = "users:{0}:{1}";

        public CacheService(IApplicationData data)
        {
            this.Data = data;
        }

        protected IApplicationData Data { get; set; }
    }
}