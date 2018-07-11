using Ninject;
using System;
using System.Collections.Generic;
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
            repository.TruncateElements();
        }
        [HttpGet]
        public ActionResult Index(string permalink = null)
        {
            if (permalink == null)
            {
                IEnumerable<string> listDirectories = new List<string>();
                readRootFolder();

                if (listDirectories.Count() > 0)
                {
                    ViewBag.listDirectories = listDirectories;
                    return View("~/Views/ShoDir/showDirs.cshtml");
                }
            }

            Element parentElement = null;

            if (permalink != null)
            {
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
            path = ".\\root";
            Element parentElement = makeElement(null, path);
            ProcessDirectory(parentElement.Id, path);
        }
        private void ProcessDirectory(int parentId, string rootDirectory)
        {
            IEnumerable<string> listDirectories = Directory.EnumerateDirectories(rootDirectory);
            foreach (String element in listDirectories)
            {
                Element temp = makeElement(parentId, element);
                ProcessDirectory(temp.Id, element);
            }
        }
        private Element makeElement(int? parentId, string currentDirectory)
        {
            Element element = new Element();
            element.Url = currentDirectory;
            element.ParentId = parentId;
            element.Id = elementRepository.StoreElement(element);
            return element;
        }
    }
}