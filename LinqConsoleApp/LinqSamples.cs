using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}
            Console.WriteLine("=============Przyklad 1");
            Console.WriteLine("==Query");
            //1. Query syntax (SQL)
            var res = from emp in Emps 
                where emp.Job == "Backend programmer"
                select emp;
            foreach (Emp emp in res)
            {
                Console.WriteLine(emp);
            }


            Console.WriteLine("==Lambda");
            //2. Lambda and Extension methods
            var res2 = Emps.Where(e => e.Job == "Backend programmer");
            foreach (Emp emp in res2)
            {
                Console.WriteLine(emp);
            }

        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            Console.WriteLine("=============Przyklad 2");
            Console.WriteLine("==Query");
            var res = from emp in Emps
                            where emp.Job == "Frontend programmer" && emp.Salary > 1000
                            orderby emp.Ename descending
                            select emp;

            foreach (Emp emp in res)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("==Lambda");
            var res2 = Emps
                .Where(e => e.Job == "Frontend programmer" && e.Salary > 1000)
                .OrderByDescending(e => e.Ename);

            foreach (Emp emp in res2)
            {
                Console.WriteLine(emp);
            }
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            Console.WriteLine("=============Przyklad 3");

            Console.WriteLine("==Lambda");
            var res = Emps.Max(e => e.Salary);
            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            Console.WriteLine("=============Przyklad 4");
            Console.WriteLine("==Query");
            var res = from emp in Emps
                            where emp.Salary == Emps.Max(e => e.Salary)
                            select emp;

            foreach (Emp emp in res)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("==Lambda");
            var res2 = Emps.Where(e => e.Salary == Emps.Max(e1 => e1.Salary));

            foreach (Emp emp in res2)
            {
                Console.WriteLine(emp);
            }
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            Console.WriteLine("=============Przyklad 5");
            Console.WriteLine("==Query");
            var res = from emp in Emps
                            select new
                            {
                                Nazwisko = emp.Ename,
                                Praca = emp.Job
                            };

            foreach (var re in res)
            {
                Console.WriteLine(re);
            }

            Console.WriteLine("==Lambda");

            var res2 = Emps.Select(e => new {Nazwisko = e.Ename, Praca = e.Job});

            foreach (var re in res2)
            {
                Console.WriteLine(re);
            }

        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            Console.WriteLine("=============Przyklad 6");
            Console.WriteLine("==Query");
            var res = from emp in Emps
                join dept in Depts on emp.Deptno equals dept.Deptno
                select new
                {
                    emp.Ename,
                    emp.Job,
                    dept.Dname
                };

            foreach (var re in res)
            {
                Console.WriteLine(re);
            }

            Console.WriteLine("==Lambda");
            var res2 = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno,
                (emp, dept) => new {emp.Ename, emp.Job, dept.Dname});

            foreach (var re in res2)
            {
                Console.WriteLine(re);
            }


        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            Console.WriteLine("=============Przyklad 7");
            Console.WriteLine("==Query");

            var res = from emp in Emps
                group emp by emp.Job
                into prace
                select new
                {
                    Praca = prace.Key,
                    LiczbaPracownikow = prace.Count()
                };
            foreach (var re in res)
            {
                Console.WriteLine(re);   
            }

            Console.WriteLine("==Lambda");

            var res2 = Emps.GroupBy(e => e.Job).Select(praca => new
            {
                Praca = praca.Key,
                LiczbaPracownikow = praca.Count()
            });

            foreach (var x1 in res2)
            {
                Console.WriteLine(x1);
            }

        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            Console.WriteLine("=============Przyklad 8");
            Console.WriteLine("==Lambda");
            var res = Emps.Any(e => e.Job == "Backend programmer");
            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            Console.WriteLine("=============Przyklad 9");
            Console.WriteLine("==Lambda");

            var res = Emps
                .Where(e => e.Job == "Frontend programmer")
                .OrderByDescending(e=>e.HireDate)
                .FirstOrDefault();

            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            Console.WriteLine("=============Przyklad 10");
            Console.WriteLine("==Query");
            var res = from emp in Emps
                    .Union(new List<Emp> {new Emp {Ename = "Brak wartości", Job = null, HireDate = null}})
                select new
                {
                    emp.Ename,
                    emp.Job,
                    emp.HireDate
                };

            foreach (var re in res)
            {
                Console.WriteLine(re);
            }

            Console.WriteLine("==Lambda");
            var res2 = Emps
                .Union(new List<Emp> {new Emp {Ename = "Brak wartości", Job = null, HireDate = null}})
                .Select(e => new {e.Ename, e.Job, e.HireDate});

            foreach (var x1 in res2)
            {
                Console.WriteLine(x1);
            }
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            Console.WriteLine("=============Przyklad 11");
            Console.WriteLine("==Lambda");

            var res = Emps.Aggregate((res, next) =>
            {
                if (res.Salary < next.Salary) return next;
                else return res;
            });

            Console.WriteLine(res);

        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            Console.WriteLine("=============Przyklad 12");
            Console.WriteLine("==Lambda");

            var res = Emps.SelectMany(e => Depts, (e, d) => new
            {
                e.Ename,
                d.Dname
            });

            foreach (var re in res)
            {
                Console.WriteLine(re);
            }
        }
    }
}
