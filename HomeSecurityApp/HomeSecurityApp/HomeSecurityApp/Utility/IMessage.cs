﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSecurityApp.Utility
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
