using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab12
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Exam exam = new Exam();
            Reflector<Exam>.Asembly(exam.GetType());
            Console.WriteLine();
            Reflector<Exam>.PublicConstructors(exam.GetType());
            Console.WriteLine();
            Reflector<Exam>.PublicMethods(exam.GetType());
            Reflector<Exam>.Interfaces(exam.GetType());
            Reflector<Exam>.PublicMethods(exam.GetType());
            Reflector<Exam>.Invoke(exam.GetType(), "GetDate", new object[] { });
            Exam FirstExam = Reflector<Exam>.Create<Exam>(exam.GetType(), new Type[] { }, new object[] { });
            Console.WriteLine(FirstExam.Theme);
        }
    }

    abstract class Experiment
    {
        public abstract string GetTheme();

        public virtual DateTime GetDate()
        {
            return DateTime.Now.AddDays(7);
        }
    }

    class Test : Experiment, IQuestion
    {
        private string theme = "C#";
        private int[] answers = new int[10] { 2, 4, 1, 1, 3, 1, 4, 4, 1, 3 };

        public int CheckAnswer(int[] answers)
        {
            return 1;
        }

        string IQuestion.GetTheme()
        {
            return "Hello from interface";
        }

        public override string GetTheme()
        {
            return "Hello from class";
        }

        public override string ToString()
        {
            return theme;
        }
    }

    class Exam : Experiment
    {
        public string Theme { get; set; }
        private DateTime examDate = DateTime.Now.AddDays(12);

        public Exam()
        {
            Theme = "OOP";
            examDate = DateTime.Now.AddDays(12);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string GetTheme()
        {
            return this.Theme;
        }

        public override string ToString()
        {
            return "Theme";
        }

        public override DateTime GetDate()
        {
            return examDate;
        }
    }

    sealed class FinalExam : Exam
    {
        public new string Theme { get; set; }
        public override string ToString()
        {
            return this.Theme;
        }
    }

    class Printer
    {
        public void IAmPrinting(Experiment obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }

    public interface IQuestion
    {
        int CheckAnswer(int[] answers);
        string GetTheme();
    }
}
