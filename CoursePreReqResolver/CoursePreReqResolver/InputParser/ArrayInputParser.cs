using CoursePreReqResolver.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoursePreReqResolver.InputParser
{
    public class ArrayInputParser : IInputParser
    {

        private Dictionary<string, List<string>> CourseList = new Dictionary<string, List<string>>();

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
            if (CourseList.ContainsKey(preReq))
            {
                CourseList[preReq].Add(course);
            }
            else if (CourseList.ContainsKey(course))
            {
                
            }
            else
            {
                CourseList[preReq] = new List<string>();
                CourseList[preReq].Add(course);
            }
        }

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
