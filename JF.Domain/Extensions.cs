using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain
{
    public static class Extensions
    {
        public static List<String> GetValuesOfJob()
        {
            List<String> jobs = new();
            var enumType = typeof(Jobs);
            var memberInfo = enumType.GetMembers();
            var enumValueMembersInfo = memberInfo.Where(m => m.DeclaringType == enumType).Skip(1);

            foreach (var value in enumValueMembersInfo)
            {
                var valueAttribute = value.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)valueAttribute[0]).Description;
                jobs.Add(description.ToString());
            }

            return jobs;
        }

        public static List<String> GetValuesOfOtrasli()
        {
            List<String> otrasli = new();
            var enumType = typeof(Otrasli);
            var memberInfo = enumType.GetMembers();
            var enumValueMembersInfo = memberInfo.Where(m => m.DeclaringType == enumType).Skip(1);

            foreach (var value in enumValueMembersInfo)
            {
                var valueAttribute = value.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)valueAttribute[0]).Description;
                otrasli.Add(description.ToString());
            }

            return otrasli;
        }

        public static List<String> GetValuesOfGraphs()
        {
            List<String> graphs = new();
            var enumType = typeof(Graphs);
            var memberInfo = enumType.GetMembers();
            var enumValueMembersInfo = memberInfo.Where(m => m.DeclaringType == enumType).Skip(1);

            foreach (var value in enumValueMembersInfo)
            {
                var valueAttribute = value.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)valueAttribute[0]).Description;
                graphs.Add(description.ToString());
            }

            return graphs;
        }
    }
}
