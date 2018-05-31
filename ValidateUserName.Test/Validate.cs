using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using API.Controllers;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidateUserName.Test
{
    [TestClass]
    public class ValidateUserName:Controller
    {
        
        [TestMethod]
        public void TestingUserNameAndPassword_ExpectedAreEqual()
        {

            var user = new User {UserName = "Arvid", Password = "123"};
            var expectedName = "Arvid";
            var expectedPassword = "123";
            Assert.AreEqual(user.UserName, expectedName);
            Assert.AreEqual(user.Password,expectedPassword);


        }
        [TestMethod]
        public void TestingUserPassword_ExpectedAreNotEqual()
        {

            var user = new User { UserName = "Arvid", Password = "123" };
            var expectedPassword = "";
            Assert.AreNotEqual(user.Password, expectedPassword);


        }

        //[TestMethod]
        //public void TestingUserNameAndPassword()
        //{
        //    var user = new User { UserName = "Arvid" };
        //    var user = new User { UserName = "Laban", Password = null };
        //    var metod = new CrimeController().AddUser(user);
        //    Assert.ThrowsException<FormatException>(() => metod);
        //    Assert.AreEqual(user, "Per");
        //}

        [TestMethod]
        public void AddingNewUserWithoutPassword_expectedException()
        {

            var user = new User { UserName = "Laban", Password = null };
            var metod = new CrimeController().AddUser(user);
            Assert.ThrowsException<FormatException>(() => metod);

        }

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestResult))]
        //public void WhenAddingANewUserWithoutPassword_ExpectedBadRequest()
        //{
        //    var user = new User { UserName = "Laban" };
        //    var metod = new CrimeController().AddUser(user);
        //    Assert.IsNotNull(user.Password);

        //}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestResult))]
        //public void WhenAddingANewUserWithSameName_ExpectedBadRequest()
        //{
        //    var list = new List<User>(new User {UserName = "Laban"});

        //    var user = new User { UserName = "Laban" };
        //    var metod = new CrimeController().AddUser(user);
        //    Assert.IsNotNull(user.Password);

        //}


    }
}
