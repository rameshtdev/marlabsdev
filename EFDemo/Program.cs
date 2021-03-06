﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFirst;
using DatabaseFirst;
using CodeFirst;
namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            /* //Model First
            var objBusiness = new ModelFirstLogic();
            objBusiness.AddCourse("Programming", "4");
            objBusiness.AddCourse("IT management", "3");
            objBusiness.AddCourse("Network Security", "2");
            objBusiness.AddCourse("Disaster Recovery", "4");
           
            objBusiness.AddStudent("UserFirstName1", "UserLastName1");
            objBusiness.AddStudent("UserFirstName2", "UserLastName2");
            objBusiness.AddStudent("UserFirstName3", "UserLastName3");
             
            //DB First
            var objBusiness = new DBFirstCodeLogic();
            objBusiness.AddCourse("System Architecture Advanced", "4");

            //Code First verbose commands
             (1) Enable-Migrations
            (2) Add-Migration Version_Name -ConnectionString "data source=.\sqlexpress;initial catalog=codefirst;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" -ConnectionProviderName "System.Data.SqlClient" -Verbose

            (3) Update-Database -ConnectionString "data source=.\sqlexpress;initial catalog=codefirst;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" -ConnectionProviderName "System.Data.SqlClient" -Verbose

            var objBusiness = new CodeFirstDataLogic();
            objBusiness.AddCourse("System Architecture Advanced", 7);
           
            var objBusiness = new ModelFirstLogic();
            var student = objBusiness.GetStudent(1);
            Console.ReadKey();
             

            //ASMX
            ProductService.ProductServiceSoapClient client = new ProductService.ProductServiceSoapClient();
            var product1= client.GetProduct(1);
            var product2 = client.GetProduct(2);
            Console.ReadKey();
            */
            //WCF

            WCFTestReference.IProductService product = new WCFTestReference.ProductServiceClient();
            WCFTestReference.Input inp = new WCFTestReference.Input() { ProductId = 1 };
            WCFTestReference.Input inp1 = new WCFTestReference.Input() { ProductId = 2 };
            var product1 = product.GetProduct(inp);
            var product2 = product.GetProduct(inp1);
            Console.ReadKey();
        }
    }
}
