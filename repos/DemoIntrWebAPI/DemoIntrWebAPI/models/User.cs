﻿namespace DemoIntrWebAPI.models
{
    public class User
    {

        public string UserName {get; set;}

        public string Email { get; set; }
        public IFormFile ProfilePic { get; set; }


    }
}