using System;
using System.Runtime.InteropServices.ComTypes;
using API.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidateUserName.Test
{
    [TestClass]
    public class ValidateUserName
    {
         
        [TestMethod]
        public void TestingUserNameAndPassword_()
        {
            var user = new User {UserName = "Arvid", Password = "123"};
            var expectedName = "Arvid";
            var expectedPassword = "123";
            Assert.AreEqual(user.UserName, expectedName);
            Assert.AreEqual(user.Password,expectedPassword);


        }
        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void TextingUserNameAndPassword()
        //{
        //    var user = new User{UserName = "Arvid"};
        //var user = new User { UserName = "Laban", Password = null };
        //var metod = new CrimeController().AddUser(user);
        //Assert.ThrowsException<FormatException>(()=>metod);
        //    Assert.AreEqual(user,"Per");




        //}
        [TestMethod]
        public void TestingAddingNewUserWithoutPassword_expectedException()
        {
            var user = new User { UserName = "Laban", Password = null };
            var metod = new CrimeController().AddUser(user);
            Assert.ThrowsException<FormatException>(()=>metod);



        }
        //[TestMethod]
        //public void Test()
        //{
        //    var user = new User { UserName = "Laban" };
        //    var metod = new CrimeController().AddUser(user);
        //    Assert.ThrowsException<BadRequestResult>(() => metod);



        //}
    }
}
