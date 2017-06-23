﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks(ISettings settings);
    }
}
