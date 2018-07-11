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
            throw new NotImplementedException();
        }

        public Element findParentElementByPermalink(string permalink)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Element> findParentId(int parentID)
        {
            throw new NotImplementedException();
        }

        public int StoreElement(Element element)
        {
            throw new NotImplementedException();
        }

        public void TruncateElements()
        {
            throw new NotImplementedException();
        }
    }
}