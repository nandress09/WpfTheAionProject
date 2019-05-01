﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public abstract class GameItem
    {
        //
        // auto implemented properties are used for 
        //
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int ExperiencePoints { get; set; }
        public string UseMessage { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }

        public GameItem(int id, string name, int value, string description, int experiencePoints, string useMessage = "")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            ExperiencePoints = experiencePoints;
            UseMessage = useMessage;
        }

        public abstract string InformationString();
    }
}
