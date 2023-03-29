using System;

namespace Comand_29._03
{
    class Program
    {
        public class Tv
        {
            public void Onn()
            {
                Console.WriteLine("Включение телевизора !!");
            }
            public void Off()
            {
                Console.WriteLine("Выключение телевизора !!");
            }
        }
        public class Microvolnovka
        {
            public void Start_Cooking(int time)
            {
                Console.WriteLine($"Начало разогрева еды:{time}");

            }
            public void End_Cooking()
            {
                Console.WriteLine("Конец разогрева еды");
            }
        }
        public abstract class IComand
        {
            public abstract void Execute();
            public abstract void Undo();

        }
        public class TV_Command : IComand
        {
            public Tv tv { set; get; }

            public TV_Command(Tv t)
            {
                tv = t;
            }
            public override void Execute()
            {
                tv.Onn();
            }
            public override void Undo()
            {
                tv.Off();
            }
        }
        public class Microvolnovka_Command : IComand
        {
            public Microvolnovka microvolnovka { set; get; }

            public Microvolnovka_Command(Microvolnovka m)
            {
                microvolnovka = m;
            }
            public override void Execute()
            {
                microvolnovka.Start_Cooking(10);
            }
            public override void Undo()
            {
                microvolnovka.End_Cooking();
            }
        }
        public class Controller
        {
            public IComand comand { set; get; }

            public Controller()
            {

            }
            public void SetCommand(IComand c)
            {
                comand = c;
            }
            public void PressButton()
            {
                comand.Execute();
            }
            public void PressUndo()
            {
                comand.Undo();
            }

            public void Invok(IComand comand, bool Undo)
            {
                Controller controller = new Controller();
                controller.SetCommand(comand);
                controller.PressButton();
                if (Undo)
                {
                    controller.PressUndo();
                }
            }
        }
        
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Controller controller = new Controller();
            Tv tv = new Tv();
            IComand comand = new TV_Command(tv);
            controller.Invok(comand, true);
            Microvolnovka microvolnovka = new Microvolnovka();
            comand = new Microvolnovka_Command(microvolnovka);
            controller.Invok(comand, false);
        }
    }
}
