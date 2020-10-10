using CoursePreReqResolver.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoursePreReqResolver.InputParser
{
    public class ArrayInputParser : IInputParser
    {
        /// <summary>
        /// This list contains the actual courses along with PreRequisites
        /// </summary>
        private Dictionary<string, List<string>> CourseList = new Dictionary<string, List<string>>();

        /// <summary>
        /// the list contains flattened list of dependencies. 
        /// e.g the input is 
        /// "Intro:God"
        /// "Circular:Intro"
        /// "God:Circular"
        /// This list contains a flattened dependencies like God<-- {Intro, Circular}.
        /// This list helps in identifying cycles
        /// </summary>
        private Dictionary<string, List<string>> FlatList = new Dictionary<string, List<string>>();

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
                if (!courses.Contains(item.Key))
                {
                    courses.Add(item.Key);
                }
                var list = item.Value;
                list.Reverse();
                courses.AddRange(list);
            }

            return courses;

        }

        private void AddCourseAndPreReqs(string course, string preReq)
        {
            if (FlatList.ContainsKey(preReq))
            {
                CourseList[preReq].Add(course);
                FlatList[preReq].Add(course);
            }
            else if (FlatList.ContainsKey(course))
            {
                if (FlatList[course].Contains(preReq))
                {
                    throw InputParserException.InvalidInputException(ErrorMessages.INPUT_CONTAINS_CYCLE);
                }
                FlatList[preReq] = CourseList[course];
                FlatList[preReq].Add(course);
                FlatList.Remove(course);
            }
            else
            {
                CourseList[preReq] = new List<string>
                {
                    course
                };

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
                if (CourseList[key].Contains(course))
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
