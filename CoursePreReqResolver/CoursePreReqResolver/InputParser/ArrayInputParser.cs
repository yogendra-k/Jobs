using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoursePreReqResolver.InputParser
{
    /// <summary>
    /// Class provides ability to parse the string array input into list<string>
    /// </summary>
    public class ArrayInputParser 
    {
        /// <summary>
        /// This list contains the actual courses along with PreRequisites
        /// </summary>
        private Dictionary<string, List<string>> CourseList = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// the list contains flattened list of dependencies. 
        /// e.g the input is 
        /// "Intro:God"
        /// "Circular:Intro"
        /// "God:Circular"
        /// This list contains a flattened dependencies like God<-- {Intro, Circular}.
        /// This list helps in identifying cycles
        /// </summary>
        private Dictionary<string, List<string>> FlatList = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Parses the string array into List<string> which contains the ordered courses and its PreRequisites
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IEnumerable<string> ParseInput(string[] input)
        {
            ValidateInput(input);

            List<string> courses = new List<string>();
            List<string> nonDependentCourses = new List<string>();
            foreach (string coursePreReq in input)
            {
                if (!string.IsNullOrWhiteSpace(coursePreReq))
                {
                    var dependencyArray = coursePreReq.Split(':');

                    var course = dependencyArray[0].Trim();
                    var preReq = dependencyArray[1].Trim();

                    if (string.Equals(course,preReq,StringComparison.InvariantCultureIgnoreCase))
                    {
                        throw InputParserException.InvalidInputException(ErrorMessages.INVALID_INPUT_MESSAGE);
                    }

                    if (string.IsNullOrEmpty(preReq))
                    {
                        if (!courses.Contains(course))
                        {
                            courses.Add(course);
                        }
                    }
                    else
                    {
                        AddCourseAndPreReqs(course, preReq);
                    }

                }
            }
            foreach (var item in CourseList)
            {
                if (!courses.Contains(item.Key, StringComparer.InvariantCultureIgnoreCase))
                {
                    courses.Add(item.Key);
                }
                var list = item.Value;
                list.Reverse();
                courses.AddRange(list);
            }

            return courses;

        }

        /// <summary>
        /// A course can be a pre requisite for other course as well as 
        /// the course can have prerequisite. 
        /// This method links the course and its pre requisites appropriately
        /// </summary>
        /// <param name="course">The given course</param>
        /// <param name="preReq">The PreReq for the course</param>
        private void AddCourseAndPreReqs(string course, string preReq)
        {
            if (FlatList.ContainsKey(preReq))
            {
                CourseList[preReq].Add(course);
                FlatList[preReq].Add(course);
            }
            else if (FlatList.ContainsKey(course))
            {
                if (FlatList[course].Contains(preReq, StringComparer.InvariantCultureIgnoreCase))
                {
                    throw InputParserException.InvalidInputException(ErrorMessages.INPUT_CONTAINS_CYCLE);
                }
            }
            else
            {
                CourseList[preReq] = new List<string>
                {
                    course
                };
                //This is to establish all the courses that would depend on a particular course directly or indirectly. 
                //e.g if the input is 
                //intro:God
                //circular:intro
                //then this basically means that intro and circular are dependent on course titled God
                string key = FindPreReq(preReq);
                if (!string.IsNullOrEmpty(key))
                {
                    FlatList[key].Add(course);
                }
                else
                {
                    FlatList[preReq] = new List<string>
                    {
                        course
                    };
                }
            }
        }

        /// <summary>
        /// Given a course, find its PreRequisite
        /// </summary>
        /// <param name="course">The course whose PreReq has to be found</param>
        /// <returns>the name of the PreReq for the course if it exists. Empty string if no PreReq found</returns>
        private string FindPreReq(string course)
        {
            foreach (string key in CourseList.Keys)
            {
                if (CourseList[key].Contains(course, StringComparer.InvariantCultureIgnoreCase))
                {
                    return key;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates the input
        /// </summary>
        /// <param name="input"></param>
        private void ValidateInput(string[] input)
        {
            //Test if input is null
            if (input == null)
            {
                throw InputParserException.InvalidInputException(ErrorMessages.NULL_INPUT_MESSAGE);
            }

            if (input.Any(x=>string.IsNullOrWhiteSpace(x)))
            {
                throw InputParserException.InvalidInputException(ErrorMessages.INVALID_INPUT_MESSAGE);
            }

            //Test if input contains ":" in every element
            if (input.Any(x => !x.Contains(":")))
            {
                throw InputParserException.InvalidInputException(ErrorMessages.INVALID_INPUT_MESSAGE);
            }

        }
    }
}
