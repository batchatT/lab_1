using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1
{
    class Student : IComparable
    {
        private string _name;
        private string _id;
        private int _course;

        private int[] _marksArr = new int[10];
        private double _avgMark => _marksArr.Average();
        public string Name
        {
            get => _name;

            set
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Iм`я не може бути порожнім");
                    }
                    for (int i = 0; i < value.Length; ++i)
                    {
                        if (Char.IsDigit(value[i]))
                        {
                            throw new Exception("Iм`я не може мiстити цифри");
                        }
                    }
                    _name = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Помилка: {e.Message}");
                }
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                try
                {
                    for (int i = 0; i < value.Length; ++i)
                    {
                        if (!Char.IsDigit(value[i]))
                        {
                            throw new Exception("Номер залiкової книжки може мiстити тiльки цифри");
                        }
                    }
                    _id = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Помилка: {e.Message}");
                }
            }
        }

        public int Course
        {
            get => _course;
            set
            {
                try
                {
                    if (value <= 0 || value > 6)
                    {
                        throw new Exception("Курс повинен знаходитись у діапазоні від 1 до 6 включно");
                    }
                    else _course = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Помилка: {e.Message}");
                }
            }
        }

        public int[] MarksArr { get => _marksArr; }
        public Student(string name, string id, int course)
        {
            Name = name;
            Id = id;
            Course = course;
        }

        public void SetMark(Subjects subj, int mark) => _marksArr[(int)subj] = mark;
        public int GetMark(Subjects subj) => _marksArr[(int)subj];
        public override string ToString() => $"Студент {Name}, залiкова книжка {Id}, курс {Course}";
        public int[] CompareTo(Student obj)
        {
            int[] diffMarks = new int[10];
            foreach (int i in diffMarks)
            {
                diffMarks[i] = this._marksArr[i] - obj._marksArr[i];
            }
            return diffMarks;
        }
        public int CompareTo(object obj) => throw new NotImplementedException();
    }
    enum Subjects
    {
        English,
        Embedded,
        Web,
        CSharp,
        CPlusPlus,
        ElCircuits,
        BigData,
        VHDL,
        Sports,
        Philosophy
    }
}
    