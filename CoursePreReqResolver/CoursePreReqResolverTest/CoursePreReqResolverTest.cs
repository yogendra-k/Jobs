using CoursePreReqResolver;
using CoursePreReqResolver.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoursePreReqResolverTest
{
    [TestClass]
    public class CoursePreReqResolverTest
    {
        #region Validation Test methods

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
            string[] input = new string[] { "HistoryRubber" };

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string result = resolver.GetOrderOfCourses(input);
            Assert.AreEqual(ErrorMessages.INVALID_INPUT_MESSAGE, result);

        }

        [TestMethod]
        public void When_Input_Contains_Cycle_Then_Exception_Is_Generated()
        {
            string[] input = new string[] { "Intro to Arguing on the Internet: Godwin’s Law",
                                            "Understanding Circular Logic: Intro to Arguing on the Internet",
                                            "Godwin’s Law: Understanding Circular Logic"
                                          };

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string expectedResult = ErrorMessages.INPUT_CONTAINS_CYCLE;
            string result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);

        } 
        #endregion

        [TestMethod]
        public void When_Valid_Input_Then_CorrectSequence_Generated()
        {
            string[] input = new string[] { "Advanced Pyrotechnics: Introduction to Fire",
                                            "Introduction to Fire:"
                                        };

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string expectedResult = "Introduction to Fire, Advanced Pyrotechnics";
            string result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);
            input = new string[] {  "Introduction to Paper Airplanes:",
                                    "Advanced Throwing Techniques: Introduction to Paper Airplanes",
                                    "History of Cubicle Siege Engines: Rubber Band Catapults 101",
                                    "Advanced Office Warfare: History of Cubicle Siege Engines",
                                    "Rubber Band Catapults 101: ",
                                    "Paper Jet Engines: Introduction to Paper Airplanes"
                                };

            expectedResult = "Introduction to Paper Airplanes, Rubber Band Catapults 101, Paper Jet Engines, Advanced Throwing Techniques, History of Cubicle Siege Engines, Advanced Office Warfare";
            result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_Valid_Input_But_CaseInsensitive_Then_CorrectSequence_Generated()
        {
            string[] input = new string[] { "Advanced Pyrotechnics: Introduction to Fire",
                                            "Introduction To Fire:"
                                        };

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string expectedResult = "Introduction To Fire, Advanced Pyrotechnics";
            string result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);

            input = new string[] {  "A:",
                                    "ATT: a",
                                    "History : Rubber ",
                                    "Advanced : history ",
                                    "rubber : ",
                                    "Paper Jet : a"
                                };

            expectedResult = "A, rubber, Paper Jet, ATT, History, Advanced";
            result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void When_Input_Contains_Only_OneCourseNoDependency_Then_CorrectSequence_Generated()
        {
            string[] input = new string[] { "Advanced Pyrotechnics: "};

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string expectedResult = "Advanced Pyrotechnics";
            string result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_Input_Contains_TwoCoursesNoDependency_Then_CorrectSequence_Generated()
        {
            string[] input = new string[] { "Advanced Pyrotechnics: ","Introduction to Fire:" };

            CoursePreReqResolver.CoursePreReqResolver resolver = new CoursePreReqResolver.CoursePreReqResolver();

            string expectedResult = "Advanced Pyrotechnics, Introduction to Fire";
            string result = resolver.GetOrderOfCourses(input);

            Assert.AreEqual(expectedResult, result);
        }

      
    }
}
