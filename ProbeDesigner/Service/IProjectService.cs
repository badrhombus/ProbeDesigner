using System;
using ProbeDesigner.Model;
using RevolutionProbe.Model;

namespace ProbeDesigner.Service
{
    internal interface IProjectService
    {
        void GetProjects(Action<Projects, Exception> callback);
    }
}