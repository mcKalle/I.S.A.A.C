﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace ISAAC.SpeakEngine.Speaking
{
    
    public class Question
    {
        [XmlAttribute("QuestionText")] 
        public string QuestionText;

        [XmlElement("Answers")]
        public List<string> Answers;
    }
}
