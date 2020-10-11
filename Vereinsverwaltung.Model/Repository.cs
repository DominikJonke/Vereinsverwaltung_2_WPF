using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Vereinsverwaltung.Model
{
    public class Repository
    {
        private const string fileName = "Verein.csv";

        private static Repository instance;

        List<Member> members;

        private Repository()
        {
            members = new List<Member>();
            LoadMembersFromCsv();
        }

        public static Repository GetInstance()
        {
            if (instance == null)
                instance = new Repository();

            return instance;
        }
        private void LoadMembersFromCsv()
        {
            string[][] memberCsv = fileName.ReadStringMatrixFromCsv(true);
            members = memberCsv
                .Select(line => 
                new Member
                {
                    Firstname = line[0],
                    Lastname = line[1],
                    Birthdate = line[2]
                }).ToList();
        }

        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public void DeletMember(Member member)
        {
            members.Remove(member);
        }

        public List<Member> GetAllMembers()
        {
            return members.OrderBy(x => x.Lastname).ToList();
        }
    }
}
