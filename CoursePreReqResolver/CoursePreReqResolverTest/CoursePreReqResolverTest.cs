using CoursePreReqResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoursePreReqResolverTest
{
    [TestClass]
    public class CoursePreReqResolverTest
    {
        [TestMethod]
        public void When_Input_Is_EmtyArray_Then_Result_Is_EmptyString()
        {
            //if the string input is empty the result is empty string
            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string result = resolver.GetOrderOfCourses(new string[] { });
            Assert.AreEqual(string.Empty, result);

        }

        [TestMethod]
        public void When_Input_Is_Null_Then_Exception_Is_Generated()
        {
            //if the input is null, an error message is returned
            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string result = resolver.GetOrderOfCourses(null);
            Assert.AreEqual(ErrorMessages.NULL_INPUT_MESSAGE, result);
        }
    }
}