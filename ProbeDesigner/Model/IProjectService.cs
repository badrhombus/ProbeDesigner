using System;

namespace RevolutionProbe.Model
{
    internal interface IProjectService
    {
        void GetProjects(Action<Projects, Exception> callback);
    }
}