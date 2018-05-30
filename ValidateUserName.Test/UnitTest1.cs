using System;
using System.Runtime.InteropServices.ComTypes;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidateUserName.Test
{
    [TestClass]
    public class ValidateUserName
    {
         
        [TestMethod]
        public void TestingUserNameAndPassword_()
        {
            var user = new User("Arvid", "123");
            var expectedName = "Arvid";
            var expectedPassword = "123";
            Assert.AreEqual(user.UserName, expectedName);
            Assert.AreEqual(user.Password,expectedPassword);


        //}
        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void TextingUserNameAndPassword()
        //{
        //    var user = new User("", "123");
        //    Assert.AreEqual(user.UserName, "");



        //}
    }
}
