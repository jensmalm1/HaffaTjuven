using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidateUserName.Test
{
    [TestClass]
    public class ValidateUserName
    {
        //User
        [TestMethod]
        public void WhenAddingANewUserAndNameIsNull_ExcpectedBadRequestMsg()
        {
            Assert.AreEqual(user.UserName, "Anna");
           

        }
    }
}
