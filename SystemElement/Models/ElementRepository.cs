using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemElement.Models
{
    public class ElementRepository : IElementRepository
    {
        private readonly ElementDBContext dBContext;
        private Boolean Disposed;
        public ElementRepository(ElementDBContext context)
        {
            dBContext = context;
        }
        public Element findNullParentId()
        {
            return dBContext.Elements.Where(m => m.ParentId == null).FirstOrDefault();
        }

        public Element findParentElementByPermalink(string permalink)
        {
            return dBContext.Elements.Where(m => m.Url == permalink).FirstOrDefault();
        }

        public IEnumerable<Element> findParentId(int parentID)
        {
            return dBContext.Elements.Where(m => m.ParentId == parentID).ToList();
        }

        public Element StoreElement(Element element)
        {
            dBContext.Elements.Add(element);
            dBContext.SaveChanges();
            return element;
        }

        public void TruncateElements()
        {
            dBContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Elements]");
        }
    }
}