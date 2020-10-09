using CoursePreReqResolver.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoursePreReqResolver.InputParser
{
    public class ArrayInputParser : IInputParser
    {
        public IEnumerable<string> ParseInput(string[] input)
        {
            ValidateInput(input);
            CourseAndPreReqs courseAndPreReqs = ParseInputIntoCoursesAndPreReqs(input);

            List<string> coursesInOrder = new List<string>();
            coursesInOrder.AddRange(courseAndPreReqs.NonDependentCourses);
            List<string> visitedCourses = new List<string>();

            foreach (var course in courseAndPreReqs.NonDependentCourses)
            {
                if (!visitedCourses.Contains(course))
                {
                    var dependentCourses = courseAndPreReqs.Courses[course];
                    dependentCourses.Reverse();
                    coursesInOrder.AddRange(dependentCourses);
                    visitedCourses.Add(course);

                }
            }

            foreach (var course in courseAndPreReqs.Courses)
            {
                if (!visitedCourses.Contains(course.Key))
                {
                    var dependentCourses = courseAndPreReqs.Courses[course.Key];
                    dependentCourses.Reverse();
                    coursesInOrder.AddRange(dependentCourses);
                    visitedCourses.Add(course.Key);

                }
            }

            return coursesInOrder;

        }

        private CourseAndPreReqs ParseInputIntoCoursesAndPreReqs(string[] input)
        {
            IDictionary<string, List<string>> dependencies = new Dictionary<string, List<string>>();
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
                        nonDependentCourses.Add(course);
                    }

                    if (!string.IsNullOrEmpty(preReq))
                    {
                        if (!dependencies.ContainsKey(preReq))
                        {
                            dependencies[preReq] = new List<string>();
                        }
                        dependencies[preReq].Add(course);

                    }
                }
            }

            CourseAndPreReqs courseAndPreReqs = new CourseAndPreReqs { Courses = dependencies, NonDependentCourses = nonDependentCourses };

            return courseAndPreReqs;
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
