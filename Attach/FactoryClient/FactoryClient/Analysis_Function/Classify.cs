using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FactoryClient.Analysis_Function
{
    //class ,grade ,week ,month
    class Classify
    {
        public enum Style
        {
            user_class, grade, week, month
        }
        List<Tuple<string, int>> user_class = new List<Tuple<string, int>>(),
            grade = new List<Tuple<string, int>>(),
            week = new List<Tuple<string, int>>(),
            month = new List<Tuple<string, int>>();

        bool Done_Build = false;

        public Classify(JArray data)
        {
            Task.Run(() =>
            {
                Dictionary<string, int> user_class = new Dictionary<string, int>(),
                   grade = new Dictionary<string, int>(),
                   week = new Dictionary<string, int>(),
                   month = new Dictionary<string, int>();
                Dictionary<DayOfWeek, string> weekdays = new Dictionary<DayOfWeek, string>()
                {
                    { DayOfWeek.Monday ,"週一" },
                    { DayOfWeek.Tuesday ,"週二" },
                    { DayOfWeek.Wednesday ,"週三" },
                    { DayOfWeek.Thursday ,"週四" },
                    { DayOfWeek.Friday ,"週五" },
                    { DayOfWeek.Saturday ,"週六" },
                    { DayOfWeek.Sunday ,"週日" }
                };

                for (int i = 1; i <= 20; i++) for (int j = 1; j <= 3; j++) user_class[(j * 100 + i).ToString()] = 0;
                for (int i = 1; i <= 3; i++) grade[i.ToString()] = 0;
                foreach (string s in weekdays.Values) week[s] = 0;
                for (int i = 1; i <= 12; i++) month[i.ToString()] = 0;
                user_class["其他"] = grade["其他"] = 0;

                foreach (JToken item in data)
                {
                    DateTime dt = DateTime.ParseExact(item["recv_date"].ToString(), "yyyy-MM-dd HH:mm:ss", null);

                    if (user_class.ContainsKey(item["user"]["class"]["class_no"].ToString()))
                        user_class[item["user"]["class"]["class_no"].ToString()] += 1;
                    else user_class["其他"] += 1;

                    if (grade.ContainsKey(item["user"]["class"]["class_no"].ToString().Substring(0, 1)))
                        grade[item["user"]["class"]["class_no"].ToString().Substring(0, 1)] += 1;
                    else grade["其他"] += 1;

                    week[weekdays[dt.DayOfWeek]] += 1;
                    month[dt.Month.ToString()] += 1;
                }

                for (int i = 1; i <= 20; i++) for (int j = 1; j <= 3; j++)
                        this.user_class.Add(new Tuple<string, int>(
                            (j * 100 + i).ToString(),
                            user_class[(j * 100 + i).ToString()])
                        );
                for (int i = 1; i <= 3; i++)
                    this.grade.Add(new Tuple<string, int>(
                        i.ToString(),
                        grade[i.ToString()])
                    );
                foreach (string s in weekdays.Values)
                    this.week.Add(new Tuple<string, int>(s, week[s]));
                for (int i = 1; i <= 12; i++)
                    this.month.Add(new Tuple<string, int>(i.ToString(), month[i.ToString()]));
                this.user_class.Add(new Tuple<string, int>("其他", user_class["其他"]));
                this.grade.Add(new Tuple<string, int>("其他", grade["其他"]));

                Done_Build = true;
            });
        }

        public IEnumerable<Tuple<string, int>> Get_Classify(Style style, string user_tag = null)
        {
            while (!Done_Build) Thread.Sleep(100);
            switch (style)
            {
                case Style.grade:
                    return grade;
                case Style.week:
                    return week;
                case Style.user_class:
                    return from item in user_class
                           where (user_tag == "其他" ? item.Item1 : item.Item1.Substring(0, 1)) == user_tag
                           orderby item.Item1
                           select item;
                case Style.month:
                    return month;
                default:
                    return null;
            }
        }
    }
}
