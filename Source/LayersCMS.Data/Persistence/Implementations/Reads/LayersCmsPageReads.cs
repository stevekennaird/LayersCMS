using System;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Implementations.Reads.Base;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Data;

namespace LayersCMS.Data.Persistence.Implementations.Reads
{
    public class LayersCmsPageReads : LayersCmsReads,  ILayersCmsPageReads
    {
        #region Implementation of ILayersCmsReads<LayersCmsPage>

        public LayersCmsPage GetById(int id)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                return conn.QuerySingle<LayersCmsPage>(new {Id = id});
            }
        }

        #endregion

        #region Implementation of ILayersCmsPageReads

        public LayersCmsPage GetByUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("url");

            // If the url doesn't start with a forward slash, prepend one to the url
            if (!url.StartsWith("/"))
                url = String.Format("/{0}", url);

            using (IDbConnection conn = GetDbConnection())
            {
                return conn.QuerySingle<LayersCmsPage>(new { Url = url });
            }
        }

        public IEnumerable<LayersCmsPage> GetCollectionForParent(int? parentId)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                return parentId.HasValue 
                        ? conn.Select<LayersCmsPage>(p => parentId.Value == p.ParentId)
                        : conn.Select<LayersCmsPage>(p => parentId == null);
            }
        }

        #endregion
    }
}
