﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        public bool CreateLabel(long noteId, long userId, string labelName);
    }
}
