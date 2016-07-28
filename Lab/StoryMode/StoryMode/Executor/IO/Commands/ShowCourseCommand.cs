﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Exceptions;
using Executor.Interfaces;
using Executor.IO.Interfaces;
using Executor.Network;
using Executor.Repository;
using Executor.Judge;

namespace Executor.IO.Commands
{
    class ShowCourseCommand : Command
    {
        public ShowCourseCommand(string input, string[] data, ITester tester,
            IDatabase repository, IDownloader downloadManager, IDirectoryManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
