using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemElement.Models;

namespace SystemElement.Controllers
{
    public class HomeController : Controller
    {
        private IElementRepository elementRepository;
        private String path;

        public HomeController(IElementRepository repository)
        {
            elementRepository = repository;
        }
        [HttpGet]
        public ActionResult Index(string permalink = null)
        {
            if (permalink == null)
            {
                elementRepository.TruncateElements();
                readRootFolder();
            }

            Element parentElement = null;

            if (permalink != null)
            {
                permalink = @"\" + permalink;
                parentElement = elementRepository.findParentElementByPermalink(permalink);
            }
            else
            {
                parentElement = elementRepository.findNullParentId();
            }

            if (parentElement == null)
            {
                if (permalink.IndexOf('/') != -1)
                {
                    string[] arrayParams = permalink.Split('/');
                    string parEln = arrayParams[arrayParams.Length - 1];
                    parentElement = elementRepository.findParentElementByPermalink(parEln);
                }
            }
            ViewBag.parentElement = parentElement;
            ViewBag.elements = elementRepository.findParentId(parentElement.Id);
            if (parentElement == null)
            {
                return View("Eror");
            }
            return View();
        }

        private void readRootFolder()
        {
            path = ConfigurationManager.AppSettings["RootPath"];

            string path2 = Server.MapPath(path);
            string some = Path.GetDirectoryName(path2);
            string words = path2.Substring(some.Length);


            Element parentElement = makeElement(null, words);
            ProcessDirectory(parentElement.Id, path2);
        }
        private void ProcessDirectory(int parentId, string rootDirectory)
        {
            string some = Path.GetDirectoryName(rootDirectory);

            List<string> listDirectories = Directory.EnumerateDirectories(rootDirectory).ToList();
            foreach (String element in listDirectories)
            {
                string words = element.Substring(rootDirectory.Length);
                Element temp = makeElement(parentId, words);
                ProcessDirectory(temp.Id, element);
            }
        }
        private Element makeElement(int? parentId, string currentDirectory)
        {
            Element element = new Element();
            element.Url = currentDirectory;
            element.ParentId = parentId;
            return elementRepository.StoreElement(element);
        }
    }
}