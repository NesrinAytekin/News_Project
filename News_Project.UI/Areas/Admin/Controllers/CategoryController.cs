using News_Project.Entity.Entities;
using News_Project.Service.Repository;
using News_Project.UI.Areas.Admin.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_Project.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository(); //Sınıf Çağırıldığında üretilsin diye yapıcı method içerinde yazdık
           
        }
        // GET: Admin/Category

        [HttpGet]
        public ActionResult Create()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult Create(CategoryDTO data)//CategoryDTO'ya burada ihtiyaç yok direk nesnenin kendisini gönder diyorum
        {
            //Aşağıda Tek satırda nesnenin bütün datalarını getir diyorum burada.
            //CoreRepositoryde belirttiğim Add() metodunu kullanarak sınıfım "T" Tipindeki itemlerını getir diyorum yani category sınıfının dataları getir diyerek tek satırda işlem tamamlanmış oluyor.
            //Boylece tek metotla istediğim nesnenin verilerini getirebilirim.
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = data.Name;
                _categoryRepository.Add(category);
                ViewBag.TransactionStatus = 1;
                return View();//Eklenir eklenmez Listeyi Bana göstersin
            }
            else
            {
                ViewBag.TransactionStatus = 2;
                return View(); //Eklenir eklenmez Listeyi Bana göstersin
            }

        }
        public ActionResult List()
        {
            //Aşağıda CoreRepositoryden kalıtım Alan CategoryRepository sınıfımın GetActive() metodunu kullanarak İçerisine "T" yerine verdiğim categori sınıfında aktifleri tek satırla listelemiş oldum
            List<Category> model = _categoryRepository.GetActive();
            return View(model);
        }
        public ActionResult Update(int id)
        {        
                Category category = _categoryRepository.GetById(id);
                CategoryDTO model = new CategoryDTO();
                model.Id = category.Id; //Yakaladığım categori nesnesindeki verileri model'atayacağım
                model.Name = category.Name;
                ViewBag.TransactionStatus = 1;
                return View(model);//doldurduğum modelle birlikte döndür diyorum
        
        }
        [HttpPost]
        public ActionResult Update(CategoryDTO model)
        {
            //Yukarıdaki işlemde databasede yakalaadıgım modeli category'e atmıştım şimdi oluşturduğum modeli database atayacağım
            Category category = _categoryRepository.GetById(model.Id);
            category.Name = model.Name;
            _categoryRepository.Update(category);
            return Redirect("/Admin/Category/List");
        }
        public ActionResult Delete (int id)
        {
            _categoryRepository.Remove(id);
            return Redirect("/Admin/Category/List");
        }
    }
}