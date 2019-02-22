using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo
{
    class Participants
    {
        private string lastname, firstname,strAnswers;
        private int classid, schoolid;
        private string final_scores;

        public Participants() {
            lastname = "";
            firstname = "";
            strAnswers = "";
            classid = 0;
            schoolid = 0;
        }

        public void setLastname(string ln) {
            this.lastname = ln;
        }

        public void setFirstname(string fn) {
            this.firstname = fn;
        }

        public void setStrAnswers(string sa) {
            this.strAnswers = sa;
        }

        public void setClassid(int ci) {
            this.classid = ci;
        }

        public void setSchoolid(int si) {
            this.schoolid = si;
        }

        public void setfinal_scores(string s) {
            this.final_scores = s;
        }

        public string getLastName() {
            return this.lastname;
        }

        public string getFirstName()
        {
            return this.firstname;
        }

        public int getClassid ()
        {
            return this.classid;
        }

        public int getSchoolid()
        {
            return this.schoolid;
        }

        public string getfinal_scores()
        {
            return this.final_scores;
        }

        public string getstrAnswers() {
            return this.strAnswers;
        }
    }
}
