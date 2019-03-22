using System;
using System.Collections.Generic;
using HospSimWebsite.Interfaces;
using Microsoft.IdentityModel.Xml;

namespace HospSimWebsite
{
    public class Patient : IHuman
    {
        private int id;
        private string name;
        private int age;
        private Disease disease;
        private List<String> descriptions;

        public Patient(int id, string name, int age, Disease disease)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.disease = disease;
            this.descriptions = descriptions;
        }
        
        public Patient(string name, int age, Disease disease)
        {
            this.name = name;
            this.age = age;
            this.disease = disease;
            this.descriptions = descriptions;
        }

        public string Name
        {
            get => name;
        }

        public int Age
        {
            get => age;
        }

        public Disease Disease
        {
            get => disease;
        }

        public int Id
        {
            get => id;
        }
    }
}