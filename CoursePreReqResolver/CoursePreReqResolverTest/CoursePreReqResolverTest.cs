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

        [TestMethod]
        public void When_Input_Contains_Elements_WithAllSpaces_Then_Exception_Is_Generated()
        {
            string[] input = new string[] { "                    " };

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string result = resolver.GetOrderOfCourses(input);
            Assert.AreEqual(ErrorMessages.INVALID_INPUT_MESSAGE, result);


            input = new string[] { "A:B", "    " };
            resolver = new CoursePreReqResolver.CoursePreReqResolver();
            result = resolver.GetOrderOfCourses(input);
            Assert.AreEqual(ErrorMessages.INVALID_INPUT_MESSAGE, result);
        }

        [TestMethod]
        public void When_Input_Contains_Elements_WithNoColon_Then_Exception_Is_Generated()
        {
            string[] input = new string[] {"HistoryRubber"};

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string result = resolver.GetOrderOfCourses(input);
            Assert.AreEqual(ErrorMessages.INVALID_INPUT_MESSAGE, result);

        }

        [TestMethod]
        public void When_Valid_Input_Then_CorrectSequence_Generated()
        { 
            
        }

        
    }
}
