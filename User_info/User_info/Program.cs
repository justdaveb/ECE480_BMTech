using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace User_info
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\lukas\Documents\2016 fall\ECE 480\Users\UserLoadFileNew.csv"));//C:\Users\David\Documents\Visual Studio 2013\Projects\Users\UserLoadFile2.csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            List<string> listD = new List<string>();
            List<string> listE = new List<string>();
            List<string> listF = new List<string>();
            List<string> listG = new List<string>();
            List<string> listH = new List<string>();
            List<string> listI = new List<string>();
            List<string> courses1 = new List<string>();
            List<string> courses2 = new List<string>();
            List<string> courses3 = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var attributes = line.Split(',');
                listA.Add(attributes[0]);
                listB.Add(attributes[1]);
                listC.Add(attributes[2]);
                listD.Add(attributes[3]);
                listE.Add(attributes[4]);
                listF.Add(attributes[5]);
                listG.Add(attributes[6]);
                listH.Add(attributes[7]);
                listI.Add(attributes[8]);
            }
            foreach (string test in listB)
            {
                if (test == "")
                {
                    courses1.Add("0");
                }
                else
                {
                    courses1.Add("1");
                }
            }


            User yin = new User();
            User Johnson = new User();
            yin.update(listB);
            Johnson.update(listE);
            Console.WriteLine("test");
            Console.WriteLine(Johnson.taken_courses[0]);
            double[] tester = new double[100];
           // int j = 20;
            for (int j = 0; j <Johnson.counter2; j++)
            {
                tester[j] = Convert.ToDouble(Johnson.courses_taken[j]);
                Johnson.taken_courses[j] = tester[j];
            }
            Console.WriteLine("test");
            Console.WriteLine(Johnson.taken_courses[0]);
            Console.WriteLine(Johnson.counter2);

            /* foreach (string name in listE)
             {
                 Console.WriteLine("\"{0}\"", name);
             }*/



            //Console.WriteLine("Please Enter a Student's ID");
            //studentID = Console.ReadLine();
            //Student.SearchStudent(studentID);
            //Student.loadStudent();
        }
    }
    public class User
    {
        string admin_lvl;
        string admin_type;
        string identification;
        string major, student_LVL;
        string last_name, first_name;
        public string[] courses_taken = new string[100];
        public double[] taken_courses = new double[100];
        int units_desired;
        double[] Desired_course = new double[6];
        public int counter = 0, counter2 = 0;
        int[] compare = new int[100];

        public User()//default constructor
        {

        }
        public User(List<string> list)//constructor we should be using
        {
            update(list);

        }
        public void update(List<string> list)
        {
            admin_type = list[1];
            major = list[5];
            admin_lvl = list[0];
            //update_user();
            update_Lastname(list[2]);
            update_Firstname(list[3]);
            identification = list[4];
            update_studentLVL(list[6]);
            //display();
            load_user();
            for (int i = 7; i < 100; i++)
            {
                
                if (list[i] == "X")
                    break;
                else 
                    add_takenCourse(list[i]);
               }
            load_user();
        }
        public void display()
        {
            Console.WriteLine("\n {0}, {1}, {2}, {3}, {4}, {5}, {6}", admin_lvl, admin_type, last_name, first_name, identification, major, student_LVL);

        }

        //the next part is for updating student parameters.
        /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
        /*public void update_user()//This will be primarily entering new students
        {
            //prompts for major, name, etc.
        }*/
        public void load_user()
        {
            int tab_counter=0;
            Console.WriteLine("User's name: {0}, {1}", last_name, first_name);
            Console.WriteLine("User's ID#: {0}", identification);
            Console.WriteLine("User's type: {0}", admin_type);
            Console.WriteLine("User's department/major: {0}", major);
            if (admin_lvl == "0")
            {
                Console.WriteLine("Student level: {0}", student_LVL);
                if (courses_taken[0] == "x")
                    Console.WriteLine("No courses taken so far.");
                else
                {
                    Console.WriteLine("Courses taken: ");
                    for (int j = 0; j <= counter2; j++)
                    {
                        if (courses_taken[j] == "X")
                            break;
                        else
                        {
                            if (tab_counter == 9)
                            {
                                tab_counter = 0;
                                Console.WriteLine(" ");
                            }
                            Console.Write(courses_taken[j]);
                            Console.Write("\t");
                            tab_counter++;
                        }
                    }
                }
            }
            Console.WriteLine(" ");

        }
        public void update_units(int units)//This will input the amount of units the student wants to take
        {
            units_desired = units;
        }
        public void add_desired_course(double course)//This is where the student will enter desired courses.  if there are none, defaults to blank
        {
            Desired_course[counter] = course;
            counter++;
        }
        public void update_Lastname(string last)//This will be called upon initialization, or if the student has a name change
        {
            last_name = last;
        }
        public void update_Firstname(string first)
        {
            first_name = first;
        }
        public void update_major(string new_major)//If the student changes their major
        {
            major = new_major;
        }
        public void update_studentLVL(string newLVL)//freshman, etc...
        {
            student_LVL = newLVL;
        }
        public void add_takenCourse(string taken)//, int total, Courses[] winter)
        {
            courses_taken[counter2] = taken;
            /* for (int i=0; i<total; i++)//compares to the list of courses to see mark what does not need to be taken
            {
                if (taken == winter[i].course)
                    compare[i] = 1;
            }*/
            counter2++;

        }
        
        //the next part is for the methods that will be used for generation, etc
        /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/
    }

    public class Courses
    {
        public double course;
        string course_name;
        int units;
        string major;
        int days, begin, end;
        double core;
        double[] pre = new double[6];
        int counter1;

        public Courses()//default constructor
        {

        }
        public Courses(double a, string name, int b, string maj, int day, int start, int stop)//detailed constructor
        {
            course = a;
            course_name = name;
            units = b;
            major = maj;
            days = day;
            begin = start;
            end = stop;
            counter1 = 0;
        }
        public void updateCourses(double a, string name, int b, string maj, int day, int start, int stop)//input all data
        {
            course = a;
            course_name = name;
            units = b;
            major = maj;
            days = day;
            begin = start;
            end = stop;
            counter1 = 0;
        }
        public void add_coreq(double coreq)//add a corequisite
        {
            core = coreq;   
        }
        public void add_Prereq(double prereq)//add a prerequisite
        {
            pre[counter1] = prereq;
            counter1++;
        }
        public void load_course()
        {
            Console.WriteLine("Course: ", course);
            Console.WriteLine("Course name: ", course_name);
            Console.WriteLine("Units: ", units, "/tMajor(s): ", major);
            Console.WriteLine("Day/Times:", days, " ", begin, " ", end);
            Console.WriteLine("Coreq: ", core);
            Console.Write("Prereq: ");
            for (int k=0; k<6; k++)
            {
                if (pre[k] == 0)
                    Console.WriteLine(" ");
                else
                    Console.Write(Convert.ToString(pre[k]), "/t");
            }
        }
    }
}
