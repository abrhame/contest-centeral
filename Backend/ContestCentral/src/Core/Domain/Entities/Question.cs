using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        public String QuestionUrl { get; set; }
        public Tag Tags { get; set; }
        public Number Rating { get; set; }

    }
}